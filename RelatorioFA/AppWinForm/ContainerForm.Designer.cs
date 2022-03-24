namespace RelatorioFA.AppWinForm
{
    partial class ContainerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gerarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todasEmpresasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDaFábricaÁgilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devOpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primeiraSprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devExternoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMCompartilhadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarEditarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comoUtilizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarToolStripMenuItem,
            this.configuraçãoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gerarToolStripMenuItem
            // 
            this.gerarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todasEmpresasToolStripMenuItem1,
            this.relatórioDaFábricaÁgilToolStripMenuItem});
            this.gerarToolStripMenuItem.Name = "gerarToolStripMenuItem";
            this.gerarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.gerarToolStripMenuItem.Text = "Relatório";
            // 
            // todasEmpresasToolStripMenuItem1
            // 
            this.todasEmpresasToolStripMenuItem1.Name = "todasEmpresasToolStripMenuItem1";
            this.todasEmpresasToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.todasEmpresasToolStripMenuItem1.Text = "Todas empresas";
            this.todasEmpresasToolStripMenuItem1.Click += new System.EventHandler(this.TodasEmpresasToolStripMenuItem_Click);
            // 
            // relatórioDaFábricaÁgilToolStripMenuItem
            // 
            this.relatórioDaFábricaÁgilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devOpsToolStripMenuItem,
            this.primeiraSprintToolStripMenuItem,
            this.devExternoToolStripMenuItem,
            this.sMCompartilhadoToolStripMenuItem});
            this.relatórioDaFábricaÁgilToolStripMenuItem.Name = "relatórioDaFábricaÁgilToolStripMenuItem";
            this.relatórioDaFábricaÁgilToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.relatórioDaFábricaÁgilToolStripMenuItem.Text = "Avulso";
            // 
            // devOpsToolStripMenuItem
            // 
            this.devOpsToolStripMenuItem.Name = "devOpsToolStripMenuItem";
            this.devOpsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.devOpsToolStripMenuItem.Text = "DevOps";
            this.devOpsToolStripMenuItem.Click += new System.EventHandler(this.DevOpsToolStripMenuItem_Click);
            // 
            // primeiraSprintToolStripMenuItem
            // 
            this.primeiraSprintToolStripMenuItem.Name = "primeiraSprintToolStripMenuItem";
            this.primeiraSprintToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.primeiraSprintToolStripMenuItem.Text = "Dev";
            this.primeiraSprintToolStripMenuItem.Click += new System.EventHandler(this.DevSprintToolStripMenuItem_Click);
            // 
            // devExternoToolStripMenuItem
            // 
            this.devExternoToolStripMenuItem.Name = "devExternoToolStripMenuItem";
            this.devExternoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.devExternoToolStripMenuItem.Text = "Dev - Externo";
            this.devExternoToolStripMenuItem.Click += new System.EventHandler(this.DevExternoToolStripMenuItem_Click);
            // 
            // sMCompartilhadoToolStripMenuItem
            // 
            this.sMCompartilhadoToolStripMenuItem.Name = "sMCompartilhadoToolStripMenuItem";
            this.sMCompartilhadoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sMCompartilhadoToolStripMenuItem.Text = "SM - Média";
            this.sMCompartilhadoToolStripMenuItem.Click += new System.EventHandler(this.SMCompartilhadoToolStripMenuItem_Click);
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarEditarXMLToolStripMenuItem});
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            // 
            // gerarEditarXMLToolStripMenuItem
            // 
            this.gerarEditarXMLToolStripMenuItem.Name = "gerarEditarXMLToolStripMenuItem";
            this.gerarEditarXMLToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.gerarEditarXMLToolStripMenuItem.Text = "Gerar / Editar XML";
            this.gerarEditarXMLToolStripMenuItem.Click += new System.EventHandler(this.ModeloDeArquivoDeConfiguraçãoToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comoUtilizarToolStripMenuItem,
            this.versõesToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // comoUtilizarToolStripMenuItem
            // 
            this.comoUtilizarToolStripMenuItem.Enabled = false;
            this.comoUtilizarToolStripMenuItem.Name = "comoUtilizarToolStripMenuItem";
            this.comoUtilizarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.comoUtilizarToolStripMenuItem.Text = "Documentação";
            // 
            // versõesToolStripMenuItem
            // 
            this.versõesToolStripMenuItem.Name = "versõesToolStripMenuItem";
            this.versõesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.versõesToolStripMenuItem.Text = "Versões";
            this.versõesToolStripMenuItem.Click += new System.EventHandler(this.VersõesToolStripMenuItem_Click);
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(656, 339);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ContainerForm";
            this.Text = "Relatório de fábrica ágil - v 4.13.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gerarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDaFábricaÁgilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comoUtilizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devOpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primeiraSprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMCompartilhadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarEditarXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasEmpresasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem devExternoToolStripMenuItem;
    }
}