using System.Collections.Generic;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class FornecedorDTO
    {
        public FornecedorDTO()
        {
            Contracts = new List<ContratoDTO>();
        }

        [XmlElement("NomeFornecedor")]
        public string Name { get; set; }
        [XmlElement("Contrato")]
        public List<ContratoDTO> Contracts { get; set; }
        [XmlElement("CaminhoLogomarca")]
        public string CaminhoLogomarca { get; set; }
        public UtilDTO.BILLING_TYPE BillingType { get; set; }
    }
}
