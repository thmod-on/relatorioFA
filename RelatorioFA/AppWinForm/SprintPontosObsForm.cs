using System;
using System.Collections.Generic;
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
            SetScreenLayout(fluxo);
            SetSprints();
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

        private void BtnUpdateSprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbSprints.SelectedIndex < 0)
                {
                    throw new Exception("Ops, parece que você esqueceu de selecionar uma sprint\n;)");
                }

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
                    selectedSprint.AcceptedPointsExpenses = Convert.ToInt32(txbAcceptedPointsExpense.Text);
                    selectedSprint.AcceptedPointsInvestment = Convert.ToInt32(txbAcceptedPointsInvestment.Text);
                    selectedSprint.SmPoints = Convert.ToInt32(txbSmPoints.Text);
                    selectedSprint.Obs = Regex.Replace(txbObs.Text, @"\r\n?|\n", " ");
                    selectedSprint.CerimonialPoint = (UtilDTO.CERIMONIAL_POINT)cbbCerimonialPoint.SelectedItem;
                }

                ShowLog($"Dados da sprint {lsbSprints.SelectedItem} atualizados.");
                btnNextForm.Enabled = true;

                txbAcceptedPointsExpense.Text = "0";
                txbAcceptedPointsInvestment.Text = "0";
                txbSmPoints.Text = "0";
                txbObs.Clear();
                if (lsbSprints.SelectedIndex < lsbSprints.Items.Count - 1)
                {
                    lsbSprints.SelectedIndex += 1;
                }
                txbAcceptedPointsInvestment.Focus();
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }

        private void BtnPreviousForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new SprintBaseForm(containerForm, UtilDTO.NAVIGATION.VARIOS_RELATORIOS, sprintsDevList, sprintsSmList));
        }
        #endregion

        #region Eventos automaticos
        #region LsbSprints_SelectedIndexChanged
        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSprints.SelectedIndex >= 0)
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
        }
        #endregion

        #region TxbAcceptedPointsInvestment_KeyPress
        private void TxbAcceptedPointsInvestment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }
        #endregion

        #region TxbAcceptedPointsExpense_KeyPress
        private void TxbAcceptedPointsExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }
        #endregion

        #region TxbSmPoints_KeyPress
        private void TxbSmPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = UtilDTO.AllowOnlyNumbers_OnKeyPress(sender, e);
        }
        #endregion
        #endregion

        #region AUX
        #region SetCerimonialPointCombo
        private void SetCerimonialPointCombo()
        {
            cbbCerimonialPoint.DataSource = Enum.GetValues(typeof(UtilDTO.CERIMONIAL_POINT));
            cbbCerimonialPoint.SelectedIndex = 0;
        } 
        #endregion

        #region SetSprints
        private void SetSprints()
        {
            if (sprintsDevList != null)
            {
                foreach (var sprint in sprintsDevList)
                {
                    lsbSprints.Items.Add(sprint.Range.Name);
                }
            }
            else if (sprintsSmList != null)
            {
                foreach (var sprint in sprintsSmList)
                {
                    lsbSprints.Items.Add(sprint.Range.Name);
                }
            }
            lsbSprints.SelectedIndex = 0;
        }
        #endregion

        #region SetScreenLayout
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

            if (sprintsDevList != null)
            {
                txbResult.AppendText("Sprints Dev");
                txbResult.AppendText("\n===========\n");
                foreach (var sprint in sprintsDevList)
                {
                    txbResult.AppendText(sprint.ToStringBuilder().ToString());
                }
            }

            if (sprintsSmList != null)
            {
                txbResult.AppendText("\nSprints SM");
                txbResult.AppendText("\n===========\n");
                foreach (var sprint in sprintsSmList)
                {
                    txbResult.AppendText(sprint.ToStringBuilder().ToString());
                }
            }
            txbResult.Select(0, 0);
        }
        #endregion

        #endregion
    }
}
