﻿
namespace RelatorioFA.AppWinForm
{
    partial class SprintDevOpsForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txbObs = new System.Windows.Forms.RichTextBox();
            this.lsbSprints = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbOpsSupportUst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbOpsWarningUst = new System.Windows.Forms.TextBox();
            this.txbOpsActuationUst = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbOpsDevsCount = new System.Windows.Forms.TextBox();
            this.txbOpsUsUst = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPartners = new System.Windows.Forms.ComboBox();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.btnPreviousForm = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnChangeConfigFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Sprints adicionadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Log:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.lsbSprints);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 63;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txbObs);
            this.groupBox5.Location = new System.Drawing.Point(3, 275);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 150);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Alguma observação sobre a sprint?";
            // 
            // txbObs
            // 
            this.txbObs.Location = new System.Drawing.Point(12, 30);
            this.txbObs.Name = "txbObs";
            this.txbObs.Size = new System.Drawing.Size(262, 114);
            this.txbObs.TabIndex = 6;
            this.txbObs.Text = "";
            this.txbObs.Leave += new System.EventHandler(this.TxbObs_Leave);
            // 
            // lsbSprints
            // 
            this.lsbSprints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbSprints.FormattingEnabled = true;
            this.lsbSprints.Location = new System.Drawing.Point(305, 33);
            this.lsbSprints.Name = "lsbSprints";
            this.lsbSprints.Size = new System.Drawing.Size(135, 95);
            this.lsbSprints.TabIndex = 56;
            this.lsbSprints.SelectedIndexChanged += new System.EventHandler(this.LsbSprints_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txbOpsSupportUst);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txbOpsWarningUst);
            this.groupBox2.Controls.Add(this.txbOpsActuationUst);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbOpsDevsCount);
            this.groupBox2.Controls.Add(this.txbOpsUsUst);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(3, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 164);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados de pagamento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "UST suporte";
            // 
            // txbOpsSupportUst
            // 
            this.txbOpsSupportUst.Location = new System.Drawing.Point(112, 22);
            this.txbOpsSupportUst.Name = "txbOpsSupportUst";
            this.txbOpsSupportUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsSupportUst.TabIndex = 1;
            this.txbOpsSupportUst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbOpsSupportUst_KeyPress);
            this.txbOpsSupportUst.Leave += new System.EventHandler(this.TxbOpsSupportUst_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "UST sobreaviso";
            // 
            // txbOpsWarningUst
            // 
            this.txbOpsWarningUst.Location = new System.Drawing.Point(112, 48);
            this.txbOpsWarningUst.Name = "txbOpsWarningUst";
            this.txbOpsWarningUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsWarningUst.TabIndex = 2;
            this.txbOpsWarningUst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbOpsWarningUst_KeyPress);
            this.txbOpsWarningUst.Leave += new System.EventHandler(this.TxbOpsWarningUst_Leave);
            // 
            // txbOpsActuationUst
            // 
            this.txbOpsActuationUst.Location = new System.Drawing.Point(112, 76);
            this.txbOpsActuationUst.Name = "txbOpsActuationUst";
            this.txbOpsActuationUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsActuationUst.TabIndex = 3;
            this.txbOpsActuationUst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbOpsActuationUst_KeyPress);
            this.txbOpsActuationUst.Leave += new System.EventHandler(this.TxbOpsActuationUst_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Qtd. plantonistas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "UST acionamento";
            // 
            // txbOpsDevsCount
            // 
            this.txbOpsDevsCount.Location = new System.Drawing.Point(111, 132);
            this.txbOpsDevsCount.Name = "txbOpsDevsCount";
            this.txbOpsDevsCount.Size = new System.Drawing.Size(121, 20);
            this.txbOpsDevsCount.TabIndex = 5;
            this.txbOpsDevsCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbOpsDevsCount_KeyPress);
            this.txbOpsDevsCount.Leave += new System.EventHandler(this.TxbOpsDevsCount_Leave);
            // 
            // txbOpsUsUst
            // 
            this.txbOpsUsUst.Location = new System.Drawing.Point(112, 102);
            this.txbOpsUsUst.Name = "txbOpsUsUst";
            this.txbOpsUsUst.Size = new System.Drawing.Size(121, 20);
            this.txbOpsUsUst.TabIndex = 4;
            this.txbOpsUsUst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbOpsUsUst_KeyPress);
            this.txbOpsUsUst.Leave += new System.EventHandler(this.TxbOpsUsUst_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "UST US";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbbPartners);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 74);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Escolha o fornecedor na lista abaixo e preencha os dados conforme solicitados";
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
            // cbbPartners
            // 
            this.cbbPartners.FormattingEnabled = true;
            this.cbbPartners.Location = new System.Drawing.Point(110, 39);
            this.cbbPartners.Name = "cbbPartners";
            this.cbbPartners.Size = new System.Drawing.Size(121, 21);
            this.cbbPartners.Sorted = true;
            this.cbbPartners.TabIndex = 0;
            this.cbbPartners.SelectedIndexChanged += new System.EventHandler(this.CbbPartners_SelectedIndexChanged);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(11, 33);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 416);
            this.txbResult.TabIndex = 54;
            this.txbResult.Text = "";
            // 
            // btnPreviousForm
            // 
            this.btnPreviousForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousForm.Location = new System.Drawing.Point(12, 488);
            this.btnPreviousForm.Name = "btnPreviousForm";
            this.btnPreviousForm.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousForm.TabIndex = 66;
            this.btnPreviousForm.Text = "<- Retornar";
            this.btnPreviousForm.UseVisualStyleBackColor = true;
            this.btnPreviousForm.Click += new System.EventHandler(this.BtnPreviousForm_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(669, 488);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 69;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(469, 488);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 68;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(583, 488);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 67;
            this.btnGenerate.Text = "Gerar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(696, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Tela 2/2";
            // 
            // btnChangeConfigFolder
            // 
            this.btnChangeConfigFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeConfigFolder.Location = new System.Drawing.Point(93, 488);
            this.btnChangeConfigFolder.Name = "btnChangeConfigFolder";
            this.btnChangeConfigFolder.Size = new System.Drawing.Size(131, 23);
            this.btnChangeConfigFolder.TabIndex = 71;
            this.btnChangeConfigFolder.Text = "Carregar configuração";
            this.btnChangeConfigFolder.UseVisualStyleBackColor = true;
            this.btnChangeConfigFolder.Click += new System.EventHandler(this.BtnChangeConfigFolder_Click);
            // 
            // SprintDevOpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.btnChangeConfigFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnPreviousForm);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SprintDevOpsForm";
            this.Text = "SprintDevOpsForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.ListBox lsbSprints;
        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPartners;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbOpsWarningUst;
        private System.Windows.Forms.TextBox txbOpsActuationUst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbOpsDevsCount;
        private System.Windows.Forms.TextBox txbOpsUsUst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox txbObs;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChangeConfigFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbOpsSupportUst;
    }
}