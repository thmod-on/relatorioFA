using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class FornecedorDTO
    {
        public FornecedorDTO()
        {
            Contracts = new List<ContratoDTO>();
        }

        [XmlElement("Nome")]
        public string Name { get; set; }
        [XmlElement("ValorUst")]
        public double UstValue { get; set; }
        [XmlElement("Contrato")]
        public List<ContratoDTO> Contracts { get; set; }
        [XmlElement("CaminhoLogomarca")]
        public string CaminhoLogomarca { get; set; }
        public UtilDTO.BILLING_TYPE BillingType { get; set; }//atualmente serve apenas para o contrato da Influir
    }
}
