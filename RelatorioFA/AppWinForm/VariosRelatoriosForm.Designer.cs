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
            this.txbTeamName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbAcceptedPointsInvestment = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbAcceptedPointsExpense = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txbObs = new System.Windows.Forms.RichTextBox();
            this.txbSprintDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txbAuthor = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbbContractType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lsbDevTeam = new System.Windows.Forms.ListBox();
            this.btnAddSprint = new System.Windows.Forms.Button();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbSmPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCerimonialPoint = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Release / Sprint";
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Location = new System.Drawing.Point(257, 384);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(103, 23);
            this.btnGenerateAll.TabIndex = 20;
            this.btnGenerateAll.Text = "Gerar todos";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(499, 44);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(219, 395);
            this.txbResult.TabIndex = 3;
            this.txbResult.Text = "";
            // 
            // txbAbsence
            // 
            this.txbAbsence.Location = new System.Drawing.Point(90, 134);
            this.txbAbsence.Name = "txbAbsence";
            this.txbAbsence.Size = new System.Drawing.Size(121, 20);
            this.txbAbsence.TabIndex = 7;
            this.txbAbsence.Leave += new System.EventHandler(this.TxbAbsence_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ausências";
            // 
            // txbTeamName
            // 
            this.txbTeamName.Location = new System.Drawing.Point(91, 19);
            this.txbTeamName.Name = "txbTeamName";
            this.txbTeamName.Size = new System.Drawing.Size(121, 20);
            this.txbTeamName.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Nome do time";
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(257, 355);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 29;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // lblOutputDocPath
            // 
            this.lblOutputDocPath.Location = new System.Drawing.Point(375, 324);
            this.lblOutputDocPath.Name = "lblOutputDocPath";
            this.lblOutputDocPath.Size = new System.Drawing.Size(104, 117);
            this.lblOutputDocPath.TabIndex = 30;
            this.lblOutputDocPath.Text = "Exportar para";
            this.lblOutputDocPath.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Data inicial";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Data final";
            // 
            // dtpIniDate
            // 
            this.dtpIniDate.CustomFormat = "";
            this.dtpIniDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIniDate.Location = new System.Drawing.Point(95, 54);
            this.dtpIniDate.Name = "dtpIniDate";
            this.dtpIniDate.Size = new System.Drawing.Size(121, 20);
            this.dtpIniDate.TabIndex = 33;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(94, 80);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 34;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.DtpEndDate_ValueChanged);
            // 
            // cbbSprintRanges
            // 
            this.cbbSprintRanges.FormattingEnabled = true;
            this.cbbSprintRanges.ItemHeight = 13;
            this.cbbSprintRanges.Location = new System.Drawing.Point(94, 29);
            this.cbbSprintRanges.Name = "cbbSprintRanges";
            this.cbbSprintRanges.Size = new System.Drawing.Size(121, 21);
            this.cbbSprintRanges.TabIndex = 35;
            this.cbbSprintRanges.SelectedIndexChanged += new System.EventHandler(this.CbbSprintRanges_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "+1 Cerimônias";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "Time";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbAcceptedPointsInvestment);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbbSprintRanges);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpIniDate);
            this.groupBox2.Controls.Add(this.txbAcceptedPointsExpense);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txbObs);
            this.groupBox2.Controls.Add(this.txbSprintDays);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Location = new System.Drawing.Point(11, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 319);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sprint";
            // 
            // txbAcceptedPointsInvestment
            // 
            this.txbAcceptedPointsInvestment.Location = new System.Drawing.Point(93, 138);
            this.txbAcceptedPointsInvestment.Name = "txbAcceptedPointsInvestment";
            this.txbAcceptedPointsInvestment.Size = new System.Drawing.Size(121, 20);
            this.txbAcceptedPointsInvestment.TabIndex = 51;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 141);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Pts. aceitos INV";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Pts. aceitos DES";
            // 
            // txbAcceptedPointsExpense
            // 
            this.txbAcceptedPointsExpense.Location = new System.Drawing.Point(92, 167);
            this.txbAcceptedPointsExpense.Name = "txbAcceptedPointsExpense";
            this.txbAcceptedPointsExpense.Size = new System.Drawing.Size(121, 20);
            this.txbAcceptedPointsExpense.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Dias da sprint";
            // 
            // txbObs
            // 
            this.txbObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txbObs.Location = new System.Drawing.Point(8, 215);
            this.txbObs.Name = "txbObs";
            this.txbObs.Size = new System.Drawing.Size(205, 98);
            this.txbObs.TabIndex = 4;
            this.txbObs.Text = "";
            // 
            // txbSprintDays
            // 
            this.txbSprintDays.Location = new System.Drawing.Point(93, 108);
            this.txbSprintDays.Name = "txbSprintDays";
            this.txbSprintDays.Size = new System.Drawing.Size(121, 20);
            this.txbSprintDays.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Observações";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txbAuthor);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txbTeamName);
            this.groupBox3.Controls.Add(this.cbbContractType);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 102);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Relatório";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Coordenador";
            // 
            // txbAuthor
            // 
            this.txbAuthor.Enabled = false;
            this.txbAuthor.Location = new System.Drawing.Point(91, 44);
            this.txbAuthor.Name = "txbAuthor";
            this.txbAuthor.Size = new System.Drawing.Size(121, 20);
            this.txbAuthor.TabIndex = 26;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 76);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 52;
            this.label23.Text = "Tipo";
            this.label23.Visible = false;
            // 
            // cbbContractType
            // 
            this.cbbContractType.FormattingEnabled = true;
            this.cbbContractType.ItemHeight = 13;
            this.cbbContractType.Location = new System.Drawing.Point(91, 70);
            this.cbbContractType.Name = "cbbContractType";
            this.cbbContractType.Size = new System.Drawing.Size(121, 21);
            this.cbbContractType.TabIndex = 51;
            this.cbbContractType.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbbCerimonialPoint);
            this.groupBox5.Controls.Add(this.lsbDevTeam);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txbAbsence);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(257, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 211);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Time";
            // 
            // lsbDevTeam
            // 
            this.lsbDevTeam.FormattingEnabled = true;
            this.lsbDevTeam.Location = new System.Drawing.Point(9, 41);
            this.lsbDevTeam.Name = "lsbDevTeam";
            this.lsbDevTeam.Size = new System.Drawing.Size(203, 82);
            this.lsbDevTeam.TabIndex = 53;
            this.lsbDevTeam.SelectedIndexChanged += new System.EventHandler(this.LsbDevTeam_SelectedIndexChanged);
            // 
            // btnAddSprint
            // 
            this.btnAddSprint.Location = new System.Drawing.Point(257, 324);
            this.btnAddSprint.Name = "btnAddSprint";
            this.btnAddSprint.Size = new System.Drawing.Size(103, 23);
            this.btnAddSprint.TabIndex = 46;
            this.btnAddSprint.Text = "Adicionar Sprint";
            this.btnAddSprint.UseVisualStyleBackColor = true;
            this.btnAddSprint.Click += new System.EventHandler(this.BtnAddSprint_Click);
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.Location = new System.Drawing.Point(499, 12);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(103, 23);
            this.btnLoadXml.TabIndex = 47;
            this.btnLoadXml.Text = "Carregar config.";
            this.btnLoadXml.UseVisualStyleBackColor = true;
            this.btnLoadXml.Click += new System.EventHandler(this.BtnLoadXml_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(257, 413);
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
            this.groupBox4.Location = new System.Drawing.Point(257, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 77);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scrum Msater";
            // 
            // txbSmPoints
            // 
            this.txbSmPoints.Location = new System.Drawing.Point(90, 13);
            this.txbSmPoints.Name = "txbSmPoints";
            this.txbSmPoints.Size = new System.Drawing.Size(118, 20);
            this.txbSmPoints.TabIndex = 53;
            this.txbSmPoints.Text = "6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Pts. SM";
            // 
            // cbbCerimonialPoint
            // 
            this.cbbCerimonialPoint.FormattingEnabled = true;
            this.cbbCerimonialPoint.Location = new System.Drawing.Point(90, 164);
            this.cbbCerimonialPoint.Name = "cbbCerimonialPoint";
            this.cbbCerimonialPoint.Size = new System.Drawing.Size(121, 21);
            this.cbbCerimonialPoint.TabIndex = 54;
            // 
            // VariosRelatoriosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.btnLoadXml);
            this.Controls.Add(this.btnAddSprint);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblOutputDocPath);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnGenerateAll);
            this.Controls.Add(this.txbResult);
            this.Name = "VariosRelatoriosForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateAll;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.TextBox txbAbsence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTeamName;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txbAuthor;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txbSprintDays;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbbContractType;
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
    }
}

