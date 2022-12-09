using System;
using System.IO;
using System.Windows.Forms;

namespace RelatorioFA.DTO
{
    public class UtilDTO
    {
        public static string configName = "RelatorioFA_2.xml";

        public enum CATEGORY
        {
            DESPESA,
            INVESTIMENTO
        }

        public enum BATCHS
        {
            SM,
            DEV,
            EXTERNO,
            DEVOPS
        }

        public enum ROLES
        {
            HOUSE,
            PADRAO,
            JUNIOR,
            PLENO,
            PLENO_I,
            PLENO_II,
            PLENO_III,
            SENIOR,
            SENIOR_I,
            SENIOR_II,
            SENIOR_III,
            SM_FIXO,
            SM_MEDIA,
            EXTERNO
        }

        public enum BILLING_TYPE
        {
            UST,
            UST_DEVOPS,
            UST_EXTERNAL
        }

        public enum CERIMONIAL_POINT
        {
            DESPESA,
            INVESTIMENTO,
            NENHUM
        }

        public enum NAVIGATION
        {
            DEVOPS,
            VARIOS_RELATORIOS,
            DEV,
            SM,
            DEV_EXTERNO
        }

        public enum REPORT_TYPE
        {
            DEV,
            DEVOPS,
            SM
        }

        public static string GetProjectRootFolder()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }

        public static string ConvertDoubleToStringWithDotAtDecimal(double myDouble)
        {
            return myDouble.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool AllowOnlyNumbers_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            return e.Handled;
        }
    }
}
