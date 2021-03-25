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

        public ModeloConfigXMLForm(Form parentForm)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            LoadConfigData();
            LoadContractType();

            //txbAuthor.Text = "Thiago de Mendonça Modesto";
            //txbTeamName.Text = "ACAFS - Governo";
            //txbPartnerName.Text = "Influir";
            //txbPartnerUstValue.Text = "750";
            //txbContractFactor.Text = "1";
            //btnGenerateFilled.Enabled = true;
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void LoadContractType()
        {
            foreach (var contractType in Enum.GetValues(typeof(UtilDTO.CONTRACTS)))
            {

                if (contractType.ToString() != UtilDTO.CONTRACTS.BANESE.ToString())
                {
                    cbbContractType.Items.Add(contractType); 
                }
            }
            cbbContractType.SelectedIndex = 0;
        }

        private string outputPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        const string outputName = "RelatorioFA.xml";
        private ConfigDTO config = new ConfigDTO();
        
        private void LoadConfigData()
        {
            lblOutputPath.Text = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            FornecedorDTO fakePartner = new FornecedorDTO()
            {
                Name = UtilDTO.CONTRACTS.BANESE.ToString()
            };
            config.Partners.Add(fakePartner);

            ContratoDTO fakeContract = new ContratoDTO()
            {
                Name = UtilDTO.CONTRACTS.BANESE.ToString()
            };
            config.Partners.Find(x => x.Name == UtilDTO.CONTRACTS.BANESE.ToString()).Contracts.Add(fakeContract);
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

                    btnGenerate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro durante escolha do local de saída do arquivo XML. Mensagem:\n{ex.Message}\n\nPilha de erro:\n{ex.StackTrace}";
            }
        } 
        #endregion

        #region BtnGenerate_Click
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            txbResult.Clear();
            try
            {
                Processing(true);
                PrincipalTO.GenerateConfigXmlFile(outputPath, outputName);
                Processing(false);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro durante geração do arquivo XML. Mensagem:\n{ex.Message}\n\nPilha de erro:\n{ex.StackTrace}";
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
                catch(Exception e)
                {
                    throw e;
                }
            }

            return "";
        }


        #region BtnAddContract_Click
        private void BtnAddContract_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateContractData();
                ContratoDTO newContract = new ContratoDTO()
                {
                    Name = cbbContractType.SelectedItem.ToString(),
                    Factor = Convert.ToDouble(txbContractFactor.Text)
                };

                if (txbContractHourValue.Text.Trim() != string.Empty)
                {
                    newContract.HourValue = Convert.ToDouble(txbContractHourValue.Text);
                }

                config.Partners
                    .Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts
                    .Add(newContract);

                UpdateContractsCombo();
                txbContractHourValue.Clear();
                txbContractFactor.Clear();
                PrintUserLog($"Contrato '{newContract.Name}' adicionado ao parceiro '{cbbPartner.SelectedItem.ToString()}'");
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
                    Name = txbDevName.Text
                };

                if (cbbContract.SelectedItem.ToString() != UtilDTO.CONTRACTS.BANESE.ToString())
                {
                    config.Partners
                                .Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                                .Contracts
                                    .Find(x => x.Name == cbbContract.SelectedItem.ToString())
                                    .Collaborators
                                        .Add(newDev);
                }
                else
                {
                    config.BaneseDes.Add(newDev);
                }
                txbDevName.Clear();
                btnGenerateFilled.Enabled = true;
                PrintUserLog($"Desenvolvedor '{newDev.Name}' adicionado ao contrato '{cbbContract.SelectedItem.ToString()}'");
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
        #endregion

        private void UpdatePartnersCombo()
        {
            cbbPartner.Items.Clear();
            foreach (var partner in config.Partners)
            {
                if (partner.Name != UtilDTO.CONTRACTS.BANESE.ToString())
                {
                    cbbPartner.Items.Add(partner.Name);
                }
            }
            cbbPartner.SelectedIndex = cbbPartner.Items.Count - 1;
            EnableContractFields();
        }

        private void UpdateContractsCombo()
        {
            cbbContract.Items.Clear();
            cbbContract.Items.Add(UtilDTO.CONTRACTS.BANESE.ToString());
            if (config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts.Count > 0)
            {
                foreach (var contract in config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts)
                {
                    cbbContract.Items.Add(contract.Name);
                }
                cbbContract.SelectedIndex = 0;
                EnableDevFields();
            }
            else
            {
                cbbContract.Enabled = false;
                txbDevName.Enabled = false;
                btnAddDev.Enabled = false;
            }
        }

        private void EnableDevFields()
        {
            cbbContract.Enabled = true;
            txbDevName.Enabled = true;
            btnAddDev.Enabled = true;
        }

        private void EnableContractFields()
        {
            cbbPartner.Enabled = true;
            //txbContractHourValue.Enabled = true;
            cbbContractType.Enabled = true;
            txbContractFactor.Enabled = true;
            btnAddContract.Enabled = true;
        }

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
                    if (contract.Name != UtilDTO.CONTRACTS.BANESE.ToString() && contract.Collaborators.Count < 1)
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
                throw new Exception("Fator de ajuste nãao pode ser zero.");
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

        private void CbbPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContractsCombo();
        }

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

            btnAddPartner.Enabled = !processing;
            btnAddContract.Enabled = !processing;
            btnAddDev.Enabled = !processing;
            btnGenerate.Enabled = !processing;
            btnGenerateFilled.Enabled = !processing;
            btnOutputPath.Enabled = !processing;
        }

        private void PrintUserLog(string mensagem)
        {
            txbResult.Text = mensagem;
            txbResult.AppendText($"\n\nAutor: {txbAuthor.Text}\nTime: {txbTeamName.Text}");
            txbResult.AppendText($"\n\nTime dev Baanese:");
            if (config.BaneseDes.Count > 0)
            {
                foreach (var dev in config.BaneseDes)
                {
                    txbResult.AppendText($"\n  > {dev.Name}");
                } 
            }
            if (config.Partners.Count > 1)
            {
                foreach (var partner in config.Partners)
                {
                    if (partner.Name != UtilDTO.CONTRACTS.BANESE.ToString())
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
                                        txbResult.AppendText($"\n         . {dev.Name}");
                                    }
                                }
                            }
                        } 
                    }
                }
            }
        }

        private void btnLogomarcaParceiro_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
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
    }
}
