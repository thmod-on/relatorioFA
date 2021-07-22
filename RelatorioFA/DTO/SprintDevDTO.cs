
using System.Text;

namespace RelatorioFA.DTO
{
    public class SprintDevDTO : SprintBaseDTO
    {
        public double PointsPerTeamMemberExpenses { get; set; }
        public double PointsPerTeamMemberInvestment { get; set; }
        public int AcceptedPointsExpenses { get; set; }
        public int AcceptedPointsInvestment { get; set; }

        public override StringBuilder ToStringBuilder()
        {
            StringBuilder aux = base.ToStringBuilder();

            aux.Append($"- Pts. aceitos INV: {AcceptedPointsInvestment}\n");
            aux.Append($"- Pts. aceitos DES: {AcceptedPointsExpenses}\n");
            if (Contracts.Count > 0)
            {
                foreach (var contract in Contracts)
                {
                    aux.Append("===\n");
                    aux.Append($"- {contract.PartnerName}.{contract.Name} ({contract.NumeroSAP})\n");
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
