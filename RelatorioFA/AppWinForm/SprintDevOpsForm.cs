﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RelatorioFA.DTO;
using RelatorioFA.Transacao;

namespace RelatorioFA.AppWinForm
{
    public partial class SprintDevOpsForm : Form
    {
        public SprintDevOpsForm(ContainerForm containerForm, List<SprintDevOpsDTO> sprintsList)
        {
            InitializeComponent();
            SetSprintsDevOpsList(sprintsList);
            this.containerForm = containerForm;
            LoadConfig();
        }

        private List<SprintDevOpsDTO> sprintsDevOpsList;
        private ConfigXmlDTO configXml;
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private readonly ContainerForm containerForm;
        private SprintDevOpsDTO selectedSprint = new SprintDevOpsDTO();
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();


        #region LoadConfig
        private void LoadConfig()
        {
            try
            {
                //load config
                configXml = PrincipalTO.LoadConfig(outputDocPath);

                //set partners
                foreach (var partner in
                    from partner in configXml.Partners
                    from contract in partner.Contracts
                    from batch in contract.Batches
                    where batch.Name == UtilDTO.BATCHS.DEVOPS.ToString()
                    select partner)
                {
                    cbbPartners.Items.Add(partner.Name);
                }
                              
                cbbPartners.SelectedIndex = 0;

                lsbSprints.SelectedIndex = 0;
                ShowLog("Por favor forneça os dados de desempenho do(s) plantonista(s).");
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }
        #endregion

        #region AUX
        private void SetSprintsDevOpsList(List<SprintDevOpsDTO> sprintsList)
        {
            sprintsDevOpsList = sprintsList;
            foreach (var sprint in sprintsList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
            }
        }

        private void ValidateData()
        {
            foreach (var sprint in sprintsDevOpsList)
            {
                if (sprint.TeamSize < 1)
                {
                    throw new Exception($"Favor preencher a quantidade de plantonistas na sprint {sprint.Range.Name}");
                }
            }
        }

        private void Processing(bool processing)
        {
            if (processing)
            {
                txbResult.Text = "Processando...";

                cbbPartners.Enabled = !processing;

                txbOpsSupportUst.Enabled = !processing;
                txbOpsActuationUst.Enabled = !processing;
                txbOpsDevsCount.Enabled = !processing;
                txbOpsUsUst.Enabled = !processing;
                txbOpsWarningUst.Enabled = !processing;
                txbObs.Enabled = !processing;

                btnPreviousForm.Enabled = !processing;
                btnSetOutputDocPath.Enabled = !processing;
                btnGenerate.Enabled = !processing;
                btnChangeConfigFolder.Enabled = !processing;

                lsbSprints.Enabled = !processing;
            }
        }

        private void ShowLog(string message = null)
        {
            txbResult.Clear();
            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            txbResult.AppendText("Se as configurações de autor ou nome precisarem de ajuste, favor revisar o arquivo de configuração e começar o processo novamente.");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"Autor: {configXml.AuthorName}\n");
            txbResult.AppendText($"Área: {configXml.AreaName}\n");
            txbResult.AppendText($"Time: {configXml.TeamName}");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"O arquivo será gerado em: {outputDocPath}");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"Fornecedor: {selectedPartner.Name}\n");
            txbResult.AppendText($"Contrato: {selectedContract.SapNumber}\n");
            txbResult.AppendText($"UST: R${selectedContract.UstValue}\n\n");

            foreach (var sprint in sprintsDevOpsList)
            {
                txbResult.AppendText(sprint.Range.Name);
                txbResult.AppendText("\n");
                txbResult.AppendText($"   - Data inicial: {sprint.Range.IniDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Data final: {sprint.Range.EndDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Imagem: {sprint.ImagePath}\n");
                txbResult.AppendText($"   - Pontos de suporte: {sprint.SupportUst}\n");
                txbResult.AppendText($"   - Pontos de sobreaviso: {sprint.WarningUst}\n");
                txbResult.AppendText($"   - Pontos de acionamento: {sprint.ActuationUst}\n");
                txbResult.AppendText($"   - Pontos de histórias DevOps: {sprint.UsUst}\n");
                txbResult.AppendText($"   - Plantonistas: {sprint.TeamSize}\n");
                txbResult.AppendText($"   - OBS.: {sprint.Obs}\n");
            }
            txbResult.Select(0, 0);
        }
        #endregion

        #region Eventos de Click
        #region BtnPreviousForm_Click
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {
            containerForm.AbrirForm(new SprintBaseForm(containerForm, UtilDTO.NAVIGATION.DEVOPS, sprintsDevOpsList));
        } 
        #endregion

        #region BtnSetOutputDocPath_Click
        private void BtnSetOutputDocPath_Click(object sender, System.EventArgs e)
        {
            outputDocPath = UtilWinForm.SetOutputDocPath();
            ShowLog("Caminho de saído do arquivo definido.");
        } 
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateData();
                Processing(true);
                selectedPartner.BillingType = UtilDTO.BILLING_TYPE.UST_DEVOPS;
                PrincipalTO.CreateOpsDoc(configXml, selectedPartner, selectedContract, outputDocPath, sprintsDevOpsList);
                btnOpenDestinationFolder.Enabled = true;
                txbResult.Text = $"Arquivo gerado em: {outputDocPath}";
            }
            catch (Exception ex)
            {
                Processing(false);
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        }
        #endregion

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        }
        #endregion

        #region BtnChangeConfigFolder_Click
        private void BtnChangeConfigFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputDocPath = folderDlg.SelectedPath;
            }

            LoadConfig();
        } 
        #endregion
        #endregion

        #region Eventos automaticos
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSprint = sprintsDevOpsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());

            txbOpsSupportUst.Text = selectedSprint.SupportUst.ToString();
            txbOpsWarningUst.Text = selectedSprint.WarningUst.ToString();
            txbOpsActuationUst.Text = selectedSprint.ActuationUst.ToString();
            txbOpsUsUst.Text = selectedSprint.UsUst.ToString();
            txbOpsDevsCount.Text = selectedSprint.TeamSize.ToString();
            txbObs.Text = selectedSprint.Obs;

            txbOpsSupportUst.Focus();
        }

        private void TxbOpsWarningUst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }

        private void TxbOpsActuationUst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }

        private void TxbOpsUsUst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }

        private void TxbOpsDevsCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }

        private void TxbOpsSupportUst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }

        private void TxbOpsWarningUst_Leave(object sender, EventArgs e)
        {
            selectedSprint.WarningUst = Convert.ToDouble(txbOpsWarningUst.Text);
            ShowLog();
        }

        private void TxbOpsActuationUst_Leave(object sender, EventArgs e)
        {
            selectedSprint.ActuationUst = Convert.ToDouble(txbOpsActuationUst.Text);
            ShowLog();
        }

        private void TxbOpsUsUst_Leave(object sender, EventArgs e)
        {
            selectedSprint.UsUst = Convert.ToDouble(txbOpsUsUst.Text);
            ShowLog();
        }

        private void TxbOpsDevsCount_Leave(object sender, EventArgs e)
        {
            selectedSprint.TeamSize = Convert.ToDouble(txbOpsDevsCount.Text);
            ShowLog();
        }

        private void TxbObs_Leave(object sender, EventArgs e)
        {
            selectedSprint.Obs = txbObs.Text;
            ShowLog();
        }

        private void TxbOpsSupportUst_Leave(object sender, EventArgs e)
        {
            selectedSprint.SupportUst = Convert.ToDouble(txbOpsSupportUst.Text);
            ShowLog();
        }

        private void CbbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPartner = configXml.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
            selectedContract = (from contract in selectedPartner.Contracts
                                from batch in contract.Batches
                                where batch.Name == UtilDTO.BATCHS.DEVOPS.ToString()
                                select contract).First();
        }
        #endregion
    }
}
