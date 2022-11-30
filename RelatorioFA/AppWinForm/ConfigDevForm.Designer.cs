namespace RelatorioFA.AppWinForm
{
    partial class ConfigDevForm
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
            this.lblRole = new System.Windows.Forms.Label();
            this.lsbRoles = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lsbPartnerContractBatch = new System.Windows.Forms.ListBox();
            this.gpbRoles = new System.Windows.Forms.GroupBox();
            this.cbbAvaliableRoles = new System.Windows.Forms.ComboBox();
            this.btnRemoveRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDevHouse = new System.Windows.Forms.Label();
            this.gpbDevHouse = new System.Windows.Forms.GroupBox();
            this.btnRemoveHouseDev = new System.Windows.Forms.Button();
            this.ckbHouseDevWorksHalfDay = new System.Windows.Forms.CheckBox();
            this.btnAddHouseDev = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txbHouseDevName = new System.Windows.Forms.TextBox();
            this.lsbHouseDevs = new System.Windows.Forms.ListBox();
            this.gpbDev = new System.Windows.Forms.GroupBox();
            this.btnRemoveDev = new System.Windows.Forms.Button();
            this.ckbDevWorksHalfDay = new System.Windows.Forms.CheckBox();
            this.btnAddDev = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDevName = new System.Windows.Forms.TextBox();
            this.lblDevs = new System.Windows.Forms.Label();
            this.lsbDevs = new System.Windows.Forms.ListBox();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreviousForm = new System.Windows.Forms.Button();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.lblScreen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbRoles.SuspendLayout();
            this.gpbDevHouse.SuspendLayout();
            this.gpbDev.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 11);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblRole);
            this.splitContainer1.Panel1.Controls.Add(this.lsbRoles);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lsbPartnerContractBatch);
            this.splitContainer1.Panel1.Controls.Add(this.gpbRoles);
            this.splitContainer1.Panel1.Controls.Add(this.lblDevHouse);
            this.splitContainer1.Panel1.Controls.Add(this.gpbDevHouse);
            this.splitContainer1.Panel1.Controls.Add(this.lsbHouseDevs);
            this.splitContainer1.Panel1.Controls.Add(this.gpbDev);
            this.splitContainer1.Panel1.Controls.Add(this.lblDevs);
            this.splitContainer1.Panel1.Controls.Add(this.lsbDevs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbResult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 460);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(298, 115);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 13);
            this.lblRole.TabIndex = 92;
            this.lblRole.Text = "Cargo";
            this.lblRole.Visible = false;
            // 
            // lsbRoles
            // 
            this.lsbRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbRoles.FormattingEnabled = true;
            this.lsbRoles.Location = new System.Drawing.Point(301, 131);
            this.lsbRoles.Name = "lsbRoles";
            this.lsbRoles.Size = new System.Drawing.Size(135, 95);
            this.lsbRoles.Sorted = true;
            this.lsbRoles.TabIndex = 91;
            this.lsbRoles.Visible = false;
            this.lsbRoles.SelectedIndexChanged += new System.EventHandler(this.LsbRoles_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Fornecedor - Contrato - Lote";
            this.label4.Visible = false;
            // 
            // lsbPartnerContractBatch
            // 
            this.lsbPartnerContractBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbPartnerContractBatch.FormattingEnabled = true;
            this.lsbPartnerContractBatch.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lsbPartnerContractBatch.Location = new System.Drawing.Point(301, 18);
            this.lsbPartnerContractBatch.Name = "lsbPartnerContractBatch";
            this.lsbPartnerContractBatch.Size = new System.Drawing.Size(135, 95);
            this.lsbPartnerContractBatch.Sorted = true;
            this.lsbPartnerContractBatch.TabIndex = 89;
            this.lsbPartnerContractBatch.Visible = false;
            this.lsbPartnerContractBatch.SelectedIndexChanged += new System.EventHandler(this.LsbPartnerContractBatch_SelectedIndexChanged);
            // 
            // gpbRoles
            // 
            this.gpbRoles.Controls.Add(this.cbbAvaliableRoles);
            this.gpbRoles.Controls.Add(this.btnRemoveRole);
            this.gpbRoles.Controls.Add(this.btnAddRole);
            this.gpbRoles.Controls.Add(this.label1);
            this.gpbRoles.Location = new System.Drawing.Point(9, 6);
            this.gpbRoles.Name = "gpbRoles";
            this.gpbRoles.Size = new System.Drawing.Size(280, 125);
            this.gpbRoles.TabIndex = 82;
            this.gpbRoles.TabStop = false;
            this.gpbRoles.Text = "Defina abaixo os cargos existentes em cada contrato";
            this.gpbRoles.Visible = false;
            // 
            // cbbAvaliableRoles
            // 
            this.cbbAvaliableRoles.FormattingEnabled = true;
            this.cbbAvaliableRoles.Location = new System.Drawing.Point(104, 38);
            this.cbbAvaliableRoles.Name = "cbbAvaliableRoles";
            this.cbbAvaliableRoles.Size = new System.Drawing.Size(121, 21);
            this.cbbAvaliableRoles.TabIndex = 82;
            // 
            // btnRemoveRole
            // 
            this.btnRemoveRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRole.Location = new System.Drawing.Point(6, 93);
            this.btnRemoveRole.Name = "btnRemoveRole";
            this.btnRemoveRole.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveRole.TabIndex = 81;
            this.btnRemoveRole.Text = "Desvincular cargo";
            this.btnRemoveRole.UseVisualStyleBackColor = true;
            this.btnRemoveRole.Click += new System.EventHandler(this.BtnRemoveRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.Location = new System.Drawing.Point(154, 93);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(120, 23);
            this.btnAddRole.TabIndex = 79;
            this.btnAddRole.Text = "Vincular cargo";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.BtnAddRole_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome";
            // 
            // lblDevHouse
            // 
            this.lblDevHouse.AutoSize = true;
            this.lblDevHouse.Location = new System.Drawing.Point(298, 337);
            this.lblDevHouse.Name = "lblDevHouse";
            this.lblDevHouse.Size = new System.Drawing.Size(73, 13);
            this.lblDevHouse.TabIndex = 88;
            this.lblDevHouse.Text = "Devs da casa";
            this.lblDevHouse.Visible = false;
            // 
            // gpbDevHouse
            // 
            this.gpbDevHouse.Controls.Add(this.btnRemoveHouseDev);
            this.gpbDevHouse.Controls.Add(this.ckbHouseDevWorksHalfDay);
            this.gpbDevHouse.Controls.Add(this.btnAddHouseDev);
            this.gpbDevHouse.Controls.Add(this.label5);
            this.gpbDevHouse.Controls.Add(this.txbHouseDevName);
            this.gpbDevHouse.Location = new System.Drawing.Point(3, 323);
            this.gpbDevHouse.Name = "gpbDevHouse";
            this.gpbDevHouse.Size = new System.Drawing.Size(280, 125);
            this.gpbDevHouse.TabIndex = 83;
            this.gpbDevHouse.TabStop = false;
            this.gpbDevHouse.Text = "Por fim, quem são os devs da casa?";
            this.gpbDevHouse.Visible = false;
            // 
            // btnRemoveHouseDev
            // 
            this.btnRemoveHouseDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveHouseDev.Location = new System.Drawing.Point(6, 93);
            this.btnRemoveHouseDev.Name = "btnRemoveHouseDev";
            this.btnRemoveHouseDev.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveHouseDev.TabIndex = 81;
            this.btnRemoveHouseDev.Text = "Remover dev";
            this.btnRemoveHouseDev.UseVisualStyleBackColor = true;
            this.btnRemoveHouseDev.Click += new System.EventHandler(this.BtnRemoveHouseDev_Click);
            // 
            // ckbHouseDevWorksHalfDay
            // 
            this.ckbHouseDevWorksHalfDay.AutoSize = true;
            this.ckbHouseDevWorksHalfDay.Location = new System.Drawing.Point(10, 65);
            this.ckbHouseDevWorksHalfDay.Name = "ckbHouseDevWorksHalfDay";
            this.ckbHouseDevWorksHalfDay.Size = new System.Drawing.Size(130, 17);
            this.ckbHouseDevWorksHalfDay.TabIndex = 80;
            this.ckbHouseDevWorksHalfDay.Text = "Trabalha turno único?";
            this.ckbHouseDevWorksHalfDay.UseVisualStyleBackColor = true;
            // 
            // btnAddHouseDev
            // 
            this.btnAddHouseDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHouseDev.Location = new System.Drawing.Point(154, 93);
            this.btnAddHouseDev.Name = "btnAddHouseDev";
            this.btnAddHouseDev.Size = new System.Drawing.Size(120, 23);
            this.btnAddHouseDev.TabIndex = 79;
            this.btnAddHouseDev.Text = "Adicionar dev";
            this.btnAddHouseDev.UseVisualStyleBackColor = true;
            this.btnAddHouseDev.Click += new System.EventHandler(this.BtnAddHouseDev_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nome";
            // 
            // txbHouseDevName
            // 
            this.txbHouseDevName.Location = new System.Drawing.Point(110, 35);
            this.txbHouseDevName.Name = "txbHouseDevName";
            this.txbHouseDevName.Size = new System.Drawing.Size(121, 20);
            this.txbHouseDevName.TabIndex = 4;
            // 
            // lsbHouseDevs
            // 
            this.lsbHouseDevs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbHouseDevs.FormattingEnabled = true;
            this.lsbHouseDevs.Location = new System.Drawing.Point(301, 353);
            this.lsbHouseDevs.Name = "lsbHouseDevs";
            this.lsbHouseDevs.Size = new System.Drawing.Size(135, 95);
            this.lsbHouseDevs.Sorted = true;
            this.lsbHouseDevs.TabIndex = 87;
            this.lsbHouseDevs.Visible = false;
            this.lsbHouseDevs.SelectedIndexChanged += new System.EventHandler(this.LsbHouseDevs_SelectedIndexChanged);
            // 
            // gpbDev
            // 
            this.gpbDev.Controls.Add(this.btnRemoveDev);
            this.gpbDev.Controls.Add(this.ckbDevWorksHalfDay);
            this.gpbDev.Controls.Add(this.btnAddDev);
            this.gpbDev.Controls.Add(this.label3);
            this.gpbDev.Controls.Add(this.txbDevName);
            this.gpbDev.Location = new System.Drawing.Point(3, 171);
            this.gpbDev.Name = "gpbDev";
            this.gpbDev.Size = new System.Drawing.Size(280, 125);
            this.gpbDev.TabIndex = 80;
            this.gpbDev.TabStop = false;
            this.gpbDev.Text = "Bacana, agora para cada contrato me fala sobre seus colaboradores";
            this.gpbDev.Visible = false;
            // 
            // btnRemoveDev
            // 
            this.btnRemoveDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDev.Location = new System.Drawing.Point(6, 93);
            this.btnRemoveDev.Name = "btnRemoveDev";
            this.btnRemoveDev.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveDev.TabIndex = 81;
            this.btnRemoveDev.Text = "Remover colaborador";
            this.btnRemoveDev.UseVisualStyleBackColor = true;
            this.btnRemoveDev.Click += new System.EventHandler(this.BtnRemoveDev_Click);
            // 
            // ckbDevWorksHalfDay
            // 
            this.ckbDevWorksHalfDay.AutoSize = true;
            this.ckbDevWorksHalfDay.Location = new System.Drawing.Point(10, 65);
            this.ckbDevWorksHalfDay.Name = "ckbDevWorksHalfDay";
            this.ckbDevWorksHalfDay.Size = new System.Drawing.Size(130, 17);
            this.ckbDevWorksHalfDay.TabIndex = 80;
            this.ckbDevWorksHalfDay.Text = "Trabalha turno único?";
            this.ckbDevWorksHalfDay.UseVisualStyleBackColor = true;
            // 
            // btnAddDev
            // 
            this.btnAddDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDev.Location = new System.Drawing.Point(154, 93);
            this.btnAddDev.Name = "btnAddDev";
            this.btnAddDev.Size = new System.Drawing.Size(120, 23);
            this.btnAddDev.TabIndex = 79;
            this.btnAddDev.Text = "Adicionar colaborador";
            this.btnAddDev.UseVisualStyleBackColor = true;
            this.btnAddDev.Click += new System.EventHandler(this.BtnAddDev_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome";
            // 
            // txbDevName
            // 
            this.txbDevName.Location = new System.Drawing.Point(110, 35);
            this.txbDevName.Name = "txbDevName";
            this.txbDevName.Size = new System.Drawing.Size(121, 20);
            this.txbDevName.TabIndex = 4;
            // 
            // lblDevs
            // 
            this.lblDevs.AutoSize = true;
            this.lblDevs.Location = new System.Drawing.Point(298, 226);
            this.lblDevs.Name = "lblDevs";
            this.lblDevs.Size = new System.Drawing.Size(92, 13);
            this.lblDevs.TabIndex = 86;
            this.lblDevs.Text = "Devs adicionados";
            this.lblDevs.Visible = false;
            // 
            // lsbDevs
            // 
            this.lsbDevs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDevs.FormattingEnabled = true;
            this.lsbDevs.Location = new System.Drawing.Point(301, 242);
            this.lsbDevs.Name = "lsbDevs";
            this.lsbDevs.Size = new System.Drawing.Size(135, 95);
            this.lsbDevs.Sorted = true;
            this.lsbDevs.TabIndex = 85;
            this.lsbDevs.Visible = false;
            this.lsbDevs.SelectedIndexChanged += new System.EventHandler(this.LsbDevs_SelectedIndexChanged);
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.Location = new System.Drawing.Point(13, 36);
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(287, 416);
            this.txbResult.TabIndex = 68;
            this.txbResult.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Log:";
            // 
            // btnPreviousForm
            // 
            this.btnPreviousForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviousForm.Location = new System.Drawing.Point(12, 482);
            this.btnPreviousForm.Name = "btnPreviousForm";
            this.btnPreviousForm.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousForm.TabIndex = 74;
            this.btnPreviousForm.Text = "<- Retornar";
            this.btnPreviousForm.UseVisualStyleBackColor = true;
            this.btnPreviousForm.Click += new System.EventHandler(this.BtnPreviousForm_Click);
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(481, 482);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 76;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Visible = false;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(590, 482);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 77;
            this.btnGenerate.Text = "Gerar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(671, 482);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 78;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Visible = false;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // lblScreen
            // 
            this.lblScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(726, 510);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(48, 13);
            this.lblScreen.TabIndex = 79;
            this.lblScreen.Text = "Tela 3/3";
            // 
            // ConfigDevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnPreviousForm);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfigDevForm";
            this.Text = "ConfigDevForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbRoles.ResumeLayout(false);
            this.gpbRoles.PerformLayout();
            this.gpbDevHouse.ResumeLayout(false);
            this.gpbDevHouse.PerformLayout();
            this.gpbDev.ResumeLayout(false);
            this.gpbDev.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbDev;
        private System.Windows.Forms.Button btnRemoveDev;
        private System.Windows.Forms.CheckBox ckbDevWorksHalfDay;
        private System.Windows.Forms.Button btnAddDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDevName;
        private System.Windows.Forms.GroupBox gpbDevHouse;
        private System.Windows.Forms.Button btnRemoveHouseDev;
        private System.Windows.Forms.CheckBox ckbHouseDevWorksHalfDay;
        private System.Windows.Forms.Button btnAddHouseDev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbHouseDevName;
        private System.Windows.Forms.Label lblDevHouse;
        private System.Windows.Forms.ListBox lsbHouseDevs;
        private System.Windows.Forms.Label lblDevs;
        private System.Windows.Forms.ListBox lsbDevs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lsbPartnerContractBatch;
        private System.Windows.Forms.GroupBox gpbRoles;
        private System.Windows.Forms.ComboBox cbbAvaliableRoles;
        private System.Windows.Forms.Button btnRemoveRole;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ListBox lsbRoles;
    }
}