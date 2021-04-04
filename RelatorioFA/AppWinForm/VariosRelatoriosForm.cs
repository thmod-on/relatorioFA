using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RelatorioFA.Transacao;
using RelatorioFA.DTO;
using System.IO;
using System.Text.RegularExpressions;

namespace RelatorioFA.AppWinForm
{
    public partial class VariosRelatoriosForm : Form
    {
        public VariosRelatoriosForm(Form containerForm)
        {
            InitializeComponent();
            SetFields();
            LoadConfig(outputDocPath);
            ResizeParent(containerForm);
        }

        public VariosRelatoriosForm()
        {
            InitializeComponent();
            SetFields();
            LoadConfig(outputDocPath);
        }

        ConfigDTO config = new ConfigDTO();
        List<ColaboradorDTO> devTeam = new List<ColaboradorDTO>();
        List<SprintDTO> sprints = new List<SprintDTO>();
        List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
        private string outputDocPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Dictionary<ColaboradorDTO, int> devAbsence = new Dictionary<ColaboradorDTO, int>();
        string sprintImagePath = string.Empty;

        private void SetFields()
        {
            txbResult.Enabled = false;
            txbAbsence.Text = "0";

            btnGenerateAll.Enabled = false;

            //txbObs.Text = "time topado!";
            //txbAcceptedPointsExpense.Text = "24";
            //txbAcceptedPointsInvestment.Text = "10";
            //outputDocPath = System.IO.Directory.GetCurrentDirectory();
        }

        #region Config
        #region LoadConfig
        private void LoadConfig(string outputDocPath)
        {
            try
            {
                config = PrincipalTO.LoadConfig(outputDocPath);
                SetPartnerContractType();
                LoadTeamName();
                LoadDevTeam();
                LoadAuthor();
                SetDefaultDevAbsence();
                LoadCerimonialPointCombo();

                sprintRanges = PrincipalTO.GenerateRanges();
                LoadSprintRangesCbb(sprintRanges);
                BlockFields(false);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                txbResult.Text = ex.Message;
                BlockFields(true);
                btnLoadXml.Focus();
            }
            catch (System.Xml.XmlException ex)
            {
                txbResult.Text = "Falha na estrutura do XML. Mensagem: " + ex.Message + "\n\n" + ex.StackTrace;
            }
            catch (Exception ex)
            {
                txbResult.Text = "Exceção não tratada ao tentar carregar alguma configuração. Mensagem: " + ex.Message + "\n\n" + ex.StackTrace;
            }
        }

        private void SetPartnerContractType()
        {
            //POG para Influir, depois melhorar, se precisar
            foreach (var partner in config.Partners)
            {
                partner.BillingType = UtilDTO.BILLING_TYPE.UST;
                foreach (var contract in partner.Contracts)
                {
                    if (contract.HourValue > 0)
                    {
                        partner.BillingType = UtilDTO.BILLING_TYPE.UST_HORA;
                        break;
                    }
                }
            }
        }
        #endregion

        private void LoadCerimonialPointCombo()
        {
            cbbCerimonialPoint.DataSource = Enum.GetValues(typeof(UtilDTO.CERIMONIAL_POINT));
            cbbCerimonialPoint.SelectedIndex = 0;
        }

        private void SetDefaultDevAbsence()
        {
            devAbsence.Clear();
            foreach (var dev in devTeam)
            {
                devAbsence.Add(dev, 0);
            }
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void LoadAuthor()
        {
            lblAuthor.Text = config.AuthorName;
        }
        #endregion

        #region LoadDevTeam
        private void LoadDevTeam()
        {
            foreach (var dev in config.BaneseDes)
            {
                devTeam.Add(dev);
                lsbDevTeam.Items.Add(dev.Name);
            }

            foreach (var partner in config.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    {
                        foreach (var dev in contract.Collaborators)
                        {
                            devTeam.Add(dev);
                            lsbDevTeam.Items.Add(dev.Name);
                        }
                    }
                }
            }
        }
        #endregion

        #region Atualização de campos
        private void LoadSprintRangesCbb(List<IntervaloDTO> sprintRanges)
        {
            foreach (var range in sprintRanges)
            {
                cbbSprintRanges.Items.Add(range.Name);
            }
            cbbSprintRanges.SelectedIndex = 0;
        }

        private void LoadTeamName()
        {
            lblTeamName.Text = config.TeamName;
        }

        private void ClearFields()
        {
            txbAcceptedPointsExpense.Text = "0";
            txbAbsence.Text = "0";
            txbObs.Clear();
            txbResult.Clear();
        }

        #region ValidateFieldsGenerate
        private void ValidateFieldsGenerate()
        {
            if (sprints.Count == 0)
            {
                throw new Exception("Ao menos uma sprint deve ser adicionada.");
            }

            if (outputDocPath == string.Empty)
            {
                throw new Exception("Um caminho deve ser escolhido para geração do arquivo.");
            }
        }
        #endregion
        #endregion

        #region cbb item change
        private void CbbSprintRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpIniDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).IniDate;
            dtpEndDate.Value = sprintRanges.Find(x => x.Name == cbbSprintRanges.SelectedItem.ToString()).EndDate;
        }

        private void DtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            txbSprintDays.Text = ((dtpEndDate.Value - dtpIniDate.Value).Days - 3).ToString();
        }

        private void LsbDevTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txbAbsence.Text = devAbsence[lsbDevTeam.SelectedItem.ToString()].ToString();
            ColaboradorDTO dev = devAbsence.Keys.ToList().Find(d => d.Name == lsbDevTeam.SelectedItem.ToString());
            txbAbsence.Text = devAbsence[dev].ToString();
            txbAbsence.Focus();
        }
        #endregion

        #region Eventos de click
        #region BtnAddSprint_Click
        private void BtnAddSprint_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAddSprint();

                Dictionary<string, double> devPresence = new Dictionary<string, double>();

                PrincipalTO.SetDevPresence(out devPresence, devAbsence, Convert.ToInt32(txbSprintDays.Text));

                IntervaloDTO range = new IntervaloDTO
                {
                    Name = cbbSprintRanges.SelectedItem.ToString(),
                    IniDate = dtpIniDate.Value,
                    EndDate = dtpEndDate.Value
                };

                SprintDTO newSprint = new SprintDTO()
                {
                    Range = range,
                    Obs = Regex.Replace(txbObs.Text, @"\r\n?|\n", " "),
                    AcceptedPointsExpenses = Convert.ToInt32(txbAcceptedPointsExpense.Text),
                    AcceptedPointsInvestment = Convert.ToInt32(txbAcceptedPointsInvestment.Text),
                    TeamSize = PrincipalTO.CalcTeamSize(devPresence),
                    CerimonialPoint = (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedItem,
                    ImagePath = sprintImagePath
                };

                PrincipalTO.CalcPointsPerTeamMember(newSprint);

                foreach (var partner in config.Partners)
                {
                    foreach (var contract in partner.Contracts)
                    {
                        ContratoSprintDTO cs = new ContratoSprintDTO()
                        {
                            EmployeesCount = PrincipalTO.CalcEmployeesPrticipation(contract, devPresence)
                        };

                        cs.PointsPerPartnerExpenses = PrincipalTO.CalcPartnerPoints(newSprint.PointsPerTeamMemberExpenses, contract.Factor, (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedValue == UtilDTO.CERIMONIAL_POINT.DESPESA ? true : false, cs.EmployeesCount);
                        cs.PointsPerPartnerInvestment = PrincipalTO.CalcPartnerPoints(newSprint.PointsPerTeamMemberInvestment, contract.Factor, (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedValue == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO ? true : false, cs.EmployeesCount);

                        if (contract.HourValue > 0)
                        {
                            cs.HoursExpenses = PrincipalTO.CalcSprintHours(cs.PointsPerPartnerExpenses, partner.UstValue, contract.HourValue);
                            cs.HoursInvestment = PrincipalTO.CalcSprintHours(cs.PointsPerPartnerInvestment, partner.UstValue, contract.HourValue);
                        }

                        if (contract.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString())
                        {
                            cs.EmployeesCount = 1;
                            cs.PointsPerPartnerExpenses = Convert.ToDouble(txbSmPoints.Text);
                        }

                        contract.ContractSprint.Add(cs);
                    }
                }
                
                sprints.Add(newSprint);
                txbResult.Text = $"Sprint {newSprint.Range.Name} adicionada ao conjunto.";

                SetDefaultDevAbsence();
                txbAcceptedPointsExpense.Clear();
                txbAcceptedPointsInvestment.Clear();
                txbObs.Clear();
                pbxSprintImage.Image = null;
                txbAbsence.Text = "0";
                btnGenerateAll.Enabled = true;
                if (cbbSprintRanges.SelectedIndex < cbbSprintRanges.Items.Count)
                {
                    cbbSprintRanges.SelectedIndex += 1;
                }

                lsbSprints.Items.Add(newSprint.Range.Name);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro durante processo de adição da sprint. Mensagem:\n{ex.Message}\n\nTrace:\n{ex.StackTrace}";
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
                lblOutputDocPath.Text = folderDlg.SelectedPath;
                lblOutputDocPath.Visible = true;

                outputDocPath = folderDlg.SelectedPath;

                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFieldsGenerate();

                Processing(true);
                sprints.Sort((x, y) => x.Range.Name.CompareTo(y.Range.Name));
                PrincipalTO.CreateDocs(config, sprints, devTeam, outputDocPath);
                txbResult.Text = $"Arquivos gerados na pasta\n{outputDocPath}";
                btnOpenDestinationFolder.Enabled = true;
            }
            catch (Exception ex)
            {
                txbResult.Text = "Erro ao gerar relatório. Mensagem: " + ex.Message + "\n\nPilha:\n" + ex.StackTrace.ToString();
            }
            finally
            {
                Processing(false);
            }
        }
        #endregion

        #region BtnLoadXml_Click
        private void BtnLoadXml_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadConfig(folderDlg.SelectedPath);
                txbResult.Text = "Configurações carregadas com sucesso";
            }
        }
        #endregion

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        }
        #endregion

        #region BtnSprintImage_Click
        private void BtnSprintImage_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            string filePath = null;
            sprintImagePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens PNG (*.png)|*.png|Imagens Jpeg (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        pbxSprintImage.Load(filePath);
                    }
                }
            }

            sprintImagePath = filePath;
        }
        #endregion
        #endregion

        #region Processing
        private void Processing(bool processing)
        {
            //TODO quando terminar de processar abrir um novo form zerado para o usuário e descartar esse
            if (processing)
            {
                txbResult.Text = "Gerando arquivo...";
            }

            BlockFields(processing);
        }

        #region BlockFields
        private void BlockFields(bool block)
        {
            btnGenerateAll.Enabled = !block;
            btnAddSprint.Enabled = !block;

            txbAcceptedPointsExpense.Enabled = !block;
            txbAcceptedPointsInvestment.Enabled = !block;
            txbAbsence.Enabled = !block;
            txbObs.Enabled = !block;
            txbSprintDays.Enabled = !block;
            txbSmPoints.Enabled = !block;

            cbbSprintRanges.Enabled = !block;
            cbbCerimonialPoint.Enabled = !block;

            dtpIniDate.Enabled = !block;
            dtpEndDate.Enabled = !block;

            lsbDevTeam.Enabled = !block;
        } 
        #endregion
        #endregion

        #region TxbAbsence_Leave
        private void TxbAbsence_Leave(object sender, EventArgs e)
        {
            if (lsbDevTeam.Items.Count > 0)
            {
                if (ValidteAbsence())
                {
                    try
                    {
                        ColaboradorDTO dev = devAbsence.Keys.ToList().Find(x => x.Name == lsbDevTeam.SelectedItem.ToString());
                        devAbsence[dev] = Convert.ToInt32(txbAbsence.Text);
                        //devAbsence[lsbDevTeam.SelectedItem.ToString()] = Convert.ToInt32(txbAbsence.Text);
                    }
                    catch (Exception)
                    {
                        txbResult.Text = "Você deve selecionar um coloborador para atribuir sua falta.";
                    }
                }
                else
                {
                    txbResult.Text = "Colaborador não pode ter mais ausências que a quantidade de dias na sprint.";
                    txbAbsence.Focus();
                } 
            }
        }

        private bool ValidteAbsence()
        {
            return (Convert.ToInt32(txbSprintDays.Text) < Convert.ToInt32(txbAbsence.Text)) ? false : true;
        }
        #endregion

        #region ValidateAddSprint
        private void ValidateAddSprint()
        {
            if (txbAcceptedPointsExpense.Text.Trim() == string.Empty && txbAcceptedPointsInvestment.Text.Trim() == string.Empty)
            {
                throw new Exception("Uma sprint não pode ser cadastrada sem pontos aceitos.");
            }

            if (txbAcceptedPointsExpense.Text.Trim() == string.Empty || Convert.ToInt32(txbAcceptedPointsExpense.Text) < 1)
            {
                txbAcceptedPointsExpense.Text = "0";
            }

            if (txbAcceptedPointsInvestment.Text.Trim() == string.Empty || Convert.ToInt32(txbAcceptedPointsInvestment.Text) < 1)
            {
                txbAcceptedPointsInvestment.Text = "0";
            }

            if (sprints.Any(x => x.Range.Name == cbbSprintRanges.SelectedItem.ToString()))
            {
                throw new Exception($"A sprint {cbbSprintRanges.SelectedItem} já foi adicionada ao conjunto.");
            }
        }
        #endregion

        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Atualizar os objetos com os dados da tela


            //Carregar os novos dados
            SprintDTO sprint = new SprintDTO();
            sprint = sprints.Find(x => x.Range.Name == lsbSprints.SelectedItem.ToString());

            txbObs.Text = sprint.Obs;
            txbAcceptedPointsExpense.Text = sprint.AcceptedPointsExpenses.ToString();
            txbAcceptedPointsInvestment.Text = sprint.AcceptedPointsInvestment.ToString();

            dtpIniDate.Text = sprint.Range.IniDate.ToString();
            dtpEndDate.Text = sprint.Range.EndDate.ToString();

            cbbCerimonialPoint.SelectedItem = sprint.CerimonialPoint;
            cbbSprintRanges.SelectedItem = sprint.Range.Name;
        }
    }
}
