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

        /// <summary>
        /// Construtor para tratmento de fluxo SM
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="fluxo"></param>
        /// <param name="sprintSmList"></param>
        public SprintBaseForm(ContainerForm parentForm, UtilDTO.NAVIGATION fluxo, List<SprintSmDTO> sprintSmList)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            this.fluxo = fluxo;
            containerForm = parentForm;
            LoadRanges();
            SetSreenNumber(fluxo);

            foreach (var sprint in sprintSmList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
                this.sprintsSmList.Add(sprint);
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
        private string selectedRangeName;

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
                if (fluxo == UtilDTO.NAVIGATION.SM)
                {
                    bool hasSharedSm = false;
                    foreach (var _ in from partner in configXml.Partners
                                      from contract in partner.Contracts
                                      from batch in contract.Batches
                                      where batch.Name == UtilDTO.BATCHS.SM.ToString() &&
                                        batch.Roles.Any(role => role.Name == UtilDTO.ROLES.SM_MEDIA.ToString())
                                      select new { })
                    {
                        hasSharedSm = true;
                    }

                    if (!hasSharedSm)
                    {
                        txbResult.Text = "Psiu, olha aqui!\n\nVocê não possui nenhum contrato de SM que receba pela média de times.\n\nSerá que este é o menu que queria entrar mesmo ou falta algo em sua configuração?";
                        BlockFields(true);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                txbResult.Text = ex.Message;
                BlockFields(true);
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
                    case UtilDTO.NAVIGATION.DEV:
                        SprintDevDTO newAdaptaionSprint = new SprintDevDTO()
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == newAdaptaionSprint.Range.Name));
                        sprintsDevList.Add(newAdaptaionSprint);
                        sprintsDevList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                        break;
                    case UtilDTO.NAVIGATION.SM:
                        SprintSmDTO newSmSprintToAdd = new SprintSmDTO()
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsSmList.Remove(sprintsSmList.Find(s => s.Range.Name == newSmSprintToAdd.Range.Name));
                        sprintsSmList.Add(newSmSprintToAdd);
                        sprintsSmList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                        break;
                    case UtilDTO.NAVIGATION.DEV_EXTERNO:
                        SprintDevDTO newSprintExternal = new SprintDevDTO() 
                        {
                            Range = range,
                            ImagePath = sprintImagePath
                        };

                        //Remove e adiciona para caso ele esteja atualizando os dados
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == newSprintExternal.Range.Name));
                        sprintsDevList.Add(newSprintExternal);
                        sprintsDevList.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                        break;
                    default:
                        throw new NotImplementedException();
                }

                pbxSprintImage.Image = null;

                //atualizar a lista de sprints
                lsbSprints.Items.Remove(range.Name);
                lsbSprints.Items.Add(range.Name);

                sprintImagePath = null;
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

        #region BtnNextForm_Click
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
                case UtilDTO.NAVIGATION.DEV:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, configXml, fluxo, sprintsDevList));
                    break;
                case UtilDTO.NAVIGATION.SM:
                    containerForm.AbrirForm(new SprintSmCompartilhadoPontos(containerForm, configXml, fluxo, sprintsSmList));
                    break;
                case UtilDTO.NAVIGATION.DEV_EXTERNO:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, configXml, fluxo, sprintsDevList));
                    break;
                default:
                    throw new NotImplementedException();
            }
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
                LoadXmlConfig(folderDlg.SelectedPath);
                BlockFields(false);
                txbResult.Text = "Seja bem vindo de volta.";
            }
        } 
        #endregion

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

        #region BtnRemoveSprint_Click
        private void BtnRemoveSprint_Click(object sender, EventArgs e)
        {
            try
            {
                lsbSprints.Items.Remove(selectedRangeName);
                switch (fluxo)
                {
                    case UtilDTO.NAVIGATION.DEVOPS:
                        sprintsDevOpsList.Remove(sprintsDevOpsList.Find(s => s.Range.Name == selectedRangeName));
                        break;
                    case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == selectedRangeName));
                        sprintsSmList.Remove(sprintsSmList.Find(s => s.Range.Name == selectedRangeName));
                        break;
                    case UtilDTO.NAVIGATION.DEV:
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == selectedRangeName));
                        break;
                    case UtilDTO.NAVIGATION.SM:
                        sprintsSmList.Remove(sprintsSmList.Find(s => s.Range.Name == selectedRangeName));
                        break;
                    case UtilDTO.NAVIGATION.DEV_EXTERNO:
                        sprintsDevList.Remove(sprintsDevList.Find(s => s.Range.Name == selectedRangeName));
                        break;
                    default:
                        throw new NotImplementedException();
                }
                ShowLog();
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro. {ex.Message}";
            }
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
                selectedRangeName = lsbSprints.SelectedItem.ToString();
                //Neste caso o fluxo serve apenas para encontrar a lista preenchida
                switch (fluxo)
                {
                    case UtilDTO.NAVIGATION.DEVOPS:
                        var selectedDevOpsSprint = sprintsDevOpsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                        if (!String.IsNullOrEmpty(selectedDevOpsSprint.ImagePath))
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
                    //case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    default:
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
                }
            }
        }
        #endregion

        #region AUX
        private void BlockFields(bool block)
        {
            txbSprintDays.Enabled = !block;
            dtpIniDate.Enabled = !block;
            dtpEndDate.Enabled = !block;
            cbbSprintRanges.Enabled = !block;
            btnAddSprint.Enabled = !block;
            btnAddSprintImage.Enabled = !block;
            btnRemoveSprintImage.Enabled = !block;
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new Size(this.Width, this.Height + 20);
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
                case UtilDTO.NAVIGATION.DEV:
                    lblScreen.Text = "Tela 1/3";
                    break;
                case UtilDTO.NAVIGATION.SM:
                    lblScreen.Text = "Tela 1/2";
                    break;
                case UtilDTO.NAVIGATION.DEV_EXTERNO:
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
                case UtilDTO.NAVIGATION.DEV:
                    foreach (var sprint in sprintsDevList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }
                    break;
                case UtilDTO.NAVIGATION.SM:
                    foreach (var sprint in sprintsSmList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }
                    break;
                case UtilDTO.NAVIGATION.DEV_EXTERNO:
                    foreach (var sprint in sprintsDevList)
                    {
                        txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    }
                    break;
                default:
                    throw new NotImplementedException("ShowLog não implementado log para este fluxo");
            }
        }
        #endregion
    }
}