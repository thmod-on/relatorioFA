using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelatorioFA.AppWinForm
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(this.Width, this.Height);
        }

        #region AbrirForm
        /// <summary>
        /// Método que remove os demais forms presentes no MDIForm e abre o solicitado
        /// </summary>
        /// <param name="form"></param>
        private void AbrirForm(Form form)
        {
            RemoverFilhos();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region RemoverFilhos
        /// <summary>
        /// Remove os filhos do form pai, caso os possua
        /// </summary>
        private void RemoverFilhos()
        {
            if (this.HasChildren)
            {
                foreach (var form in this.MdiChildren)
                {
                    form.Close();
                }
            }
        }
        #endregion

        #region Ações do menu
        private void VersõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new SobreForm(this));
        }

        private void ModeloDeArquivoDeConfiguraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new ModeloConfigXMLForm(this));
        }
        #endregion

        private void TodasEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new VariosRelatoriosForm(this));
        }
    }
}
