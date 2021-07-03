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
        public SprintPontosObsForm(ContainerForm containerForm, ConfigXmlDTO configXml, UtilDTO.NAVIGATION fluxo, List<SprintDevDTO> sprintsDevList = null, List<SprintSmDTO> sprintsSmList = null)
        {
            InitializeComponent();
            this.sprintsDevList = sprintsDevList;
            this.sprintsSmList = sprintsSmList;
            SetCerimonialPointCombo();
            this.containerForm = containerForm;
            this.configXml = configXml;
            this.fluxo = fluxo;
            ResizeParent(containerForm);
            SetScreenLayout(fluxo);
        }

        private readonly UtilDTO.NAVIGATION fluxo;
        private readonly ContainerForm containerForm;
        private readonly List<SprintDevDTO> sprintsDevList = new List<SprintDevDTO>();
        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();
        private readonly ConfigXmlDTO configXml;

        #region Eventos de Click
        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new SprintAbsenceHourForm(containerForm, configXml, fluxo, sprintsDevList, sprintsSmList));
        }

        private void BtnAddSprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (sprintsDevList != null)
                {
                    var selectedSprint = sprintsDevList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                    selectedSprint.AcceptedPointsExpenses = Convert.ToInt32(txbAcceptedPointsExpense.Text);
                    selectedSprint.AcceptedPointsInvestment = Convert.ToInt32(txbAcceptedPointsInvestment.Text);
                    selectedSprint.Obs = Regex.Replace(txbObs.Text, @"\r\n?|\n", " ");
                    selectedSprint.CerimonialPoint = (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedItem;
                }

                if (sprintsSmList != null)
                {
                    var selectedSprint = sprintsSmList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                    selectedSprint.SmPoints = Convert.ToInt32(txbSmPoints.Text);
                    selectedSprint.Obs = Regex.Replace(txbObs.Text, @"\r\n?|\n", " ");
                    selectedSprint.CerimonialPoint = (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedItem;
                }

                ShowLog($"Dados da sprint {lsbSprints.SelectedItem} atualizados.");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro não tratado ou previsto.\n\n{ex.Message}";
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
            txbAcceptedPointsExpense.Text = "0";
            txbAcceptedPointsInvestment.Text = "0";
            txbSmPoints.Text = "0";
            txbObs.Clear();
            cbbCerimonialPoint.SelectedIndex = 0;

            if (sprintsDevList != null)
            {
                var selectedSprint = sprintsDevList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                txbAcceptedPointsExpense.Text = selectedSprint.AcceptedPointsExpenses.ToString();
                txbAcceptedPointsInvestment.Text = selectedSprint.AcceptedPointsInvestment.ToString();
                txbObs.Text = string.IsNullOrEmpty(selectedSprint.Obs) ? "" : selectedSprint.Obs;
                cbbCerimonialPoint.SelectedItem = selectedSprint.CerimonialPoint;
            }

            if (sprintsSmList != null)
            {
                var selectedSprint = sprintsSmList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString());
                txbSmPoints.Text = selectedSprint.SmPoints.ToString();
                txbObs.Text = string.IsNullOrEmpty(selectedSprint.Obs) ? "" : selectedSprint.Obs;
                cbbCerimonialPoint.SelectedItem = selectedSprint.CerimonialPoint;
            }

            ShowLog();
        }
        #endregion

        #region AUX
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
                    lblScreen.Text = "Tela 2/3";
                    break;
                default:
                    break;
            }
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new Size(this.Width, this.Height + 20);
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

            if (sprintsDevList != null)
            {
                txbResult.AppendText("Sprints Dev");
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
    }
}
