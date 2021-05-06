using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFA.DTO
{
    public class SprintDevOpsDTO : SprintDTO
    {
        public double WarningUst { get; set; }
        public double ActuationUst { get; set; }
        public double UsUst { get; set; }
    }
}
