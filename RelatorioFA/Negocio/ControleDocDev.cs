using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class ControleDocDev : ControleDoc
    {
        #region GenerateDoc
        public static void GenerateDoc(ConfigDocDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevDTO> sprints)
        {
            try
            {
                List<IntervaloDTO> ranges = new List<IntervaloDTO>();
                foreach (var sprint in sprints)
                {
                    ranges.Add(sprint.Range);
                }

                List<SprintBaseDTO> baseSprints = new List<SprintBaseDTO>();
                foreach (var sprint in sprints)
                {
                    baseSprints.Add(sprint.GetBaseSprint());
                }

                string outputDocName = GetDocumentName(baseSprints, config, partner.Name);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(para1, ranges, config);
                CreateFollowPages(document, partner, baseSprints, para1, config.DevTeam);
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
        public static void CreateLastPage(Document document, Paragraph para1, List<SprintDevDTO> sprints, object missing, ConfigDocDTO config, FornecedorDTO partner)
        {
            SetLastPageText(document, para1, partner);

            switch (partner.BillingType)
            {
                case (UtilDTO.BILLING_TYPE.UST):
                    CreateSummaryTableUst(document, sprints, missing, partner.UstValue);
                    break;
                case (UtilDTO.BILLING_TYPE.UST_HORA):
                    CreateSummaryTableUstHour(document, sprints, missing);
                    break;
                default:
                    break;
            }

            SetLastPageSignature(para1, config);
        } 
        #endregion

        #region CreateSummaryTableUst
        private static void CreateSummaryTableUst(Document document, List<SprintDevDTO> sprints, object missing, double ustValue)
        {
            CreateSummaryTableUstDev(document, sprints, ref missing, ustValue, UtilDTO.CATEGORY.DES);
            AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
            CreateSummaryTableUstDev(document, sprints, ref missing, ustValue, UtilDTO.CATEGORY.INV);
        }

        #region CreateSummaryTableUstDev
        private static void CreateSummaryTableUstDev(Document document, List<SprintDevDTO> sprints, ref object missing, double ustValue, UtilDTO.CATEGORY category)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 9;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstDev(ref summaryTable, category);

            foreach (var sprint in sprints)
            {
                foreach (var contract in sprint.Contracts)
                {
                    if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                    {
                        int acceptedPoints = category == UtilDTO.CATEGORY.DES ? sprint.AcceptedPointsExpenses : sprint.AcceptedPointsInvestment;
                        double pointsPerTeamMember = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerTeamMemberExpenses : sprint.PointsPerTeamMemberInvestment;
                        string cerimonialPoint = "0";
                        if ((category == UtilDTO.CATEGORY.DES && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA) ||
                            (category == UtilDTO.CATEGORY.INV && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO))
                        {
                            cerimonialPoint = "1";
                        }
                        double pointsPerPartner = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerPartnerExpenses : sprint.PointsPerPartnerInvestment;

                        summaryTable.Rows.Add(missing);
                        summaryTable.Rows[line].Range.Font.Bold = 0;
                        summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                        summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name + "\n" + contract.Name;
                        summaryTable.Rows[line].Cells[2].Range.Text = acceptedPoints.ToString();
                        summaryTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString();
                        summaryTable.Rows[line].Cells[4].Range.Text = sprint.EmployeesCount.ToString();
                        summaryTable.Rows[line].Cells[5].Range.Text = pointsPerTeamMember.ToString(decimalFormat);
                        summaryTable.Rows[line].Cells[6].Range.Text = contract.Factor.ToString();
                        summaryTable.Rows[line].Cells[7].Range.Text = cerimonialPoint;
                        summaryTable.Rows[line].Cells[8].Range.Text = pointsPerPartner.ToString(decimalFormat);

                        totalPoints += pointsPerPartner;
                        line++;
                    }
                }
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, ustValue, ref missing);
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
        private static void CreateSummaryTableUstHour(Document document, List<SprintDevDTO> sprints, object missing)
        {
            CreateSummaryTableUstHour(document, sprints, missing, UtilDTO.CATEGORY.DES);
            AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
            CreateSummaryTableUstHour(document, sprints, missing, UtilDTO.CATEGORY.INV);
        }

        private static void CreateSummaryTableUstHour(Document document, List<SprintDevDTO> sprints, object missing, UtilDTO.CATEGORY category)
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
                int acceptedPoints = category == UtilDTO.CATEGORY.DES ? sprint.AcceptedPointsExpenses : sprint.AcceptedPointsInvestment;
                double pointsPerTeamMember = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerTeamMemberExpenses : sprint.PointsPerTeamMemberInvestment;
                double pointsPerPartner = category == UtilDTO.CATEGORY.DES ? sprint.PointsPerPartnerExpenses : sprint.PointsPerPartnerInvestment;
                int hours = category == UtilDTO.CATEGORY.DES ? sprint.HoursExpenses : sprint.HoursInvestment;
                string cerimonialPoint = "0";
                if ((category == UtilDTO.CATEGORY.DES && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA) ||
                    (category == UtilDTO.CATEGORY.INV && sprint.CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO))
                {
                    cerimonialPoint = "1";
                }

                summaryTable.Rows.Add(missing);
                summaryTable.Rows[line].Range.Font.Bold = 0;
                summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                summaryTable.Rows[line].Cells[2].Range.Text = acceptedPoints.ToString();
                summaryTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString();
                summaryTable.Rows[line].Cells[4].Range.Text = sprint.EmployeesCount.ToString();
                summaryTable.Rows[line].Cells[5].Range.Text = pointsPerTeamMember.ToString(decimalFormat);
                summaryTable.Rows[line].Cells[6].Range.Text = cerimonialPoint;
                summaryTable.Rows[line].Cells[7].Range.Text = pointsPerPartner.ToString(decimalFormat);
                summaryTable.Rows[line].Cells[8].Range.Text = hours.ToString();

                totalHours += hours;
                line++;
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
