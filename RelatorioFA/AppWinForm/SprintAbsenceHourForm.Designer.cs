
namespace RelatorioFA.AppWinForm
{
    partial class SprintAbsenceHourForm
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
            this.btnPreviousForm = new System.Windows.Forms.Button();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.lsbSprints = new System.Windows.Forms.ListBox();
            this.btnUpdateSprint = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbbPartners = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txbExtraHour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lsbDevTeam = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txbAbsence = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreviousForm
            // 
            this.btnPreviousForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousForm.Location = new System.Drawing.Point(12, 485);
            this.btnPreviousForm.Name = "btnPreviousForm";
            this.btnPreviousForm.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousForm.TabIndex = 79;
            this.btnPreviousForm.Text = "<- Rtornar";
            this.btnPreviousForm.UseVisualStyleBackColor = true;
            this.btnPreviousForm.Click += new System.EventHandler(this.BtnPreviousForm_Click);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(9, 33);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 416);
            this.txbResult.TabIndex = 54;
            this.txbResult.Text = "";
            // 
            // lsbSprints
            // 
            this.lsbSprints.FormattingEnabled = true;
            this.lsbSprints.Location = new System.Drawing.Point(305, 32);
            this.lsbSprints.Name = "lsbSprints";
            this.lsbSprints.Size = new System.Drawing.Size(135, 95);
            this.lsbSprints.Sorted = true;
            this.lsbSprints.TabIndex = 56;
            this.lsbSprints.SelectedIndexChanged += new System.EventHandler(this.LsbSprints_SelectedIndexChanged);
            // 
            // btnUpdateSprint
            // 
            this.btnUpdateSprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSprint.Location = new System.Drawing.Point(278, 485);
            this.btnUpdateSprint.Name = "btnUpdateSprint";
            this.btnUpdateSprint.Size = new System.Drawing.Size(120, 23);
            this.btnUpdateSprint.TabIndex = 77;
            this.btnUpdateSprint.Text = "Atualizar";
            this.btnUpdateSprint.UseVisualStyleBackColor = true;
            this.btnUpdateSprint.Click += new System.EventHandler(this.BtnUpdateSprint_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 9);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbbPartners);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lsbSprints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 75;
            // 
            // cbbPartners
            // 
            this.cbbPartners.FormattingEnabled = true;
            this.cbbPartners.Location = new System.Drawing.Point(76, 28);
            this.cbbPartners.Name = "cbbPartners";
            this.cbbPartners.Size = new System.Drawing.Size(193, 21);
            this.cbbPartners.TabIndex = 71;
            this.cbbPartners.SelectedIndexChanged += new System.EventHandler(this.CbbPartners_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Fornecedor";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblMessage);
            this.groupBox5.Controls.Add(this.txbExtraHour);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.lsbDevTeam);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txbAbsence);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(3, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 368);
            this.groupBox5.TabIndex = 69;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Controle de participação";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(6, 241);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(260, 74);
            this.lblMessage.TabIndex = 57;
            this.lblMessage.Text = "Este colaborador fez hora extra?     + 0,5 pts se durante a semana até às 20h;   " +
    "      + 1pt se durante a semana depois das 20h ou final de semana / feriado.";
            // 
            // txbExtraHour
            // 
            this.txbExtraHour.Location = new System.Drawing.Point(113, 318);
            this.txbExtraHour.Name = "txbExtraHour";
            this.txbExtraHour.Size = new System.Drawing.Size(153, 20);
            this.txbExtraHour.TabIndex = 2;
            this.txbExtraHour.Text = "0";
            this.txbExtraHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbExtraHour_KeyPress);
            this.txbExtraHour.Leave += new System.EventHandler(this.TxbExtraHour_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Horas extras (horas)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 21);
            this.label5.TabIndex = 54;
            this.label5.Text = "Este colaborador teve alguma falta?";
            // 
            // lsbDevTeam
            // 
            this.lsbDevTeam.FormattingEnabled = true;
            this.lsbDevTeam.Location = new System.Drawing.Point(9, 63);
            this.lsbDevTeam.Name = "lsbDevTeam";
            this.lsbDevTeam.Size = new System.Drawing.Size(257, 82);
            this.lsbDevTeam.TabIndex = 3;
            this.lsbDevTeam.SelectedIndexChanged += new System.EventHandler(this.LsbDevTeam_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(268, 39);
            this.label19.TabIndex = 43;
            this.label19.Text = "Selecione um colaborado e preencha sua participação na sprint";
            // 
            // txbAbsence
            // 
            this.txbAbsence.Location = new System.Drawing.Point(113, 208);
            this.txbAbsence.Name = "txbAbsence";
            this.txbAbsence.Size = new System.Drawing.Size(153, 20);
            this.txbAbsence.TabIndex = 1;
            this.txbAbsence.Text = "0";
            this.txbAbsence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbAbsence_KeyPress);
            this.txbAbsence.Leave += new System.EventHandler(this.TxbAbsence_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ausências (dias)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Sprints adicionadas";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Log:";
            // 
            // lblScreen
            // 
            this.lblScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(696, 511);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(42, 13);
            this.lblScreen.TabIndex = 78;
            this.lblScreen.Text = "Tela 1/";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(544, 485);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(103, 23);
            this.btnGenerate.TabIndex = 58;
            this.btnGenerate.Text = "Gerar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(418, 485);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 59;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(667, 485);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 60;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // SprintAbsenceHourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnPreviousForm);
            this.Controls.Add(this.btnUpdateSprint);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblScreen);
            this.Name = "SprintAbsenceHourForm";
            this.Text = "SprintAbsenceHourForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.ListBox lsbSprints;
        private System.Windows.Forms.Button btnUpdateSprint;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lsbDevTeam;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txbAbsence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPartners;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txbExtraHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
    }
}