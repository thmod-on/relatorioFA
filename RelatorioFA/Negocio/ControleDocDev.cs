using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;
using System.Linq;

namespace RelatorioFA.Negocio
{
    public class ControleDocDev : ControleDoc
    {
        #region GenerateDoc
        public static void GenerateDoc(ConfigXmlDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevDTO> sprints)
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

                foreach (var configPartner in config.Partners)
                {
                    foreach (var contract in configPartner.Contracts)
                    {
                        if (contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString() &&
                            contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString())
                        {
                            foreach (var dev in contract.Collaborators)
                            {
                                devTeam.Add(dev);
                            }
                        }
                    }
                }

                string outputDocName = GetDocumentName(baseSprints, config, partner.Name);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(para1, ranges, config);
                CreateFollowPages(document, partner, baseSprints, para1, devTeam);
                CreateLastPage(document, para1, sprints, missing, config, partner);
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
        public static void CreateLastPage(Document document, Paragraph para1, List<SprintDevDTO> sprints, object missing, ConfigXmlDTO config, FornecedorDTO partner)
        {
            SetLastPageText(document, para1, partner);

            switch (partner.BillingType)
            {
                case (UtilDTO.BILLING_TYPE.UST):
                    CreateSummaryTableUst(document, sprints, missing, partner);
                    break;
                case (UtilDTO.BILLING_TYPE.UST_HORA):
                    CreateSummaryTableUstHour(document, sprints, missing, partner.UstValue);
                    break;
                default:
                    break;
            }

            SetLastPageSignature(para1, config);
        } 
        #endregion

        #region CreateSummaryTableUst
        private static void CreateSummaryTableUst(Document document, List<SprintDevDTO> sprints, object missing, FornecedorDTO partner)
        {
            CreateSummaryTableUstDev(document, sprints, ref missing, partner, UtilDTO.CATEGORY.DES);
            AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
            CreateSummaryTableUstDev(document, sprints, ref missing, partner, UtilDTO.CATEGORY.INV);
        }

        #region CreateSummaryTableUstDev
        private static void CreateSummaryTableUstDev(Document document, List<SprintDevDTO> sprintsDevList, ref object missing, FornecedorDTO partner, UtilDTO.CATEGORY category)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 9;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstDev(ref summaryTable, category);

            foreach (var sprint in sprintsDevList)
            {
                foreach (var contract in sprint.Contracts)
                {
                    if (contract.PartnerName == partner.Name)
                    {
                        double employeeCount = 0;
                        double partialPoints = 0;
                        int acceptedPoints = category == UtilDTO.CATEGORY.DES ? sprint.AcceptedPointsExpenses : sprint.AcceptedPointsInvestment;
                        double pointsPerTeamMember = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerTeamMemberExpenses : sprint.PointsPerTeamMemberInvestment;
                        string cerimonialPoint = "0";
                        if ((category == UtilDTO.CATEGORY.DES && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA) ||
                            (category == UtilDTO.CATEGORY.INV && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO))
                        {
                            cerimonialPoint = "1";
                        }
                        foreach (var dev in contract.Collaborators)
                        {
                            employeeCount += dev.Presence;
                        }
                        partialPoints = (pointsPerTeamMember + Convert.ToDouble(cerimonialPoint)) * contract.Factor * employeeCount;
                        summaryTable.Rows.Add(missing);
                        summaryTable.Rows[line].Range.Font.Bold = 0;
                        summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                        summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name + "\n" + contract.Name;
                        summaryTable.Rows[line].Cells[2].Range.Text = acceptedPoints.ToString();//A
                        summaryTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString(decimalFormat);//B
                        summaryTable.Rows[line].Cells[4].Range.Text = employeeCount.ToString(decimalFormat);//C
                        summaryTable.Rows[line].Cells[5].Range.Text = pointsPerTeamMember.ToString(decimalFormat);//D
                        summaryTable.Rows[line].Cells[6].Range.Text = contract.Factor.ToString();//E
                        summaryTable.Rows[line].Cells[7].Range.Text = cerimonialPoint;//F
                        summaryTable.Rows[line].Cells[8].Range.Text = partialPoints.ToString(decimalFormat);//G

                        totalPoints += partialPoints;
                        line++;
                    }
                }
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, partner.UstValue, ref missing);
        }
        #region SetTableHeaderUstDev
        private static void SetTableHeaderUstDev(ref Table table, UtilDTO.CATEGORY category)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues " + category,
                "B. Tamanho do time",
                "C. Qtd funcionários empresa",
                "D. Pts por membro do time\n(A / B)",
                "E. Fator de ajuste",
                "F. UST pelas cerimônias",
                "G. Total de pontos\n( D + F) * E * C",
                " - "
            };
            SetGenericTableHeader(ref table, headers);
        }
        #endregion
        #endregion
        #endregion

        #region CreateSummaryTableUstHour
        private static void CreateSummaryTableUstHour(Document document, List<SprintDevDTO> sprints, object missing, double ustValue)
        {
            //Utilizado apenas para uma empresa. Melhroar se necessario
            //Selecionar da lista de sprints aquelas que sao de hora.
            List<SprintDevDTO> sprintHourList = new List<SprintDevDTO>();
            SprintDevDTO sprintHour;
            foreach (var sprint in sprints)
            {
                foreach (var contract in sprint.Contracts)
                {
                    if (contract.HourValue > 0)
                    {
                        sprintHour = new SprintDevDTO()
                        {
                            Range = sprint.Range,
                            AcceptedPointsExpenses = sprint.AcceptedPointsExpenses,
                            AcceptedPointsInvestment = sprint.AcceptedPointsInvestment,
                            CerimonialPoint = sprint.CerimonialPoint,
                            ImagePath = sprint.ImagePath,
                            Obs = sprint.Obs,
                            TeamSize = sprint.TeamSize,
                            PointsPerTeamMemberExpenses = sprint.PointsPerTeamMemberExpenses,
                            PointsPerTeamMemberInvestment = sprint.PointsPerTeamMemberInvestment
                        };
                        sprintHour.Contracts.Add(contract);
                        sprintHourList.Add(sprintHour);
                    }
                }
            }

            CreateSummaryTableUstHourContent(document, sprintHourList, missing, ustValue, UtilDTO.CATEGORY.DES);
            AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
            CreateSummaryTableUstHourContent(document, sprintHourList, missing, ustValue, UtilDTO.CATEGORY.INV);
        }

        private static void CreateSummaryTableUstHourContent(Document document, List<SprintDevDTO> sprints, object missing, double ustValue, UtilDTO.CATEGORY category)
        {
            int columns = 9;
            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstHour(ref summaryTable, category);

            int line = 2;
            double totalHours = 0;

            foreach (var sprint in sprints)
            {
                foreach (var contract in sprint.Contracts)
                {
                    double employeeCount = 0;
                    double hours = 0;
                    double pointsPerPartner = 0;
                    string cerimonialPoint = "0";
                    if ((category == UtilDTO.CATEGORY.DES && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA) ||
                        (category == UtilDTO.CATEGORY.INV && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO))
                    {
                        cerimonialPoint = "1";
                    }
                    foreach (var dev in contract.Collaborators)
                    {
                        employeeCount += dev.Presence;
                    }

                    double pointsPerTeamMember = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerTeamMemberExpenses : sprint.PointsPerTeamMemberInvestment;

                    pointsPerPartner = employeeCount * (pointsPerTeamMember + Convert.ToDouble(cerimonialPoint));

                    hours = Math.Ceiling(pointsPerPartner * ustValue / contract.HourValue);

                    int acceptedPoints = category == UtilDTO.CATEGORY.DES ? sprint.AcceptedPointsExpenses : sprint.AcceptedPointsInvestment;
                    
                    summaryTable.Rows.Add(missing);
                    summaryTable.Rows[line].Range.Font.Bold = 0;
                    summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                    summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                    summaryTable.Rows[line].Cells[2].Range.Text = acceptedPoints.ToString();//A
                    summaryTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString(decimalFormat);//B
                    summaryTable.Rows[line].Cells[4].Range.Text = employeeCount.ToString(decimalFormat);//C
                    summaryTable.Rows[line].Cells[5].Range.Text = pointsPerTeamMember.ToString(decimalFormat);//D
                    summaryTable.Rows[line].Cells[6].Range.Text = cerimonialPoint;//E
                    summaryTable.Rows[line].Cells[7].Range.Text = pointsPerPartner.ToString(decimalFormat);//F
                    summaryTable.Rows[line].Cells[8].Range.Text = hours.ToString();//G

                    totalHours += hours;
                    line++;
                } 
            }

            summaryTable.Rows.Add(missing);
            summaryTable.Rows[line].Cells[1].Range.Text = "TOTAL:";
            summaryTable.Rows[line].Cells[1].Merge(summaryTable.Rows[line].Cells[columns - 2]);
            summaryTable.Rows[line].Cells[2].Range.Text = totalHours.ToString() + "h";
            summaryTable.Rows[line].Cells[2].Range.Font.Bold = 1;
            summaryTable.Rows[line].Cells[3].Range.Text = string.Format("{0:C}", totalHours * sprints[0].Contracts[0].HourValue);//(TODO) Atualmente apenas uma empresa usa esta categoria e representa a excecao. Melhorar depois!
            summaryTable.Rows[line].Cells[3].Range.Font.Bold = 1;

            //summaryTable.Range.Cells.AutoFit();
            //summaryTable.Range.Cells.DistributeHeight();
            summaryTable.Range.ParagraphFormat.SpaceAfter = 0;
        }

        private static void SetTableHeaderUstHour(ref Table table, UtilDTO.CATEGORY category)
        {
            List<string> headers = new List<string>()
            {
                "Sprint"
                ,$"A. Pts entregues {category}"
                ,"B. Tamanho do time"
                ,"C. Qtd funcionários empresa"
                ,"D. Pts por membro do time\n(A / B)"
                ,"E. Pontuação de cerimônia"
                ,"F. Pontos fornecedor\n(C *(D + E))"
                ,"G. Horas na sprint\n(F * UST / Valor hora)"
                ,"A ser faturado\n(G * Valor hora)"
            };
            SetGenericTableHeader(ref table, headers);
        }
        #endregion
    }
}
