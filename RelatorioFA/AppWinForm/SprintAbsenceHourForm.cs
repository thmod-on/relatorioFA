using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RelatorioFA.DTO;
using RelatorioFA.Transacao;

namespace RelatorioFA.AppWinForm
{
    public partial class SprintAbsenceHourForm : Form
    {
        public SprintAbsenceHourForm(ContainerForm containerForm, ConfigXmlDTO configXml, UtilDTO.NAVIGATION fluxo, List<SprintDevDTO> sprintsDevList, List<SprintSmDTO> sprintsSmList = null)
        {
            InitializeComponent();
            this.sprintsDevList = sprintsDevList;
            this.sprintsSmList = sprintsSmList;
            this.configXml = configXml;
            this.fluxo = fluxo;
            this.containerForm = containerForm;
            //Texto cortando
            lblMessage.Text = "Este colaborador fez hora extra?\n+ Considerado hora extra serviços entre as 22h e 6h de um dia útil, finais de semana ou feriado. Por isso o pagaremos 0,5pts por turno adicional, ajustando para seu proporcional quando necessário.";
            lblScreen.Text = "Tela 3/3";
            SetSprintListBox();
            SetDefaultDevAbsensesAndExtraHour();
            SetDevSprintWithContractsAndDevs();
            SetCbbPartners();
            ShowLog();
        }

        private const string all = "TODOS";
        private const string mark = "- ";
        private readonly UtilDTO.NAVIGATION fluxo;
        private readonly ContainerForm containerForm;
        private readonly ConfigXmlDTO configXml;
        private readonly List<SprintDevDTO> sprintsDevList = new List<SprintDevDTO>();
        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();
        private readonly IntervaloDTO selectedRange = new IntervaloDTO();
        private readonly Dictionary<string, int> devAbsences = new Dictionary<string, int>();
        private readonly Dictionary<string, double> devExtraHour = new Dictionary<string, double>();
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private string selectedDevName;

        #region Eventos automaticos
        private void SetCbbPartners()
        {
            cbbPartners.Items.Add(all);
            foreach (var partner in configXml.Partners)
            {
                if (partner.Contracts.Any(c => c.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString()) &&
                    partner.Contracts.Any(c => c.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    )
                {
                    cbbPartners.Items.Add(partner.Name);
                }
            }
            cbbPartners.SelectedIndex = 0;
            lsbDevTeam.SelectedIndex = 0;
        }


        #region CbbPartners_SelectedIndexChanged
        private void CbbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            FornecedorDTO selectedPartner = null;
            if (!string.IsNullOrEmpty(cbbPartners.SelectedItem.ToString()))
            {
                lsbDevTeam.Items.Clear();
                if (cbbPartners.SelectedItem.ToString() != all)
                {
                    selectedPartner = configXml.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
                    SetPartnersDevInLsbDevTeam(selectedPartner);
                }
                else
                {
                    if (configXml.BaneseDes.Count > 0)
                    {
                        foreach (var dev in configXml.BaneseDes)
                        {
                            lsbDevTeam.Items.Add(mark + dev.Name);
                        } 
                    }
                    foreach (var partner in configXml.Partners)
                    {
                        SetPartnersDevInLsbDevTeam(partner);
                    }
                }
                lsbDevTeam.SelectedIndex = 0;
            }
        }
        #endregion

        #region LsbDevTeam_SelectedIndexChanged
        private void LsbDevTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDevName = lsbDevTeam.SelectedItem.ToString();
            if (selectedDevName.IndexOf(mark) >= 0)
            {
                selectedDevName = selectedDevName.Substring(mark.Length);
            }
            txbAbsence.Text = devAbsences[selectedDevName].ToString();
            txbExtraHour.Text = devExtraHour[selectedDevName].ToString();
            txbAbsence.Focus();
        }
        #endregion

        #region LsbSprints_SelectedIndexChanged
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSprints.SelectedIndex != -1)
            {
                selectedRange.Name = lsbSprints.SelectedItem.ToString();
            }
            
            var selectedSprint = sprintsDevList.Find(sprint => sprint.Range.Name == selectedRange.Name);
            foreach (var contract in selectedSprint.Contracts)
            {
                if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() 
                    && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                {
                    foreach (var dev in contract.Collaborators)
                    {
                        devAbsences[dev.Name] = dev.AbsenceDays;
                        devExtraHour[dev.Name] = dev.ExtraHours;
                    } 
                }
            }

            if (lsbDevTeam.Items.Count > 0)
            {
                lsbDevTeam.SelectedIndex = 0; 
            }
        }
        #endregion

        #region TxbAbsence_KeyPress
        private void TxbAbsence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }
        #endregion

        #region TxbExtraHour_KeyPress
        private void TxbExtraHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }
        #endregion

        #region TxbAbsence_Leave
        private void TxbAbsence_Leave(object sender, EventArgs e)
        {
            devAbsences[selectedDevName] = Convert.ToInt32(txbAbsence.Text);
        }
        #endregion

        #region TxbExtraHour_Leave
        private void TxbExtraHour_Leave(object sender, EventArgs e)
        {
            devExtraHour[selectedDevName] = Convert.ToDouble(txbExtraHour.Text);
        } 
        #endregion
        #endregion

        #region AUX
        private void SetDefaultDevAbsensesAndExtraHour()
        {
            devAbsences.Clear();
            devExtraHour.Clear();
            foreach (var houseDev in configXml.BaneseDes)
            {
                devAbsences.Add(houseDev.Name, 0);
                devExtraHour.Add(houseDev.Name, 0);
            }
            foreach (var partner in configXml.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    {
                        foreach (var dev in contract.Collaborators)
                        {
                            devAbsences.Add(dev.Name, 0);
                            devExtraHour.Add(dev.Name, 0);
                        }
                    }
                }
            }
        }

        private void SetSprintDevAbsensesAndExtraHour()
        {
            var selectedDevSprint = sprintsDevList.Find(sprint => sprint.Range.Name == selectedRange.Name);
            foreach (var contratc in selectedDevSprint.Contracts)
            {
                if (contratc.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString()
                    && contratc.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                {
                    foreach (var dev in contratc.Collaborators)
                    {
                        dev.AbsenceDays = devAbsences[dev.Name];
                        dev.ExtraHours = devExtraHour[dev.Name];
                    }
                }
            }
        }

        private void SetPartnersDevInLsbDevTeam(FornecedorDTO partner)
        {
            foreach (var contract in partner.Contracts)
            {
                if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() &&
                    contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString() )
                {
                    foreach (var dev in contract.Collaborators)
                    {
                        lsbDevTeam.Items.Add(dev.Name);
                    } 
                }
            }
        }

        private void SetDevSprintWithContractsAndDevs()
        {
            foreach (var selectedDevSprint in sprintsDevList)
            {
                if (selectedDevSprint.Contracts.Count == 0)
                {
                    if (configXml.BaneseDes.Count > 0)
                    {
                        ContratoDTO houseDevContract = new ContratoDTO()
                        {
                            Name = UtilDTO.CONTRACTS.HOUSE.ToString()
                        };
                        foreach (var dev in configXml.BaneseDes)
                        {
                            ColaboradorDTO houseDev = new ColaboradorDTO()
                            {
                                Name = dev.Name,
                                WorksHalfDay = dev.WorksHalfDay,
                                AbsenceDays = devAbsences[dev.Name],
                                ExtraHours = devExtraHour[dev.Name]
                            };
                            houseDevContract.Collaborators.Add(houseDev);
                        }
                        selectedDevSprint.Contracts.Add(houseDevContract);
                    }

                    foreach (var partner in configXml.Partners)
                    {
                        foreach (var contract in partner.Contracts)
                        {
                            if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() &&
                                contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                            {
                                ContratoDTO newContract = new ContratoDTO()
                                {
                                    Name = contract.Name,
                                    Factor = contract.Factor,
                                    HourValue = contract.HourValue,
                                    NumeroSAP = contract.NumeroSAP,
                                    PartnerName = partner.Name
                                };
                                foreach (var dev in contract.Collaborators)
                                {
                                    ColaboradorDTO newDev = new ColaboradorDTO()
                                    {
                                        Name = dev.Name,
                                        AbsenceDays = devAbsences[dev.Name],
                                        ExtraHours = devExtraHour[dev.Name],
                                        WorksHalfDay = dev.WorksHalfDay
                                    };
                                    newContract.Collaborators.Add(newDev);
                                }
                                selectedDevSprint.Contracts.Add(newContract);
                            }
                        }
                    }  
                }
            }
        }

        #region SetSprintList
        private void SetSprintListBox()
        {
            foreach (var sprint in sprintsDevList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
            }

            lsbSprints.SelectedIndex = 0;
            selectedRange.Name = lsbSprints.SelectedItem.ToString();
        }
        #endregion

        #region BlockFields
        private void BlockFields(bool block)
        {
            cbbPartners.Enabled = !block;
            lsbDevTeam.Enabled = !block;
            lsbSprints.Enabled = !block;
            txbAbsence.Enabled = !block;
            txbExtraHour.Enabled = !block;
            btnPreviousForm.Enabled = !block;
            btnUpdateSprint.Enabled = !block;
            btnSetOutputDocPath.Enabled = !block;
            btnGenerate.Enabled = !block;
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

            txbResult.AppendText("Se as configurações de autor ou nome precisarem de ajuste, favor revisar o arquivo de configuração e começar o processo novamente.");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"Autor: {configXml.AuthorName}\n");
            txbResult.AppendText($"Área: {configXml.AreaName}\n");
            txbResult.AppendText($"Time: {configXml.TeamName}");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"O arquivo será gerado em: {outputDocPath}");
            txbResult.AppendText("\n===========\n");

            txbResult.AppendText("\nSprints Dev");
            txbResult.AppendText("\n===========\n");
            foreach (var sprint in sprintsDevList)
            {
                txbResult.AppendText(sprint.ToStringBuilder().ToString());
                txbResult.AppendText("\n");
            }

            if (sprintsSmList != null)
            {
                txbResult.AppendText("Sprints SM");
                txbResult.AppendText("\n===========\n");
                foreach (var sprint in sprintsSmList)
                {
                    txbResult.AppendText(sprint.ToStringBuilder().ToString());
                    txbResult.AppendText("\n");
                }
            }
            txbResult.Select(0, 0);
        }
        #endregion
        #endregion

        #region Eventos de Click
        #region BtnPreviousForm_Click
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {
            switch (fluxo)
            {
                case UtilDTO.NAVIGATION.DEVOPS:
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, configXml, fluxo, sprintsDevList, sprintsSmList));
                    break;
                default:
                    break;
            }
        } 
        #endregion

        #region BtnAddSprint_Click
        private void BtnUpdateSprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                SetSprintDevAbsensesAndExtraHour();

                SetDefaultDevAbsensesAndExtraHour();

                //Organizando a sprint SM
                if (sprintsSmList != null)
                {
                    if (sprintsSmList.Find(sprint => sprint.Range.Name == selectedRange.Name).Contracts.Count < 1)
                    {
                        foreach (var partner in configXml.Partners)
                        {
                            foreach (var contract in partner.Contracts)
                            {
                                if (contract.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString() ||
                                    contract.Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                                {
                                    ContratoDTO smContract = new ContratoDTO()
                                    {
                                        Factor = contract.Factor,
                                        HourValue = contract.HourValue,
                                        Name = contract.Name,
                                        NumeroSAP = contract.NumeroSAP
                                    };
                                    foreach (var sm in contract.Collaborators)
                                    {
                                        smContract.Collaborators.Add(sm);
                                    }
                                    sprintsSmList.Find(sprint => sprint.Range.Name == selectedRange.Name).Contracts.Add(smContract);
                                }
                            }
                        }
                    }
                }

                txbAbsence.Clear();
                txbExtraHour.Clear();
                ShowLog($"Srpint {selectedRange.Name} atualizada.");
                if (lsbSprints.SelectedIndex < lsbSprints.Items.Count - 1)
                {
                    lsbSprints.SelectedIndex += 1;
                }
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
            System.Diagnostics.Process.Start(outputDocPath);
        }
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                BlockFields(true);
                txbResult.Text = "Processando...";
                //realizar os calculos e ajustar dados finais
                foreach (var sprint in sprintsDevList)
                {
                    //DEV
                    int sprintDays = (sprint.Range.EndDate - sprint.Range.IniDate).Days;
                    PrincipalTO.SetDevPresence(sprint.Contracts, sprintDays);
                    double teamSize = PrincipalTO.CalcTeamSize(sprint);
                    sprint.TeamSize = teamSize;
                    PrincipalTO.CalcPointsPerTeamMember(sprint);
                    //SM
                    var smSprint = sprintsSmList.Find(s => s.Range.Name == sprint.Range.Name);
                    smSprint.TeamSize = teamSize;
                    smSprint.EmployeesCount = 1;
                }

                //chamar a geracao dos relatorios
                foreach (var partner in configXml.Partners)
                {
                    //(TODO) Melhorar um dia
                    if (partner.Name == "Influir")
                    {
                        partner.BillingType = UtilDTO.BILLING_TYPE.UST_HORA;
                    }

                    if (partner.Contracts.Any(contract => 
                        contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() &&
                        contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString()) )
                    {
                        PrincipalTO.CreateDevDoc(configXml, partner, outputDocPath, sprintsDevList);
                    }

                    if (partner.Contracts.Any(contract =>
                        contract.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString() ||
                        contract.Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString()))
                    {
                        PrincipalTO.CreateSmDoc(configXml, partner, outputDocPath, sprintsSmList);
                    }
                }
                txbResult.Text = $"Arquivos gerados na pasta {outputDocPath}";
                btnOpenDestinationFolder.Enabled = true;
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
                BlockFields(false);
            }
        }
        #endregion

        #region BtnSetOutputDocPath_Click
        private void BtnSetOutputDocPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputDocPath = folderDlg.SelectedPath;
            }

            ShowLog("Caminho de saído do arquivo definodo.");
        }
        #endregion

        #endregion
    }
}