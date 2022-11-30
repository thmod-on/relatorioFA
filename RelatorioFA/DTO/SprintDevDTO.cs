
using System.Text;
using System.Linq;

namespace RelatorioFA.DTO
{
    public class SprintDevDTO : SprintBaseDTO
    {
        public double PointsPerTeamMemberExpenses { get; set; }
        public double PointsPerTeamMemberInvestment { get; set; }
        public int AcceptedPointsExpenses { get; set; }
        public int AcceptedPointsInvestment { get; set; }
        public bool AdaptaionSprint { get; set; }

        public override StringBuilder ToStringBuilder()
        {
            StringBuilder aux = base.ToStringBuilder();

            aux.Append($"- Pts. aceitos INV: {AcceptedPointsInvestment}\n");
            aux.Append($"- Pts. aceitos DES: {AcceptedPointsExpenses}\n");

            foreach (var contract in Contracts)
            {
                aux.Append("===\n");
                aux.Append($"- {contract.PartnerName}.{contract.SapNumber}\n");
                foreach (var batch in from batch in contract.Batches
                                      where batch.Name == UtilDTO.BATCHS.DEV.ToString()
                                      select batch)
                {
                    aux.Append("- Desenvolvedores:\n");
                    foreach (var dev in from role in batch.Roles
                                        from dev in role.Collaborators
                                        select dev)
                    {
                        aux.Append($"   > {dev.Name} \n");
                        aux.Append($"     . Trabalha turno único: {dev.WorksHalfDay} \n");
                        aux.Append($"     . Ausências (dias): {dev.AbsenceDays} \n");
                        aux.Append($"     . H.E. (INV): {dev.ExtraHourInvestment} \n");
                        aux.Append($"     . H.E. (DES): {dev.ExtraHoursExpenses} \n");
                    }
                }
            }

            return aux;
        }
    }
}
