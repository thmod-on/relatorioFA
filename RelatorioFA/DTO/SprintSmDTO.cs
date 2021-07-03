
using System.Text;

namespace RelatorioFA.DTO
{
    public class SprintSmDTO : SprintBaseDTO
    {

        public double EmployeesCount { get; set; }
        public double PointsPerPartnerExpenses { get; set; }
        public double PointsPerPartnerInestment { get; set; }
        public double AcceptedPointsInvestment { get; set; }
        public double AcceptedPointsExpenses { get; set; }
        public int SmPoints { get; set; }

        public override StringBuilder ToStringBuilder()
        {
            var aux = base.ToStringBuilder();
            aux.Append($"Pontos de SM: {SmPoints}\n");

            return aux;
        }
    }
}
