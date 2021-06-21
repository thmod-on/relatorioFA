using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RelatorioFA.DTO;

namespace RelatorioFA.AppWinForm
{
    public partial class SprintPontosObsForm : Form
    {
        public SprintPontosObsForm(ContainerForm containerForm, ConfigDocDTO config, UtilDTO.NAVIGATION fluxo, List<SprintDevDTO> sprintDevList = null, List<SprintDevOpsDTO> sprintDevOpsList = null)
        {
            InitializeComponent();
            SetSprintsList(sprintList);
            SetCerimonialPointCombo();
            this.containerForm = containerForm;
            this.sprintList = sprintList;
            this.config = config;
            ResizeParent(containerForm);
            SetScreenLayout(fluxo);
        }

        private readonly ContainerForm containerForm;
        private readonly List<SprintBaseDTO> sprintList;
        private readonly ConfigDocDTO config;
        private SprintBaseDTO selectedSprint = new SprintBaseDTO();

        #region Eventos de Click
        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new SprintAbsenceHourForm(containerForm, config, sprintList));
        }

        private void BtnAddSprint_Click(object sender, EventArgs e)
        {
            try
            {
                selectedSprint.AcceptedPointsExpenses = Convert.ToInt32(txbAcceptedPointsExpense.Text);
                selectedSprint.AcceptedPointsInvestment = Convert.ToInt32(txbAcceptedPointsInvestment.Text);
                selectedSprint.SmPoints = Convert.ToInt32(txbSmPoints.Text);
                selectedSprint.Obs = Regex.Replace(txbObs.Text, @"\r\n?|\n", " ");
                selectedSprint.CerimonialPoint = (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedItem;
                ShowLog($"Dados da sprint {selectedSprint.Range.Name} atualizados.");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro não tratado  ou previsto.\n\n{ex.Message}";
            }
        }

        private void BtnPreviousForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new SprintBaseForm(containerForm, UtilDTO.NAVIGATION.VARIOS_RELATORIOS));
        }
        #endregion

        #region Eventos automaticos
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSprints.SelectedItem != null)
            {
                selectedSprint = sprintList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                txbAcceptedPointsExpense.Text = selectedSprint.AcceptedPointsExpenses.ToString();
                txbAcceptedPointsInvestment.Text = selectedSprint.AcceptedPointsInvestment.ToString();
                txbSmPoints.Text = selectedSprint.SmPoints.ToString();
                txbObs.Text = string.IsNullOrEmpty(selectedSprint.Obs) ? "" : selectedSprint.Obs;
                cbbCerimonialPoint.SelectedItem = selectedSprint.CerimonialPoint;
            }
            ShowLog();
        }
        #endregion

        #region AUX
        private void SetSprintsList(List<SprintBaseDTO> sprintList)
        {
            foreach (var sprint in sprintList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
            }
        }

        private void SetCerimonialPointCombo()
        {
            cbbCerimonialPoint.DataSource = Enum.GetValues(typeof(UtilDTO.CERIMONIAL_POINT));
            cbbCerimonialPoint.SelectedIndex = 0;
        }

        private void SetScreenLayout(UtilDTO.NAVIGATION fluxo)
        {
            switch (fluxo)
            {
                case UtilDTO.NAVIGATION.DEVOPS:
                    break;
                case UtilDTO.NAVIGATION.VARIOS_RELATORIOS:
                    lblScreen.Text = "Tela 2/??";
                    break;
                default:
                    break;
            }
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void ShowLog(string message = "")
        {
            txbResult.Clear();

            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            foreach (var sprint in sprintList)
            {
                txbResult.AppendText(sprint.Range.Name);
                txbResult.AppendText("\n");
                txbResult.AppendText($"   - Data inicial: {sprint.Range.IniDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Data final: {sprint.Range.EndDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Imagem: {sprint.ImagePath}\n");
                txbResult.AppendText($"   - Pts. aceitos INV: {sprint.AcceptedPointsInvestment}\n");
                txbResult.AppendText($"   - Pts. aceitos DES: {sprint.AcceptedPointsExpenses}\n");
                txbResult.AppendText($"   - Pt. de cerimônia: {sprint.CerimonialPoint}\n");
                txbResult.AppendText($"   - PTs. do SM: {sprint.SmPoints}\n");
                txbResult.AppendText($"   - OBS.: {sprint.Obs}\n\n");
            }
        }
        #endregion
    }
}
