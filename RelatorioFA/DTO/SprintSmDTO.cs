
using System.Text;

namespace RelatorioFA.DTO
{
    public class SprintSmDTO : SprintBaseDTO
    {

        public double EmployeesCount { get; set; }
        public double DevTeamSize1 { get; set; }
        public double DevTeamSize2 { get; set; }
        public double AcceptedPointsTeam1 { get; set; }
        public double AcceptedPointsTeam2 { get; set; }
        public double AverageTeam1 { get; set; }
        public double AverageTeam2 { get; set; }
        public double AverageSprint { get; set; }
        public double SmPoints { get; set; }

        public override StringBuilder ToStringBuilder()
        {
            var aux = base.ToStringBuilder();
            aux.Append($"Pontos time 1: {AcceptedPointsTeam1}\n");
            aux.Append($"Pontos time 2: {AcceptedPointsTeam2}\n");
            aux.Append($"Tamanho do time 1: {DevTeamSize1}\n");
            aux.Append($"Tamanho do time 2: {DevTeamSize2}\n");
            aux.Append($"Pontos de SM: {SmPoints}\n");

            return aux;
        }
    }
}
