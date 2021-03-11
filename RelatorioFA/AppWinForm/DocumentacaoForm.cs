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
    public partial class DocumentacaoForm : Form
    {
        public DocumentacaoForm()
        {
            InitializeComponent();
        }

        private enum GUIDE_OPTION
        {
            MODELO_PREENCHIDO,
            NomeTime,
            DesenvBanese,
            Fornecedor
        }

        private void LoadGuideOptions()
        {
            cbbGuide.DataSource = Enum.GetValues(typeof(GUIDE_OPTION));
            cbbGuide.DropDownWidth = SetDropDownWidth(cbbGuide);
        }

        private int SetDropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        private void CbbGuide_SelectedIndexChanged(object sender, EventArgs e)
        {
            GUIDE_OPTION option;
            Enum.TryParse<GUIDE_OPTION>(cbbGuide.SelectedValue.ToString(), out option);
            LoadGuideText(option);
        }

        #region LoadGuideText
        private void LoadGuideText(GUIDE_OPTION option)
        {
            txbGuide.Text = "Para correto funcionamento o arquivo de configuração deve estar na pasta raiz do projeto (a ser melhorado) com o nome 'RelatorioFA.xml' e com os campos preenchidos";
            switch (option)
            {
                case GUIDE_OPTION.MODELO_PREENCHIDO:
                    txbGuide.AppendText("<Config>");
                    break;
                case GUIDE_OPTION.NomeTime:
                    txbGuide.AppendText("\n\nElemento 'NomeTime' deve conter o nome do time que está gerando o relatório. De preferência com sigla da área - nome do time. Ex.: ACAFS - Governo");
                    break;
                case GUIDE_OPTION.DesenvBanese:
                    txbGuide.AppendText("\nElemento 'DesenvBanese' irá conter o nome de cada colaborador do Banese para o time de desenvolimento. Para cada colaborador deve ser criado um elemento 'DesenvBanese' com um elemento 'Nome' dentro;");
                    break;
                case GUIDE_OPTION.Fornecedor:
                    txbGuide.AppendText("\nElemento 'Fornecedor' irá conter os dados dos contratos do fornecedor e a lista de colaboradores vinculados a ele. Caso mais de um fornecedor atenda ao time, basta copiar a estutura completa do elemento 'Fornecedor' e colar abaxio.");
                    txbGuide.AppendText("\n   . 'Nome' é o nome do fornecedor;");
                    txbGuide.AppendText("\n   . 'ValorUst' é o valor em R$ pago por cada ponto aceito nas histórias;");
                    txbGuide.AppendText("\n   . 'Contrato' representa o detalhamento de cada contrato que o time fizer uso daquele fornecedor. Caso o time faça uso de mais de um tipo de nível técnico, uma cópia da lista pode ser colada abaixo;");
                    break;
                default:
                    break;
            }

            txbGuide.AppendText("\n   .   . 'Tipo' representa o tipo / nível do colaborador fornecido pela empresa");
            txbGuide.AppendText("\n   .   . 'FatorAjuste' indica por quanto a UST deve ser multiplicada");
            txbGuide.AppendText("\n   .   . 'Colaborador' Assim como no elemento 'DesenvBanese' deve possuir o nome d o colaborador da empresa e pode ser repetido quantas vezes necessárias");
        }
        #endregion
    }
}
