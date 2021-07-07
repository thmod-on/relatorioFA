
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
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.btnSetOutputDocPath = new System.Windows.Forms.Button();
            this.btnPreviousForm = new System.Windows.Forms.Button();
            this.txbResult = new System.Windows.Forms.RichTextBox();
            this.gpbContracts = new System.Windows.Forms.GroupBox();
            this.btnRemoveContract = new System.Windows.Forms.Button();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.cbbContractType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txbContractFactor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbContractSap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDevName = new System.Windows.Forms.TextBox();
            this.lsbPartners = new System.Windows.Forms.ListBox();
            this.gpbDev = new System.Windows.Forms.GroupBox();
            this.btnRemoveDev = new System.Windows.Forms.Button();
            this.ckbDevWorksHalfDay = new System.Windows.Forms.CheckBox();
            this.btnAddDev = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblDevHouse = new System.Windows.Forms.Label();
            this.lsbHouseDevs = new System.Windows.Forms.ListBox();
            this.gpbDevHouse = new System.Windows.Forms.GroupBox();
            this.btnRemoveHouseDev = new System.Windows.Forms.Button();
            this.ckbHouseDevWorksHalfDay = new System.Windows.Forms.CheckBox();
            this.btnAddHouseDev = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txbHouseDevName = new System.Windows.Forms.TextBox();
            this.lblDevs = new System.Windows.Forms.Label();
            this.lsbDevs = new System.Windows.Forms.ListBox();
            this.lblContracts = new System.Windows.Forms.Label();
            this.lsbContracts = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnNextForm = new System.Windows.Forms.Button();
            this.gpbContracts.SuspendLayout();
            this.gpbDev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbDevHouse.SuspendLayout();
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
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFolder.Enabled = false;
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(562, 482);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDestinationFolder.TabIndex = 76;
            this.btnOpenDestinationFolder.Text = "Abrir destino";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Visible = false;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // btnSetOutputDocPath
            // 
            this.btnSetOutputDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputDocPath.Location = new System.Drawing.Point(362, 482);
            this.btnSetOutputDocPath.Name = "btnSetOutputDocPath";
            this.btnSetOutputDocPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetOutputDocPath.TabIndex = 75;
            this.btnSetOutputDocPath.Text = "Exportar para";
            this.btnSetOutputDocPath.UseVisualStyleBackColor = true;
            this.btnSetOutputDocPath.Visible = false;
            this.btnSetOutputDocPath.Click += new System.EventHandler(this.BtnSetOutputDocPath_Click);
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
            this.gpbContracts.Controls.Add(this.cbbContractType);
            this.gpbContracts.Controls.Add(this.label1);
            this.gpbContracts.Controls.Add(this.label12);
            this.gpbContracts.Controls.Add(this.txbContractFactor);
            this.gpbContracts.Controls.Add(this.label11);
            this.gpbContracts.Controls.Add(this.txbContractSap);
            this.gpbContracts.Location = new System.Drawing.Point(3, 3);
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
            // cbbContractType
            // 
            this.cbbContractType.FormattingEnabled = true;
            this.cbbContractType.Location = new System.Drawing.Point(110, 30);
            this.cbbContractType.Name = "cbbContractType";
            this.cbbContractType.Size = new System.Drawing.Size(121, 21);
            this.cbbContractType.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tipo de contrato";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Fator de ajuste";
            // 
            // txbContractFactor
            // 
            this.txbContractFactor.Location = new System.Drawing.Point(110, 87);
            this.txbContractFactor.Name = "txbContractFactor";
            this.txbContractFactor.Size = new System.Drawing.Size(121, 20);
            this.txbContractFactor.TabIndex = 19;
            this.txbContractFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbContractFactor_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Número no SAP";
            // 
            // txbContractSap
            // 
            this.txbContractSap.Location = new System.Drawing.Point(110, 61);
            this.txbContractSap.Name = "txbContractSap";
            this.txbContractSap.Size = new System.Drawing.Size(121, 20);
            this.txbContractSap.TabIndex = 17;
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
            // gpbDev
            // 
            this.gpbDev.Controls.Add(this.btnRemoveDev);
            this.gpbDev.Controls.Add(this.ckbDevWorksHalfDay);
            this.gpbDev.Controls.Add(this.btnAddDev);
            this.gpbDev.Controls.Add(this.label3);
            this.gpbDev.Controls.Add(this.txbDevName);
            this.gpbDev.Location = new System.Drawing.Point(3, 185);
            this.gpbDev.Name = "gpbDev";
            this.gpbDev.Size = new System.Drawing.Size(280, 125);
            this.gpbDev.TabIndex = 55;
            this.gpbDev.TabStop = false;
            this.gpbDev.Text = "Bacana, agora para cada contrato me fala sobre seus devs";
            this.gpbDev.Visible = false;
            // 
            // btnRemoveDev
            // 
            this.btnRemoveDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDev.Location = new System.Drawing.Point(6, 93);
            this.btnRemoveDev.Name = "btnRemoveDev";
            this.btnRemoveDev.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveDev.TabIndex = 81;
            this.btnRemoveDev.Text = "Remover dev";
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
            this.btnAddDev.Text = "Adicionar dev";
            this.btnAddDev.UseVisualStyleBackColor = true;
            this.btnAddDev.Click += new System.EventHandler(this.BtnAddDev_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.lblDevHouse);
            this.splitContainer1.Panel1.Controls.Add(this.lsbHouseDevs);
            this.splitContainer1.Panel1.Controls.Add(this.gpbDevHouse);
            this.splitContainer1.Panel1.Controls.Add(this.lblDevs);
            this.splitContainer1.Panel1.Controls.Add(this.lsbDevs);
            this.splitContainer1.Panel1.Controls.Add(this.lblContracts);
            this.splitContainer1.Panel1.Controls.Add(this.lsbContracts);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lsbPartners);
            this.splitContainer1.Panel1.Controls.Add(this.gpbDev);
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
            // lblDevHouse
            // 
            this.lblDevHouse.AutoSize = true;
            this.lblDevHouse.Location = new System.Drawing.Point(302, 346);
            this.lblDevHouse.Name = "lblDevHouse";
            this.lblDevHouse.Size = new System.Drawing.Size(73, 13);
            this.lblDevHouse.TabIndex = 84;
            this.lblDevHouse.Text = "Devs da casa";
            this.lblDevHouse.Visible = false;
            // 
            // lsbHouseDevs
            // 
            this.lsbHouseDevs.FormattingEnabled = true;
            this.lsbHouseDevs.Location = new System.Drawing.Point(305, 362);
            this.lsbHouseDevs.Name = "lsbHouseDevs";
            this.lsbHouseDevs.Size = new System.Drawing.Size(135, 95);
            this.lsbHouseDevs.Sorted = true;
            this.lsbHouseDevs.TabIndex = 83;
            this.lsbHouseDevs.Visible = false;
            this.lsbHouseDevs.SelectedIndexChanged += new System.EventHandler(this.LsbHouseDevs_SelectedIndexChanged);
            // 
            // gpbDevHouse
            // 
            this.gpbDevHouse.Controls.Add(this.btnRemoveHouseDev);
            this.gpbDevHouse.Controls.Add(this.ckbHouseDevWorksHalfDay);
            this.gpbDevHouse.Controls.Add(this.btnAddHouseDev);
            this.gpbDevHouse.Controls.Add(this.label5);
            this.gpbDevHouse.Controls.Add(this.txbHouseDevName);
            this.gpbDevHouse.Location = new System.Drawing.Point(3, 324);
            this.gpbDevHouse.Name = "gpbDevHouse";
            this.gpbDevHouse.Size = new System.Drawing.Size(280, 125);
            this.gpbDevHouse.TabIndex = 82;
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
            // lblDevs
            // 
            this.lblDevs.AutoSize = true;
            this.lblDevs.Location = new System.Drawing.Point(302, 235);
            this.lblDevs.Name = "lblDevs";
            this.lblDevs.Size = new System.Drawing.Size(92, 13);
            this.lblDevs.TabIndex = 72;
            this.lblDevs.Text = "Devs adicionados";
            this.lblDevs.Visible = false;
            // 
            // lsbDevs
            // 
            this.lsbDevs.FormattingEnabled = true;
            this.lsbDevs.Location = new System.Drawing.Point(305, 251);
            this.lsbDevs.Name = "lsbDevs";
            this.lsbDevs.Size = new System.Drawing.Size(135, 95);
            this.lsbDevs.Sorted = true;
            this.lsbDevs.TabIndex = 71;
            this.lsbDevs.Visible = false;
            this.lsbDevs.SelectedIndexChanged += new System.EventHandler(this.LsbDevs_SelectedIndexChanged);
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
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(476, 482);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 74;
            this.btnGenerate.Text = "Gerar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
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
            this.Controls.Add(this.btnOpenDestinationFolder);
            this.Controls.Add(this.btnSetOutputDocPath);
            this.Controls.Add(this.btnPreviousForm);
            this.Controls.Add(this.btnGenerate);
            this.Name = "ConfigContratoForm";
            this.Text = "ConfigContratoForm";
            this.gpbContracts.ResumeLayout(false);
            this.gpbContracts.PerformLayout();
            this.gpbDev.ResumeLayout(false);
            this.gpbDev.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbDevHouse.ResumeLayout(false);
            this.gpbDevHouse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.Button btnSetOutputDocPath;
        private System.Windows.Forms.Button btnPreviousForm;
        private System.Windows.Forms.RichTextBox txbResult;
        private System.Windows.Forms.GroupBox gpbContracts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDevName;
        private System.Windows.Forms.ListBox lsbPartners;
        private System.Windows.Forms.GroupBox gpbDev;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblDevs;
        private System.Windows.Forms.ListBox lsbDevs;
        private System.Windows.Forms.Label lblContracts;
        private System.Windows.Forms.ListBox lsbContracts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbContractFactor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbContractSap;
        private System.Windows.Forms.ComboBox cbbContractType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.Button btnAddDev;
        private System.Windows.Forms.CheckBox ckbDevWorksHalfDay;
        private System.Windows.Forms.Button btnRemoveContract;
        private System.Windows.Forms.Button btnRemoveDev;
        private System.Windows.Forms.GroupBox gpbDevHouse;
        private System.Windows.Forms.Button btnRemoveHouseDev;
        private System.Windows.Forms.CheckBox ckbHouseDevWorksHalfDay;
        private System.Windows.Forms.Button btnAddHouseDev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbHouseDevName;
        private System.Windows.Forms.Label lblDevHouse;
        private System.Windows.Forms.ListBox lsbHouseDevs;
        private System.Windows.Forms.Button btnNextForm;
    }
}