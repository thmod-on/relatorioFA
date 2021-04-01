﻿using System;
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
        public static ConfigDTO LoadConfig(string outputDocPath)
        {
            return ConfigXmlDA.LoadConfig(outputDocPath);
        }
        
        public static void CreateDocs(ConfigDTO config, List<SprintDTO> sprints, List<ColaboradorDTO> devTeam, string outputDocPath)
        {
            ControleDoc.GenerateAllDocs(config, sprints, devTeam, outputDocPath);
        }

        public static List<IntervaloDTO> GenerateRanges()
        {
            return Controle.GenerateRanges();
        }
        
        public static double CalcTeamSize(Dictionary<string, double> devPresence)
        {
            return Controle.CalcTeamSize(devPresence);
        }

        public static void SetDevPresence(out Dictionary<string, double> devPresence, Dictionary<string, int> devAbsence, int sprintDays)
        {
            Controle.SetDevPresence(out devPresence, devAbsence, sprintDays);
        }

        public static void CalcPointsPerTeamMember(SprintDTO newSprint)
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

        public static void GenerateConfigXmlFile(string outputPath, string outputName, ConfigDTO config)
        {
            ControleXml.GenerateConfigXmlFile(outputPath, outputName, config);
        }

        public static double CalcBillingHour(int hours, double hourValue)
        {
            return Controle.CalcBillingHour(hours, hourValue);
        }

        public static int CalcSprintHours(double pointsPerPartner, double ustValue, double hourValue)
        {
            return Controle.CalcSprintHours(pointsPerPartner, ustValue, hourValue);
        }
    }
}
