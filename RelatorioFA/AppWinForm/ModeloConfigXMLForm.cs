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
            LoadPresetBatches();
            LoadPresetRoles();
            cbbPartner.Items.Add(NOVO);
            cbbPartner.SelectedIndex = 0;
        }

        public ModeloConfigXMLForm()
        {
            InitializeComponent();
            LoadConfigData();
            LoadPresetBatches();
            LoadPresetRoles();
            cbbPartner.Items.Add(NOVO);
            cbbPartner.SelectedIndex = 0;
        }

        private string outputPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private ConfigXmlDTO config = new ConfigXmlDTO();

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 30);
        }

        private void LoadPresetBatches()
        {
            foreach (var batch in Enum.GetValues(typeof(UtilDTO.BATCHS)))
            {
                cbbAvaliableBatchs.Items.Add(batch);
            }
            cbbAvaliableBatchs.SelectedIndex = 0;
        }

        #region LoadContractType
        private void LoadPresetRoles()
        {
            foreach (var role in Enum.GetValues(typeof(UtilDTO.ROLES)))
            {
                if (role.ToString() != UtilDTO.ROLES.HOUSE.ToString())
                {
                    cbbAvaliableRoles.Items.Add(role);
                }
            }
            cbbAvaliableRoles.SelectedIndex = 0;
        } 
        #endregion

        private void LoadConfigData()
        {
            lblOutputPath.Text = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            FornecedorDTO fakePartner = new FornecedorDTO()
            {
                Name = UtilDTO.ROLES.HOUSE.ToString()
            };
            config.Partners.Add(fakePartner);

            ContratoDTO fakeContract = new ContratoDTO()
            {
                SapNumber = UtilDTO.ROLES.HOUSE.ToString()
            };
            config.Partners.Find(x => x.Name == UtilDTO.ROLES.HOUSE.ToString()).Contracts.Add(fakeContract);
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

        #region BtnSave_Click
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFieldsToGenerateDoc();
                Processing(true);
                config.AuthorName = txbAuthor.Text;
                config.TeamName = txbTeamName.Text;
                PrincipalTO.GenerateConfigXmlFile(outputPath, UtilDTO.configName, config);
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
                    SapNumber = txbSapNumber.Text,
                    UstValue = Convert.ToDouble(txbUstValue.Text)
                };

                if (cbbContract.SelectedValue.ToString() != NOVO &&
                    cbbContract.SelectedValue.ToString() != UtilDTO.ROLES.HOUSE.ToString())
                {
                    var oldContract = config
                        .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                        .Contracts.Find(c => c.SapNumber == cbbContract.SelectedValue.ToString());

                    config
                        .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                        .Contracts
                        .Remove(oldContract);
                }

                config.Partners
                    .Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts
                    .Add(newContract);

                UpdateContractsCombo();
                PrintUserLog($"Contrato '{newContract.SapNumber}' adicionado ao parceiro '{cbbPartner.SelectedItem}'");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao associar tipo de contrato ao fornecedor. Mensagem:\n{ex.Message}";
            }
        }
        #endregion

        #region DevControl
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
                    if (cbbContract.SelectedValue.ToString() == UtilDTO.ROLES.HOUSE.ToString())
                    {
                        config.BaneseDes.Add(newDev);
                    }
                    else
                    {
                        config
                            .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                            .Contracts.Find(x => x.SapNumber == cbbContract.SelectedValue.ToString())
                            .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                            .Roles.Find(r => r.Name == cbbAvaliableRoles.SelectedItem.ToString())
                            .Collaborators.Add(newDev);
                    }
                }
                else
                {
                    var oldDevData = config
                            .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                            .Contracts.Find(x => x.SapNumber == cbbContract.SelectedValue.ToString())
                            .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                            .Roles.Find(r => r.Name == cbbAvaliableRoles.SelectedItem.ToString())
                            .Collaborators.Find(dev => dev.Name == cbbDevs.SelectedItem.ToString());

                    var role = config
                            .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                            .Contracts.Find(x => x.SapNumber == cbbContract.SelectedValue.ToString())
                            .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                            .Roles.Find(r => r.Name == cbbAvaliableRoles.SelectedItem.ToString());

                    role.Collaborators.Remove(oldDevData);
                    role.Collaborators.Add(newDev);
                }

                txbDevName.Clear();
                UpdateDevsCombo();
                btnSave.Enabled = true;
                PrintUserLog($"Desenvolvedor '{newDev.Name}' adicionado ao contrato '{cbbContract.SelectedValue}' do fornecedor '{cbbPartner.SelectedItem}'");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro não tratado. Mensagem:\n{ex.Message}\n\nPilha:\n{ex.StackTrace}";
            }
        }

        private void BtnRemoveDev_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region BtnOpenFile_Click
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                var file = Path.Combine(outputPath, UtilDTO.configName);
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
                if (partner.Name != UtilDTO.ROLES.HOUSE.ToString())
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
                { UtilDTO.ROLES.HOUSE.ToString(), UtilDTO.ROLES.HOUSE.ToString() }
            };
            if (config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts.Count > 0)
            {
                foreach (var contract in config.Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString()).Contracts)
                {
                    comboItens.Add(contract.SapNumber, cbbPartner.SelectedItem.ToString() + " - " + contract.SapNumber);
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

        /// <summary>
        /// Update the dev cbb with all devs already added to that partner > contract > batch > role
        /// </summary>
        private void UpdateDevsCombo()
        {
            cbbDevs.Items.Clear();
            cbbDevs.Items.Add(NOVO);
            List<ColaboradorDTO> colaboradores = new List<ColaboradorDTO>();
            if (cbbContract.SelectedValue.ToString() == UtilDTO.ROLES.HOUSE.ToString())
            {
                colaboradores = config.BaneseDes;
            }
            else
            {
                colaboradores = config
                    .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                    .Contracts.Find(c => c.SapNumber == (cbbContract.SelectedValue.ToString()))
                    .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                    .Roles.Find(p => p.Name == cbbAvaliableRoles.SelectedItem.ToString())
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
            txbSapNumber.Enabled = true;
            txbUstValue.Enabled = true;
            btnAddContract.Enabled = true;
            btnRemoveContract.Enabled = true;
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
            if (txbPartnerName.Text.Trim() == string.Empty)
            {
                throw new Exception("Ao menos um parceiro deve ser cadastrado.");
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

            foreach (var _ in from partner in config.Partners
                              from contract in partner.Contracts
                              where contract.SapNumber != UtilDTO.ROLES.HOUSE.ToString()
                              from batch in contract.Batches
                              from role in batch.Roles
                              where role.Collaborators.Count < 1
                              select new { })
            {
                throw new Exception("Ao menos um colaborador deve ser aadicionado a cada contrato.");
            }
        }

        private void ValidateContractData()
        {
            if (txbUstValue.Text == string.Empty)
            {
                txbUstValue.Focus();
                throw new Exception("Fator de ajuste precisa ser preenchido.");
            }

            if (Convert.ToDouble(txbUstValue.Text) == 0)
            {
                txbUstValue.Focus();
                throw new Exception("Fator de ajuste não pode ser zero.");
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
                    picBoxLogomarca.Image = null;

                    cbbContract.Enabled = false;
                    txbUstValue.Enabled = false;
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
                    txbUstValue.Enabled = true;
                    btnAddContract.Text = "Adicionar";
                    txbUstValue.Clear();
                }
                else
                {
                    if (cbbContract.SelectedValue.ToString() == UtilDTO.ROLES.HOUSE.ToString())
                    {
                        btnAddContract.Enabled = false;
                        txbUstValue.Enabled = false;
                        UpdateDevsCombo();
                    }
                    else
                    {
                        btnAddContract.Enabled = true;
                        txbUstValue.Enabled = true;
                        btnAddContract.Text = "Atualizar";
                        ContratoDTO contract = config
                                            .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                                            .Contracts.Find(c => c.SapNumber == cbbContract.SelectedValue.ToString());
                        txbUstValue.Text = contract.UstValue.ToString();
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

                if (cbbContract.SelectedValue.ToString() == UtilDTO.ROLES.HOUSE.ToString())
                {
                    dev = config
                        .BaneseDes.Find(x => x.Name == cbbDevs.SelectedItem.ToString());
                }
                else
                {
                    dev = config
                            .Partners.Find(p => p.Name == cbbPartner.SelectedItem.ToString())
                            .Contracts.Find(c => c.SapNumber == cbbContract.SelectedValue.ToString())
                            .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                            .Roles.Find(r => r.Name == cbbAvaliableRoles.SelectedItem.ToString())
                            .Collaborators.Find(x => x.Name == cbbDevs.SelectedItem.ToString());
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
                txbResult.Text = $"Arquivo\n{UtilDTO.configName}\n\nGerado na pasta\n{outputPath}";
                btnOpenFile.Enabled = true;
            }
        }

        #region BlockFields
        private void BlockFields(bool processing)
        {
            txbAuthor.Enabled = !processing;
            txbTeamName.Enabled = !processing;
            txbPartnerName.Enabled = !processing;
            txbUstValue.Enabled = !processing;
            txbDevName.Enabled = !processing;

            cbbPartner.Enabled = !processing;
            cbbContract.Enabled = !processing;
            cbbDevs.Enabled = !processing;

            btnAddPartner.Enabled = !processing;
            btnAddContract.Enabled = !processing;
            btnAddDev.Enabled = !processing;
            btnLoad.Enabled = !processing;
            btnSave.Enabled = !processing;
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
                    if (partner.Name != UtilDTO.ROLES.HOUSE.ToString())
                    {
                        txbResult.AppendText($"\n\nParceiro  - {partner.Name}");
                        txbResult.AppendText($"\n > Logomarca: {partner.CaminhoLogomarca}");
                        if (partner.Contracts.Count > 0)
                        {
                            foreach (var contract in partner.Contracts)
                            {
                                txbResult.AppendText($"\n > Contrato - {contract.SapNumber}");
                                txbResult.AppendText($"\n  - UST: R${contract.UstValue}");
                                foreach (var batch in contract.Batches)
                                {
                                    txbResult.AppendText($"\n  > Lote: {batch.Name}");
                                    foreach (var role in batch.Roles)
                                    {
                                        txbResult.AppendText($"\n   > Cargo: {role.Name}");
                                        txbResult.AppendText($"\n    - Fator: {role.Factor}");
                                        if (role.Collaborators.Count > 0)
                                        {
                                            txbResult.AppendText($"\n    > Devs:");
                                            foreach (var dev in role.Collaborators)
                                            {
                                                txbResult.AppendText($"\n     - Nome: {dev.Name}");
                                                txbResult.AppendText($"\n     - Turno único: {dev.WorksHalfDay}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region BatchControl
        private void BtnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                LoteDTO newBatch = new LoteDTO()
                {
                    Name = cbbAvaliableBatchs.Text
                };

                config
                    .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                    .Contracts.Find(c => c.SapNumber == cbbContract.SelectedItem.ToString())
                    .Batches.Add(newBatch);

                cbbAvaliableBatchs.SelectedIndex = 0;

                PrintUserLog($"Contrato '{newBatch.Name}' adicionado ao contrato '{cbbContract.SelectedItem}' do parceiro '{cbbPartner.SelectedItem}'");
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao associar o lote ao contrato. Mensagem:\n{ex.Message}";
            }
        }

        private void BtnRemoveBatch_Click(object sender, EventArgs e)
        {
            try
            {
                LoteDTO oldBatch = (from partner in config.Partners
                                    where partner.Name == cbbPartner.SelectedItem.ToString()
                                    from contract in partner.Contracts
                                    where contract.SapNumber == cbbContract.SelectedItem.ToString()
                                    from batch in contract.Batches
                                    where batch.Name == cbbAvaliableBatchs.SelectedItem.ToString()
                                    select batch).First();

                config
                    .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                    .Contracts.Find(c => c.SapNumber == cbbContract.SelectedItem.ToString())
                    .Batches.Remove(oldBatch);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao remover o lote.\n{ex.Message}";
            }
        }
        #endregion

        #region RoleControl
        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                CargoDTO newRole = new CargoDTO()
                {
                    Name = cbbAvaliableRoles.SelectedItem.ToString(),
                    Factor = Convert.ToDouble(txbFactor.Text)
                };

                config
                    .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                    .Contracts.Find(c => c.SapNumber == cbbContract.SelectedItem.ToString())
                    .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                    .Roles.Add(newRole);

                cbbAvaliableRoles.SelectedIndex = 0;
                txbFactor.Clear();
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao associar cargo.\n{ex.Message}";
            }
        }

        private void BtnRemoveRole_Click(object sender, EventArgs e)
        {
            try
            {
                CargoDTO oldRole = (from partner in config.Partners
                                    where partner.Name == cbbPartner.SelectedItem.ToString()
                                    from contract in partner.Contracts
                                    where contract.SapNumber == cbbContract.SelectedItem.ToString()
                                    from batch in contract.Batches
                                    where batch.Name == cbbAvaliableBatchs.SelectedItem.ToString()
                                    from role in batch.Roles
                                    where role.Name == cbbAvaliableRoles.SelectedItem.ToString()
                                    select  role).First();
                config
                   .Partners.Find(x => x.Name == cbbPartner.SelectedItem.ToString())
                   .Contracts.Find(c => c.SapNumber == cbbContract.SelectedItem.ToString())
                   .Batches.Find(b => b.Name == cbbAvaliableBatchs.SelectedItem.ToString())
                   .Roles.Remove(oldRole);
            }
            catch (Exception ex)
            {
                txbResult.Text = $"Erro ao remover cargo.\n{ex.Message}";
            }
        } 
        #endregion


    }
}
