using System.Collections.Generic;
using System.Xml.Serialization;


namespace RelatorioFA.DTO
{
    public class CargoDTO
    {
        public CargoDTO()
        {
            Collaborators = new List<ColaboradorDTO>();
        }

        [XmlElement("NomeCargo")]
        public string Name { get; set; }
        [XmlElement("FatorAjuste")]
        public double Factor { get; set; }
        [XmlElement("Colaborador")]
        public List<ColaboradorDTO> Collaborators { get; set; }
    }
}
