using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.DTO
{
    public class ColaboradorDTO
    {
        [XmlElement("Nome")]
        public string Name { get; set; }
        [XmlElement("UmTurno")]
        public bool WorksHalfDay { get; set; }
    }
}
