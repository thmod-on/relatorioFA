using System;
using System.Windows.Forms;
using RelatorioFA.DTO;

namespace RelatorioFA.AppWinForm
{
    public partial class ConfigContratoForm : Form
    {
        public ConfigContratoForm(ContainerForm containerForm, ConfigXmlDTO config)
        {
            InitializeComponent();
            this.config = config;
            this.containerForm = containerForm;
            foreach (var partner in config.Partners)
            {
                lsbPartners.Items.Add(partner.Name);
            }

            LoadAvaliableBatchs();
        }

        private readonly ConfigXmlDTO config = new ConfigXmlDTO();
        private readonly ContainerForm containerForm;
        
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();
        private LoteDTO selectedBatch = new LoteDTO();


        #region Eventos de Click
        #region BtnPreviousForm_Click
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {
            containerForm.AbrirForm(new ConfigBaseForm(containerForm, config));
        } 
        #endregion

        #region BtnAddContract_Click
        private void BtnAddContract_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateContractData();

                //validar se o contrato existe. Se existir, emite aviso e se não adiciona
                if (!selectedPartner.Contracts.Find(c => c == selectedContract).Equals(null))
                {
                    txbResult.Text = $"Contrato {lsbContracts.SelectedItem} já pertence ao parceiro {lsbPartners.SelectedItem}";
                }
                else
                {
                    var newContract = new ContratoDTO()
                    {
                        SapNumber = txbContractSap.Text,
                        UstValue = Convert.ToDouble(txbContractUstValue.Text)
                    };

                    config
                        .Partners.Find(p => p == selectedPartner)
                        .Contracts.Add(newContract);

                    selectedPartner
                        .Contracts.Add(newContract);

                    lsbContracts.Items.Add(newContract.SapNumber);

                    txbContractSap.Clear();
                    txbContractUstValue.Clear();

                    ShowLog("Contrato adicionado.");
                }
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
                txbResult.Text = "Para remover um contrato, antes deve selecionar o fornecedor e o contrato a ser removido.";
            }
            else
            {
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts.Remove(selectedContract);

                selectedPartner.Contracts.Remove(selectedContract);

                lsbContracts.Items.Remove(selectedContract.SapNumber);
                selectedContract = null;
                txbContractSap.Clear();
                txbContractUstValue.Clear();
                ShowLog("Contrato removido.");
            }
        }
        #endregion

        #region BtnNextForm_Click
        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            bool allPartnersHasContractsAndBatchs = true;
            foreach (var partner in config.Partners)
            {
                if (partner.Contracts.Count < 1)
                {
                    allPartnersHasContractsAndBatchs = false;
                    break;
                }
                foreach (var contract in partner.Contracts)
                {
                    if (contract.Batches.Count < 1)
                    {
                        allPartnersHasContractsAndBatchs = false;
                        break;
                    }
                }
            }
            if (!allPartnersHasContractsAndBatchs)
            {
                txbResult.Text = "Antes de prosseguir você deve cadastrar ao menos um contrato para cada parceiro e um lote para cada contrato.";
            }
            else
            {
                containerForm.AbrirForm(new ConfigDevForm(containerForm, config));
            }
        }
        #endregion

        #region BtnAddBatch_Click
        private void BtnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedContract.Batches.Find(b => b.Name == cbbAvaliableBatch.SelectedItem.ToString()).Equals(null))
                {
                    txbResult.Text = $"O lote {cbbAvaliableBatch.SelectedItem} já pertence ao contrato {selectedPartner.Name} - {selectedContract.SapNumber}";
                }
                else
                {
                    LoteDTO newBatch = new LoteDTO()
                    {
                        Name = cbbAvaliableBatch.SelectedItem.ToString()
                    };

                    config
                        .Partners.Find(p => p == selectedPartner)
                        .Contracts.Find(c => c == selectedContract)
                        .Batches.Add(newBatch);

                    selectedContract
                        .Batches.Add(newBatch);

                    lsbBatch.Items.Add(newBatch.Name);
                    cbbAvaliableBatch.SelectedIndex = 0;
                    ShowLog("Lote adicionado");
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region BtnRemoveBatch_Click
        private void BtnRemoveBatch_Click(object sender, EventArgs e)
        {
            if (lsbPartners.SelectedItem == null ||
                lsbContracts.SelectedItem == null ||
                lsbBatch.SelectedItem == null)
            {
                txbResult.Text = "Para remover um lote, antes deve selecionar o fornecedor, o contrato e o lote a ser removido.";
            }
            else
            {
                config
                    .Partners.Find(p => p == selectedPartner)
                    .Contracts.Find(c => c == selectedContract)
                    .Batches.Remove(selectedBatch);

                selectedContract.Batches.Remove(selectedBatch);

                lsbBatch.Items.Remove(selectedBatch.Name);
                selectedBatch = null;
                cbbAvaliableBatch.SelectedIndex = 0;
                ShowLog("Lote removido");
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

            txbResult.AppendText($"Autor: {config.AuthorName}\n");
            txbResult.AppendText($"Área: {config.AreaName}\n");
            txbResult.AppendText($"Time: {config.TeamName}\n\n");

            foreach (var partner in config.Partners)
            {
                txbResult.AppendText($"\n\nParceiro: {partner.Name}\n");
                txbResult.AppendText($"   - Logomarca: {partner.CaminhoLogomarca}\n");
                foreach (var contract in partner.Contracts)
                {
                    txbResult.AppendText($"   - Contrato: {contract.SapNumber}\n");
                    txbResult.AppendText($"      . Valor da UST: {contract.UstValue}\n");
                    foreach (var batch in contract.Batches)
                    {
                        txbResult.AppendText($"         > Dev: {batch.Name}\n");
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

            if (string.IsNullOrEmpty(txbContractUstValue.Text) ||
                string.IsNullOrEmpty(txbContractSap.Text))
            {
                throw new Exception("Número SAP e valor da UST são de preenchimento obrigatório.");
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
        #endregion

        #region Eventos automáticos
        #region LoadAvaliableBatchs
        private void LoadAvaliableBatchs()
        {
            foreach (var batch in Enum.GetValues(typeof(UtilDTO.BATCHS)))
            {
                cbbAvaliableBatch.Items.Add(batch);
            }
            cbbAvaliableBatch.SelectedIndex = 0;
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
                        lsbContracts.Items.Add(contract.SapNumber);
                    }

                    lsbContracts.SelectedIndex = 0;
                }
                lblContracts.Text = $"Contratos de {selectedPartner.Name}";
            }
        }
        #endregion

        #region LsbContracts_SelectedIndexChanged
        private void LsbContracts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsbContracts.SelectedItem != null)
            {
                selectedContract = selectedPartner
                    .Contracts.Find(c => c.SapNumber == lsbContracts.SelectedItem.ToString());

                txbContractSap.Text = selectedContract.SapNumber;
                txbContractUstValue.Text = selectedContract.UstValue.ToString();
                lsbBatch.Items.Clear();

                if (selectedContract.Batches.Count > 0)
                {
                    foreach (var batch in selectedContract.Batches)
                    {
                        lsbBatch.Items.Add(batch.Name);
                    }
                    lsbBatch.SelectedIndex = 0;
                }
                lblBatch.Text = $"Lotes do contrato {selectedContract.SapNumber}";
            }
        }
        #endregion

        #region LsbBatch_SelectedIndexChanged
        private void LsbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbBatch.SelectedItem != null)
            {
                selectedBatch = selectedContract.
                    Batches.Find(b => b.Name == lsbBatch.SelectedItem.ToString());
                cbbAvaliableBatch.SelectedItem = selectedBatch.Name;
            }
        } 
        #endregion

        #region TxbContractUstValue_KeyPress
        private void TxbContractUstValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        }
        #endregion

        #endregion
    }
}
