using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using RelatorioFA.DTO;
using RelatorioFA.Transacao;

namespace RelatorioFA.AppWinForm
{
    public partial class ConfigContratoForm : Form
    {
        public ConfigContratoForm(ContainerForm containerForm, ConfigDTO config)
        {
            InitializeComponent();
            this.config = config;
            this.containerForm = containerForm;
            foreach (var partner in config.Partners)
            {
                lsbPartners.Items.Add(partner.Name);
            }

            LoadContractType();
        }

        private readonly ConfigDTO config = new ConfigDTO();
        private readonly ContainerForm containerForm;
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();
        private ColaboradorDTO selectedDev = new ColaboradorDTO();
        private ColaboradorDTO selectedHouseDev = new ColaboradorDTO();
        const string outputName = "RelatorioFA.xml";
        private enum SCREEN
        {
            SECOND,
            LAST
        };
        private SCREEN currentScreen = SCREEN.SECOND;
        
        #region Eventos de Click
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {
            switch (currentScreen)
            {
                case SCREEN.SECOND:
                    containerForm.AbrirForm(new ConfigBaseForm(containerForm, config));
                    break;
                case SCREEN.LAST:
                    currentScreen = SCREEN.SECOND;
                    SetScreenLayout();
                    break;
                default:
                    break;
            }
        }

        #region BtnSetOutputDocPath_Click
        private void BtnSetOutputDocPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            try
            {
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    outputDocPath = folderDlg.SelectedPath;

                    txbResult.Text = $"Local de saída alterado para {folderDlg.SelectedPath}.";
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        } 
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateFieldsToGenerateDoc();
                Processing(true);
                PrincipalTO.GenerateConfigXmlFile(outputDocPath, outputName, config);
                txbResult.Text = $"Arquivo {outputName} gerado na pasta {outputDocPath}. Utilize o botão abaixo para abrir a pasta.";
                btnOpenDestinationFolder.Enabled = true;
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        } 
        #endregion

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, System.EventArgs e)
        {
            try
            {
                var file = Path.Combine(outputDocPath, outputName);
                Process.Start(file);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        } 
        #endregion

        #region BtnAddContract_Click
        private void BtnAddContract_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateContractData();

                var newContract = new ContratoDTO()
                {
                    Name = cbbContractType.SelectedItem.ToString(),
                    Factor = Convert.ToDouble(txbContractFactor.Text),
                    NumeroSAP = txbContractSap.Text
                };

                if (config.Partners.Find(p => p == selectedPartner).Contracts.Find(c => c.Name == newContract.Name) != null)
                {
                    newContract.Collaborators = config.Partners.Find(p => p == selectedPartner).Contracts.Find(c => c.Name == newContract.Name).Collaborators;
                }

                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts
                        .Remove(config.Partners.Find(p => p == selectedPartner).Contracts.Find(c => c.Name == newContract.Name));
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts
                        .Add(newContract);

                lsbContracts.Items.Remove(newContract.Name);
                lsbContracts.Items.Add(newContract.Name);

                txbContractSap.Clear();
                txbContractFactor.Clear();

                ShowLog("Contrato adicionado.");
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnAddDev_Click
        private void BtnAddDev_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateDevData();
                var newDev = new ColaboradorDTO()
                {
                    Name = txbDevName.Text,
                    WorksHalfDay = ckbDevWorksHalfDay.Checked
                };

                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts.Find(c => c == selectedContract)
                    .Collaborators
                        .Remove(config.Partners.Find(p => p == selectedPartner).Contracts.Find(c => c == selectedContract).Collaborators.Find(x => x.Name == newDev.Name));
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts.Find(c => c == selectedContract)
                    .Collaborators
                        .Add(newDev);

                lsbDevs.Items.Remove(newDev.Name);
                lsbDevs.Items.Add(newDev.Name);

                txbDevName.Clear();
                ckbDevWorksHalfDay.Checked = false;

                ShowLog("Colaborador adicionado.");
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnRemoveContract_Click
        private void BtnRemoveContract_Click(object sender, System.EventArgs e)
        {
            if (lsbPartners.SelectedItem == null ||
                lsbContracts.SelectedItem == null)
            {
                txbResult.Text = "Para remover um contrato antes deve selecionar o fornecedor e o contrato a ser removido.";
            }
            else
            {
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts
                        .Remove(selectedContract);

                lsbContracts.Items.Remove(selectedContract.Name);
                selectedContract = null;
                txbContractSap.Clear();
                txbContractFactor.Clear();
                ShowLog("Contrato removido.");
            }
        }
        #endregion

        #region BtnRemoveDev_Click
        private void BtnRemoveDev_Click(object sender, System.EventArgs e)
        {
            if (lsbPartners.SelectedItem == null ||
                lsbContracts.SelectedItem == null ||
                lsbDevs.SelectedItem == null)
            {
                txbResult.Text = "Para remover um dev antes deve selecionar o fornecedor, o contrato e o dev a ser removido.";
            }
            else
            {
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts.Find(c => c == selectedContract)
                    .Collaborators
                        .Remove(selectedDev);

                lsbDevs.Items.Remove(selectedDev.Name);
                selectedDev = null;

                txbDevName.Clear();
                ckbDevWorksHalfDay.Checked = false;

                ShowLog("Dev removido do time.");
            }

        }
        #endregion

        #region BtnRemoveHouseDev_Click
        private void BtnRemoveHouseDev_Click(object sender, System.EventArgs e)
        {
            if (lsbHouseDevs.SelectedItem == null)
            {
                txbResult.Text = "Para remover um colaborador da casa antes deve selecionar o dev que deseja remover.";
            }
            else
            {
                config.BaneseDes.Remove(selectedHouseDev);
                lsbHouseDevs.Items.Remove(selectedHouseDev.Name);
                selectedHouseDev = null;

                txbHouseDevName.Clear();
                ckbHouseDevWorksHalfDay.Checked = false;

                ShowLog("Colaborador adicionado.");
            }
        }
        #endregion

        #region BtnAddHouseDev_Click
        private void BtnAddHouseDev_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbHouseDevName.Text))
            {
                txbResult.Text = "Você precisa fornecer o nome do colaborador para ser adicionado.";
            }
            else
            {
                var newDev = new ColaboradorDTO()
                {
                    Name = txbHouseDevName.Text,
                    WorksHalfDay = ckbHouseDevWorksHalfDay.Checked
                };
                config.BaneseDes.Add(newDev);
                lsbHouseDevs.Items.Add(newDev.Name);

                txbHouseDevName.Clear();
                ckbHouseDevWorksHalfDay.Checked = false;

                ShowLog("Colaborador da casa adicionado.");
            }
        }
        #endregion

        #region BtnNextForm_Click
        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            bool allPartnersHasContracts = true;
            foreach (var partner in config.Partners)
            {
                if (partner.Contracts.Count < 1)
                {
                    allPartnersHasContracts = false;
                    break;
                }
            }
            if (allPartnersHasContracts)
            {
                currentScreen = SCREEN.LAST;
                SetScreenLayout();
            }
            else
            {
                txbResult.Text = "Antes de prosseguir você deve cadastrar ao menos um contrato para cada parceiro";
            }
        } 
        #endregion
        #endregion

        #region AUX
        #region ShowLog
        private void ShowLog(string message)
        {
            txbResult.Clear();

            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            txbResult.AppendText($"O arquivo será gerado em: {outputDocPath}");
            txbResult.AppendText("\n===========\n\n");

            txbResult.AppendText($"Autor: {config.AuthorName}\n");
            txbResult.AppendText($"Área: {config.AreaName}\n");
            txbResult.AppendText($"Time: {config.TeamName}\n\n");

            txbResult.AppendText("Devs da casa:\n");
            foreach (var dev in config.BaneseDes)
            {
                txbResult.AppendText($"   - Dev: {dev.Name}\n");
                txbResult.AppendText($"   - Turno único: {dev.WorksHalfDay}\n");
            }

            foreach (var partner in config.Partners)
            {
                txbResult.AppendText($"\n\nParceiro: {partner.Name}\n");
                txbResult.AppendText($"   - Valor da UST: {partner.UstValue:C}\n");
                txbResult.AppendText($"   - Logomarca: {partner.CaminhoLogomarca}\n");
                foreach (var contract in partner.Contracts)
                {
                    txbResult.AppendText($"   - Contrato: {contract.Name}\n");
                    txbResult.AppendText($"      . Número SAP: {contract.NumeroSAP}\n");
                    txbResult.AppendText($"      . Fator de ajuste: {contract.Factor}\n");
                    foreach (var dev in contract.Collaborators)
                    {
                        txbResult.AppendText($"         > Dev: {dev.Name}\n");
                        txbResult.AppendText($"         > Turno único: {dev.WorksHalfDay}\n");
                    }
                }
            }

            txbResult.Select(0, 0);
        }
        #endregion

        #region ValidateContractData
        private void ValidateContractData()
        {
            if (lsbPartners.SelectedItem == null)
            {
                throw new Exception("Para adicionar um editar um contrato antes deve selecionar um fornecedor.");
            }

            if (string.IsNullOrEmpty(txbContractFactor.Text))
            {
                throw new Exception("Campo de fator de ajuste é obrigatório.");
            }
        }
        #endregion

        #region ValidateDevData
        private void ValidateDevData()
        {
            if (lsbPartners.SelectedItem == null ||
                lsbContracts.SelectedItem == null)
            {
                throw new Exception("Para adicionar ou editar um desenvolvedor antes deve selecionar um fornecedor e um contrato.");
            }

            if (string.IsNullOrEmpty(txbDevName.Text))
            {
                throw new Exception("Você precisa fornecer o nome do colaborador para ser adicionado.");
            }
        }
        #endregion

        #region SetScreenLayout
        private void SetScreenLayout()
        {
            bool toSecondPage = currentScreen == SCREEN.SECOND;

            gpbContracts.Visible = toSecondPage;
            gpbDev.Visible = !toSecondPage;
            gpbDevHouse.Visible = !toSecondPage;

            lsbDevs.Visible = !toSecondPage;
            lsbHouseDevs.Visible = !toSecondPage;

            btnSetOutputDocPath.Visible = !toSecondPage;
            btnOpenDestinationFolder.Visible = !toSecondPage;
            btnGenerate.Visible = !toSecondPage;
            btnNextForm.Visible = toSecondPage;

            lblDevs.Visible = !toSecondPage;
            lblDevHouse.Visible = !toSecondPage;
            lblScreen.Text = toSecondPage ? "Tela 2/3" : "Tela 3/3";

            if (lsbHouseDevs.Visible)
            {
                if (config.BaneseDes.Count > 0)
                {
                    lsbHouseDevs.Items.Clear();
                    foreach (var dev in config.BaneseDes)
                    {
                        lsbHouseDevs.Items.Add(dev.Name);
                    }
                }
            }

        }
        #endregion

        #region ValidateNumericalInput
        private void ValidateNumericalInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region ValidateFieldsToGenerateDoc
        private void ValidateFieldsToGenerateDoc()
        {
            foreach (var partner in config.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    if (contract.Collaborators.Count < 1)
                    {
                        throw new Exception("Ao menos um colaborador deve ser adicionado a cada contrato.");
                    }
                }
            }
        } 
        #endregion

        #region Processing
        private void Processing(bool processing)
        {
            txbResult.Text = "Processando...";

            BlockFields(processing);
        } 
        #endregion

        #region BlockFields
        private void BlockFields(bool block)
        {
            cbbContractType.Enabled = !block;

            ckbDevWorksHalfDay.Enabled = !block;
            ckbHouseDevWorksHalfDay.Enabled = !block;

            txbContractFactor.Enabled = !block;
            txbContractSap.Enabled = !block;
            txbDevName.Enabled = !block;
            txbHouseDevName.Enabled = !block;

            lsbPartners.Enabled = !block;
            lsbContracts.Enabled = !block;
            lsbDevs.Enabled = !block;
            lsbHouseDevs.Enabled = !block;

            btnAddContract.Enabled = !block;
            btnRemoveContract.Enabled = !block;
            btnAddDev.Enabled = !block;
            btnRemoveDev.Enabled = !block;
            btnAddHouseDev.Enabled = !block;
            btnRemoveHouseDev.Enabled = !block;
            btnGenerate.Enabled = !block;
            btnOpenDestinationFolder.Enabled = !block;
            btnPreviousForm.Enabled = !block;
            btnSetOutputDocPath.Enabled = !block;
        } 
        #endregion
        #endregion

        #region Eventos automáticos
        #region LoadContractType
        private void LoadContractType()
        {
            foreach (var contractType in Enum.GetValues(typeof(UtilDTO.CONTRACTS)))
            {

                if (contractType.ToString() != UtilDTO.CONTRACTS.BANESE.ToString())
                {
                    cbbContractType.Items.Add(contractType);
                }
            }
            cbbContractType.SelectedIndex = 0;
        }
        #endregion

        #region LsbPartners_SelectedIndexChanged
        private void LsbPartners_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsbPartners.SelectedItem != null)
            {
                selectedPartner = config.Partners.Find(p => p.Name == lsbPartners.SelectedItem.ToString());

                ShowLog("Para alterar os dados de um parceiro, por favor volte à tela anterior.");
                lsbContracts.Items.Clear();

                if (selectedPartner.Contracts.Count > 0)
                {
                    foreach (var contract in selectedPartner.Contracts)
                    {
                        lsbContracts.Items.Add(contract.Name);
                    }

                    lsbContracts.SelectedIndex = 0;

                    lblContracts.Text = $"Contratos de {selectedPartner.Name}";
                } 
            }
        }
        #endregion

        #region LsbContracts_SelectedIndexChanged
        private void LsbContracts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsbContracts.SelectedItem != null)
            {
                selectedContract = config
                       .Partners.Find(x => x == selectedPartner)
                       .Contracts.Find(c => c.Name == lsbContracts.SelectedItem.ToString());

                txbContractSap.Text = selectedContract.NumeroSAP;
                txbContractFactor.Text = selectedContract.Factor.ToString();
                cbbContractType.SelectedIndex = cbbContractType.FindStringExact(selectedContract.Name);
                lsbDevs.Items.Clear();

                if (selectedContract.Collaborators.Count > 0)
                {
                    foreach (var dev in selectedContract.Collaborators)
                    {
                        lsbDevs.Items.Add(dev.Name);
                    }
                    lsbDevs.SelectedIndex = 0;

                    lblDevs.Text = $"Devs {selectedContract.Name}";
                } 
            }
        }
        #endregion

        #region LsbDevs_SelectedIndexChanged
        private void LsbDevs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsbDevs.SelectedItem != null)
            {
                selectedDev = config
                        .Partners.Find(p => p == selectedPartner)
                        .Contracts.Find(c => c == selectedContract)
                        .Collaborators.Find(x => x.Name == lsbDevs.SelectedItem.ToString());

                txbDevName.Text = selectedDev.Name;
                ckbDevWorksHalfDay.Checked = selectedDev.WorksHalfDay; 
            }
        }
        #endregion

        #region LsbHouseDevs_SelectedIndexChanged
        private void LsbHouseDevs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbHouseDevs.SelectedItem != null)
            {
                selectedHouseDev = config.BaneseDes.Find(c => c.Name == lsbHouseDevs.SelectedItem.ToString());

                txbHouseDevName.Text = selectedHouseDev.Name;
                ckbHouseDevWorksHalfDay.Checked = selectedHouseDev.WorksHalfDay; 
            }
        } 
        #endregion

        private void TxbContractFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        }
        #endregion
    }
}
