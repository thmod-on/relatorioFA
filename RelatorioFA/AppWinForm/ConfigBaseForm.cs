using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RelatorioFA.DTO;
using RelatorioFA.Transacao;

namespace RelatorioFA.AppWinForm
{
    public partial class ConfigBaseForm : Form
    {
        public ConfigBaseForm(ContainerForm containerForm)
        {
            InitializeComponent();
            this.containerForm = containerForm;
            ResizeParent(containerForm);
            LoadConfig();
            
        }

        private readonly string rootFolder = UtilDTO.GetProjectRootFolder();
       
        public ConfigBaseForm(ContainerForm containerForm, ConfigXmlDTO config)
        {
            InitializeComponent();
            this.config = config;
            foreach (var partner in config.Partners)
            {
                lsbPartners.Items.Add(partner.Name);
            }

            txbAuthorName.Text = config.AuthorName;
            txbAreaName.Text = config.AreaName;
            txbTeamName.Text = config.TeamName;

            btnNextForm.Enabled = true;
            this.containerForm = containerForm;
            ResizeParent(containerForm);
            ShowLog("Seja bem vindo de volta.\n=)");
        }

        private ConfigXmlDTO config = new ConfigXmlDTO();
        string partnerLogoPath;
        private readonly ContainerForm containerForm = new ContainerForm();

        #region Eventos de Click
        #region BtnLogomarcaParceiro_Click
        private void BtnLogomarcaParceiro_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens Jpeg (*.jpg)|*.jpg|Imagens PNG (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    partnerLogoPath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        picBoxLogomarca.Load(partnerLogoPath);
                    }
                }
            }
        }
        #endregion

        #region BtnRemovePartner_Click
        private void BtnRemovePartner_Click(object sender, EventArgs e)
        {
            if (lsbPartners.SelectedItem == null)
            {
                txbResult.Text = "Por favor escolha um parceiro da lista para ser removido.";
            }
            else
            {
                var selectedPartner = config.Partners.Find(p => p.Name == lsbPartners.SelectedItem.ToString());
                config.Partners.Remove(selectedPartner);
                lsbPartners.Items.Remove(selectedPartner.Name);
                txbPartnerName.Clear();
                txbPartnerUstValue.Clear();
                picBoxLogomarca.Image = null;
                lsbPartners.SelectedItem = null;

                ShowLog("Parceiro removido\n=(");
            }
        } 
        #endregion

        #region BtnAdd_Click
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            config.AuthorName = txbAuthorName.Text;
            config.AreaName = txbAreaName.Text;
            config.TeamName = txbTeamName.Text;

            if (!string.IsNullOrEmpty(txbPartnerName.Text) &&
                !string.IsNullOrEmpty(txbPartnerUstValue.Text))
            {
                FornecedorDTO newPartner = new FornecedorDTO()
                {
                    Name = txbPartnerName.Text,
                    UstValue = Convert.ToDouble(txbPartnerUstValue.Text),
                    CaminhoLogomarca = partnerLogoPath
                };

                config.Partners.Remove(config.Partners.Find(p => p.Name == newPartner.Name));
                config.Partners.Add(newPartner);
                config.Partners.Sort((x, y) => x.Name.CompareTo(y.Name));

                lsbPartners.Items.Remove(newPartner.Name);
                lsbPartners.Items.Add(newPartner.Name);

                txbPartnerName.Clear();
                txbPartnerUstValue.Clear();
                picBoxLogomarca.Image = null;
                partnerLogoPath = string.Empty;
                txbPartnerName.Focus();
                btnNextForm.Enabled = true; 
            }

            ShowLog("Dados adicionados.");
        }
        #endregion

        #region BtnNextForm_Click
        private void BtnNextForm_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateConfigData();
                containerForm.AbrirForm(new ConfigContratoForm(containerForm, config));
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO. {ex.Message}";
            }
        }
        #endregion
        #endregion

        #region Eventos automáticos
        private void LoadConfig()
        {
            try
            {
                config = PrincipalTO.LoadConfig(rootFolder);

                txbAuthorName.Text = config.AuthorName;
                txbAreaName.Text = config.AreaName;
                txbTeamName.Text = config.TeamName;

                foreach (var partner in config.Partners)
                {
                    lsbPartners.Items.Add(partner.Name);
                }

                btnNextForm.Enabled = true;

                ShowLog("Parece que você tem um arquivo preconfigurado. Legal! Vamos editá-lo\n=]");
            }
            catch (FileNotFoundException)
            {
                txbResult.Text = $"Não encontrei um arquivo de configuração na pasta {rootFolder}. Espero que este seja o início de uma nova amizade\n;)";
            }
            catch (Exception ex)
            {
                txbResult.Text = ex.Message;
            }
        }

            private void LsbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbPartners.SelectedItem != null)
            {
                var selectedPartner = config.Partners.Find(p => p.Name == lsbPartners.SelectedItem.ToString());

                txbPartnerName.Text = selectedPartner.Name;
                txbPartnerUstValue.Text = selectedPartner.UstValue.ToString();
                if (!string.IsNullOrEmpty(selectedPartner.CaminhoLogomarca))
                {
                    picBoxLogomarca.Load(selectedPartner.CaminhoLogomarca);
                }
            }
        }

        private void TxbPartnerUstValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        } 
        #endregion

        #region AUX
        private void ShowLog(string message)
        {
            txbResult.Clear();

            if (!string.IsNullOrEmpty(message))
            {
                txbResult.AppendText(message);
                txbResult.AppendText("\n===========\n\n");
            }

            txbResult.AppendText($"Autor: {config.AuthorName}\n");
            txbResult.AppendText($"Área: {config.AreaName}\n");
            txbResult.AppendText($"Time: {config.TeamName}");

            foreach (var partner in config.Partners)
            {
                txbResult.AppendText($"\n\nParceiro: {partner.Name}\n");
                txbResult.AppendText($"   - Valor da UST: {partner.UstValue:C}\n");
                txbResult.AppendText($"   - Logomarca: {partner.CaminhoLogomarca}");
            }

            txbResult.Select(0, 0);
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void ValidateConfigData()
        {
            if (string.IsNullOrEmpty(config.AuthorName) ||
                string.IsNullOrEmpty(config.AreaName) ||
                string.IsNullOrEmpty(config.TeamName))
            {
                throw new Exception("Parece que você esqueceu algo. Preciso saber:\n- Seu nome;\n- A área que está alocado;\n- Qual time come seu juízo\n\n * Se já preencheu este dados, aperte no botão 'Adicionar / Atualizar'\n\n;)");
            }

            if (config.Partners.Count < 1)
            {
                throw new Exception("Hum... Parece ue você não cadastrou nenhum fornecedor ainda. Precisamos destes dados para os próximos passos.\n^^'");
            }
        }

        private void ValidateNumericalInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
