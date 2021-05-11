using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    [XmlRoot("Config")]
    public class ConfigDTO
    {
        public ConfigDTO()
        {
            BaneseDes = new List<ColaboradorDTO>();
            Partners = new List<FornecedorDTO>();
        }

        [XmlElement("NomeArea")]
        public string AreaName { get; set; }
        [XmlElement("NomeTime")]
        public string TeamName { get; set; }
        [XmlElement("Autor")]
        public string AuthorName { get; set; }
        [XmlElement("DesenvBanese")]
        public List<ColaboradorDTO> BaneseDes { get; set; }
        [XmlElement("Fornecedor")]
        public List<FornecedorDTO> Partners { get; set; }
    }
}
