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
        public static double CalcTeamSize(Dictionary<string, double> devPresence)
        {
            return Controle.CalcTeamSize(devPresence);
        }

        public static void CalcPointsPerTeamMember(SprintDevDTO newSprint)
        {
            Controle.CalcPointsPerTeamMember(newSprint);
        }

        public static double CalcEmployeesPrticipation(ContratoDTO contract, Dictionary<string, double> devPresence)
        {
            return Controle.CalcEmployeesPrticipation(contract, devPresence);
        }

        public static double CalcPartnerPoints(double pointsPerTeamMember, double factor, bool addCerimonialPoint, double emploeeCount)
        {
            return Controle.CalcPartnerPoints(pointsPerTeamMember, factor, addCerimonialPoint, emploeeCount);
        }

        public static double CalcBillingUst(double ustValue, double pointsPerPartner, double factor)
        {
            return Controle.CalcBillingUst(ustValue, pointsPerPartner, factor);
        }

        public static double CalcBillingHour(int hours, double hourValue)
        {
            return Controle.CalcBillingHour(hours, hourValue);
        }

        public static int CalcSprintHours(double pointsPerPartner, double ustValue, double hourValue)
        {
            return Controle.CalcSprintHours(pointsPerPartner, ustValue, hourValue);
        }

        public static void GenerateConfigXmlFile(string outputPath, string outputName, ConfigXmlDTO config)
        {
            ControleXml.GenerateConfigXmlFile(outputPath, outputName, config);
        } 
        #endregion

        #region CreateDoc
        public static void CreateDevDoc(ConfigDocDTO config, FornecedorDTO partner, string outputDocPath, List<SprintBaseDTO> sprints)
        {
            ControleDocDev.GenerateDoc(config, partner, outputDocPath, sprints);
        }

        public static void GenerateDoc(ConfigDocDTO config, FornecedorDTO partner, string outputDocPath, List<SprintSmDTO> sprints)
        {
            ControleDocSm.GenerateDoc(config, partner, outputDocPath, sprints);
        }

        public static void CreateOpsDoc(ConfigDocDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevOpsDTO> sprints)
        {
            ControleDocDevOps.GenerateDoc(config, partner, outputDocPath, sprints);
        } 
        #endregion

        public static void SetDevPresence(out Dictionary<string, double> devPresence, Dictionary<ColaboradorDTO, int> devAbsence, int sprintDays)
        {
            Controle.SetDevPresence(out devPresence, devAbsence, sprintDays);
        }
    }
}
