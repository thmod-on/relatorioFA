using System.Collections.Generic;
using System.Text;

namespace RelatorioFA.DTO
{
    public abstract class SprintBaseDTO
    {
        public SprintBaseDTO()
        {
            Range = new IntervaloDTO();
            Contracts = new List<ContratoDTO>();
        }

        public string Obs { get; set; }
        public string ImagePath { get; set; }
        public IntervaloDTO Range { get; set; }
        public double TeamSize { get; set; }
        public UtilDTO.CERIMONIAL_POINT CerimonialPoint { get; set; }
        public List<ContratoDTO> Contracts { get; set; }

        public virtual StringBuilder ToStringBuilder() 
        {
            var aux = new StringBuilder();
            aux.Append("____________________________________\n");
            aux.Append($"Sprint {Range.Name} ({Range.IniDate:d} ~ {Range.EndDate:d})\n");
            aux.Append($"- Dias da sprint: {(Range.EndDate - Range.IniDate).TotalDays}\n");
            aux.Append($"- Imagem: {ImagePath}\n");
            aux.Append($"- Obs.: {Obs}\n");
            aux.Append($"- Ponto de cerimônia: {CerimonialPoint}\n");
            
            return aux;
        }

        public SprintBaseDTO GetBaseSprint()
        {
            return this;
        }
    }
}
