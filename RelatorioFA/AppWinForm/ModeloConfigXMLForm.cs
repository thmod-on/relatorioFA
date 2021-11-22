using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RelatorioFA.Transacao;
using RelatorioFA.DTO;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace RelatorioFA.AppWinForm
{
    public partial class ModeloConfigXMLForm : Form
    {
        private string arquivoImagemLogomarca;
        private const string NOVO = "NOVO";

        public ModeloConfigXMLForm(Form parentForm)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            LoadConfigData();
            LoadContractType();
            cbbPartner.Items.Add(NOVO);
            cbbPartner.SelectedIndex = 0;
        }

        public ModeloConfigXMLForm()
        {
            InitializeComponent();
            LoadConfigData();
            LoadContractType();
            cbbPartner.Items.Add(NOVO);
            cbbPartner.SelectedIndex = 0;
        }

        private string outputPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        const string outputName = "RelatorioFA.xml";
        private ConfigXmlDTO config = new ConfigXmlDTO();

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 30);
        }

        #region LoadContractType
        private void LoadContractType()
        {
            foreach (var contractType in Enum.GetValues(typeof(UtilDTO.CONTRACTS)))
            {

                if (contractType.ToString() != UtilDTO.CONTRACTS.HOUSE.ToString())
                {
                    cbbContractType.Items.Add(contractType);
                }
            }
            cbbContractType.SelectedIndex = 0;
        } 
        #endregion

        private void LoadConfigData()
        {
            lblOutputPath.Text = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            FornecedorDTO fakePartner = new FornecedorDTO()
            {
                Name = UtilDTO.CONTRACTS.HOUSE.ToString()
            };
            config.Partners.Add(fakePartner);

            ContratoDTO fakeContract = new ContratoDTO()
            {
                Name = UtilDTO.CONTRACTS.HOUSE.ToString()
            };
            config.Partners.Find(x => x.Name == UtilDTO.CONTRACTS.HOUSE.ToString()).Contracts.Add(fakeContract);
            txbContractHourValue.Text = "0";
        }

        #region eventos de click
        #region BtnOutputPath_Click
        private void BtnOutputPath_Click(object sender, EventArgs e)
        {
            txbResult.Clear();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            try
            {
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblOutputPath.Text = folderDlg.SelectedPath;
                    lblOutputPath.Visible = true;

                    outputPath = folderDlg.SelectedPath;

                    btnLoad.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro durante escolha do local de saída do arquivo XML. Mensagem:\n{ex.Message}\n\nPilha de erro:\n{ex.StackTrace}";
            }
        }
        #endregion

        #region BtnLoad_Click
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string filePath;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "XML (*.XML)|*.XML";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        config = PrincipalTO.LoadConfig(filePath);
                        UpdatePartnersCombo();
                        UpdateContractsCombo();
                        txbAuthor.Text = config.AuthorName;
                        txbTeamName.Text = config.TeamName;
                        PrintUserLog("Arquivo de configuração carregado.");
                    }
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO\n\n{ex.Message}\n\n{ex.InnerException.Message}";
            }
        } 
        #endregion

        #region BtnGenerateFilled_Click
        private void BtnGenerateFilled_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFieldsToGenerateDoc();
                Processing(true);
                config.AuthorName = txbAuthor.Text;
                config.TeamName = txbTeamName.Text;
                PrincipalTO.GenerateConfigXmlFile(outputPath, outputName, config);
                Processing(false);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro durante geração do arquivo XML. Mensagem:\n{ex.Message}\n\nPilha de erro:\n{ex.StackTrace}";
            }
        } 
        #endregion

        #region BtnAddPartner_Click
        private void BtnAddPartner_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePartnerData();
                FornecedorDTO partner = new FornecedorDTO()
                {
                    Name = txbPartnerName.Text,
                    UstValue = Convert.ToDouble(txbPartnerUstValue.Text)
                };
                partner.CaminhoLogomarca = SalvarImagemParceiro(partner.Name);

                if (cbbPartner.SelectedItem.ToString() != NOVO)
                {
                    config.Partners.Remove(config.Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString()));
                }
                config.Partners.Add(partner);

                picBoxLogomarca.Image = null;
                arquivoImagemLogomarca = null;
                txbPartnerName.Clear();
                txbPartnerUstValue.Clear();
                UpdatePartnersCombo();
                PrintUserLog($"Parceiro '{partner.Name}' adicionado.");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro não tratato. Mensagem:\n{ex.Message}\n\nPilha:\n{ex.StackTrace}";
            }
        }
        #endregion

        #region SalvarImagemParceiro
        private string SalvarImagemParceiro(string nomeParceiro)
        {
            if (arquivoImagemLogomarca != null)
            {
                try
                {
                    nomeParceiro = nomeParceiro.Trim().Replace(" ", "_");

                    FileInfo fileInfoImagem = new FileInfo(arquivoImagemLogomarca);
                    FileInfo fileInfoExecutavel = new FileInfo(Application.ExecutablePath);

                    string pathDestino = $"{fileInfoExecutavel.DirectoryName}\\imagens\\";

                    if (!Directory.Exists(pathDestino))
                        Directory.CreateDirectory(pathDestino);

                    pathDestino = $"{pathDestino}{nomeParceiro}{fileInfoImagem.Extension}";
                    fileInfoImagem.CopyTo(pathDestino, true);

                    return pathDestino;
                }
                catch (PathTooLongException)
                {
                    throw new PathTooLongException("O caminho para salvar a imagem é muito longo. Favor escolher outra pasta destino para a logomarca do parceiro");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return "";
        } 
        #endregion

        #region BtnAddContract_Click
        private void BtnAddContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbContract.SelectedValue.ToString() == NOVO)
                {
                    ValidateContractData(); 
                }

                ContratoDTO newContract = new ContratoDTO()
                {
                    Name = cbbContractType.SelectedItem.ToString(),
                    Factor = Convert.ToDouble(txbContractFactor.Text)
                };

                if (txbContractHourValue.Text.Trim() != string.Empty)
                {
                    newContract.HourValue = Convert.ToDouble(txbContractHourValue.Text);
                }

                if (cbbContract.SelectedValue.ToString() != NOVO &&
                    cbbContract.SelectedValue.ToString() != UtilDTO.CONTRACTS.HOUSE.ToString())
                {
                    var oldContract = config
                        .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                        .Contracts.Find(c => c.Name == cbbContract.SelectedValue.ToString());

                    config
                        .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                        .Contracts
                        .Remove(oldContract);
                }

                config.Partners
                    .Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts
                    .Add(newContract);

                UpdateContractsCombo();
                //txbContractHourValue.Clear();
                //txbContractFactor.Clear();
                PrintUserLog($"Contrato '{newContract.Name}' adicionado ao parceiro '{cbbPartner.SelectedItem}'");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao associar tipo de contrato ao fornecedor. Mensagem:\n{ex.Message}";
            }
        }
        #endregion

        #region BtnAddDev_Click
        private void BtnAddDev_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateDevData();
                ColaboradorDTO newDev = new ColaboradorDTO()
                {
                    Name = txbDevName.Text,
                    WorksHalfDay = ckbHalf.Checked
                };

                if (cbbDevs.SelectedItem.ToString() == NOVO)
                {
                    if (cbbContract.SelectedValue.ToString() == UtilDTO.CONTRACTS.HOUSE.ToString())
                    {
                        config.BaneseDes.Add(newDev);
                    }
                    else
                    {
                        config.Partners
                                     .Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                                     .Contracts
                                         .Find(x => x.Name == cbbContract.SelectedValue.ToString())
                                         .Collaborators
                                            .Add(newDev);
                    }
                }
                else
                {
                    var oldDevData = config.Partners
                               .Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                               .Contracts
                                   .Find(x => x.Name == cbbContract.SelectedValue.ToString())
                                   .Collaborators
                                   .Find(dev => dev.Name == cbbDevs.SelectedItem.ToString());

                    var contract = config.Partners
                                     .Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                                     .Contracts
                                         .Find(x => x.Name == cbbContract.SelectedValue.ToString());

                    contract.Collaborators.Remove(oldDevData);
                    contract.Collaborators.Add(newDev);
                }

                txbDevName.Clear();
                UpdateDevsCombo();
                btnGenerateFilled.Enabled = true;
                PrintUserLog($"Desenvolvedor '{newDev.Name}' adicionado ao contrato '{cbbContract.SelectedValue}' do fornecedor '{cbbPartner.SelectedItem}'");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro não tratado. Mensagem:\n{ex.Message}\n\nPilha:\n{ex.StackTrace}";
            }
        }
        #endregion

        #region BtnOpenFile_Click
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                var file = Path.Combine(outputPath, outputName);
                Process.Start(file);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao abrir o arquivo solicitado. Mensagem:\n{ex.Message}\n\nPilha:\n{ex.StackTrace}";
            }
        }
        #endregion

        #region BtnLogomarcaParceiro_Click
        private void BtnLogomarcaParceiro_Click(object sender, EventArgs e)
        {
            string filePath = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens Jpeg (*.jpg)|*.jpg|Imagens PNG (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        picBoxLogomarca.Load(filePath);
                    }
                }
            }
            arquivoImagemLogomarca = filePath;
        } 
        #endregion
        #endregion

        private void UpdatePartnersCombo()
        {
            cbbPartner.Enabled = true;
            cbbPartner.Items.Clear();
            cbbPartner.Items.Add(NOVO);
            foreach (var partner in config.Partners)
            {
                if (partner.Name != UtilDTO.CONTRACTS.HOUSE.ToString())
                {
                    cbbPartner.Items.Add(partner.Name);
                }
            }
            cbbPartner.SelectedIndex = cbbPartner.Items.Count - 1;
            EnableContractFields();
        }

        private void UpdateContractsCombo()
        {
            cbbContract.DataSource = null;

            Dictionary<string, string> comboItens = new Dictionary<string, string>
            {
                { NOVO, NOVO + " - " +  cbbPartner.SelectedItem.ToString()},
                { UtilDTO.CONTRACTS.HOUSE.ToString(), UtilDTO.CONTRACTS.HOUSE.ToString() }
            };
            if (config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts.Count > 0)
            {
                foreach (var contract in config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts)
                {
                    comboItens.Add(contract.Name, cbbPartner.SelectedItem.ToString() + " - " + contract.Name);
                }
            }
            else
            {
                cbbContract.Enabled = false;
                txbDevName.Enabled = false;
                btnAddDev.Enabled = false;
            }
            cbbContract.DisplayMember = "Value";
            cbbContract.ValueMember = "Key";
            cbbContract.DataSource = new BindingSource(comboItens, null);
            cbbContract.SelectedIndex = cbbContract.Items.Count > 2 ? cbbContract.Items.Count - 1 : 0;
            if (config.Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString()).Contracts.Count > 0)
            {
                EnableDevFields(); 
            }
        }

        private void UpdateDevsCombo()
        {
            cbbDevs.Items.Clear();
            cbbDevs.Items.Add(NOVO);
            List<ColaboradorDTO> colaboradores = new List<ColaboradorDTO>();
            if (cbbContract.SelectedValue.ToString() == UtilDTO.CONTRACTS.HOUSE.ToString())
            {
                colaboradores = config.BaneseDes;
            }
            else
            {
                colaboradores = config
                    .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                    .Contracts.Find(c => c.Name == (cbbContract.SelectedValue.ToString()))
                    .Collaborators; 
            }
            if (colaboradores.Count > 0)
            {
                foreach (var col in colaboradores)
                {
                    cbbDevs.Items.Add(col.Name);
                }
            }
            cbbDevs.SelectedIndex = 0;
        }

        private void EnableDevFields()
        {
            cbbDevs.Enabled = true;
            txbDevName.Enabled = true;
            btnAddDev.Enabled = true;
        }

        private void EnableContractFields()
        {
            cbbContract.Enabled = true;
            //txbContractHourValue.Enabled = true;
            cbbContractType.Enabled = true;
            txbContractFactor.Enabled = true;
            btnAddContract.Enabled = true;
        }

        #region KeyPress
        private void TxbUstValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        }

        private void TxbContractHourValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        }

        private void TxbContractFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericalInput(sender, e);
        } 
        #endregion

        #region Validações
        private void ValidatePartnerData()
        {
            if (txbPartnerName.Text.Trim() == string.Empty || txbPartnerUstValue.Text.Trim() == string.Empty)
            {
                throw new Exception("Todos os campos do parceiro (região 1) são de preenchimento obrigatório");
            }
        }

        private void ValidateDevData()
        {
            if (txbDevName.Text == string.Empty)
            {
                throw new Exception("Nome do colaborador é obrigatório");
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

        private void ValidateFieldsToGenerateDoc()
        {
            if (txbAuthor.Text.Trim() == string.Empty || txbTeamName.Text.Trim() == string.Empty)
            {
                throw new Exception("O nome do autor e do time são campos obrigatórios.");
            }

            foreach (var partner in config.Partners)
            {
                foreach (var contract in partner.Contracts)
                {
                    if (contract.Name != UtilDTO.CONTRACTS.HOUSE.ToString() && contract.Collaborators.Count < 1)
                    {
                        throw new Exception("Ao menos um colaborador deve ser aadicionado a cada contrato.");
                    }
                }
            }
        }

        private void ValidateContractData()
        {
            if (txbContractFactor.Text == string.Empty)
            {
                txbContractFactor.Focus();
                throw new Exception("Fator de ajuste precisa ser preenchido.");
            }

            if (Convert.ToDouble(txbContractFactor.Text) == 0)
            {
                txbContractFactor.Focus();
                throw new Exception("Fator de ajuste não pode ser zero.");
            }

            if (config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts.Any(x => x.Name == cbbContractType.SelectedItem.ToString()))
            {
                throw new Exception("Tipo de contrato já associado ao parceiro");
            }

            if ((UtilDTO.CONTRACTS)cbbContractType.SelectedItem == UtilDTO.CONTRACTS.SM_MEDIA)
            {
                throw new Exception("Relatório de SM ainda não implementado");
            }
        }
        #endregion

        #region SelectedIndexChanged
        private void CbbPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbPartner.SelectedItem.ToString() != NOVO)
                {
                    btnAddPartner.Text = "Atualizar";
                    FornecedorDTO partner = config
                            .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString());
                    txbPartnerName.Text = partner.Name;
                    txbPartnerUstValue.Text = partner.UstValue.ToString();
                    if (partner.CaminhoLogomarca != string.Empty &&
                        partner.CaminhoLogomarca != null)
                    {
                        picBoxLogomarca.Load(partner.CaminhoLogomarca);
                    }
                    UpdateContractsCombo();
                }
                else
                {
                    btnAddPartner.Text = "Adicionar";
                    txbPartnerName.Clear();
                    txbPartnerUstValue.Clear();
                    picBoxLogomarca.Image = null;

                    cbbContract.Enabled = false;
                    cbbContractType.Enabled = false;
                    txbContractFactor.Enabled = false;
                    txbContractHourValue.Enabled = false;
                    cbbDevs.Enabled = false;
                    txbDevName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO ao carregar dados do parceiro.\n\nMensagem: {ex.Message}";
                BlockFields(true);
            }
        }

        private void CbbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbResult.Clear();
            try
            {
                if (cbbContract.SelectedValue == null || cbbContract.SelectedValue.ToString() == NOVO )
                {
                    btnAddContract.Enabled = true;
                    txbContractFactor.Enabled = true;
                    cbbContractType.Enabled = true;
                    btnAddContract.Text = "Adicionar";
                    txbContractFactor.Clear();
                }
                else
                {
                    if (cbbContract.SelectedValue.ToString() == UtilDTO.CONTRACTS.HOUSE.ToString())
                    {
                        btnAddContract.Enabled = false;
                        txbContractFactor.Enabled = false;
                        cbbContractType.Enabled = false;
                        UpdateDevsCombo();
                    }
                    else
                    {
                        btnAddContract.Enabled = true;
                        txbContractFactor.Enabled = true;
                        cbbContractType.Enabled = true;
                        btnAddContract.Text = "Atualizar";
                        ContratoDTO contract = config
                                            .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                                            .Contracts.Find(c => c.Name == cbbContract.SelectedValue.ToString());
                        txbContractFactor.Text = contract.Factor.ToString();
                        UpdateDevsCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"ERRO\n\nMensagem: {ex.Message}";
            }
        }

        private void CbbDevs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDevs.SelectedItem.ToString() != NOVO)
            {
                btnAddDev.Text = "Atualizar";
                ColaboradorDTO dev = new ColaboradorDTO();

                if (cbbContract.SelectedValue.ToString() == UtilDTO.CONTRACTS.HOUSE.ToString())
                {
                    dev = config
                        .BaneseDes
                            .Find(x => x.Name == cbbDevs.SelectedItem.ToString());
                }
                else
                {
                    dev = config
                            .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                            .Contracts.Find(c => c.Name == cbbContract.SelectedValue.ToString())
                            .Collaborators
                                .Find(x => x.Name == cbbDevs.SelectedItem.ToString());
                }

                txbDevName.Text = dev.Name;
                ckbHalf.Checked = dev.WorksHalfDay;
            }
            else
            {
                btnAddDev.Text = "Adicionar";
                txbDevName.Clear();
                ckbHalf.Checked = false;
            }
        }
        #endregion

        private void Processing(bool processing)
        {
            if (processing)
            {
                txbResult.Text = "Processando...";
                BlockFields(processing);
            }
            else
            {
                txbResult.Text = $"Arquivo\n{outputName}\n\nGerado na pasta\n{outputPath}";
                btnOpenFile.Enabled = true;
            }
        }

        #region BlockFields
        private void BlockFields(bool processing)
        {
            txbAuthor.Enabled = !processing;
            txbTeamName.Enabled = !processing;
            txbPartnerName.Enabled = !processing;
            txbPartnerUstValue.Enabled = !processing;
            txbContractFactor.Enabled = !processing;
            txbContractHourValue.Enabled = !processing;
            cbbContractType.Enabled = !processing;
            txbDevName.Enabled = !processing;

            cbbPartner.Enabled = !processing;
            cbbContract.Enabled = !processing;
            cbbDevs.Enabled = !processing;

            btnAddPartner.Enabled = !processing;
            btnAddContract.Enabled = !processing;
            btnAddDev.Enabled = !processing;
            btnLoad.Enabled = !processing;
            btnGenerateFilled.Enabled = !processing;
            btnOutputPath.Enabled = !processing;
            btnLogomarcaParceiro.Enabled = !processing;

            ckbHalf.Enabled = !processing;
        }
        #endregion

        #region PrintUserLog
        private void PrintUserLog(string mensagem)
        {
            txbResult.Text = mensagem;
            txbResult.AppendText($"\n\nAutor: {txbAuthor.Text}\nTime: {txbTeamName.Text}");
            txbResult.AppendText($"\n\nTime dev Baanese:");
            if (config.BaneseDes.Count > 0)
            {
                foreach (var dev in config.BaneseDes)
                {
                    txbResult.AppendText($"\n  > Nome: {dev.Name}");
                    txbResult.AppendText($"\n  > Turno único:  {dev.WorksHalfDay}");
                }
            }
            if (config.Partners.Count > 0)
            {
                foreach (var partner in config.Partners)
                {
                    if (partner.Name != UtilDTO.CONTRACTS.HOUSE.ToString())
                    {
                        txbResult.AppendText($"\n\nParceiro  - {partner.Name}");
                        txbResult.AppendText($"\n   > UST: R${partner.UstValue}");
                        txbResult.AppendText($"\n   > Logomarca: {partner.CaminhoLogomarca}");
                        if (partner.Contracts.Count > 0)
                        {
                            foreach (var contract in partner.Contracts)
                            {
                                txbResult.AppendText($"\n   > Contrato - {contract.Name}");
                                txbResult.AppendText($"\n      - Fator: {contract.Factor}");
                                txbResult.AppendText($"\n      - Valor da hora: R${contract.HourValue}");
                                if (contract.Collaborators.Count > 0)
                                {
                                    txbResult.AppendText($"\n      - Devs:");
                                    foreach (var dev in contract.Collaborators)
                                    {
                                        txbResult.AppendText($"\n         . Nome: {dev.Name}");
                                        txbResult.AppendText($"\n         . Turno único: {dev.WorksHalfDay}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        } 
        #endregion
    }
}
