using System.Collections.Generic;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class ContratoDTO
    {
        public ContratoDTO(){
            Batches = new List<LoteDTO> ();
        }

        [XmlElement("NumeroSAP")]
        public string SapNumber { get; set; }
        [XmlElement("ValorUst")]
        public double UstValue { get; set; }
        public string PartnerName { get; set; }
        [XmlElement("Lote")]
        public List<LoteDTO> Batches { get; set; }
    }
}
