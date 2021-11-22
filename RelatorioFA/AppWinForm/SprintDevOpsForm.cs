using System;
using System.Collections.Generic;
using System.Drawing;
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
            ResizeParent(containerForm);
            SetSprintsDevOpsList(sprintsList);
            this.containerForm = containerForm;
            LoadConfig();
        }

        private List<SprintDevOpsDTO> sprintsDevOpsList;
        private ConfigXmlDTO configXml;
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private readonly ContainerForm containerForm;
        private SprintDevOpsDTO selectedSprint = new SprintDevOpsDTO();

        #region LoadConfig
        private void LoadConfig()
        {
            try
            {
                //load config
                configXml = PrincipalTO.LoadConfig(outputDocPath);

                //set partners
                foreach (var partner in configXml.Partners)
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
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

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

                txbOpsActuationUst.Enabled = !processing;
                txbOpsDevsCount.Enabled = !processing;
                txbOpsUsUst.Enabled = !processing;
                txbOpsWarningUst.Enabled = !processing;
                txbObs.Enabled = !processing;

                btnPreviousForm.Enabled = !processing;
                btnAddSprint.Enabled = !processing;
                btnSetOutputDocPath.Enabled = !processing;
                btnGenerate.Enabled = !processing;
                btnChangeConfigFolder.Enabled = !processing;

                lsbSprints.Enabled = !processing;
            }
            else
            {
                txbResult.Text = $"Documento gerado em: {outputDocPath}";
                btnOpenDestinationFolder.Enabled = !processing;
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
            txbResult.AppendText($"Fornecedor: {cbbPartners.SelectedItem}\n");
            txbResult.AppendText($"UST: R${configXml.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString()).UstValue}\n\n");

            foreach (var sprint in sprintsDevOpsList)
            {
                txbResult.AppendText(sprint.Range.Name);
                txbResult.AppendText("\n");
                txbResult.AppendText($"   - Data inicial: {sprint.Range.IniDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Data final: {sprint.Range.EndDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Imagem: {sprint.ImagePath}\n");
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
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {
            containerForm.AbrirForm(new SprintBaseForm(containerForm, UtilDTO.NAVIGATION.DEVOPS, sprintsDevOpsList));
        }

        private void BtnAddSprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                cbbPartners.Enabled = false;

                var selectedSprint = sprintsDevOpsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                selectedSprint.Obs = txbObs.Text;
                selectedSprint.WarningUst = Convert.ToDouble(txbOpsWarningUst.Text);
                selectedSprint.ActuationUst = Convert.ToDouble(txbOpsActuationUst.Text);
                selectedSprint.UsUst = Convert.ToDouble(txbOpsUsUst.Text);
                selectedSprint.TeamSize = Convert.ToDouble(txbOpsDevsCount.Text);

                if(lsbSprints.SelectedIndex < lsbSprints.Items.Count - 1)
                {
                    lsbSprints.SelectedIndex += 1;
                }

                txbOpsWarningUst.Focus();

                ShowLog("Dados da sprint atualizados.");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        }

        private void BtnSetOutputDocPath_Click(object sender, System.EventArgs e)
        {
            outputDocPath = UtilWinForm.SetOutputDocPath();
            ShowLog("Caminho de saído do arquivo definodo.");
            btnGenerate.Enabled = true;
        }

        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateData();
                Processing(true);
                FornecedorDTO partner = new FornecedorDTO();
                partner = configXml.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
                partner.BillingType = UtilDTO.BILLING_TYPE.UST_DEVOPS;
                PrincipalTO.CreateOpsDoc(configXml, partner, outputDocPath, sprintsDevOpsList);
                btnOpenDestinationFolder.Enabled = true;
                txbResult.Text = $"Arquivo gerado em: {outputDocPath}";
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        }

        private void BtnOpenDestinationFolder_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        }

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

        #region Eventos automaticos
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSprint = sprintsDevOpsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());

            txbOpsWarningUst.Text = selectedSprint.WarningUst.ToString();
            txbOpsActuationUst.Text = selectedSprint.ActuationUst.ToString();
            txbOpsUsUst.Text = selectedSprint.UsUst.ToString();
            txbOpsDevsCount.Text = selectedSprint.TeamSize.ToString();
            txbObs.Text = selectedSprint.Obs;
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
        #endregion

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
    }
}
