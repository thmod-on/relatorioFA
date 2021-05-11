using System;
using System.IO;

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
            BANESE,
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
    }
}
