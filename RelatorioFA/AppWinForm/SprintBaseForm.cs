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
    public partial class SprintBaseForm : Form
    {
        public SprintBaseForm(ContainerForm parentForm, UtilDTO.NAVIGATION fluxo)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            this.fluxo = fluxo;
            containerForm = parentForm;
            LoadConfig(UtilDTO.GetProjectRootFolder());
            LoadRanges();
            SetSreenNumber(fluxo);
        }

        public SprintBaseForm(ContainerForm parentForm, UtilDTO.NAVIGATION fluxo, List<SprintBaseDTO> sprintsList)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            this.fluxo = fluxo;
            containerForm = parentForm;
            LoadRanges();
            SetSreenNumber(fluxo);

            foreach (var sprint in sprintsList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
                this.sprintsList.Add(sprint);
            }
            lsbSprints.SelectedIndex = 0;

            ShowLog("Bem vindo de volta\n:)");
            btnNextForm.Enabled = true;
        }

        private readonly ContainerForm containerForm;
        private readonly UtilDTO.NAVIGATION fluxo;
        private string sprintImagePath;
        private List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
        private ConfigXmlDTO config;
        private readonly List<SprintBaseDTO> sprintsList = new List<SprintBaseDTO>();

        #region LoadRanges
        private void LoadRanges()
        {
            sprintRanges = PrincipalTO.GenerateRanges();
            foreach (var range in sprintRanges)
            {
                cbbSprintRanges.Items.Add(range.Name);
            }
            cbbSprintRanges.SelectedIndex = 0;
        }
        #endregion

        private void LoadConfig(string path)
        {
            try
            {
                config = PrincipalTO.LoadConfig(path);
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }

        #region Eventos de Click
        #region BtnAddSprint_Click
        private void BtnAddSprint_Click(object sender, EventArgs e)
        {
            try
            {
                IntervaloDTO range = new IntervaloDTO
                {
                    Name = cbbSprintRanges.SelectedItem.ToString(),
                    IniDate = dtpIniDate.Value,
                    EndDate = dtpEndDate.Value
                };

                SprintBaseDTO newSprint = new SprintBaseDTO()
                {
                    Range = range,
                    ImagePath = sprintImagePath
                };

                //Remove e adiciona para caso ele esteja atualizando os dados
                sprintsList.Remove(sprintsList.Find(s => s.Range.Name == newSprint.Range.Name));
                sprintsList.Add(newSprint);
                sprintsList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));

                lsbSprints.Items.Remove(newSprint.Range.Name);
                lsbSprints.Items.Add(newSprint.Range.Name);

                sprintImagePath = null;
                pbxSprintImage.Image = null;
                btnNextForm.Enabled = true;

                if (cbbSprintRanges.SelectedIndex < cbbSprintRanges.Items.Count)
                {
                    cbbSprintRanges.SelectedIndex += 1;
                }

                ShowLog("Sprint adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro. {ex.Message}";
            }
        } 
        #endregion

        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            switch (fluxo)
            {
                case UtilDTO.NAVIGATION.DEVOPS:
                    containerForm.AbrirForm(new SprintDevOpsForm(containerForm, sprintsList));
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, config, sprintsList, fluxo));
                    break;
                default:
                    break;
            }
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
                LoadConfig(folderDlg.SelectedPath);
            }
        }

        #region BtnAddSprintImage_Click
        private void BtnAddSprintImage_Click(object sender, EventArgs e)
        {
            sprintImagePath = string.Empty;

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

        #region BtnRemoveSprintImage_Click
        private void BtnRemoveSprintImage_Click(object sender, EventArgs e)
        {
            pbxSprintImage.Image = null;
            sprintImagePath = null;
        } 
        #endregion
        #endregion

        #region Comportamentos automaticos
        private void CbbSprintRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpIniDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).IniDate;
            dtpEndDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).EndDate;
        }

        private void DtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            txbSprintDays.Text = ((dtpEndDate.Value - dtpIniDate.Value).Days - 3).ToString();
        }

        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSprints.Items.Count > 0)
            {
                var selectedSprint = new SprintBaseDTO();
                selectedSprint = sprintsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());

                if (selectedSprint.ImagePath != null &&
                    selectedSprint.ImagePath != "")
                {
                    pbxSprintImage.Load(selectedSprint.ImagePath);
                }
                else
                {
                    pbxSprintImage.Image = null;
                }
                cbbSprintRanges.SelectedItem = selectedSprint.Range.Name;
                dtpIniDate.Value = selectedSprint.Range.IniDate;
                dtpEndDate.Value = selectedSprint.Range.EndDate;
            }
        }
        #endregion

        #region AUX
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void SetSreenNumber(UtilDTO.NAVIGATION fluxo)
        {
            switch (fluxo)
            {
                case UtilDTO.NAVIGATION.DEVOPS:
                    lblScreen.Text = "Tela 1/2";
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    break;
                default:
                    break;
            }
        } 
        #endregion

        #region ShowLog
        private void ShowLog(string message = "")
        {
            txbResult.Clear();

            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            foreach (var sprint in sprintsList)
            {
                txbResult.AppendText(sprint.Range.Name);
                txbResult.AppendText("\n");
                txbResult.AppendText($"   - Data inicial: {sprint.Range.IniDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Data final: {sprint.Range.EndDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Imagem: {sprint.ImagePath}\n");
            }
        }
        #endregion
    }
}
