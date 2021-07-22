using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            LoadXmlConfig(UtilDTO.GetProjectRootFolder());
            LoadRanges();
            SetSreenNumber(fluxo);
        }

        public SprintBaseForm(ContainerForm parentForm, UtilDTO.NAVIGATION fluxo, List<SprintDevDTO> sprintsDevList, List<SprintSmDTO> sprintsSmList = null)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            this.fluxo = fluxo;
            containerForm = parentForm;
            LoadRanges();
            SetSreenNumber(fluxo);

            foreach (var sprint in sprintsDevList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
                this.sprintsDevList.Add(sprint);
            }
            lsbSprints.SelectedIndex = 0;

            this.sprintsSmList = sprintsSmList;

            ShowLog("Bem vindo de volta\n:)");
            btnNextForm.Enabled = true;
        }

        /// <summary>
        /// Construtor para tratamento de fluxo DevOps
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="fluxo"></param>
        /// <param name="sprintsList"></param>
        public SprintBaseForm(ContainerForm parentForm, UtilDTO.NAVIGATION fluxo, List<SprintDevOpsDTO> sprintsList)
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
                sprintsDevOpsList.Add(sprint);
            }
            lsbSprints.SelectedIndex = 0;

            ShowLog("Bem vindo de volta\n:)");
            btnNextForm.Enabled = true;
        }

        private readonly ContainerForm containerForm;
        private readonly UtilDTO.NAVIGATION fluxo;
        private string sprintImagePath;
        private List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
        private ConfigXmlDTO configXml;
        private readonly List<SprintDevOpsDTO> sprintsDevOpsList = new List<SprintDevOpsDTO>();
        private readonly List<SprintDevDTO> sprintsDevList = new List<SprintDevDTO>();
        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();

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

        #region LoadXmlConfig
        private void LoadXmlConfig(string path)
        {
            try
            {
                configXml = PrincipalTO.LoadConfig(path);
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        } 
        #endregion

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

                switch (fluxo)
                {
                    case UtilDTO.NAVIGATION.DEVOPS:
                        SprintDevOpsDTO newSprint = new SprintDevOpsDTO()
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsDevOpsList.Remove(sprintsDevOpsList.Find(s => s.Range.Name == newSprint.Range.Name));
                        sprintsDevOpsList.Add(newSprint);
                        sprintsDevOpsList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                        break;
                    case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                        SprintDevDTO newDevSprint = new SprintDevDTO()
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == newDevSprint.Range.Name));
                        sprintsDevList.Add(newDevSprint);
                        sprintsDevList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));

                        SprintSmDTO newSmSprint = new SprintSmDTO()
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsSmList.Remove(sprintsSmList.Find(s => s.Range.Name == newSmSprint.Range.Name));
                        sprintsSmList.Add(newSmSprint);
                        sprintsSmList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                        break;
                    default:
                        break;
                }

                //atualizar a lista de sprints
                lsbSprints.Items.Remove(range.Name);
                lsbSprints.Items.Add(range.Name);

                sprintImagePath = null;
                pbxSprintImage.Image = null;
                btnNextForm.Enabled = true;

                if (cbbSprintRanges.SelectedIndex < cbbSprintRanges.Items.Count - 1)
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
                    containerForm.AbrirForm(new SprintDevOpsForm(containerForm, sprintsDevOpsList));
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, configXml, fluxo, sprintsDevList, sprintsSmList));
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
                LoadXmlConfig(folderDlg.SelectedPath);
            }
        }

        #region BtnAddSprintImage_Click
        private void BtnAddSprintImage_Click(object sender, EventArgs e)
        {
            sprintImagePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens PNG (*.png)|*.png|Imagens Jpeg (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
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
            if (lsbSprints.SelectedIndex >= 0)
            {
                //Neste caso o fluxo serve apenas para encontrar a lista preenchida
                switch (fluxo)
                {
                    case UtilDTO.NAVIGATION.DEVOPS:
                        var selectedDevOpsSprint = sprintsDevOpsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                        if (selectedDevOpsSprint.ImagePath != null &&
                            selectedDevOpsSprint.ImagePath != "")
                        {
                            pbxSprintImage.Load(selectedDevOpsSprint.ImagePath);
                        }
                        else
                        {
                            pbxSprintImage.Image = null;
                        }
                        cbbSprintRanges.SelectedItem = selectedDevOpsSprint.Range.Name;
                        dtpIniDate.Value = selectedDevOpsSprint.Range.IniDate;
                        dtpEndDate.Value = selectedDevOpsSprint.Range.EndDate;
                        break;
                    case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                        var selectedSprint = sprintsDevList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                        if (!String.IsNullOrEmpty(selectedSprint.ImagePath))
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
                        break;
                    default:
                        break;
                }
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
                    lblScreen.Text = "Tela 1/3";
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

            switch (fluxo)
            {
                case UtilDTO.NAVIGATION.DEVOPS:
                    foreach (var sprint in sprintsDevOpsList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    txbResult.AppendText("Sprints Dev");
                    txbResult.AppendText("\n===========\n");
                    foreach (var sprint in sprintsDevList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }

                    txbResult.AppendText("\nSprints SM");
                    txbResult.AppendText("\n===========\n");
                    foreach (var sprint in sprintsSmList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}