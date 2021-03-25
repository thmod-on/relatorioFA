namespace RelatorioFA.AppWinForm
{
    partial class VariosRelatoriosForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.txbAbsence = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.lblOutputDocPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpIniDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbbSprintRanges = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txbAcceptedPointsInvestment = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbAcceptedPointsExpense = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txbObs = new System.Windows.Forms.RichTextBox();
            this.txbSprintDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lsbDevTeam = new System.Windows.Forms.ListBox();
            this.cbbCerimonialPoint = new System.Windows.Forms.ComboBox();
            this.btnAddSprint = new System.Windows.Forms.Button();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbSmPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxSprintImage = new System.Windows.Forms.PictureBox();
            this.btnSprintImage = new System.Windows.Forms.Button();
            this.lsbSprints = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSprintImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Release / Sprint";
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateAll.Location = new System.Drawing.Point(398, 465);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(103, 23);
            this.btnGenerateAll.TabIndex = 20;
            this.btnGenerateAll.Text = "Gerar todos";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(526, 11);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(272, 202);
            this.txbResult.TabIndex = 3;
            this.txbResult.Text = "";
            // 
            // txbAbsence
            // 
            this.txbAbsence.Location = new System.Drawing.Point(90, 156);
            this.txbAbsence.Name = "txbAbsence";
            this.txbAbsence.Size = new System.Drawing.Size(121, 20);
            this.txbAbsence.TabIndex = 7;
            this.txbAbsence.Leave += new System.EventHandler(this.TxbAbsence_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ausências (dias)";
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(181, 9);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(72, 13);
            this.lblTeamName.TabIndex = 23;
            this.lblTeamName.Text = "Nome do time";
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(272, 465);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 29;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // lblOutputDocPath
            // 
            this.lblOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputDocPath.AutoSize = true;
            this.lblOutputDocPath.Location = new System.Drawing.Point(333, 504);
            this.lblOutputDocPath.Name = "lblOutputDocPath";
            this.lblOutputDocPath.Size = new System.Drawing.Size(70, 13);
            this.lblOutputDocPath.TabIndex = 30;
            this.lblOutputDocPath.Text = "Exportar para";
            this.lblOutputDocPath.Visible = false;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Data final";
            // 
            // dtpIniDate
            // 
            this.dtpIniDate.CustomFormat = "";
            this.dtpIniDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIniDate.Location = new System.Drawing.Point(95, 50);
            this.dtpIniDate.Name = "dtpIniDate";
            this.dtpIniDate.Size = new System.Drawing.Size(121, 20);
            this.dtpIniDate.TabIndex = 33;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(94, 76);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 34;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.DtpEndDate_ValueChanged);
            // 
            // cbbSprintRanges
            // 
            this.cbbSprintRanges.FormattingEnabled = true;
            this.cbbSprintRanges.ItemHeight = 13;
            this.cbbSprintRanges.Location = new System.Drawing.Point(94, 19);
            this.cbbSprintRanges.Name = "cbbSprintRanges";
            this.cbbSprintRanges.Size = new System.Drawing.Size(121, 21);
            this.cbbSprintRanges.TabIndex = 35;
            this.cbbSprintRanges.SelectedIndexChanged += new System.EventHandler(this.CbbSprintRanges_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "+1 Cerimônias";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(210, 39);
            this.label19.TabIndex = 43;
            this.label19.Text = "Selecione um colaborado e preencha suas faltas na sprint";
            // 
            // txbAcceptedPointsInvestment
            // 
            this.txbAcceptedPointsInvestment.Location = new System.Drawing.Point(92, 22);
            this.txbAcceptedPointsInvestment.Name = "txbAcceptedPointsInvestment";
            this.txbAcceptedPointsInvestment.Size = new System.Drawing.Size(121, 20);
            this.txbAcceptedPointsInvestment.TabIndex = 51;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Pts. aceitos INV";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Pts. aceitos DES";
            // 
            // txbAcceptedPointsExpense
            // 
            this.txbAcceptedPointsExpense.Location = new System.Drawing.Point(91, 51);
            this.txbAcceptedPointsExpense.Name = "txbAcceptedPointsExpense";
            this.txbAcceptedPointsExpense.Size = new System.Drawing.Size(121, 20);
            this.txbAcceptedPointsExpense.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Dias da sprint";
            // 
            // txbObs
            // 
            this.txbObs.Location = new System.Drawing.Point(271, 195);
            this.txbObs.Name = "txbObs";
            this.txbObs.Size = new System.Drawing.Size(205, 65);
            this.txbObs.TabIndex = 4;
            this.txbObs.Text = "";
            // 
            // txbSprintDays
            // 
            this.txbSprintDays.Location = new System.Drawing.Point(93, 104);
            this.txbSprintDays.Name = "txbSprintDays";
            this.txbSprintDays.Size = new System.Drawing.Size(121, 20);
            this.txbSprintDays.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Observações da sprint";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(436, 9);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(68, 13);
            this.lblAuthor.TabIndex = 25;
            this.lblAuthor.Text = "Coordenador";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lsbDevTeam);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txbAbsence);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(7, 174);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 210);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Controle de ausências";
            // 
            // lsbDevTeam
            // 
            this.lsbDevTeam.FormattingEnabled = true;
            this.lsbDevTeam.Location = new System.Drawing.Point(9, 63);
            this.lsbDevTeam.Name = "lsbDevTeam";
            this.lsbDevTeam.Size = new System.Drawing.Size(203, 82);
            this.lsbDevTeam.TabIndex = 53;
            this.lsbDevTeam.SelectedIndexChanged += new System.EventHandler(this.LsbDevTeam_SelectedIndexChanged);
            // 
            // cbbCerimonialPoint
            // 
            this.cbbCerimonialPoint.FormattingEnabled = true;
            this.cbbCerimonialPoint.Location = new System.Drawing.Point(90, 106);
            this.cbbCerimonialPoint.Name = "cbbCerimonialPoint";
            this.cbbCerimonialPoint.Size = new System.Drawing.Size(121, 21);
            this.cbbCerimonialPoint.TabIndex = 54;
            // 
            // btnAddSprint
            // 
            this.btnAddSprint.Location = new System.Drawing.Point(3, 23);
            this.btnAddSprint.Name = "btnAddSprint";
            this.btnAddSprint.Size = new System.Drawing.Size(121, 23);
            this.btnAddSprint.TabIndex = 46;
            this.btnAddSprint.Text = "Adicionar Sprint";
            this.btnAddSprint.UseVisualStyleBackColor = true;
            this.btnAddSprint.Click += new System.EventHandler(this.BtnAddSprint_Click);
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadXml.Location = new System.Drawing.Point(147, 465);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(103, 23);
            this.btnLoadXml.TabIndex = 47;
            this.btnLoadXml.Text = "Carregar config.";
            this.btnLoadXml.UseVisualStyleBackColor = true;
            this.btnLoadXml.Click += new System.EventHandler(this.BtnLoadXml_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(521, 465);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 48;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbSmPoints);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txbAcceptedPointsInvestment);
            this.groupBox4.Controls.Add(this.cbbCerimonialPoint);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txbAcceptedPointsExpense);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(271, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 137);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pontuações";
            // 
            // txbSmPoints
            // 
            this.txbSmPoints.Location = new System.Drawing.Point(91, 78);
            this.txbSmPoints.Name = "txbSmPoints";
            this.txbSmPoints.Size = new System.Drawing.Size(121, 20);
            this.txbSmPoints.TabIndex = 53;
            this.txbSmPoints.Text = "6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Pts. SM";
            // 
            // pbxSprintImage
            // 
            this.pbxSprintImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxSprintImage.Location = new System.Drawing.Point(526, 237);
            this.pbxSprintImage.Name = "pbxSprintImage";
            this.pbxSprintImage.Size = new System.Drawing.Size(272, 171);
            this.pbxSprintImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSprintImage.TabIndex = 52;
            this.pbxSprintImage.TabStop = false;
            // 
            // btnSprintImage
            // 
            this.btnSprintImage.Location = new System.Drawing.Point(271, 331);
            this.btnSprintImage.Name = "btnSprintImage";
            this.btnSprintImage.Size = new System.Drawing.Size(103, 23);
            this.btnSprintImage.TabIndex = 53;
            this.btnSprintImage.Text = "Escolher imagem";
            this.btnSprintImage.UseVisualStyleBackColor = true;
            this.btnSprintImage.Click += new System.EventHandler(this.BtnSprintImage_Click);
            // 
            // lsbSprints
            // 
            this.lsbSprints.FormattingEnabled = true;
            this.lsbSprints.Location = new System.Drawing.Point(4, 44);
            this.lsbSprints.Name = "lsbSprints";
            this.lsbSprints.Size = new System.Drawing.Size(120, 95);
            this.lsbSprints.TabIndex = 55;
            this.lsbSprints.SelectedIndexChanged += new System.EventHandler(this.LsbSprints_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAddSprint);
            this.splitContainer1.Panel1.Controls.Add(this.lsbSprints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.btnSprintImage);
            this.splitContainer1.Panel2.Controls.Add(this.pbxSprintImage);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.txbObs);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(942, 413);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 44);
            this.label3.TabIndex = 54;
            this.label3.Text = "Escolha a imagem com as US que foram aceitas mostrando o tipo de faturamento (INV" +
    " / DES)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpIniDate);
            this.groupBox1.Controls.Add(this.txbSprintDays);
            this.groupBox1.Controls.Add(this.cbbSprintRanges);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 139);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datas";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 504);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Os arquivos serão exportados para:";
            // 
            // VariosRelatoriosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 526);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLoadXml);
            this.Controls.Add(this.btnGenerateAll);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.lblOutputDocPath);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Name = "VariosRelatoriosForm";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSprintImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateAll;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.TextBox txbAbsence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Label lblOutputDocPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpIniDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cbbSprintRanges;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txbSprintDays;
        private System.Windows.Forms.Button btnAddSprint;
        private System.Windows.Forms.ListBox lsbDevTeam;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbAcceptedPointsExpense;
        private System.Windows.Forms.RichTextBox txbObs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadXml;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbSmPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAcceptedPointsInvestment;
        private System.Windows.Forms.ComboBox cbbCerimonialPoint;
        private System.Windows.Forms.Button btnSprintImage;
        private System.Windows.Forms.PictureBox pbxSprintImage;
        private System.Windows.Forms.ListBox lsbSprints;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}

