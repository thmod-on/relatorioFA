using System;
using System.Collections.Generic;
using System.Linq;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class Controle
    {
        public static void SetDevPresence(List<ContratoDTO> contractList, int sprintDays, bool adaptaionSprint)
        {
            foreach (var contract in contractList)
            {
                if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() &&
                    contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString() )
                {
                    foreach (var dev in contract.Collaborators)
                    {
                        if (!adaptaionSprint)
                        {
                            double factor = dev.WorksHalfDay ? 0.5 : 1;
                            dev.Presence = Math.Round((sprintDays - dev.AbsenceDays) * factor / sprintDays, 3);
                        }
                        else
                        {
                            dev.Presence = 1;
                        }
                    }
                }
            }
        }

        public static double CalcTeamSize(FornecedorDTO selectedPartner, SprintDevDTO sprintDev, UtilDTO.NAVIGATION navigation)
        {
            double teamSize = 0;
            if (navigation != UtilDTO.NAVIGATION.DEV_EXTERNO)
            {
                foreach (var contract in sprintDev.Contracts)
                {
                    if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() &&
                        contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    {
                        if (!sprintDev.AdaptaionSprint)
                        {
                            foreach (var dev in contract.Collaborators)
                            {
                                teamSize += dev.Presence;
                            }
                        }
                        else
                        {
                            if (selectedPartner.Contracts.Any(c => c.Name == contract.Name) &&
                                contract.PartnerName == selectedPartner.Name)
                            {
                                foreach (var dev in contract.Collaborators)
                                {
                                    teamSize += 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                teamSize = 1;
            }

            return teamSize;
        }

        public static void CalcSmSprintData(List<SprintSmDTO> sprintsSmList)
        {
            foreach (var sprint in sprintsSmList)
            {
                sprint.AverageTeam1 = Math.Round(sprint.AcceptedPointsTeam1 / sprint.DevTeamSize1, 3);
                sprint.AverageTeam2 = Math.Round(sprint.AcceptedPointsTeam2 / sprint.DevTeamSize2, 3);
                sprint.AverageSprint = Math.Round((sprint.AverageTeam1 + sprint.AverageTeam2) / 2, 3);
                sprint.SmPoints = Math.Round(sprint.AverageSprint * sprint.Contracts[0].Factor + 1, 3);
            }
        }

        public static List<IntervaloDTO> GenerateRanges()
        {
            List<IntervaloDTO> sprintRanges = new List<IntervaloDTO>();
            DateTime lastSprintEndDate = new DateTime(2022, 01, 05);
            int currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int sprintCountPerRelease = 6;
            int maxReleases = 4;

            for (int release = 1; release <= maxReleases; release++)
            {
                for (int sprint = 1; sprint <= sprintCountPerRelease; sprint++)
                {
                    IntervaloDTO range = new IntervaloDTO
                    {
                        Name = $"{currentYear} - R{release} - S{sprint}",
                        IniDate = lastSprintEndDate.AddDays(1),
                        EndDate = sprint != sprintCountPerRelease ? lastSprintEndDate.AddDays(14) : lastSprintEndDate.AddDays(21)
                    };

                    sprintRanges.Add(range);

                    lastSprintEndDate = range.EndDate;
                }
            }

            return sprintRanges;
        }

        public static void CalcPointsPerTeamMember(SprintDevDTO devSprint)
        {
            devSprint.PointsPerTeamMemberExpenses = Math.Round(devSprint.AcceptedPointsExpenses / devSprint.TeamSize, 3);
            devSprint.PointsPerTeamMemberInvestment = Math.Round(devSprint.AcceptedPointsInvestment / devSprint.TeamSize, 3);
        }

        public static double CalcUstByExtraHour(double extraHour)
        {
            return (0.5 * extraHour) / 4;
        }
    }
}
