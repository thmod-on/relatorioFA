using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelatorioFA.AcessoDados;
using RelatorioFA.DTO;
using RelatorioFA.Negocio;

namespace RelatorioFA.Transacao
{
    public class PrincipalTO
    {
        public static ConfigXmlDTO LoadConfig(string outputDocPath)
        {
            return ConfigXmlDA.LoadConfig(outputDocPath);
        }
        
        public static List<IntervaloDTO> GenerateRanges()
        {
            return Controle.GenerateRanges();
        }

        #region Calc
        public static double CalcTeamSize(SprintDevDTO sprintDev)
        {
            return Controle.CalcTeamSize(sprintDev);
        }

        public static void CalcPointsPerTeamMember(SprintDevDTO devSprint)
        {
            Controle.CalcPointsPerTeamMember(devSprint);
        }
        #endregion

        public static void GenerateConfigXmlFile(string outputPath, string outputName, ConfigXmlDTO config)
        {
            ControleXml.GenerateConfigXmlFile(outputPath, outputName, config);
        } 

        #region CreateDoc
        public static void CreateDevDoc(ConfigXmlDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevDTO> sprints)
        {
            ControleDocDev.GenerateDoc(config, partner, outputDocPath, sprints);
        }

        public static void CreateSmDoc(ConfigXmlDTO config, FornecedorDTO partner, string outputDocPath, List<SprintSmDTO> sprints)
        {
            ControleDocSm.CreateSmDoc(config, partner, outputDocPath, sprints);
        }

        public static void CreateOpsDoc(ConfigXmlDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevOpsDTO> sprints)
        {
            ControleDocDevOps.CreateOpsDoc(config, partner, outputDocPath, sprints);
        } 
        #endregion

        public static void SetDevPresence(List<ContratoDTO> contractList, int sprintDays)
        {
            Controle.SetDevPresence(contractList, sprintDays);
        }
    }
}
