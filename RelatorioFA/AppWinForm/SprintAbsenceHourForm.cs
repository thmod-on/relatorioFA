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
        public SprintAbsenceHourForm(ContainerForm containerForm, ConfigXmlDTO configXml, UtilDTO.NAVIGATION fluxo, List<SprintDevDTO> sprintsDevList = null, List<SprintSmDTO> sprintsSmList = null)
        {
            InitializeComponent();
            this.sprintsDevList = sprintsDevList;
            this.sprintsSmList = sprintsSmList;
            this.configXml = configXml;
            this.fluxo = fluxo;
            this.containerForm = containerForm;
            lblMessage.Text = "Este colaborador fez hora extra?\nConsiderado hora extra serviços entre as 22h e 6h de um dia útil, finais de semana ou feriado. Será contabilizado 0,5pts por turno adicional, ajustando para seu proporcional quando necessário.";
            lblScreen.Text = "Tela 3/3";
            SetScreenLayout(fluxo);
            SetSprintListBox();
            SetDevSprintWithContractsAndDevs();
            SetSmSprintWithContracts();
            SetCbbPartners();
            ShowLog();
        }

        private const string house = "Da Casa";
        private const string all = "TODOS";
        private const string mark = "- ";
        private readonly UtilDTO.NAVIGATION fluxo;
        private readonly ContainerForm containerForm;
        private readonly ConfigXmlDTO configXml;
        private readonly List<SprintDevDTO> sprintsDevList = new List<SprintDevDTO>();
        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();
        private readonly IntervaloDTO selectedRange = new IntervaloDTO();
        FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private string selectedDevName;

        #region Eventos automaticos
        private void SetCbbPartners()
        {
            if (fluxo != UtilDTO.NAVIGATION.DEV_EXTERNO)
            {
                if (fluxo == UtilDTO.NAVIGATION.VARIOS_RELATORIOS)
                {
                    cbbPartners.Items.Add(all);
                }
                else
                {
                    cbbPartners.Items.Add(house);
                }

                foreach (var partner in from partner in configXml.Partners
                                        from contract in partner.Contracts
                                        where contract.Batches.Any(b => b.Name == UtilDTO.BATCHS.DEV.ToString())
                                        select partner)
                {
                    cbbPartners.Items.Add(partner.Name);
                }
            }
            else
            {
                foreach (var partner in from partner in configXml.Partners
                                        from contract in partner.Contracts
                                        where contract.Batches.Any(b => b.Name == UtilDTO.BATCHS.EXTERNO.ToString())
                                        select partner)
                {
                    cbbPartners.Items.Add(partner.Name);
                }
            }
            cbbPartners.SelectedIndex = 0;
        }


        #region CbbPartners_SelectedIndexChanged
        private void CbbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fluxo != UtilDTO.NAVIGATION.DEV_EXTERNO)
            {
                if (!string.IsNullOrEmpty(cbbPartners.SelectedItem.ToString()))
                {
                    lsbDevTeam.Items.Clear();
                    if (cbbPartners.SelectedItem.ToString() == all)
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
                    else if (cbbPartners.SelectedItem.ToString() == house)
                    {
                        cbbContract.Items.Clear();
                        cbbContract.Text = String.Empty;
                        foreach (var dev in configXml.BaneseDes)
                        {
                            lsbDevTeam.Items.Add(mark + dev.Name);
                        }
                    }
                    else
                    {
                        selectedPartner = configXml.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
                        SetPartnerContractsCbb(selectedPartner);
                    }
                    if (lsbDevTeam.Items.Count > 0)
                    {
                        lsbDevTeam.SelectedIndex = 0;
                    }
                }
            }
        }
        #endregion

        private void SetPartnerContractsCbb(FornecedorDTO selectedPartner)
        {
            cbbContract.Items.Clear();
            foreach (var contract in selectedPartner.Contracts)
            {
                if (contract.Batches.Any(b => b.Name == UtilDTO.BATCHS.DEV.ToString()))
                {
                    cbbContract.Items.Add(contract.SapNumber);
                }
            }
            cbbContract.SelectedIndex = 0;
        }

        #region CbbContract_SelectedIndexChanged
        private void CbbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedContract = selectedPartner.Contracts.Find(c => c.SapNumber == cbbContract.SelectedItem.ToString());
            lsbDevTeam.Items.Clear();
            lsbDevTeam.Text = String.Empty;
            foreach (var dev in from batch in selectedContract.Batches
                                where batch.Name == UtilDTO.BATCHS.DEV.ToString()
                                from role in batch.Roles
                                from dev in role.Collaborators
                                select dev)
            {
                lsbDevTeam.Items.Add(dev.Name);
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
            var dev = GetSelectedDev();
            txbAbsence.Text = dev.AbsenceDays.ToString();
            txbExtraHourExpenses.Text = dev.ExtraHoursExpenses.ToString();
            txbExtraHourInvestment.Text = dev.ExtraHourInvestment.ToString();
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

            if (lsbDevTeam.Items.Count > 0)
            {
                lsbDevTeam.SelectedIndex = lsbDevTeam.Items.Count - 1;
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
            GetSelectedDev().AbsenceDays = Convert.ToInt32(txbAbsence.Text);
            ShowLog();
            //devAbsences[selectedDevName] = Convert.ToInt32(txbAbsence.Text);
        }
        #endregion

        #region TxbExtraHour_Leave
        private void TxbExtraHourExpenses_Leave(object sender, EventArgs e)
        {
            GetSelectedDev().ExtraHoursExpenses = Convert.ToDouble(txbExtraHourExpenses.Text);
            ShowLog();
            //devExtraHour[selectedDevName] = Convert.ToDouble(txbExtraHourExpenses.Text);
        }
        #endregion

        #region TxbExtraHourInvestment_Leave
        private void TxbExtraHourInvestment_Leave(object sender, EventArgs e)
        {
            GetSelectedDev().ExtraHourInvestment = Convert.ToDouble(txbExtraHourInvestment.Text);
            ShowLog();
        }
        #endregion
        #endregion

        #region AUX
        #region GetSelectedDev
        private ColaboradorDTO GetSelectedDev()
        {
            foreach (var dev in from sprint in sprintsDevList
                                where sprint.Range.Name == lsbSprints.SelectedItem.ToString()
                                from contract in sprint.Contracts
                                from batch in contract.Batches
                                from role in batch.Roles
                                from dev in role.Collaborators
                                where dev.Name == selectedDevName
                                select dev)
            {
                return dev;
            }

            return null;
        }
        #endregion

        #region SetPartnersDevInLsbDevTeam
        private void SetPartnersDevInLsbDevTeam(FornecedorDTO partner)
        {
            foreach (var contract in partner.Contracts)
            {
                foreach (var batch in contract.Batches)
                {
                    if (batch.Name == UtilDTO.BATCHS.DEV.ToString())
                    {
                        foreach (var role in batch.Roles)
                        {
                            foreach (var dev in role.Collaborators)
                            {
                                lsbDevTeam.Items.Add(dev.Name);
                            }
                        }
                    }
                } 
            }
        }
        #endregion

        private void SetScreenLayout(UtilDTO.NAVIGATION flux)
        {
            switch (flux)
            {
                case UtilDTO.NAVIGATION.DEV_EXTERNO:
                    lblText1.Visible = false;
                    lblText2.Visible = false;
                    lblAbsence.Visible = false;

                    lsbDevTeam.Visible = false;
                    txbAbsence.Visible = false;
                    break;
                default:
                    break;
            }

        }

        private void SetSmSprintWithContracts()
        {
            if (sprintsSmList != null)
            {
                foreach (var sprintSm in sprintsSmList)
                {
                    if (sprintSm.Contracts.Count < 1)
                    {
                        sprintSm.Contracts.Add((from partner in configXml.Partners
                                               from contract in partner.Contracts
                                               from batch in contract.Batches
                                               where batch.Name == UtilDTO.BATCHS.SM.ToString()
                                               from role in batch.Roles
                                               where role.Name == UtilDTO.ROLES.SM_FIXO.ToString()
                                               select  contract).First());
                    }
                }
            }
        }

        private void SetDevSprintWithContractsAndDevs()
        {
            foreach (var selectedDevSprint in sprintsDevList)
            {
                //Caso a lista ainda não tenha contratos de dev criados
                if (selectedDevSprint.Contracts.Count == 0)
                {
                    //Caso o time tenha devs da casa
                    if (configXml.BaneseDes.Count > 0)
                    {
                        ContratoDTO houseDevContract = new ContratoDTO()
                        {
                            PartnerName = UtilDTO.ROLES.HOUSE.ToString()
                        };
                        LoteDTO houseDevBatch = new LoteDTO()
                        {
                            Name = UtilDTO.ROLES.HOUSE.ToString()
                        };
                        CargoDTO houseDevRole = new CargoDTO()
                        {
                            Name = UtilDTO.ROLES.HOUSE.ToString()
                        };
                        foreach (var dev in configXml.BaneseDes)
                        {
                            ColaboradorDTO houseDev = new ColaboradorDTO()
                            {
                                Name = dev.Name,
                                WorksHalfDay = dev.WorksHalfDay,
                                AbsenceDays = 0,
                                ExtraHoursExpenses = 0
                            };
                            houseDevRole.Collaborators.Add(houseDev);
                        }
                        houseDevBatch.Roles.Add(houseDevRole);
                        houseDevContract.Batches.Add(houseDevBatch);
                        selectedDevSprint.Contracts.Add(houseDevContract);
                    }

                    foreach (var partner in configXml.Partners)
                    {
                        if (fluxo != UtilDTO.NAVIGATION.DEV_EXTERNO)
                        {
                            foreach (var contract in partner.Contracts)
                            {
                                ContratoDTO newContract = new ContratoDTO()
                                {
                                    SapNumber = contract.SapNumber,
                                    PartnerName = partner.Name
                                };
                                foreach (var batch in contract.Batches)
                                {
                                    LoteDTO newBatch = new LoteDTO()
                                    {
                                        Name = batch.Name
                                    };
                                    if (batch.Name != UtilDTO.BATCHS.SM.ToString() &&
                                        batch.Name != UtilDTO.BATCHS.EXTERNO.ToString())
                                    {
                                        foreach (var role in batch.Roles)
                                        {  
                                            CargoDTO newRole = new CargoDTO()
                                            {
                                                Name = role.Name,
                                                Factor = role.Factor,
                                            };
                                            foreach (var dev in role.Collaborators)
                                            {
                                                ColaboradorDTO newDev = new ColaboradorDTO()
                                                {
                                                    Name = dev.Name,
                                                    AbsenceDays = 0,
                                                    ExtraHoursExpenses = 0,
                                                    WorksHalfDay = dev.WorksHalfDay
                                                };
                                                newRole.Collaborators.Add(newDev);
                                            }
                                            newBatch.Roles.Add(newRole);
                                        }
                                        newContract.Batches.Add(newBatch);
                                    }
                                }
                                selectedDevSprint.Contracts.Add(newContract);
                            }
                        }
                        else
                        {
                            foreach (var contract in partner.Contracts)
                            {
                                foreach (var batch in contract.Batches)
                                {
                                    if (batch.Name == UtilDTO.BATCHS.EXTERNO.ToString())
                                    {
                                        ContratoDTO newContract = new ContratoDTO()
                                        {
                                            SapNumber = contract.SapNumber,
                                            PartnerName = partner.Name
                                        };
                                        LoteDTO newBatch = new LoteDTO()
                                        {
                                            Name = batch.Name
                                        };
                                        CargoDTO newRole = new CargoDTO()
                                        {
                                            Name = batch.Roles[0].Name,
                                            Factor = batch.Roles[0].Factor,
                                        };
                                        newBatch.Roles.Add(newRole);
                                        newContract.Batches.Add(newBatch);
                                        selectedDevSprint.Contracts.Add(newContract);
                                    }
                                }
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
            txbExtraHourExpenses.Enabled = !block;
            txbExtraHourInvestment.Enabled = !block;
            btnPreviousForm.Enabled = !block;
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
                case UtilDTO.NAVIGATION.DEV:
                    containerForm.AbrirForm(new SprintPontosObsForm(containerForm, configXml, fluxo, sprintsDevList));
                    break;
                default:
                    break;
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
                bool hasSharedSM = false;
                bool hasExternalDev = false;
                if (cbbPartners.SelectedItem.ToString() == house)
                {
                    throw new Exception("Por favor ecolha um fornecedor para que o relatório seja gerado.");
                }

                BlockFields(true);
                txbResult.Text = "Processando...";
                //realizar os calculos e ajustar dados finais
                foreach (var sprint in sprintsDevList)
                {
                    //DEV
                    int sprintDays = (sprint.Range.EndDate - sprint.Range.IniDate).Days + 1;
                    PrincipalTO.SetDevPresence(sprint.Contracts, sprintDays, sprint.AdaptaionSprint);
                    double teamSize = PrincipalTO.CalcTeamSize(sprint, fluxo);
                    sprint.TeamSize = teamSize;
                    if (sprint.AdaptaionSprint)
                    {
                        sprint.AcceptedPointsExpenses *= (int)teamSize;
                    }
                    PrincipalTO.CalcPointsPerTeamMember(sprint);

                    //SM
                    if (sprintsSmList != null)
                    {
                        var smSprint = sprintsSmList.Find(s => s.Range.Name == sprint.Range.Name);
                        smSprint.TeamSize = teamSize;
                        smSprint.EmployeesCount = 1;
                    }
                }

                //chamar a geracao dos relatorios
                if (fluxo == UtilDTO.NAVIGATION.VARIOS_RELATORIOS)
                {
                    foreach (var partner in configXml.Partners)
                    {
                        foreach (var contract in partner.Contracts)
                        {
                            //SM_MEDIA nao será gerado nesse fluxo
                            if (contract.Batches.Any(b => b.Name == UtilDTO.BATCHS.DEV.ToString()))
                            {
                                PrincipalTO.CreateDevDoc(configXml, partner, contract, outputDocPath, sprintsDevList);
                            }

                            if (contract.Batches.Any(b => b.Roles.Any(r => r.Name == UtilDTO.ROLES.SM_MEDIA.ToString())))
                            {
                                hasSharedSM = true;
                            }

                            if (contract.Batches.Any(b => b.Name == UtilDTO.BATCHS.EXTERNO.ToString()))
                            {
                                hasExternalDev = true;
                            }

                            if (contract.Batches.Any(b => b.Roles.Any(r => r.Name == UtilDTO.ROLES.SM_FIXO.ToString())))
                            {
                                PrincipalTO.CreateSmDoc(configXml, partner, contract, outputDocPath, sprintsSmList);
                            } 
                        }
                    }
                }
                else
                {
                    var selectedPartner = configXml.Partners.Find(partner => partner.Name == cbbPartners.SelectedItem.ToString());
                    if (fluxo == UtilDTO.NAVIGATION.DEV_EXTERNO)
                    {
                        selectedPartner.BillingType = UtilDTO.BILLING_TYPE.UST_EXTERNAL;
                    }
                    PrincipalTO.CreateDevDoc(configXml, selectedPartner, selectedContract, outputDocPath, sprintsDevList);
                }

                txbResult.Text = $"Arquivos gerados na pasta {outputDocPath}";
                if (hasSharedSM)
                {
                    txbResult.AppendText("\n\nRelatório para SM compartilhado deve ser gerado avulso pelo menu correspondente.");
                }
                if (hasExternalDev)
                {
                    txbResult.AppendText("\n\nRelatório para colaborador externo deve ser gerado avulso pelo menu correspondente.");
                }
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
            outputDocPath = UtilWinForm.SetOutputDocPath();

            ShowLog("Caminho de saída do arquivo definodo.");
        }
        #endregion

        #endregion
    }
}