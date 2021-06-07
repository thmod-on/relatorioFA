using System.Collections.Generic;

namespace RelatorioFA.DTO
{
    public class ConfigDocDTO
    {
        public ConfigDocDTO()
        {
            DevTeam = new List<ColaboradorDTO>();
        }

        public string AreaName { get; set; }
        public string TeamName { get; set; }
        public string AuthorName { get; set; }
        public string OutputDocPath { get; set; }
        public List<ColaboradorDTO> DevTeam { get; set; }
    }
}
