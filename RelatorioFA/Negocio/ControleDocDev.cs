﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;
using System.Linq;

namespace RelatorioFA.Negocio
{
    public class ControleDocDev : ControleDoc
    {
        #region GenerateDoc
        public static void GenerateDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintDevDTO> sprints, UtilDTO.REPORT_TYPE reportType)
        {
            try
            {
                List<IntervaloDTO> ranges = new List<IntervaloDTO>();
                List<SprintBaseDTO> baseSprints = new List<SprintBaseDTO>();
                List<ColaboradorDTO> devTeam = new List<ColaboradorDTO>();

                foreach (var sprint in sprints)
                {
                    ranges.Add(sprint.Range);
                    baseSprints.Add(sprint.GetBaseSprint());
                }

                if (config.BaneseDes.Count > 0)
                {
                    foreach (var dev in config.BaneseDes)
                    {
                        devTeam.Add(dev);
                    }
                }

                devTeam.AddRange(from configPartner in config.Partners
                                 from cont in configPartner.Contracts
                                 from batch in cont.Batches
                                 where batch.Name == UtilDTO.BATCHS.DEV.ToString()
                                 from role in batch.Roles
                                 from dev in role.Collaborators
                                 select dev);
                
                string outputDocName = SetDocumentName(baseSprints, config, partner.Name, reportType);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(para1, ranges, config, contract.SapNumber);
                if (partner.BillingType == UtilDTO.BILLING_TYPE.UST_EXTERNAL)
                {
                    CreateFollowPages(document, partner, baseSprints, para1);
                }
                else
                {
                    CreateFollowPages(document, partner, baseSprints, para1, devTeam);
                }
                CreateLastPage(document, para1, sprints, missing, config, partner, contract);
                SetDocumentHeader(document, partner, config);
                SetDocumentFooter(document);
                SaveAndClose(ref document, ref winword, outputDocName, outputDocPath, missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CreateLastPage
        public static void CreateLastPage(Document document, Paragraph para1, List<SprintDevDTO> sprints, object missing, ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract)
        {
            SetLastPageText(document, para1, partner, contract.UstValue);

            switch (partner.BillingType)
            {
                case (UtilDTO.BILLING_TYPE.UST):
                    CreateSummaryTableUst(document, sprints, missing, partner, contract);
                    break;
                case (UtilDTO.BILLING_TYPE.UST_EXTERNAL):
                    CreateSummaryTableUstExternal(document, sprints, missing, contract.UstValue, UtilDTO.CATEGORY.INVESTIMENTO);
                    break;
                default:
                    break;
            }

            SetLastPageSignature(para1, config);
        }
        #endregion

        #region CreateSummaryTableUstExternal
        private static void CreateSummaryTableUstExternal(Document document, List<SprintDevDTO> sprints, object missing, double ustValue, UtilDTO.CATEGORY category)
        {
            double totalPoints = 0;
            int columns = 3;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            int line = SetTableHeaderUstDevExternal(ref summaryTable, category);

            foreach (var sprint in sprints)
            {
                summaryTable.Rows.Add(missing);
                summaryTable.Rows[line].Range.Font.Bold = 0;
                summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                summaryTable.Rows[line].Cells[2].Range.Text = sprint.AcceptedPointsExpenses.ToString();//A
                
                totalPoints += sprint.AcceptedPointsExpenses;
                line++;
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, ustValue, ref missing);
        }

        private static int SetTableHeaderUstDevExternal(ref Table summaryTable, UtilDTO.CATEGORY category)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "Pts entregues",
                "A ser faturado"
            };
            return SetGenericTableHeader(ref summaryTable, headers, category);
        }
        #endregion

        #region CreateSummaryTableUst
        private static void CreateSummaryTableUst(Document document, List<SprintDevDTO> sprints, object missing, FornecedorDTO partner, ContratoDTO contract)
        {
            CreateSummaryTableUstDev(document, sprints, ref missing, partner, contract, UtilDTO.CATEGORY.DESPESA);
            AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
            CreateSummaryTableUstDev(document, sprints, ref missing, partner, contract, UtilDTO.CATEGORY.INVESTIMENTO);
        }

        #region CreateSummaryTableUstDev
        private static void CreateSummaryTableUstDev(Document document, List<SprintDevDTO> sprintsDevList, ref object missing, FornecedorDTO partner, ContratoDTO contract, UtilDTO.CATEGORY category)
        {
            double totalPoints = 0;
            int columns = 10;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            int line = SetTableHeaderUstDev(ref summaryTable, category);

            foreach (var sprint in sprintsDevList)
            {
                foreach (var cont in sprint.Contracts)
                {
                    if (cont.PartnerName == partner.Name)
                    { 
                        foreach (var batch in cont.Batches)
                        {
                            if (batch.Name == UtilDTO.BATCHS.DEV.ToString())
                            {
                                foreach (var role in batch.Roles)
                                {
                                    double extraHourUst = 0;
                                    double employeeCount = 0;
                                    double partialPoints = 0;
                                    int acceptedPoints = category == UtilDTO.CATEGORY.DESPESA ? sprint.AcceptedPointsExpenses : sprint.AcceptedPointsInvestment;
                                    double pointsPerTeamMember = category == UtilDTO.CATEGORY.DESPESA ? sprint.PointsPerTeamMemberExpenses : sprint.PointsPerTeamMemberInvestment;
                                    string cerimonialPoint = "0";
                                    if ((category == UtilDTO.CATEGORY.DESPESA && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA) ||
                                        (category == UtilDTO.CATEGORY.INVESTIMENTO && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO))
                                    {
                                        cerimonialPoint = "1";
                                    }

                                    foreach (var dev in role.Collaborators)
                                    {
                                        employeeCount += dev.Presence;
                                        extraHourUst += Controle.CalcUstByExtraHour(category == UtilDTO.CATEGORY.DESPESA ? dev.ExtraHoursExpenses : dev.ExtraHourInvestment);
                                    }
                                    partialPoints = ((pointsPerTeamMember + Convert.ToDouble(cerimonialPoint)) * role.Factor * employeeCount) + extraHourUst;
                                    summaryTable.Rows.Add(missing);
                                    summaryTable.Rows[line].Range.Font.Bold = 0;
                                    summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                                    summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name + "\n" + role.Name;
                                    summaryTable.Rows[line].Cells[2].Range.Text = acceptedPoints.ToString();//A
                                    summaryTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString(decimalFormat);//B
                                    summaryTable.Rows[line].Cells[4].Range.Text = employeeCount.ToString(decimalFormat);//C
                                    summaryTable.Rows[line].Cells[5].Range.Text = pointsPerTeamMember.ToString(decimalFormat);//D
                                    summaryTable.Rows[line].Cells[6].Range.Text = role.Factor.ToString();//E
                                    summaryTable.Rows[line].Cells[7].Range.Text = cerimonialPoint;//F
                                    summaryTable.Rows[line].Cells[8].Range.Text = extraHourUst.ToString(decimalFormat);//G
                                    summaryTable.Rows[line].Cells[9].Range.Text = partialPoints.ToString(decimalFormat);//H

                                    totalPoints += Math.Round(partialPoints, 3);
                                    line++;  
                                }
                            }
                        } 
                    }
                }
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, contract.UstValue, ref missing);
        }
        #region SetTableHeaderUstDev
        private static int SetTableHeaderUstDev(ref Table table, UtilDTO.CATEGORY category)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues",
                "B. Tamanho do time",
                "C. Qtd funcionários empresa",
                "D. Pts por membro do time\n(A / B)",
                "E. Fator de ajuste",
                "F. UST pelas cerimônias",
                "G. UST Hora extra\n(0,5 UST a cada 4h)",
                "H. Total de pontos\n(( D + F) * E * C) + G",
                "A ser faturado\n(G * UST) "
            };
            return SetGenericTableHeader(ref table, headers, category);
        }
        #endregion
        #endregion
        #endregion
    }
}
