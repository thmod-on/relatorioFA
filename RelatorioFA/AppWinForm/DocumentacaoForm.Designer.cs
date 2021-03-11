namespace RelatorioFA.AppWinForm
{
    partial class DocumentacaoForm
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
            this.cbbGuide = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbGuide = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cbbGuide
            // 
            this.cbbGuide.FormattingEnabled = true;
            this.cbbGuide.Location = new System.Drawing.Point(82, 8);
            this.cbbGuide.Name = "cbbGuide";
            this.cbbGuide.Size = new System.Drawing.Size(121, 21);
            this.cbbGuide.TabIndex = 9;
            this.cbbGuide.SelectedIndexChanged += new System.EventHandler(this.CbbGuide_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Orientações";
            // 
            // txbGuide
            // 
            this.txbGuide.Location = new System.Drawing.Point(12, 32);
            this.txbGuide.Name = "txbGuide";
            this.txbGuide.Size = new System.Drawing.Size(531, 290);
            this.txbGuide.TabIndex = 10;
            this.txbGuide.Text = "";
            // 
            // DocumentacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbGuide);
            this.Controls.Add(this.cbbGuide);
            this.Name = "DocumentacaoForm";
            this.Text = "DocumentacaoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbGuide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txbGuide;
    }
}