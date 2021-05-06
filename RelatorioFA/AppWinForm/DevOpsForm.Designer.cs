
namespace RelatorioFA.AppWinForm
{
    partial class DevOpsForm
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
            this.cbbPartners = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txbOpsWarningUst = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbOpsActuationUst = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbOpsUsUst = new System.Windows.Forms.TextBox();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbOpsDevsCount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpIniDate = new System.Windows.Forms.DateTimePicker();
            this.txbSprintDays = new System.Windows.Forms.TextBox();
            this.cbbSprintRanges = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.txbObs = new System.Windows.Forms.RichTextBox();
            this.pbxSprintImage = new System.Windows.Forms.PictureBox();
            this.btnSprintImage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSprintImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbPartners
            // 
            this.cbbPartners.FormattingEnabled = true;
            this.cbbPartners.Location = new System.Drawing.Point(110, 39);
            this.cbbPartners.Name = "cbbPartners";
            this.cbbPartners.Size = new System.Drawing.Size(121, 21);
            this.cbbPartners.Sorted = true;
            this.cbbPartners.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fornecedor";
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(12, 23);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(72, 13);
            this.lblTeamName.TabIndex = 2;
            this.lblTeamName.Text = "Nome do time";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(282, 23);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(32, 13);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "Autor";
            // 
            // txbOpsWarningUst
            // 
            this.txbOpsWarningUst.Location = new System.Drawing.Point(110, 19);
            this.txbOpsWarningUst.Name = "txbOpsWarningUst";
            this.txbOpsWarningUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsWarningUst.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "UST sobreaviso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "UST acionamento";
            // 
            // txbOpsActuationUst
            // 
            this.txbOpsActuationUst.Location = new System.Drawing.Point(110, 47);
            this.txbOpsActuationUst.Name = "txbOpsActuationUst";
            this.txbOpsActuationUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsActuationUst.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "UST US";
            // 
            // txbOpsUsUst
            // 
            this.txbOpsUsUst.Location = new System.Drawing.Point(110, 73);
            this.txbOpsUsUst.Name = "txbOpsUsUst";
            this.txbOpsUsUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsUsUst.TabIndex = 8;
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(854, 64);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(230, 274);
            this.txbResult.TabIndex = 11;
            this.txbResult.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Qtd. plantonistas";
            // 
            // txbOpsDevsCount
            // 
            this.txbOpsDevsCount.Location = new System.Drawing.Point(109, 103);
            this.txbOpsDevsCount.Name = "txbOpsDevsCount";
            this.txbOpsDevsCount.Size = new System.Drawing.Size(121, 20);
            this.txbOpsDevsCount.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpIniDate);
            this.groupBox1.Controls.Add(this.txbSprintDays);
            this.groupBox1.Controls.Add(this.cbbSprintRanges);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(14, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 139);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Release / Sprint";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Data inicial";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(111, 75);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 34;
            // 
            // dtpIniDate
            // 
            this.dtpIniDate.CustomFormat = "";
            this.dtpIniDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIniDate.Location = new System.Drawing.Point(112, 49);
            this.dtpIniDate.Name = "dtpIniDate";
            this.dtpIniDate.Size = new System.Drawing.Size(121, 20);
            this.dtpIniDate.TabIndex = 33;
            // 
            // txbSprintDays
            // 
            this.txbSprintDays.Location = new System.Drawing.Point(111, 104);
            this.txbSprintDays.Name = "txbSprintDays";
            this.txbSprintDays.Size = new System.Drawing.Size(121, 20);
            this.txbSprintDays.TabIndex = 49;
            this.txbSprintDays.Visible = false;
            // 
            // cbbSprintRanges
            // 
            this.cbbSprintRanges.FormattingEnabled = true;
            this.cbbSprintRanges.ItemHeight = 13;
            this.cbbSprintRanges.Location = new System.Drawing.Point(111, 18);
            this.cbbSprintRanges.Name = "cbbSprintRanges";
            this.cbbSprintRanges.Size = new System.Drawing.Size(121, 21);
            this.cbbSprintRanges.TabIndex = 35;
            this.cbbSprintRanges.SelectedIndexChanged += new System.EventHandler(this.CbbSprintRanges_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Dias da sprint";
            this.label21.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Data final";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbOpsWarningUst);
            this.groupBox2.Controls.Add(this.txbOpsActuationUst);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txbOpsDevsCount);
            this.groupBox2.Controls.Add(this.txbOpsUsUst);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(285, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 131);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados de pagamento";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(125, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(325, 315);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Gerar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(211, 315);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 55;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(411, 315);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 56;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "O aruivo será gerado em:";
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(210, 351);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(48, 13);
            this.lblOutputPath.TabIndex = 58;
            this.lblOutputPath.Text = "Caminho";
            this.lblOutputPath.Visible = false;
            // 
            // txbObs
            // 
            this.txbObs.Location = new System.Drawing.Point(12, 30);
            this.txbObs.Name = "txbObs";
            this.txbObs.Size = new System.Drawing.Size(230, 64);
            this.txbObs.TabIndex = 59;
            this.txbObs.Text = "";
            // 
            // pbxSprintImage
            // 
            this.pbxSprintImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxSprintImage.Location = new System.Drawing.Point(11, 69);
            this.pbxSprintImage.Name = "pbxSprintImage";
            this.pbxSprintImage.Size = new System.Drawing.Size(235, 192);
            this.pbxSprintImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSprintImage.TabIndex = 60;
            this.pbxSprintImage.TabStop = false;
            // 
            // btnSprintImage
            // 
            this.btnSprintImage.Location = new System.Drawing.Point(6, 29);
            this.btnSprintImage.Name = "btnSprintImage";
            this.btnSprintImage.Size = new System.Drawing.Size(103, 23);
            this.btnSprintImage.TabIndex = 61;
            this.btnSprintImage.Text = "Escolher imagem";
            this.btnSprintImage.UseVisualStyleBackColor = true;
            this.btnSprintImage.Click += new System.EventHandler(this.BtnSprintImage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSprintImage);
            this.groupBox3.Controls.Add(this.pbxSprintImage);
            this.groupBox3.Location = new System.Drawing.Point(561, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 274);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deseja carregar alguma imagem na sprint?";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbbPartners);
            this.groupBox4.Location = new System.Drawing.Point(15, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 74);
            this.groupBox4.TabIndex = 64;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Escolha o fornecedor na lista abaixo e preencha os dados conforme solicitados";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txbObs);
            this.groupBox5.Location = new System.Drawing.Point(285, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 100);
            this.groupBox5.TabIndex = 65;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Alguma observação sobre a sprint?";
            // 
            // DevOpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 380);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblOutputPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txbResult);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTeamName);
            this.Name = "DevOpsForm";
            this.Text = "DevOpsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSprintImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbPartners;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txbOpsWarningUst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbOpsActuationUst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbOpsUsUst;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbOpsDevsCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpIniDate;
        private System.Windows.Forms.TextBox txbSprintDays;
        private System.Windows.Forms.ComboBox cbbSprintRanges;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.RichTextBox txbObs;
        private System.Windows.Forms.PictureBox pbxSprintImage;
        private System.Windows.Forms.Button btnSprintImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}