using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class Controle
    {
        public static void SetDevPresence(out Dictionary<string, double> devPresence, Dictionary<ColaboradorDTO, int> devAbsence, int sprintDays)
        {
            devPresence = new Dictionary<string, double>();
            foreach (var dev in devAbsence)
            {
                double factor = dev.Key.WorksHalfDay ? 0.5 : 1;
                devPresence.Add(dev.Key.Name, Math.Round((double)(sprintDays - dev.Value) * factor / sprintDays, 2));
            }
        }

        public static double CalcTeamSize(Dictionary<string, double> devPresence)
        {
            return devPresence.Sum(x => x.Value);
        }

        public static List<IntervaloDTO> GenerateRanges()
        {
            List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
            DateTime lastSprintEndDate = new DateTime(2021, 01, 06);
            int currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int sprintCountPerRelease = 6;
            int maxReleases = 2;

            for (int release = 1; release <= maxReleases; release++)
            {
                for (int sprint = 1; sprint <= sprintCountPerRelease; sprint++)
                {
                    IntervaloDTO range = new IntervaloDTO
                    {
                        Name = $"{currentYear} R{release}S{sprint}",
                        IniDate = lastSprintEndDate.AddDays(1),
                        EndDate = lastSprintEndDate.AddDays(14)
                    };

                    sprintRanges.Add(range);

                    lastSprintEndDate = range.EndDate;
                }
            }

            return sprintRanges;
        }

        public static double CalcEmployeesPrticipation(ContratoDTO contract, Dictionary<string, double> devPresence)
        {
            double count = 0;

            foreach (var c in contract.Collaborators)
            {
                if (devPresence.ContainsKey(c.Name))
                {
                    count += devPresence[c.Name];
                }
            }

            return count;
        }

        public static double CalcBillingUst(double ustValue, double pointsPerPartner, double factor)
        {
            return Math.Round(ustValue * pointsPerPartner * factor, 2);
        }

        public static double CalcPartnerPoints(double pointsPerTeamMember, double factor, bool addCerimonialPoint, double emploeeCount)
        {
            if (addCerimonialPoint)
            {
                pointsPerTeamMember += 1;
            }
            return Math.Round(pointsPerTeamMember * factor * emploeeCount, 3);
        }

        public static void CalcPointsPerTeamMember(SprintDevDTO newSprint)
        {
            newSprint.PointsPerTeamMemberExpenses = Math.Round(newSprint.AcceptedPointsExpenses / newSprint.TeamSize, 3);
            newSprint.PointsPerTeamMemberInvestment = Math.Round(newSprint.AcceptedPointsInvestment / newSprint.TeamSize, 3);
        }

        public static int CalcSprintHours(double pointsPerPartner, double ustValue, double hourValue)
        {
            return (int)Math.Ceiling(pointsPerPartner * ustValue / hourValue);
        }

        public static double CalcBillingHour(int hours, double hourValue)
        {
            return Math.Round(hours * hourValue, 2);
        }
    }
}
