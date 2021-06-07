﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFA.DTO
{
    public class SprintDevOpsDTO : SprintBaseDTO
    {
        public double WarningUst { get; set; }
        public double ActuationUst { get; set; }
        public double UsUst { get; set; }

        public override StringBuilder ToString()
        {
            var aux = base.ToString();
            aux.Append($"- UST por sobreaviso: {WarningUst}\n");
            aux.Append($"- UST por acionamento: {ActuationUst}\n");
            aux.Append($"- UST por US: {UsUst}\n");

            return aux;
        }
    }
}
