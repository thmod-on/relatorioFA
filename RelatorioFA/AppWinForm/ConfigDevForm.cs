using RelatorioFA.DTO;
using RelatorioFA.Transacao;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RelatorioFA.AppWinForm
{
    public partial class ConfigDevForm : Form
    {
        public ConfigDevForm(ContainerForm containerForm, ConfigXmlDTO config)
        {
            InitializeComponent();
            this.config = config;
            this.containerForm = containerForm;
            LoadAvaliableRoles();
            FillLsbPartnerContractBatch();
        }

        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private readonly ConfigXmlDTO config = new ConfigXmlDTO();
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();
        private LoteDTO selectedBatch = new LoteDTO();
        private CargoDTO selectedRole = new CargoDTO();
        private ColaboradorDTO selectedDev = new ColaboradorDTO();
        private ColaboradorDTO selectedHouseDev = new ColaboradorDTO();
        private readonly ContainerForm containerForm;


        #region Eventos de Click
        #region BtnAddRole_Click
        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBatch.Roles.Find(r => r.Name == cbbAvaliableRoles.SelectedItem.ToString()) != null)
                {
                    txbResult.Text = $"O cargo {cbbAvaliableRoles.SelectedItem} já pertence ao lote {selectedBatch.Name} do contrato {selectedContract.SapNumber} da empresa {selectedPartner.Name}";
                }
                else
                {
                    CargoDTO newRole = new CargoDTO()
                    {
                        Name = cbbAvaliableRoles.SelectedItem.ToString(),
                        Factor = Convert.ToDouble(txbRoleFactor.Text)
                    };

                    selectedBatch.Roles.Add(newRole);

                    cbbAvaliableRoles.SelectedIndex = 0;
                    txbRoleFactor.Clear();
                    lsbRoles.Items.Add(newRole.Name);
                    ShowLog("Cargo vinculado");
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnRemoveRole_Click
        private void BtnRemoveRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbPartnerContractBatch.SelectedItem == null ||
                    lsbRoles.SelectedItem == null)
                {
                    txbResult.Text = "Para remover um cargo você precisa selecionar o parceiro - contrato - lote e o cargo a ser removido";
                }
                else
                {
                    config
                        .Partners.Find(p => p == selectedPartner)
                        .Contracts.Find(c => c == selectedContract)
                        .Batches.Find(b => b == selectedBatch)
                        .Roles.Remove(selectedRole);

                    lsbRoles.Items.Remove(selectedRole.Name);
                    lsbDevs.Items.Clear();
                    selectedRole = null;
                    ShowLog("Cargo desvinculado");
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnSetOutputDocPath_Click
        private void BtnSetOutputDocPath_Click(object sender, EventArgs e)
        {
            outputDocPath = UtilWinForm.SetOutputDocPath();
            txbResult.Text = $"Local de saída alterado para {outputDocPath}.";
        }
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateConfig();
                Processing(true);
                PrincipalTO.GenerateConfigXmlFile(outputDocPath, UtilDTO.configFileName, config);
                Processing(false);
                btnOpenDestinationFolder.Enabled = true;
                txbResult.Text = $"Arquivo {UtilDTO.configFileName} gerado na pasta {outputDocPath}. Utilize o botão abaixo para abrir o destino.";
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var file = Path.Combine(outputDocPath, UtilDTO.configFileName);
                Process.Start(file);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        }
        #endregion

        #region BtnRemoveHouseDev_Click
        private void BtnRemoveHouseDev_Click(object sender, EventArgs e)
        {
            if (lsbHouseDevs.SelectedItem == null)
            {
                txbResult.Text = "Favor selecionar o dev da casa que deseja remover.";
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
        private void BtnAddHouseDev_Click(object sender, EventArgs e)
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

        #region BtnRemoveDev_Click
        private void BtnRemoveDev_Click(object sender, EventArgs e)
        {
            if (lsbPartnerContractBatch.SelectedItem == null ||
               lsbRoles.SelectedItem == null ||
               lsbDevs.SelectedItem == null)
            {
                txbResult.Text = "Para remover um dev antes deve selecionar o fornecedor, o contrato, cargo e o dev a ser removido.";
            }
            else
            {
                selectedRole.Collaborators.Remove(selectedDev);

                lsbDevs.Items.Remove(selectedDev.Name);
                selectedDev = null;

                txbDevName.Clear();
                ckbDevWorksHalfDay.Checked = false;

                ShowLog("Dev removido do time.");
            }
        }
        #endregion

        #region BtnAddDev_Click
        private void BtnAddDev_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateDevData();
                var newDev = new ColaboradorDTO()
                {
                    Name = txbDevName.Text,
                    WorksHalfDay = ckbDevWorksHalfDay.Checked
                };

                selectedRole.Collaborators.Add(newDev);

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

        #region BtnPreviousForm_Click
        private void BtnPreviousForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new ConfigContratoForm(containerForm, config));
        }
        #endregion
        #endregion

        #region Eventos automáticos
        #region LsbDevs_SelectedIndexChanged
        private void LsbDevs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsbDevs.SelectedItem != null)
            {
                selectedDev = selectedRole
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

        #region LsbPartnerContract_SelectedIndexChanged
        private void LsbPartnerContractBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbPartnerContractBatch.SelectedItem != null)
            {
                SetSelectedPartnerAndContractAndBatch();
                lsbRoles.Items.Clear();
                lsbDevs.Items.Clear();
                if (selectedBatch.Roles.Count > 0)
                {
                    foreach (var role in selectedBatch.Roles)
                    {
                        lsbRoles.Items.Add(role.Name);
                    }
                }
                lblRole.Text = $"Cargos da {selectedPartner.Name}";
            }
        }
        #endregion

        #region LsbRoles_SelectedIndexChanged
        private void LsbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbDevs.Items.Clear();
            if (lsbRoles.SelectedItem != null)
            {
                selectedRole = selectedBatch.Roles.Find(r => r.Name == lsbRoles.SelectedItem.ToString());
                if (selectedRole.Collaborators.Count > 0)
                {
                    foreach (var dev in selectedRole.Collaborators)
                    {
                        lsbDevs.Items.Add(dev.Name);
                    }
                }
            }
            lblDevs.Text = $"Colaborador em {selectedRole.Name}";
        }
        #endregion

        #region TxbRoleFactor_KeyPress
        private void TxbRoleFactor_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

        #region AUX
        #region FillAvaliableRoles
        private void LoadAvaliableRoles()
        {
            foreach (var role in Enum.GetValues(typeof(UtilDTO.ROLES)))
            {
                if (!role.Equals(UtilDTO.ROLES.HOUSE))
                {
                    cbbAvaliableRoles.Items.Add(role);
                }
            }
            cbbAvaliableRoles.SelectedIndex = 0;
        }
        #endregion

        #region FillLsbPartnerContractBatch
        private void FillLsbPartnerContractBatch()
        {
            foreach (var partner in config.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    foreach (var batch in contract.Batches)
                    {
                        lsbPartnerContractBatch.Items.Add(partner.Name + " - " + contract.SapNumber + " - " + batch.Name);
                    }
                }
            }
        }
        #endregion

        #region SetSelectedPartnerAndContractAndBatch
        private void SetSelectedPartnerAndContractAndBatch()
        {
            char coringa = '*';
            var selectedItemText = lsbPartnerContractBatch.SelectedItem.ToString().Replace(' ', coringa).Split('-');
            string partner = selectedItemText[0].Replace(coringa, ' ').Trim();
            string contract = selectedItemText[1].Replace(coringa, ' ').Trim();
            string batch = selectedItemText[2].Replace(coringa, ' ').Trim();
            selectedPartner = config.Partners.Find(c => c.Name == partner);
            selectedContract = selectedPartner.Contracts.Find(c => c.SapNumber == contract);
            selectedBatch = selectedContract.Batches.Find(b => b.Name == batch);
        }
        #endregion

        #region ShowLog
        private void ShowLog(string message)
        {
            txbResult.Clear();

            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            txbResult.AppendText($"Arquivo será gerado em: {outputDocPath}\n");
            txbResult.AppendText($"Autor: {config.AuthorName}\n");
            txbResult.AppendText($"Área: {config.AreaName}\n");
            txbResult.AppendText($"Time: {config.TeamName}\n\n");

            if (config.BaneseDes.Count > 1)
            {
                txbResult.AppendText($"Devs da casa:\n");
                foreach (var dev in config.BaneseDes)
                {
                    txbResult.AppendText($" > {dev.Name} (Meio expediente: {dev.WorksHalfDay})\n");
                }
            }

            foreach (var partner in config.Partners)
            {
                txbResult.AppendText($"\n\nParceiro: {partner.Name}\n");
                txbResult.AppendText($" > Logomarca: {partner.CaminhoLogomarca}\n");
                foreach (var contract in partner.Contracts)
                {
                    txbResult.AppendText($" > Contrato: {contract.SapNumber}\n");
                    txbResult.AppendText($"   - Valor da UST: {contract.UstValue}\n");
                    foreach (var batch in contract.Batches)
                    {
                        txbResult.AppendText($"   - Lote: {batch.Name}\n");
                        foreach (var role in batch.Roles)
                        {
                            txbResult.AppendText($"   - Cargo: {role.Name}\n");
                            txbResult.AppendText($"     - Fator de ajuste: {role.Factor}\n");
                            foreach (var dev in role.Collaborators)
                            {
                                txbResult.AppendText($"     - {role.Factor} (Meio expediente: {dev.WorksHalfDay})\n");
                            }
                        }
                    }
                }
            }

            txbResult.Select(0, 0);
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
            cbbAvaliableRoles.Enabled = !block;

            ckbDevWorksHalfDay.Enabled = !block;
            ckbHouseDevWorksHalfDay.Enabled = !block;

            txbDevName.Enabled = !block;
            txbHouseDevName.Enabled = !block;

            lsbPartnerContractBatch.Enabled = !block;
            lsbRoles.Enabled = !block;
            lsbDevs.Enabled = !block;
            lsbHouseDevs.Enabled = !block;

            btnAddRole.Enabled = !block;
            btnRemoveRole.Enabled = !block;
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

        #region ValidateDevData
        private void ValidateDevData()
        {
            if (lsbPartnerContractBatch.SelectedItem == null ||
                lsbRoles.SelectedItem == null)
            {
                throw new Exception("Para adicionar ou editar um desenvolvedor antes deve selecionar um fornecedor e um cargo.");
            }

            if (string.IsNullOrEmpty(txbDevName.Text))
            {
                throw new Exception("Você precisa fornecer o nome do colaborador para ser adicionado.");
            }

            if (selectedRole.Collaborators.Find(c => c.Name == txbDevName.Text) != null)
            {
                throw new Exception("Colaborador já existente neste cargo");
            }
        }
        #endregion

        #region ValidateConfig
        private void ValidateConfig()
        {
            foreach (var partner in config.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    foreach (var batch in contract.Batches)
                    {
                        if (batch.Roles.Count == 0)
                        {
                            if (batch.Name == UtilDTO.BATCHS.EXTERNO.ToString())
                            {
                                throw new Exception("Mesmo para o lote de colaboradores externos você precisa cadastrar um cargo pois precisamos saber o fator de ajuste. Mas não se preocupe, não será necessário cadastrar um colaborador nesse cargo.");
                            }

                            if (batch.Name != UtilDTO.BATCHS.EXTERNO.ToString())
                            {
                                throw new Exception("Parece que você deixou algum lote sem cargo cadastrado. Que tal dar uma revisada?");
                            }                            
                        }

                        foreach (var role in batch.Roles)
                        {
                            if (batch.Name != UtilDTO.BATCHS.EXTERNO.ToString() &&
                                role.Collaborators.Count == 0)
                            {
                                throw new Exception($"O único lote que pode ficar sem colaborador associado é o {UtilDTO.BATCHS.EXTERNO}");
                            }
                        }
                    }
                }
            }
        } 
        #endregion
        #endregion
    }
}
