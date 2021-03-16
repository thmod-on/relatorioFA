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
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDaFábricaÁgilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avulsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todasEmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gerarToolStripMenuItem
            // 
            this.gerarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem,
            this.relatórioDaFábricaÁgilToolStripMenuItem});
            this.gerarToolStripMenuItem.Name = "gerarToolStripMenuItem";
            this.gerarToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.gerarToolStripMenuItem.Text = "Gerar";
            // 
            // modeloDeArquivoDeConfiguraçãoToolStripMenuItem
            // 
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem.Name = "modeloDeArquivoDeConfiguraçãoToolStripMenuItem";
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem.Text = "Modelo de arq. de conf.";
            this.modeloDeArquivoDeConfiguraçãoToolStripMenuItem.Click += new System.EventHandler(this.ModeloDeArquivoDeConfiguraçãoToolStripMenuItem_Click);
            // 
            // relatórioDaFábricaÁgilToolStripMenuItem
            // 
            this.relatórioDaFábricaÁgilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avulsoToolStripMenuItem,
            this.todasEmpresasToolStripMenuItem});
            this.relatórioDaFábricaÁgilToolStripMenuItem.Name = "relatórioDaFábricaÁgilToolStripMenuItem";
            this.relatórioDaFábricaÁgilToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.relatórioDaFábricaÁgilToolStripMenuItem.Text = "Relatório da fábrica ágil";
            // 
            // avulsoToolStripMenuItem
            // 
            this.avulsoToolStripMenuItem.Enabled = false;
            this.avulsoToolStripMenuItem.Name = "avulsoToolStripMenuItem";
            this.avulsoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.avulsoToolStripMenuItem.Text = "Avulso";
            // 
            // todasEmpresasToolStripMenuItem
            // 
            this.todasEmpresasToolStripMenuItem.Name = "todasEmpresasToolStripMenuItem";
            this.todasEmpresasToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.todasEmpresasToolStripMenuItem.Text = "Todas empresas";
            this.todasEmpresasToolStripMenuItem.Click += new System.EventHandler(this.TodasEmpresasToolStripMenuItem_Click);
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
            this.ClientSize = new System.Drawing.Size(914, 467);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ContainerForm";
            this.Text = "Relatório de fábrica ágil - v 4.4.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gerarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeloDeArquivoDeConfiguraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDaFábricaÁgilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comoUtilizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avulsoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasEmpresasToolStripMenuItem;
    }
}