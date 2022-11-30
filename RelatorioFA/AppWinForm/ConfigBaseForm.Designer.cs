
namespace RelatorioFA.AppWinForm
{
    partial class ConfigBaseForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbTeamName = new System.Windows.Forms.TextBox();
            this.txbAreaName = new System.Windows.Forms.TextBox();
            this.txbAuthorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbPartners = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLogomarcaParceiro = new System.Windows.Forms.Button();
            this.picBoxLogomarca = new System.Windows.Forms.PictureBox();
            this.txbPartnerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.btnAddSprint = new System.Windows.Forms.Button();
            this.btnNextForm = new System.Windows.Forms.Button();
            this.btnRemovePrtner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogomarca)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lsbPartners);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Fornecedores adicionados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbTeamName);
            this.groupBox1.Controls.Add(this.txbAreaName);
            this.groupBox1.Controls.Add(this.txbAuthorName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Me conte sobre você";
            // 
            // txbTeamName
            // 
            this.txbTeamName.Location = new System.Drawing.Point(100, 108);
            this.txbTeamName.Name = "txbTeamName";
            this.txbTeamName.Size = new System.Drawing.Size(175, 20);
            this.txbTeamName.TabIndex = 3;
            // 
            // txbAreaName
            // 
            this.txbAreaName.Location = new System.Drawing.Point(100, 73);
            this.txbAreaName.Name = "txbAreaName";
            this.txbAreaName.Size = new System.Drawing.Size(175, 20);
            this.txbAreaName.TabIndex = 2;
            // 
            // txbAuthorName
            // 
            this.txbAuthorName.Location = new System.Drawing.Point(100, 41);
            this.txbAuthorName.Name = "txbAuthorName";
            this.txbAuthorName.Size = new System.Drawing.Size(175, 20);
            this.txbAuthorName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.05F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "(Governo, Mobile, ...)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.05F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "(ACAFS, AUDAZ, ...)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Área";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Autor";
            // 
            // lsbPartners
            // 
            this.lsbPartners.FormattingEnabled = true;
            this.lsbPartners.Location = new System.Drawing.Point(305, 33);
            this.lsbPartners.Name = "lsbPartners";
            this.lsbPartners.Size = new System.Drawing.Size(132, 95);
            this.lsbPartners.Sorted = true;
            this.lsbPartners.TabIndex = 56;
            this.lsbPartners.SelectedIndexChanged += new System.EventHandler(this.LsbPartners_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnLogomarcaParceiro);
            this.groupBox2.Controls.Add(this.picBoxLogomarca);
            this.groupBox2.Controls.Add(this.txbPartnerName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(3, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 272);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agora os parceiros que trabalham com você";
            // 
            // btnLogomarcaParceiro
            // 
            this.btnLogomarcaParceiro.Location = new System.Drawing.Point(154, 100);
            this.btnLogomarcaParceiro.Name = "btnLogomarcaParceiro";
            this.btnLogomarcaParceiro.Size = new System.Drawing.Size(121, 24);
            this.btnLogomarcaParceiro.TabIndex = 6;
            this.btnLogomarcaParceiro.Text = "Adicionar logomarca";
            this.btnLogomarcaParceiro.UseVisualStyleBackColor = true;
            this.btnLogomarcaParceiro.Click += new System.EventHandler(this.BtnLogomarcaParceiro_Click);
            // 
            // picBoxLogomarca
            // 
            this.picBoxLogomarca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxLogomarca.Location = new System.Drawing.Point(7, 136);
            this.picBoxLogomarca.Name = "picBoxLogomarca";
            this.picBoxLogomarca.Size = new System.Drawing.Size(266, 130);
            this.picBoxLogomarca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogomarca.TabIndex = 21;
            this.picBoxLogomarca.TabStop = false;
            // 
            // txbPartnerName
            // 
            this.txbPartnerName.Location = new System.Drawing.Point(100, 48);
            this.txbPartnerName.Name = "txbPartnerName";
            this.txbPartnerName.Size = new System.Drawing.Size(175, 20);
            this.txbPartnerName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nome";
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(7, 33);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 416);
            this.txbResult.TabIndex = 54;
            this.txbResult.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Log:";
            // 
            // lblScreen
            // 
            this.lblScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(726, 510);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(48, 13);
            this.lblScreen.TabIndex = 72;
            this.lblScreen.Text = "Tela 1/3";
            // 
            // btnAddSprint
            // 
            this.btnAddSprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSprint.Location = new System.Drawing.Point(344, 482);
            this.btnAddSprint.Name = "btnAddSprint";
            this.btnAddSprint.Size = new System.Drawing.Size(120, 23);
            this.btnAddSprint.TabIndex = 7;
            this.btnAddSprint.Text = "Adicionar / Atualizar";
            this.btnAddSprint.UseVisualStyleBackColor = true;
            this.btnAddSprint.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnNextForm
            // 
            this.btnNextForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextForm.Enabled = false;
            this.btnNextForm.Location = new System.Drawing.Point(699, 482);
            this.btnNextForm.Name = "btnNextForm";
            this.btnNextForm.Size = new System.Drawing.Size(75, 23);
            this.btnNextForm.TabIndex = 8;
            this.btnNextForm.Text = "Avançar ->";
            this.btnNextForm.UseVisualStyleBackColor = true;
            this.btnNextForm.Click += new System.EventHandler(this.BtnNextForm_Click);
            // 
            // btnRemovePrtner
            // 
            this.btnRemovePrtner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePrtner.Location = new System.Drawing.Point(218, 482);
            this.btnRemovePrtner.Name = "btnRemovePrtner";
            this.btnRemovePrtner.Size = new System.Drawing.Size(120, 23);
            this.btnRemovePrtner.TabIndex = 73;
            this.btnRemovePrtner.Text = "Remover parceiro";
            this.btnRemovePrtner.UseVisualStyleBackColor = true;
            this.btnRemovePrtner.Click += new System.EventHandler(this.BtnRemovePartner_Click);
            // 
            // ConfigBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.btnRemovePrtner);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.btnAddSprint);
            this.Controls.Add(this.btnNextForm);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfigBaseForm";
            this.Text = "ConfigBaseForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogomarca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lsbPartners;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btnAddSprint;
        private System.Windows.Forms.Button btnNextForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbTeamName;
        private System.Windows.Forms.TextBox txbAreaName;
        private System.Windows.Forms.TextBox txbAuthorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLogomarcaParceiro;
        private System.Windows.Forms.PictureBox picBoxLogomarca;
        private System.Windows.Forms.TextBox txbPartnerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemovePrtner;
    }
}