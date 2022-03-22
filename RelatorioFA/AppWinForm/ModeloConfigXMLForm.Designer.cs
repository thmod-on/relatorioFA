namespace RelatorioFA.AppWinForm
{
    partial class ModeloConfigXMLForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateFilled = new System.Windows.Forms.Button();
            this.txbDevName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbDevs = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ckbHalf = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAddDev = new System.Windows.Forms.Button();
            this.cbbContract = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbAuthor = new System.Windows.Forms.TextBox();
            this.txbTeamName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLogomarcaParceiro = new System.Windows.Forms.Button();
            this.picBoxLogomarca = new System.Windows.Forms.PictureBox();
            this.txbPartnerUstValue = new System.Windows.Forms.TextBox();
            this.txbPartnerName = new System.Windows.Forms.TextBox();
            this.cbbPartner = new System.Windows.Forms.ComboBox();
            this.btnAddPartner = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbbContractType = new System.Windows.Forms.ComboBox();
            this.txbContractFactor = new System.Windows.Forms.TextBox();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogomarca)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(12, 464);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(111, 23);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Carregar XML";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutputPath.Location = new System.Drawing.Point(135, 464);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(111, 23);
            this.btnOutputPath.TabIndex = 20;
            this.btnOutputPath.Text = "Local de saída";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.BtnOutputPath_Click);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(148, 497);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(35, 13);
            this.lblOutputPath.TabIndex = 3;
            this.lblOutputPath.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Log / Avisos";
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(504, 49);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 405);
            this.txbResult.TabIndex = 30;
            this.txbResult.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Autor / Responsável";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Área - Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nome";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nome";
            // 
            // btnGenerateFilled
            // 
            this.btnGenerateFilled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateFilled.Enabled = false;
            this.btnGenerateFilled.Location = new System.Drawing.Point(259, 464);
            this.btnGenerateFilled.Name = "btnGenerateFilled";
            this.btnGenerateFilled.Size = new System.Drawing.Size(111, 23);
            this.btnGenerateFilled.TabIndex = 20;
            this.btnGenerateFilled.Text = "Gerar preenchido";
            this.btnGenerateFilled.UseVisualStyleBackColor = true;
            this.btnGenerateFilled.Click += new System.EventHandler(this.BtnGenerateFilled_Click);
            // 
            // txbDevName
            // 
            this.txbDevName.Enabled = false;
            this.txbDevName.Location = new System.Drawing.Point(108, 79);
            this.txbDevName.Name = "txbDevName";
            this.txbDevName.Size = new System.Drawing.Size(100, 20);
            this.txbDevName.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbDevs);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.ckbHalf);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnAddDev);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbDevName);
            this.groupBox1.Location = new System.Drawing.Point(259, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 202);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3 - Desenvolvedor";
            // 
            // cbbDevs
            // 
            this.cbbDevs.Enabled = false;
            this.cbbDevs.FormattingEnabled = true;
            this.cbbDevs.Location = new System.Drawing.Point(108, 53);
            this.cbbDevs.Name = "cbbDevs";
            this.cbbDevs.Size = new System.Drawing.Size(100, 21);
            this.cbbDevs.TabIndex = 12;
            this.cbbDevs.SelectedIndexChanged += new System.EventHandler(this.CbbDevs_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Desenvolvedores";
            // 
            // ckbHalf
            // 
            this.ckbHalf.AutoSize = true;
            this.ckbHalf.Location = new System.Drawing.Point(7, 110);
            this.ckbHalf.Name = "ckbHalf";
            this.ckbHalf.Size = new System.Drawing.Size(150, 17);
            this.ckbHalf.TabIndex = 14;
            this.ckbHalf.Text = "Trabalha apenas um turno";
            this.ckbHalf.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(201, 41);
            this.label12.TabIndex = 18;
            this.label12.Text = "Escolha a que parceiro e contrato o colaborador estará associado";
            // 
            // btnAddDev
            // 
            this.btnAddDev.Enabled = false;
            this.btnAddDev.Location = new System.Drawing.Point(110, 163);
            this.btnAddDev.Name = "btnAddDev";
            this.btnAddDev.Size = new System.Drawing.Size(100, 23);
            this.btnAddDev.TabIndex = 14;
            this.btnAddDev.Text = "Adicionar";
            this.btnAddDev.UseVisualStyleBackColor = true;
            this.btnAddDev.Click += new System.EventHandler(this.BtnAddDev_Click);
            // 
            // cbbContract
            // 
            this.cbbContract.Enabled = false;
            this.cbbContract.FormattingEnabled = true;
            this.cbbContract.Location = new System.Drawing.Point(108, 52);
            this.cbbContract.Name = "cbbContract";
            this.cbbContract.Size = new System.Drawing.Size(100, 21);
            this.cbbContract.TabIndex = 7;
            this.cbbContract.SelectedIndexChanged += new System.EventHandler(this.CbbContract_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Contratos";
            // 
            // txbAuthor
            // 
            this.txbAuthor.Location = new System.Drawing.Point(120, 23);
            this.txbAuthor.Name = "txbAuthor";
            this.txbAuthor.Size = new System.Drawing.Size(126, 20);
            this.txbAuthor.TabIndex = 1;
            // 
            // txbTeamName
            // 
            this.txbTeamName.Location = new System.Drawing.Point(319, 23);
            this.txbTeamName.Name = "txbTeamName";
            this.txbTeamName.Size = new System.Drawing.Size(144, 20);
            this.txbTeamName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnLogomarcaParceiro);
            this.groupBox2.Controls.Add(this.picBoxLogomarca);
            this.groupBox2.Controls.Add(this.txbPartnerUstValue);
            this.groupBox2.Controls.Add(this.txbPartnerName);
            this.groupBox2.Controls.Add(this.cbbPartner);
            this.groupBox2.Controls.Add(this.btnAddPartner);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 204);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1 - Parceiro";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(14, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 32);
            this.label13.TabIndex = 13;
            this.label13.Text = "Preencha os dados do parceiro  ou escolha um já cadastrado";
            // 
            // btnLogomarcaParceiro
            // 
            this.btnLogomarcaParceiro.Location = new System.Drawing.Point(112, 135);
            this.btnLogomarcaParceiro.Name = "btnLogomarcaParceiro";
            this.btnLogomarcaParceiro.Size = new System.Drawing.Size(103, 24);
            this.btnLogomarcaParceiro.TabIndex = 5;
            this.btnLogomarcaParceiro.Text = "Logomarca";
            this.btnLogomarcaParceiro.UseVisualStyleBackColor = true;
            this.btnLogomarcaParceiro.Click += new System.EventHandler(this.BtnLogomarcaParceiro_Click);
            // 
            // picBoxLogomarca
            // 
            this.picBoxLogomarca.Location = new System.Drawing.Point(11, 135);
            this.picBoxLogomarca.Name = "picBoxLogomarca";
            this.picBoxLogomarca.Size = new System.Drawing.Size(96, 56);
            this.picBoxLogomarca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogomarca.TabIndex = 12;
            this.picBoxLogomarca.TabStop = false;
            // 
            // txbPartnerUstValue
            // 
            this.txbPartnerUstValue.Location = new System.Drawing.Point(114, 110);
            this.txbPartnerUstValue.Name = "txbPartnerUstValue";
            this.txbPartnerUstValue.Size = new System.Drawing.Size(100, 20);
            this.txbPartnerUstValue.TabIndex = 4;
            this.txbPartnerUstValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbUstValue_KeyPress);
            // 
            // txbPartnerName
            // 
            this.txbPartnerName.Location = new System.Drawing.Point(114, 84);
            this.txbPartnerName.Name = "txbPartnerName";
            this.txbPartnerName.Size = new System.Drawing.Size(100, 20);
            this.txbPartnerName.TabIndex = 3;
            // 
            // cbbPartner
            // 
            this.cbbPartner.FormattingEnabled = true;
            this.cbbPartner.Location = new System.Drawing.Point(114, 55);
            this.cbbPartner.Name = "cbbPartner";
            this.cbbPartner.Size = new System.Drawing.Size(100, 21);
            this.cbbPartner.TabIndex = 7;
            this.cbbPartner.SelectedIndexChanged += new System.EventHandler(this.CbbPartner_SelectedIndexChanged);
            // 
            // btnAddPartner
            // 
            this.btnAddPartner.Location = new System.Drawing.Point(112, 165);
            this.btnAddPartner.Name = "btnAddPartner";
            this.btnAddPartner.Size = new System.Drawing.Size(102, 23);
            this.btnAddPartner.TabIndex = 6;
            this.btnAddPartner.Text = "Adicionar";
            this.btnAddPartner.UseVisualStyleBackColor = true;
            this.btnAddPartner.Click += new System.EventHandler(this.BtnAddPartner_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Valor UST (R$)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Parceiros";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbbContractType);
            this.groupBox3.Controls.Add(this.cbbContract);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txbContractFactor);
            this.groupBox3.Controls.Add(this.btnAddContract);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 179);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2 - Contrato";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(9, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(206, 31);
            this.label15.TabIndex = 18;
            this.label15.Text = "Adicione um contrato para o parceiro selecionado ou escoha um da lista";
            // 
            // cbbContractType
            // 
            this.cbbContractType.Enabled = false;
            this.cbbContractType.FormattingEnabled = true;
            this.cbbContractType.Location = new System.Drawing.Point(108, 76);
            this.cbbContractType.Name = "cbbContractType";
            this.cbbContractType.Size = new System.Drawing.Size(100, 21);
            this.cbbContractType.TabIndex = 9;
            // 
            // txbContractFactor
            // 
            this.txbContractFactor.Enabled = false;
            this.txbContractFactor.Location = new System.Drawing.Point(108, 101);
            this.txbContractFactor.Name = "txbContractFactor";
            this.txbContractFactor.Size = new System.Drawing.Size(100, 20);
            this.txbContractFactor.TabIndex = 10;
            this.txbContractFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbContractFactor_KeyPress);
            // 
            // btnAddContract
            // 
            this.btnAddContract.Enabled = false;
            this.btnAddContract.Location = new System.Drawing.Point(108, 128);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(100, 23);
            this.btnAddContract.TabIndex = 11;
            this.btnAddContract.Text = "Adicionar";
            this.btnAddContract.UseVisualStyleBackColor = true;
            this.btnAddContract.Click += new System.EventHandler(this.BtnAddContract_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fator de ajuste";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tipo";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Location = new System.Drawing.Point(382, 464);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(111, 23);
            this.btnOpenFile.TabIndex = 20;
            this.btnOpenFile.Text = "Abrir arquivo";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 497);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "O arquivo será gerado em:";
            // 
            // ModeloConfigXMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 519);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txbTeamName);
            this.Controls.Add(this.txbAuthor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerateFilled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbResult);
            this.Controls.Add(this.lblOutputPath);
            this.Controls.Add(this.btnOutputPath);
            this.Controls.Add(this.btnLoad);
            this.Name = "ModeloConfigXMLForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogomarca)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerateFilled;
        private System.Windows.Forms.TextBox txbDevName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddDev;
        private System.Windows.Forms.TextBox txbAuthor;
        private System.Windows.Forms.TextBox txbTeamName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbPartner;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddPartner;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.ComboBox cbbContract;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbPartnerUstValue;
        private System.Windows.Forms.TextBox txbPartnerName;
        private System.Windows.Forms.TextBox txbContractFactor;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbContractType;
        private System.Windows.Forms.Button btnLogomarcaParceiro;
        private System.Windows.Forms.PictureBox picBoxLogomarca;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ckbHalf;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbbDevs;
        private System.Windows.Forms.Label label16;
    }
}