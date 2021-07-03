using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class ControleDocDevOps : ControleDoc
    {
        #region GenerateDoc
        public static void GenerateDoc(ConfigXmlDTO config, FornecedorDTO partner, string outputDocPath, List<SprintDevOpsDTO> sprintDevOpsList)
        {
            try
            {
                List<IntervaloDTO> ranges = new List<IntervaloDTO>();
                foreach (var sprint in sprintDevOpsList)
                {
                    ranges.Add(sprint.Range);
                }

                List<SprintBaseDTO> baseSprints = new List<SprintBaseDTO>();
                foreach (var sprintOps in sprintDevOpsList)
                {
                    baseSprints.Add(sprintOps.GetBaseSprint());
                }

                string outputDocName = GetDocumentName(baseSprints, config, partner.Name);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(paragraph, ranges, config);
                CreateFollowPages(document, partner, baseSprints, paragraph);
                CreateLastPage(document, paragraph, sprintDevOpsList, missing, config, partner);
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

        #region LastPage
        private static void CreateLastPage(Document document, Paragraph paragraph, List<SprintDevOpsDTO> sprintsDevOps, object missing, ConfigXmlDTO config, FornecedorDTO partner)
        {
            SetLastPageText(document, paragraph, partner);
            CreateSummaryTableUstDevOps(document, sprintsDevOps, missing, partner);
            SetLastPageSignature(paragraph, config);
        }
        #endregion

        #region CreateSummaryTableUstDevOps
        private static void CreateSummaryTableUstDevOps(Document document, List<SprintDevOpsDTO> sprintsDevOps, object missing, FornecedorDTO partner)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 7;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts sobreaviso",
                "B. Pts acionamento",
                "C. Pts de US",
                "D. Quantidade de plantonistas",
                "E. Pontos fornecedor\n(A * D) + B + C",
                "A ser faturado\n(UST * E)"
            };
            SetGenericTableHeader(ref summaryTable, headers);
            foreach (var sprint in sprintsDevOps)
            {
                double sprintPoints = (sprint.WarningUst * sprint.TeamSize) + sprint.ActuationUst + sprint.UsUst;
                summaryTable.Rows.Add(missing);
                summaryTable.Rows[line].Range.Font.Bold = 0;
                summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                summaryTable.Rows[line].Cells[2].Range.Text = sprint.WarningUst.ToString();
                summaryTable.Rows[line].Cells[3].Range.Text = sprint.ActuationUst.ToString();
                summaryTable.Rows[line].Cells[4].Range.Text = sprint.UsUst.ToString();
                summaryTable.Rows[line].Cells[5].Range.Text = sprint.TeamSize.ToString();
                summaryTable.Rows[line].Cells[6].Range.Text = sprintPoints.ToString();

                totalPoints += sprintPoints;
                line++;
            }
            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, partner.UstValue, ref missing);
        }
        #endregion
    }
}
