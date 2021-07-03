using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RelatorioFA.DTO;
using RelatorioFA.Transacao;

namespace RelatorioFA.AppWinForm
{
    public partial class DevOpsForm : Form
    {
        public DevOpsForm()
        {
            InitializeComponent();
            LoadConfig();
            LoadTestData();
        }

        public DevOpsForm(Form containerForm)
        {
            InitializeComponent();
            ResizeParent(containerForm);
            LoadConfig();
        }

        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private string sprintImagePath = string.Empty;
        private List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
        ConfigXmlDTO config = new ConfigXmlDTO();
        private readonly List<SprintDevOpsDTO> sprintDevOpsList = new List<SprintDevOpsDTO>();

        #region Tests
        private void LoadTestData()
        {
            txbOpsDevsCount.Text = "1";
            txbOpsActuationUst.Text = "2";
            txbOpsWarningUst.Text = "4";
            txbOpsUsUst.Text = "3";
        } 
        #endregion

        #region LoadConfig
        private void LoadConfig()
        {
            //load config
            config = PrincipalTO.LoadConfig(outputDocPath);

            //set labels
            lblAuthor.Text = config.AuthorName;
            lblTeamName.Text = config.TeamName;

            //set ranges
            sprintRanges = PrincipalTO.GenerateRanges();
            foreach (var range in sprintRanges)
            {
                cbbSprintRanges.Items.Add(range.Name);
            }
            cbbSprintRanges.SelectedIndex = 0;

            //set partners
            foreach (var partner in config.Partners)
            {
                cbbPartners.Items.Add(partner.Name);
            }
            cbbPartners.SelectedIndex = 0;
        }
        #endregion

        #region Click Events
        #region BtnAdd_Click
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SprintDevOpsDTO newSprintOps = new SprintDevOpsDTO()
            {
                ActuationUst = Convert.ToDouble(txbOpsActuationUst.Text),
                WarningUst = Convert.ToDouble(txbOpsWarningUst.Text),
                UsUst = Convert.ToDouble(txbOpsUsUst.Text),
                TeamSize = Convert.ToInt32(txbOpsDevsCount.Text),
                Range = sprintRanges.Find(r => r.Name == cbbSprintRanges.SelectedItem.ToString()),
                Obs = txbObs.Text,
                ImagePath = sprintImagePath
            };

            sprintDevOpsList.Add(newSprintOps);
            sprintDevOpsList.OrderBy(s => s.Range.Name);
            cbbPartners.Enabled = false;
            btnGenerate.Enabled = true;
            ShowLog("Dados adicionados.");

            if (cbbSprintRanges.SelectedIndex < cbbSprintRanges.Items.Count)
            {
                cbbSprintRanges.SelectedIndex += 1;
            }
        }
        #endregion

        #region BtnSprintImage_Click
        private void BtnSprintImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens PNG (*.png)|*.png|Imagens Jpeg (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    sprintImagePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        pbxSprintImage.Load(sprintImagePath);
                    }
                }
            }
        } 
        #endregion

        #region BtnSetOutputDocPath_Click
        private void BtnSetOutputDocPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblOutputPath.Text = folderDlg.SelectedPath;
                lblOutputPath.Visible = true;

                outputDocPath = folderDlg.SelectedPath;
            }
        }
        #endregion

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        }
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Processing(true);
                FornecedorDTO partner = new FornecedorDTO();
                partner = config.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
                partner.BillingType = UtilDTO.BILLING_TYPE.UST_DEVOPS;
                PrincipalTO.CreateOpsDoc(config, partner, outputDocPath, sprintDevOpsList);
                btnOpenDestinationFolder.Enabled = true;
                txbResult.Text = $"Arquivo gerado em: {outputDocPath}";
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion

        private void CbbSprintRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpIniDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).IniDate;
            dtpEndDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).EndDate;
        }

        #region Aux
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void ShowLog(string message)
        {
            txbResult.Text = message + "\n------------------\n\n";

            txbResult.AppendText("Fornecedor: " + cbbPartners.SelectedItem.ToString() + "\n");
            txbResult.AppendText("UST: R$" + config.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString()).UstValue);
            txbResult.AppendText("\n\n");

            foreach (var sprint in sprintDevOpsList)
            {
                txbResult.AppendText(sprint.Range.Name + " ~ " + sprint.Range.IniDate.ToString("dd/MM/yyyy") + " -> " + sprint.Range.EndDate.ToString("dd/MM/yyyy") + "\n");
                txbResult.AppendText("  UST de sobreaviso: " + sprint.WarningUst + "\n");
                txbResult.AppendText("  UST de acionamento: " + sprint.ActuationUst + "\n");
                txbResult.AppendText("  UST de US aceita: " + sprint.UsUst + "\n");
                txbResult.AppendText("  Plantonistas: " + sprint.TeamSize + "\n");
                txbResult.AppendText("  OBS: " + sprint.Obs + "\n");
                txbResult.AppendText("  Imagem: " + sprint.ImagePath);
                txbResult.AppendText("\n\n");
            }
        }

        private void Processing(bool processing)
        {
            txbResult.Text = "Processando...";

            cbbPartners.Enabled = !processing;
            cbbSprintRanges.Enabled = !processing;

            dtpIniDate.Enabled = !processing;
            dtpEndDate.Enabled = !processing;

            txbOpsActuationUst.Enabled = !processing;
            txbOpsDevsCount.Enabled = !processing;
            txbOpsUsUst.Enabled = !processing;
            txbOpsWarningUst.Enabled = !processing;

            btnAdd.Enabled = !processing;
            btnGenerate.Enabled = !processing;
            btnSetOutputDocPath.Enabled = !processing;
        }
        #endregion
    }
}
