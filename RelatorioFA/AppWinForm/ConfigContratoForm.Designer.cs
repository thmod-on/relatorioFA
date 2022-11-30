
namespace RelatorioFA.AppWinForm
{
    partial class ConfigContratoForm
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
            this.btnPreviousForm = new System.Windows.Forms.Button();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.gpbContracts = new System.Windows.Forms.GroupBox();
            this.btnRemoveContract = new System.Windows.Forms.Button();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txbContractUstValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbContractSap = new System.Windows.Forms.TextBox();
            this.lsbPartners = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lsbBatch = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveBatch = new System.Windows.Forms.Button();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.cbbAvaliableBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContracts = new System.Windows.Forms.Label();
            this.lsbContracts = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNextForm = new System.Windows.Forms.Button();
            this.gpbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScreen
            // 
            this.lblScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(726, 510);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(48, 13);
            this.lblScreen.TabIndex = 77;
            this.lblScreen.Text = "Tela 2/3";
            // 
            // btnPreviousForm
            // 
            this.btnPreviousForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviousForm.Location = new System.Drawing.Point(12, 482);
            this.btnPreviousForm.Name = "btnPreviousForm";
            this.btnPreviousForm.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousForm.TabIndex = 73;
            this.btnPreviousForm.Text = "<- Retornar";
            this.btnPreviousForm.UseVisualStyleBackColor = true;
            this.btnPreviousForm.Click += new System.EventHandler(this.BtnPreviousForm_Click);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(11, 33);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 416);
            this.txbResult.TabIndex = 54;
            this.txbResult.Text = "";
            // 
            // gpbContracts
            // 
            this.gpbContracts.Controls.Add(this.btnRemoveContract);
            this.gpbContracts.Controls.Add(this.btnAddContract);
            this.gpbContracts.Controls.Add(this.label12);
            this.gpbContracts.Controls.Add(this.txbContractUstValue);
            this.gpbContracts.Controls.Add(this.label11);
            this.gpbContracts.Controls.Add(this.txbContractSap);
            this.gpbContracts.Location = new System.Drawing.Point(9, 71);
            this.gpbContracts.Name = "gpbContracts";
            this.gpbContracts.Size = new System.Drawing.Size(280, 162);
            this.gpbContracts.TabIndex = 67;
            this.gpbContracts.TabStop = false;
            this.gpbContracts.Text = "Cadastre agora os contratos para cada fornecedor";
            // 
            // btnRemoveContract
            // 
            this.btnRemoveContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveContract.Location = new System.Drawing.Point(6, 133);
            this.btnRemoveContract.Name = "btnRemoveContract";
            this.btnRemoveContract.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveContract.TabIndex = 79;
            this.btnRemoveContract.Text = "Remover contrato";
            this.btnRemoveContract.UseVisualStyleBackColor = true;
            this.btnRemoveContract.Click += new System.EventHandler(this.BtnRemoveContract_Click);
            // 
            // btnAddContract
            // 
            this.btnAddContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddContract.Location = new System.Drawing.Point(154, 133);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(120, 23);
            this.btnAddContract.TabIndex = 78;
            this.btnAddContract.Text = "Adicionar contrato";
            this.btnAddContract.UseVisualStyleBackColor = true;
            this.btnAddContract.Click += new System.EventHandler(this.BtnAddContract_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Valor da UST";
            // 
            // txbContractUstValue
            // 
            this.txbContractUstValue.Location = new System.Drawing.Point(110, 78);
            this.txbContractUstValue.Name = "txbContractUstValue";
            this.txbContractUstValue.Size = new System.Drawing.Size(121, 20);
            this.txbContractUstValue.TabIndex = 19;
            this.txbContractUstValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbContractUstValue_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Número no SAP";
            // 
            // txbContractSap
            // 
            this.txbContractSap.Location = new System.Drawing.Point(110, 52);
            this.txbContractSap.Name = "txbContractSap";
            this.txbContractSap.Size = new System.Drawing.Size(121, 20);
            this.txbContractSap.TabIndex = 17;
            // 
            // lsbPartners
            // 
            this.lsbPartners.FormattingEnabled = true;
            this.lsbPartners.Location = new System.Drawing.Point(305, 24);
            this.lsbPartners.Name = "lsbPartners";
            this.lsbPartners.Size = new System.Drawing.Size(135, 95);
            this.lsbPartners.Sorted = true;
            this.lsbPartners.TabIndex = 56;
            this.lsbPartners.SelectedIndexChanged += new System.EventHandler(this.LsbPartners_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(12, 11);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblBatch);
            this.splitContainer1.Panel1.Controls.Add(this.lsbBatch);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblContracts);
            this.splitContainer1.Panel1.Controls.Add(this.lsbContracts);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lsbPartners);
            this.splitContainer1.Panel1.Controls.Add(this.gpbContracts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 71;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(302, 338);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(93, 13);
            this.lblBatch.TabIndex = 82;
            this.lblBatch.Text = "Lotes adicionados";
            // 
            // lsbBatch
            // 
            this.lsbBatch.FormattingEnabled = true;
            this.lsbBatch.Location = new System.Drawing.Point(305, 354);
            this.lsbBatch.Name = "lsbBatch";
            this.lsbBatch.Size = new System.Drawing.Size(135, 95);
            this.lsbBatch.Sorted = true;
            this.lsbBatch.TabIndex = 81;
            this.lsbBatch.SelectedIndexChanged += new System.EventHandler(this.LsbBatch_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveBatch);
            this.groupBox1.Controls.Add(this.btnAddBatch);
            this.groupBox1.Controls.Add(this.cbbAvaliableBatch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 162);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Para cada contrato cadastrado, defina os lotes a serem utilizados";
            // 
            // btnRemoveBatch
            // 
            this.btnRemoveBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBatch.Location = new System.Drawing.Point(6, 133);
            this.btnRemoveBatch.Name = "btnRemoveBatch";
            this.btnRemoveBatch.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveBatch.TabIndex = 79;
            this.btnRemoveBatch.Text = "Remover lote";
            this.btnRemoveBatch.UseVisualStyleBackColor = true;
            this.btnRemoveBatch.Click += new System.EventHandler(this.BtnRemoveBatch_Click);
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBatch.Location = new System.Drawing.Point(154, 133);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(120, 23);
            this.btnAddBatch.TabIndex = 78;
            this.btnAddBatch.Text = "Adicionar lote";
            this.btnAddBatch.UseVisualStyleBackColor = true;
            this.btnAddBatch.Click += new System.EventHandler(this.BtnAddBatch_Click);
            // 
            // cbbAvaliableBatch
            // 
            this.cbbAvaliableBatch.FormattingEnabled = true;
            this.cbbAvaliableBatch.Location = new System.Drawing.Point(112, 63);
            this.cbbAvaliableBatch.Name = "cbbAvaliableBatch";
            this.cbbAvaliableBatch.Size = new System.Drawing.Size(121, 21);
            this.cbbAvaliableBatch.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Lote disponível";
            // 
            // lblContracts
            // 
            this.lblContracts.AutoSize = true;
            this.lblContracts.Location = new System.Drawing.Point(302, 122);
            this.lblContracts.Name = "lblContracts";
            this.lblContracts.Size = new System.Drawing.Size(112, 13);
            this.lblContracts.TabIndex = 70;
            this.lblContracts.Text = "Contratos adicionados";
            // 
            // lsbContracts
            // 
            this.lsbContracts.FormattingEnabled = true;
            this.lsbContracts.Location = new System.Drawing.Point(305, 138);
            this.lsbContracts.Name = "lsbContracts";
            this.lsbContracts.Size = new System.Drawing.Size(135, 95);
            this.lsbContracts.Sorted = true;
            this.lsbContracts.TabIndex = 69;
            this.lsbContracts.SelectedIndexChanged += new System.EventHandler(this.LsbContracts_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Fornecedores adicionados";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Log:";
            // 
            // btnNextForm
            // 
            this.btnNextForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextForm.Location = new System.Drawing.Point(671, 482);
            this.btnNextForm.Name = "btnNextForm";
            this.btnNextForm.Size = new System.Drawing.Size(103, 23);
            this.btnNextForm.TabIndex = 78;
            this.btnNextForm.Text = "Avançar ->";
            this.btnNextForm.UseVisualStyleBackColor = true;
            this.btnNextForm.Click += new System.EventHandler(this.BtnNextForm_Click);
            // 
            // ConfigContratoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.btnNextForm);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.btnPreviousForm);
            this.Name = "ConfigContratoForm";
            this.Text = "ConfigContratoForm";
            this.gpbContracts.ResumeLayout(false);
            this.gpbContracts.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
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

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.GroupBox gpbContracts;
        private System.Windows.Forms.ListBox lsbPartners;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContracts;
        private System.Windows.Forms.ListBox lsbContracts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbContractUstValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbContractSap;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.Button btnRemoveContract;
        private System.Windows.Forms.Button btnNextForm;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.ListBox lsbBatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveBatch;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.ComboBox cbbAvaliableBatch;
        private System.Windows.Forms.Label label3;
    }
}