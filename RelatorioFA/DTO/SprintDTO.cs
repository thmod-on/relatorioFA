using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFA.DTO
{
    public class SprintDTO
    {
        public SprintDTO()
        {
            Range = new IntervaloDTO();
        }
        
        public string Obs { get; set; }
        public string ImagePath { get; set; }
        public IntervaloDTO Range { get; set; }
        public int AcceptedPointsExpenses { get; set; }
        public int AcceptedPointsInvestment { get; set; }
        public double TeamSize { get; set; }
        public double PointsPerTeamMemberExpenses { get; set; }
        public double PointsPerTeamMemberInvestment { get; set; }
        public UtilDTO.CERIMONIAL_POINT CerimonialPoint { get; set; }
        public Dictionary<string, int> DevAbsence { get; set; }
    }
}
