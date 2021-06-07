
using System.Text;

namespace RelatorioFA.DTO
{
    public class SprintDevDTO : SprintBaseDTO
    {
        public double EmployeesCount { get; set; }//considerando as ausências
        public double PointsPerPartnerExpenses { get; set; }//recalculado por fornecedor
        public double PointsPerPartnerInvestment { get; set; }
        public double PointsPerTeamMemberExpenses { get; set; }
        public double PointsPerTeamMemberInvestment { get; set; }
        public int HoursExpenses { get; set; }
        public int HoursInvestment { get; set; }
        public int AcceptedPointsExpenses { get; set; }
        public int AcceptedPointsInvestment { get; set; }

        public override StringBuilder ToString()
        {
            StringBuilder aux = base.ToString();

            aux.Append($"- Pts. aceitos INV: {AcceptedPointsInvestment}\n");
            aux.Append($"- Pts. aceitos DES: {AcceptedPointsExpenses}\n");
            aux.Append($"- Pts. / dev (time) INV: {PointsPerTeamMemberInvestment}\n");
            aux.Append($"- Pts. / dev (time) DES: {PointsPerTeamMemberExpenses}\n");
            aux.Append($"- Devs da empresa: {EmployeesCount}\n");
            aux.Append($"- Pts. / dev (empresa) INV: {PointsPerPartnerInvestment}\n");
            aux.Append($"- Pts. / dev (empresa) DES: {PointsPerPartnerExpenses}\n\n");
            if (Contracts.Count > 0)
            {
                foreach (var contract in Contracts)
                {
                    aux.Append($"- {contract.Name} ({contract.NumeroSAP})\n");
                    aux.Append($"- Fator ajuste: {contract.Factor}\n");
                    foreach (var dev in contract.Collaborators)
                    {
                        aux.Append($"  > {dev.Name} \n");
                        aux.Append($"    . Trabalha turno único: {dev.WorksHalfDay} \n");
                        aux.Append($"    . Ausências (dias): {dev.AbsenceDays} \n");
                        aux.Append($"    . Horas extras: {dev.ExtraHours} \n");
                    }
                }
            }

            return aux;
        }
    }
}
