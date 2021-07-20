using System;
using System.IO;
using System.Windows.Forms;

namespace RelatorioFA.DTO
{
    public class UtilDTO
    {
        public enum CATEGORY
        {
            DES,
            INV
        }

        public enum CONTRACTS
        {
            HOUSE,
            PADRAO,
            PLENO,
            SENIOR,
            SM_FIXO,
            SM_MEDIA
        }

        public enum BILLING_TYPE
        {
            UST,
            UST_HORA,
            HORA,
            UST_DEVOPS
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
            VARIOS_RELATORIOS
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
