using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string ConvertDoubleToStringWithDotAtDecimal(double myDouble)
        {
            return myDouble.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
