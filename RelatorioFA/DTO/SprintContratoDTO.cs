using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFA.DTO
{
    public class SprintContratoDTO
    {

        public double EmployeesCount { get; set; }//considerando as ausências
        public double PointsPerPartnerExpenses { get; set; }
        public double PointsPerPartnerInvestment { get; set; }
        public int HoursExpenses { get; set; }
        public int HoursInvestment { get; set; }
    }
}
