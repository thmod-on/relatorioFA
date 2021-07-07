
namespace RelatorioFA.AppWinForm
{
    partial class SprintPontosObsForm
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
            this.lblScreen = new System.Windows.Forms.Label();
            this.btnNextForm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.txbObs = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbSmPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbAcceptedPointsInvestment = new System.Windows.Forms.TextBox();
            this.cbbCerimonialPoint = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txbAcceptedPointsExpense = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lsbSprints = new System.Windows.Forms.ListBox();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.btnAddSprint = new System.Windows.Forms.Button();
            this.btnPreviousForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScreen
            // 
            this.lblScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(696, 511);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(42, 13);
            this.lblScreen.TabIndex = 73;
            this.lblScreen.Text = "Tela 1/";
            // 
            // btnNextForm
            // 
            this.btnNextForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextForm.Enabled = false;
            this.btnNextForm.Location = new System.Drawing.Point(699, 485);
            this.btnNextForm.Name = "btnNextForm";
            this.btnNextForm.Size = new System.Drawing.Size(75, 23);
            this.btnNextForm.TabIndex = 71;
            this.btnNextForm.Text = "Avançar ->";
            this.btnNextForm.UseVisualStyleBackColor = true;
            this.btnNextForm.Click += new System.EventHandler(this.BtnNextForm_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Sprints adicionadas";
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
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txbObs);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lsbSprints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Observações da sprint";
            // 
            // txbObs
            // 
            this.txbObs.Enabled = false;
            this.txbObs.Location = new System.Drawing.Point(2, 197);
            this.txbObs.Name = "txbObs";
            this.txbObs.Size = new System.Drawing.Size(284, 252);
            this.txbObs.TabIndex = 76;
            this.txbObs.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbSmPoints);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txbAcceptedPointsInvestment);
            this.groupBox4.Controls.Add(this.cbbCerimonialPoint);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txbAcceptedPointsExpense);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 137);
            this.groupBox4.TabIndex = 75;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pontuações";
            // 
            // txbSmPoints
            // 
            this.txbSmPoints.Enabled = false;
            this.txbSmPoints.Location = new System.Drawing.Point(91, 78);
            this.txbSmPoints.Name = "txbSmPoints";
            this.txbSmPoints.Size = new System.Drawing.Size(183, 20);
            this.txbSmPoints.TabIndex = 53;
            this.txbSmPoints.Text = "6";
            this.txbSmPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbSmPoints_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Pts. SM";
            // 
            // txbAcceptedPointsInvestment
            // 
            this.txbAcceptedPointsInvestment.Enabled = false;
            this.txbAcceptedPointsInvestment.Location = new System.Drawing.Point(92, 22);
            this.txbAcceptedPointsInvestment.Name = "txbAcceptedPointsInvestment";
            this.txbAcceptedPointsInvestment.Size = new System.Drawing.Size(182, 20);
            this.txbAcceptedPointsInvestment.TabIndex = 51;
            this.txbAcceptedPointsInvestment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbAcceptedPointsInvestment_KeyPress);
            // 
            // cbbCerimonialPoint
            // 
            this.cbbCerimonialPoint.Enabled = false;
            this.cbbCerimonialPoint.FormattingEnabled = true;
            this.cbbCerimonialPoint.Location = new System.Drawing.Point(90, 106);
            this.cbbCerimonialPoint.Name = "cbbCerimonialPoint";
            this.cbbCerimonialPoint.Size = new System.Drawing.Size(184, 21);
            this.cbbCerimonialPoint.TabIndex = 54;
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
            // txbAcceptedPointsExpense
            // 
            this.txbAcceptedPointsExpense.Enabled = false;
            this.txbAcceptedPointsExpense.Location = new System.Drawing.Point(91, 51);
            this.txbAcceptedPointsExpense.Name = "txbAcceptedPointsExpense";
            this.txbAcceptedPointsExpense.Size = new System.Drawing.Size(183, 20);
            this.txbAcceptedPointsExpense.TabIndex = 2;
            this.txbAcceptedPointsExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbAcceptedPointsExpense_KeyPress);
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
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "+1 Cerimônias";
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
            // btnAddSprint
            // 
            this.btnAddSprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSprint.Location = new System.Drawing.Point(344, 485);
            this.btnAddSprint.Name = "btnAddSprint";
            this.btnAddSprint.Size = new System.Drawing.Size(75, 23);
            this.btnAddSprint.TabIndex = 72;
            this.btnAddSprint.Text = "Adicionar";
            this.btnAddSprint.UseVisualStyleBackColor = true;
            this.btnAddSprint.Click += new System.EventHandler(this.BtnAddSprint_Click);
            // 
            // btnPreviousForm
            // 
            this.btnPreviousForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviousForm.Location = new System.Drawing.Point(12, 485);
            this.btnPreviousForm.Name = "btnPreviousForm";
            this.btnPreviousForm.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousForm.TabIndex = 74;
            this.btnPreviousForm.Text = "<- Retornar";
            this.btnPreviousForm.UseVisualStyleBackColor = true;
            this.btnPreviousForm.Click += new System.EventHandler(this.BtnPreviousForm_Click);
            // 
            // SprintPontosObsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.btnPreviousForm);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.btnNextForm);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnAddSprint);
            this.Name = "SprintPontosObsForm";
            this.Text = "SprintPontosObsForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btnNextForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lsbSprints;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.Button btnAddSprint;
        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbSmPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAcceptedPointsInvestment;
        private System.Windows.Forms.ComboBox cbbCerimonialPoint;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txbAcceptedPointsExpense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txbObs;
    }
}