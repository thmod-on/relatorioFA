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
        private SprintSmDTO selectedSprint = new SprintSmDTO();
        private IntervaloDTO selectedRange = new IntervaloDTO();

        #region Aux
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void SelectPartnerAndContract()
        {
            selectedPartner = new FornecedorDTO();
            //assumindo que tera apenas um contrato deste tipo
            foreach (var partner in configXml.Partners)
            {
                if (partner.Contracts.Any(contract => contract.Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString()))
                {
                    selectedPartner = partner;
                    break;
                }
            }

            foreach (var sprintSm in sprintsSmList)
            {
                if (sprintSm.Contracts.Count < 1)
                {
                    ContratoDTO newContract = new ContratoDTO();
                    newContract = selectedPartner.Contracts.Find(c => c.Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString());
                    sprintSm.Contracts.Add(newContract);
                    //sprintsSmList.Find(sprint => sprint.Range.Name == selectedRange.Name).Contracts.Add(newContract);


                    //foreach (var contract in selectedPartner.Contracts)
                    //{
                    //    if (contract.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString() ||
                    //        contract.Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    //    {
                    //        ContratoDTO smContract = new ContratoDTO()
                    //        {
                    //            Factor = contract.Factor,
                    //            HourValue = contract.HourValue,
                    //            Name = contract.Name,
                    //            NumeroSAP = contract.NumeroSAP
                    //        };
                    //        foreach (var sm in contract.Collaborators)
                    //        {
                    //            smContract.Collaborators.Add(sm);
                    //        }
                            
                    //    }
                    //}
                    
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

        private void LsbSprints_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSprint = sprintsSmList.Find(sprint => sprint.Range.Name == lsbSprints.SelectedItem.ToString());
            txbAcceptedPointsTeam1.Text = selectedSprint.AcceptedPointsTeam1.ToString();
            txbAcceptedPointsTeam2.Text = selectedSprint.AcceptedPointsTeam2.ToString();
            txbTeamSize1.Text = selectedSprint.DevTeamSize1.ToString();
            txbTeamSize2.Text = selectedSprint.DevTeamSize2.ToString();
            txbObs.Text = selectedSprint.Obs;
            selectedRange = selectedSprint.Range;
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
                PrincipalTO.CalcSmSprintData(sprintsSmList);
                PrincipalTO.CreateSmDoc(configXml, selectedPartner, outputDocPath, sprintsSmList);
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