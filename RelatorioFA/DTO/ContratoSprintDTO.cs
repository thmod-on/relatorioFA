using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFA.DTO
{
    public class ContratoSprintDTO
    {

        public double EmployeesCount { get; set; }//consideraando as ausências
        public double PointsPerPartnerExpenses { get; set; }
        public double PointsPerPartnerInvestment { get; set; }
        public int Hours { get; set; }
    }
}
