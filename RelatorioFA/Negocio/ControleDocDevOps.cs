﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;
using System.Linq;

namespace RelatorioFA.Negocio
{
    public class ControleDocDevOps : ControleDoc
    {
        #region GenerateDoc
        public static void CreateOpsDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintDevOpsDTO> sprintDevOpsList)
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

                string outputDocName = SetDocumentName(baseSprints, config, partner.Name, UtilDTO.REPORT_TYPE.DEVOPS);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);

                //Obtendo o contrato para a capa
                string contratoSap = "ERRO";
                foreach (var cont in from cont in partner.Contracts
                                     from batch in contract.Batches
                                     where batch.Name == UtilDTO.BATCHS.DEVOPS.ToString()
                                     select cont)
                {
                    contratoSap = contract.SapNumber;
                    break;
                }

                CreateFirstPage(paragraph, ranges, config, contratoSap);
                CreateFollowPages(document, partner, baseSprints, paragraph);
                CreateLastPage(document, paragraph, sprintDevOpsList, missing, config, partner, contract);
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
        private static void CreateLastPage(Document document, Paragraph paragraph, List<SprintDevOpsDTO> sprintsDevOps, object missing, ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract)
        {
            SetLastPageText(document, paragraph, partner, contract.UstValue);
            CreateSummaryTableUstDevOps(document, sprintsDevOps, missing, contract.UstValue);
            SetLastPageSignature(paragraph, config);
        }
        #endregion

        #region CreateSummaryTableUstDevOps
        private static void CreateSummaryTableUstDevOps(Document document, List<SprintDevOpsDTO> sprintsDevOps, object missing, double ustValue)
        {
            double totalPoints = 0;
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts suporte",
                "B. Pts sobreaviso",
                "C. Pts acionamento",
                "D. Pts de US",
                "E. Quantidade de plantonistas",
                "F. Pontos fornecedor\n((A + B) * E) + C + D",
                "A ser faturado\n(UST * F)"
            };
            int columns = headers.Count;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            int line = SetGenericTableHeader(ref summaryTable, headers, UtilDTO.CATEGORY.DESPESA);
            foreach (var sprint in sprintsDevOps)
            {
                double sprintPoints = ((sprint.SupportUst + sprint.WarningUst) * sprint.TeamSize) + sprint.ActuationUst + sprint.UsUst;
                summaryTable.Rows.Add(missing);
                summaryTable.Rows[line].Range.Font.Bold = 0;
                summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                summaryTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;
                summaryTable.Rows[line].Cells[2].Range.Text = sprint.SupportUst.ToString();
                summaryTable.Rows[line].Cells[3].Range.Text = sprint.WarningUst.ToString();
                summaryTable.Rows[line].Cells[4].Range.Text = sprint.ActuationUst.ToString();
                summaryTable.Rows[line].Cells[5].Range.Text = sprint.UsUst.ToString();
                summaryTable.Rows[line].Cells[6].Range.Text = sprint.TeamSize.ToString();
                summaryTable.Rows[line].Cells[7].Range.Text = sprintPoints.ToString();

                totalPoints += sprintPoints;
                line++;
            }
            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, ustValue, ref missing);
        }
        #endregion
    }
}
