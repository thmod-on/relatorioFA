using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class ContratoDTO
    {
        public ContratoDTO()
        {
            Collaborators = new List<ColaboradorDTO>();
        }

        [XmlElement("Tipo")]
        public string Name { get; set; }
        [XmlElement("NumeroSAP")]
        public string NumeroSAP { get; set; }
        public string PartnerName { get; set; }
        [XmlElement("FatorAjuste")]
        public double Factor { get; set; }
        [XmlElement("Colaborador")]
        public List<ColaboradorDTO> Collaborators { get; set; }
        [XmlElement("ValorHora")]
        public double HourValue { get; set; }
    }
}
