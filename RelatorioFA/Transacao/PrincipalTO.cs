using System;
using System.Collections.Generic;
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
        public static double CalcTeamSize(SprintDevDTO sprintDev, UtilDTO.NAVIGATION navigation)
        {
            return Controle.CalcTeamSize(sprintDev, navigation);
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
        public static void CreateDevDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintDevDTO> sprints)
        {
            ControleDocDev.GenerateDoc(config, partner, contract, outputDocPath, sprints);
        }

        public static void CreateSmDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintSmDTO> sprints)
        {
            ControleDocSm.CreateSmDoc(config, partner, contract, outputDocPath, sprints);
        }

        public static void CreateOpsDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintDevOpsDTO> sprints)
        {
            ControleDocDevOps.CreateOpsDoc(config, partner, contract, outputDocPath, sprints);
        } 
        #endregion

        public static void SetDevPresence(List<ContratoDTO> contractList, int sprintDays, bool adaptarionSprint = false)
        {
            Controle.SetDevPresence(contractList, sprintDays, adaptarionSprint);
        }

        public static void CalcSmSprintData(List<SprintSmDTO> sprintsSmList, double factor)
        {
            Controle.CalcSmSprintData(sprintsSmList, factor);
        }
    }
}
