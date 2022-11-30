using RelatorioFA.DTO;
using RelatorioFA.Transacao;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RelatorioFA.AppWinForm
{
    public partial class SprintSmCompartilhadoPontos : Form
    {
        public SprintSmCompartilhadoPontos(ContainerForm containerForm, ConfigXmlDTO configXml, UtilDTO.NAVIGATION fluxo, List<SprintSmDTO> sprintSmList)
        {
            InitializeComponent();
            ResizeParent(containerForm);
            this.sprintsSmList = sprintSmList;
            this.containerForm = containerForm;
            this.fluxo = fluxo;
            this.configXml = configXml;
            txbResult.Text = $"O relatório será gerado em {outputDocPath}";
            SelectPartnerAndContract();
            LoadAddedSprints();
            txbAcceptedPointsTeam1.Select();
        }

        private readonly List<SprintSmDTO> sprintsSmList = new List<SprintSmDTO>();
        private readonly ContainerForm containerForm;
        private readonly UtilDTO.NAVIGATION fluxo;
        private readonly ConfigXmlDTO configXml;
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private FornecedorDTO selectedPartner;
        private ContratoDTO selectedContract;
        private SprintSmDTO selectedSprint = new SprintSmDTO();
        
        #region Aux
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void SelectPartnerAndContract()
        {
            selectedPartner = new FornecedorDTO();
            selectedContract = new ContratoDTO();

            //assumindo que tera apenas um contrato deste tipo
            selectedPartner =
                (from partner in configXml.Partners
                 from cont in partner.Contracts
                 from batch in cont.Batches
                 where batch.Name == UtilDTO.BATCHS.SM.ToString()
                 from role in batch.Roles
                 where role.Name == UtilDTO.ROLES.SM_MEDIA.ToString()
                 select  partner).First();

            selectedContract =
                (from cont in selectedPartner.Contracts
                 from batch in cont.Batches
                 where batch.Name == UtilDTO.BATCHS.SM.ToString()
                 from role in batch.Roles
                 where role.Name == UtilDTO.ROLES.SM_MEDIA.ToString()
                 select cont).First();

            foreach (var sprintSm in sprintsSmList)
            {
                if (sprintSm.Contracts.Count < 1)
                {
                    ContratoDTO newContract = new ContratoDTO();
                    newContract = selectedContract;
                    sprintSm.Contracts.Add(newContract);
                }
            }
        }

        private void LoadAddedSprints()
        {
            foreach (var sprint in sprintsSmList)
            {
                lsbSprints.Items.Add(sprint.Range.Name);
            }
            lsbSprints.SelectedIndex = 0;
        }

        private void BlockScreen(bool v)
        {
            txbAcceptedPointsTeam1.Enabled = !v;
            txbAcceptedPointsTeam2.Enabled = !v;
            txbTeamSize1.Enabled = !v;
            txbTeamSize2.Enabled = !v;
            txbObs.Enabled = !v;
            btnPreviousForm.Enabled = !v;
            btnSetOutputDocPath.Enabled = !v;
            btnGenerate.Enabled = !v;
            btnOpenDestinationFolder.Enabled = !v;
        }

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

            foreach (var sprint in sprintsSmList)
            {
                txbResult.AppendText(sprint.ToStringBuilder().ToString());
                txbResult.AppendText("\n");
            }
            txbResult.Select(0, 0);
        }
        #endregion

        #region Eventos automáticos
        private void TxbAcceptedPointsTeam1_Leave(object sender, EventArgs e)
        {
            selectedSprint.AcceptedPointsTeam1 = Convert.ToDouble(txbAcceptedPointsTeam1.Text);
            ShowLog();
        }

        private void TxbAcceptedPointsTeam2_Leave(object sender, EventArgs e)
        {
            selectedSprint.AcceptedPointsTeam2 = Convert.ToDouble(txbAcceptedPointsTeam2.Text);
            ShowLog();
        }

        private void TxbTeamSize1_Leave(object sender, EventArgs e)
        {
            selectedSprint.DevTeamSize1 = Convert.ToDouble(txbTeamSize1.Text);
            ShowLog();
        }

        private void TxbTeamSize2_Leave(object sender, EventArgs e)
        {
            selectedSprint.DevTeamSize2 = Convert.ToDouble(txbTeamSize2.Text);
            ShowLog();
        }

        private void TxbObs_Leave(object sender, EventArgs e)
        {
            selectedSprint.Obs = txbObs.Text;
            ShowLog();
        }

        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSprint = sprintsSmList.Find(sprint => sprint.Range.Name == lsbSprints.SelectedItem.ToString());
            txbAcceptedPointsTeam1.Text = selectedSprint.AcceptedPointsTeam1.ToString();
            txbAcceptedPointsTeam2.Text = selectedSprint.AcceptedPointsTeam2.ToString();
            txbTeamSize1.Text = selectedSprint.DevTeamSize1.ToString();
            txbTeamSize2.Text = selectedSprint.DevTeamSize2.ToString();
            txbObs.Text = selectedSprint.Obs;
        }
        #endregion

        #region Eventos de Click
        private void BtnPreviousForm_Click(object sender, EventArgs e)
        {
            containerForm.AbrirForm(new SprintBaseForm(containerForm, fluxo, sprintsSmList));
        }

        private void BtnSetOutputDocPath_Click(object sender, EventArgs e)
        {
            outputDocPath = UtilWinForm.SetOutputDocPath();
            txbResult.Text = $"Caminho de geração do relatório alterado para {outputDocPath}";
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            txbResult.Text = "Processando...";
            BlockScreen(true);
            try
            {
                //Assumindo que teremos apenas um SM_MEDIA no contrato
                double factor = (
                    from batch in selectedContract.Batches
                    where batch.Name == UtilDTO.BATCHS.SM.ToString()
                    from role in batch.Roles
                    where role.Name == UtilDTO.ROLES.SM_MEDIA.ToString()
                    select role.Factor).First();


                PrincipalTO.CalcSmSprintData(sprintsSmList, factor);
                PrincipalTO.CreateSmDoc(configXml, selectedPartner, selectedContract, outputDocPath, sprintsSmList);
                txbResult.Text = $"Relatório gerado na pasta {outputDocPath}";
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Falha ao gerar arquivo. {ex.Message}";
            }
            finally
            {
                BlockScreen(false);
            }
        }

        private void BtnOpenDestinationFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        }
        #endregion
    }
}