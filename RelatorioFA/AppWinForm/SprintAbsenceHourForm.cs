using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RelatorioFA.DTO;

namespace RelatorioFA.AppWinForm
{
    public partial class SprintAbsenceHourForm : Form
    {
        public SprintAbsenceHourForm(ContainerForm containerForm, ConfigXmlDTO config, List<SprintBaseDTO> sprintsList)
        {
            InitializeComponent();
            lblMessage.Text = "Este colaborador fez hora extra?\n+ Será considerado hora exxtra serviços desenvolvidos entre as 22h e 6h de um dia útil, em finais de seman ou feriado. Por isso o BANESE pagará 0,5pts por turno adicional, ajustando para seu proporcional quando necessário.";
            this.config = config;
            this.sprintsList = sprintsList;
            SetCbbPartners();
            ResizeParent(containerForm);
        }

        private readonly ConfigXmlDTO config;
        private readonly List<SprintBaseDTO> sprintsList;
        private string outputDocPath = UtilDTO.GetProjectRootFolder();
        private FornecedorDTO selectedPartner = new FornecedorDTO();
        private ColaboradorDTO selectedDev = new ColaboradorDTO();
        
        #region Eventos automaticos
        private void SetCbbPartners()
        {
            cbbPartners.Items.Add("TODOS");
            foreach (var partner in config.Partners)
            {
                cbbPartners.Items.Add(partner.Name);
            }
            cbbPartners.SelectedIndex = 0;
        }
        #endregion

        #region AUX
        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void SetPartnersDevInLsbDevTeam(FornecedorDTO partner)
        {
            lsbDevTeam.Items.Clear();
            foreach (var contract in partner.Contracts)
            {
                foreach (var dev in contract.Collaborators)
                {
                    lsbDevTeam.Items.Add(dev.Name);
                }
            }
        }

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
            txbResult.AppendText($"Autor: {config.AuthorName}\n");
            txbResult.AppendText($"Área: {config.AreaName}\n");
            txbResult.AppendText($"Time: {config.TeamName}");
            txbResult.AppendText("\n===========\n\n");
            txbResult.AppendText($"O arquivo será gerado em: {outputDocPath}");
            txbResult.AppendText("\n===========\n\n");

            foreach (var sprint in sprintsList)
            {
                txbResult.AppendText(sprint.Range.Name);
                txbResult.AppendText("\n");
                txbResult.AppendText($"   - Data inicial: {sprint.Range.IniDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Data final: {sprint.Range.EndDate:dd/MM/yyyy}\n");
                txbResult.AppendText($"   - Imagem: {sprint.ImagePath}\n");
                txbResult.AppendText($"   - OBS.: {sprint.Obs}\n");

                //fornecedor selecionado
                if (selectedPartner != null)
                {
                    PrintPartnerData(selectedPartner);
                }
                else//todos fornecedores
                {
                    foreach (var partner in config.Partners)
                    {
                        PrintPartnerData(partner);
                    }
                }
            }
            txbResult.Select(0, 0);
        }

        private void PrintPartnerData(FornecedorDTO partner)
        {
            txbResult.AppendText($"Fornecedor: {partner.Name}\n");
            txbResult.AppendText($"Logomarca: {partner.CaminhoLogomarca}\n");
            txbResult.AppendText($"UST: R${partner.UstValue}\n");

            foreach (var contract in partner.Contracts)
            {
                txbResult.AppendText($"   - Número SAP: {contract.NumeroSAP}\n");
                txbResult.AppendText($"   - Tipo: {contract.Name}\n");
                txbResult.AppendText($"   - Fator de ajuste: {contract.Factor}\n");
                txbResult.AppendText($"   - Devs:\n");
                foreach (var dev in contract.Collaborators)
                {
                    txbResult.AppendText($"      > Nome: {dev.Name}\n");
                    //txbResult.AppendText($"      > Ausências: {sprintsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString()).DevAbsence[dev.Name]}\n");
                    //txbResult.AppendText($"      > Horas extras: {sprintsList.Find(s => s.Range.Name == lsbSprints.SelectedItem.ToString()).DevExtraHour[dev.Name]}\n");
                }
            }
        }
        #endregion
        #endregion

        #region Eventos de Click
        private void BtnPreviousForm_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnAddSprint_Click(object sender, System.EventArgs e)
        {

        }

        #region BtnOpenDestinationFolder_Click
        private void BtnOpenDestinationFolder_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(outputDocPath);
        } 
        #endregion

        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {

        }

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

        #region CbbPartners_SelectedIndexChanged
        private void CbbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbbPartners.SelectedItem.ToString()))
            {
                selectedPartner = config.Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString());
                if (selectedPartner != null)
                {
                    SetPartnersDevInLsbDevTeam(selectedPartner);
                }
                else
                {
                    foreach (var partner in config.Partners)
                    {
                        SetPartnersDevInLsbDevTeam(partner);
                    }
                }
            }
        }
        #endregion

        #endregion

        private void LsbDevTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (var contract in selectedPartner.Contracts)
            //{
            //    if (contract.Collaborators.fin)
            //    {

            //    }
            //}

            //selectedDev = config
            //                .Partners.Find(p => p.Name == cbbPartners.SelectedItem.ToString())
            //                .Contracts
        }
    }
}