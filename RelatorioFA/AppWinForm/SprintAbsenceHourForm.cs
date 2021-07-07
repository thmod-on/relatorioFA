using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.containerForm = containerForm;
            this.sprintsDevList = sprintsDevList;
            this.sprintsSmList = sprintsSmList;
            this.configXml = configXml;
            this.fluxo = fluxo;
            lblMessage.Text = "Este colaborador fez hora extra?\n+ Será considerado hora extra serviços desenvolvidos entre as 22h e 6h de um dia útil, em finais de semana ou feriado. Por isso o BANESE pagará 0,5pts por turno adicional, ajustando para seu proporcional quando necessário.";
            SetCbbPartners();
            SetSprintList();
            ResizeParent(containerForm);
        }

        private readonly string all = "TODOS";
        private readonly ContainerForm containerForm;
        private readonly UtilDTO.NAVIGATION fluxo;
        private readonly ConfigXmlDTO configXml;
        private readonly List<SprintDevDTO> sprintsDevList = new List<SprintDevDTO>();
        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ContratoDTO selectedContract = new ContratoDTO();
        private ColaboradorDTO selectedDev = new ColaboradorDTO();
        private IntervaloDTO selectedRange = new IntervaloDTO();

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
        }


        #region CbbPartners_SelectedIndexChanged
        private void CbbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPartner = null;
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
                    foreach (var partner in configXml.Partners)
                    {
                        SetPartnersDevInLsbDevTeam(partner);
                    }
                }
            }
        }
        #endregion

        #region LsbDevTeam_SelectedIndexChanged
        private void LsbDevTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var contract in selectedPartner.Contracts)
            {
                if (contract.Collaborators.Any(c => c.Name == lsbDevTeam.SelectedIndex.ToString()))
                {
                    selectedContract = contract;
                    selectedDev = contract.Collaborators.Find(c => c.Name == lsbDevTeam.SelectedIndex.ToString());
                    break;
                }
            }

            txbAbsence.Text = selectedDev.AbsenceDays.ToString();
            txbExtraHour.Text = selectedDev.ExtraHours.ToString();
        }
        #endregion

        #region LsbSprints_SelectedIndexChanged
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSprints.SelectedIndex != -1)
            {
                selectedRange.Name = lsbSprints.SelectedItem.ToString();
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
        #endregion

        #region AUX
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void SetPartnersDevInLsbDevTeam(FornecedorDTO partner)
        {
            foreach (var contract in partner.Contracts)
            {
                foreach (var dev in contract.Collaborators)
                {
                    lsbDevTeam.Items.Add(dev.Name);
                }
            }
        }

        #region SetSprintList
        private void SetSprintList()
        {
            if (sprintsDevList != null)
            {
                foreach (var sprint in sprintsDevList)
                {
                    lsbSprints.Items.Add(sprint.Range.Name);
                }
            }
            else
            {
                if (sprintsSmList != null)
                {
                    foreach (var sprint in sprintsSmList)
                    {
                        lsbSprints.Items.Add(sprint.Range.Name);
                    }
                }
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

            txbResult.AppendText("Se as configurações de autor ou nome precisarem de ajuste, favor revisar o arquivo de configuração e começar o processo novamente.");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"Autor: {configXml.AuthorName}\n");
            txbResult.AppendText($"Área: {configXml.AreaName}\n");
            txbResult.AppendText($"Time: {configXml.TeamName}");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"O arquivo será gerado em: {outputDocPath}");
            txbResult.AppendText("\n===========\n");

            if (sprintsDevList != null)
            {
                txbResult.AppendText("\nSprints Dev");
                txbResult.AppendText("\n===========\n\n");
                foreach (var sprint in sprintsDevList)
                {
                    txbResult.AppendText(sprint.ToStringBuilder().ToString());
                }
            }

            if (sprintsSmList != null)
            {
                txbResult.AppendText("\nSprints SM");
                txbResult.AppendText("\n===========\n\n");
                foreach (var sprint in sprintsSmList)
                {
                    txbResult.AppendText(sprint.ToStringBuilder().ToString());
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
        private void BtnAddSprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (selectedPartner == null ||
                    selectedContract == null ||
                    selectedDev == null ||
                    string.IsNullOrEmpty(selectedRange.Name)
                    )
                {
                    throw new Exception("Ops, você precisa selecionar um fornecedor, um colaborador e /ou uma sprint\n;)");
                }

                var selectedDevSprint = sprintsDevList.Find(s => s.Range.Name == selectedRange.Name);
                sprintsDevList.Remove(selectedDevSprint);

                selectedDevSprint
                    .Contracts.Find(c => c.Name == selectedContract.Name)
                    .Collaborators
                        .Remove(selectedDev);

                selectedDev.AbsenceDays = Convert.ToInt32(txbAbsence.Text);
                selectedDev.ExtraHours = Convert.ToDouble(txbExtraHour.Text);

                selectedDevSprint
                    .Contracts.Find(c => c.Name == selectedContract.Name)
                    .Collaborators
                        .Add(selectedDev);
                sprintsDevList.Add(selectedDevSprint);
            }
            catch (Exception ex)
            {
                ShowLog(ex.Message);
            }
            ShowLog();
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
                //realizar os calculos e ajustar dados finais
                foreach (var sprint in sprintsDevList)
                {
                    int sprintDays = (sprint.Range.EndDate - sprint.Range.IniDate).Days - 3;
                    PrincipalTO.SetDevPresence(sprint.Contracts, sprintDays);
                    sprint.TeamSize = PrincipalTO.CalcTeamSize(sprint);
                }

                //chamar a geracao dos relatorios
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
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