using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class LoteDTO
    {
        public LoteDTO()
        {
            Roles = new List<CargoDTO>();
        }

        [XmlElement("NomeLote")]
        public string Name { get; set; }
        [XmlElement("Cargo")]
        public List<CargoDTO> Roles { get; set; }
    }
}
