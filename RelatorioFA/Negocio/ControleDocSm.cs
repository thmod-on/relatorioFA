using Microsoft.Office.Interop.Word;
using RelatorioFA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelatorioFA.Negocio
{
    public class ControleDocSm : ControleDoc
    {
        public static void GenerateDoc(ConfigDocDTO config, FornecedorDTO partner, string outputDocPath, List<SprintSmDTO> sprints)
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
                Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(paragraph, ranges, config);
                CreateFollowPages(document, partner, baseSprints, paragraph, config.DevTeam);
                CreateLastPage(document, paragraph, sprints, missing, config, partner);
                SetDocumentHeader(document, partner, config);
                SetDocumentFooter(document);
                SaveAndClose(ref document, ref winword, outputDocName, outputDocPath, missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CreateLastPage(Document document, Paragraph paragraph, List<SprintSmDTO> sprints, object missing, ConfigDocDTO config, FornecedorDTO partner)
        {
            SetLastPageText(document, paragraph, partner);
            if (sprints[0].Contracts[0].Name == UtilDTO.CONTRACTS.SM_FIXO.ToString()) //(TODO) Cada time tem 1 SM, Melhorar  o DTO para representar
            {
                CreateSummaryTableUstSmSettled(document, sprints, ref missing, partner.UstValue);
            }
            else
            {
                if (sprints[0].Contracts[0].Name == UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                {
                    throw new NotImplementedException();
                }
            }
            SetLastPageSignature(paragraph, config);
        }

        #region CreateSummaryTableUstSmSettled
        private static void CreateSummaryTableUstSmSettled(Document document, List<SprintSmDTO> sprints, ref object missing, double ustValue)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 7;

            Table smTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            smTable.Borders.Enable = 1;
            smTable.Range.Font.Size = 8;

            SetTableHeaderUstSm(ref smTable);
            
            foreach (var sprint in sprints)
            {
                smTable.Rows.Add(missing);
                smTable.Rows[line].Range.Font.Bold = 0;
                smTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                smTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                smTable.Rows[line].Cells[2].Range.Text = (sprint.AcceptedPointsExpenses + sprint.AcceptedPointsInvestment).ToString();
                smTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString();
                smTable.Rows[line].Cells[4].Range.Text = sprint.EmployeesCount.ToString();
                smTable.Rows[line].Cells[5].Range.Text = sprint.PointsPerPartnerExpenses.ToString();
                smTable.Rows[line].Cells[6].Range.Text = sprint.PointsPerPartnerExpenses.ToString();

                totalPoints += sprint.PointsPerPartnerExpenses;
                line++;
            }

            SetSummaryTableTotal(ref smTable, columns, line, totalPoints, ustValue, ref missing);
        }

        #region SetTableHeaderUstSm
        private static void SetTableHeaderUstSm(ref Table smTable)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues",
                "B. Tamanho do time",
                "C. Qtd funcionários empresa",
                "D. Pts por membro do time (Fixo)",
                "E. Pontos fornecedor\n(C * D)",
                "A ser faturado\n(UST * E)"
            };
            SetGenericTableHeader(ref smTable, headers);
        }
        #endregion
        #endregion
    }
}
