using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using RelatorioFA.DTO;
using System.IO;

namespace RelatorioFA.Negocio
{
    public abstract class ControleDoc
    {
        public const string decimalFormat = "0.000";

        #region SaveAndClose
        public static void SaveAndClose(ref Document document, ref Application winword, string outputDocName, string outputDocPath, object missing)
        {
            object filename = Path.Combine(outputDocPath, outputDocName);
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
        }
        #endregion

        #region CreateFirstPage
        public static void CreateFirstPage(Paragraph paragraph, List<IntervaloDTO> ranges, ConfigXmlDTO config)
        {
            string strAux;
            List<string> paragraphTexts = new List<string>();

            AddPAragraph(paragraph, "RELATÓRIO DE ATIVIDADES", 20, 150, 1, 20, WdParagraphAlignment.wdAlignParagraphCenter);

            #region Identificação das sprints
            strAux = "ATIVIDADES DESENVOLVIDAS NAS SPRINTS: ";
            int sprintsCount = 1;
            foreach (var range in ranges)
            {
                strAux += range.Name;
                if (sprintsCount < ranges.Count())
                {
                    strAux += ", ";
                }
                sprintsCount++;
            }
            paragraphTexts.Add(strAux);

            strAux = "TIME: " + config.AreaName + " - " + config.TeamName;
            paragraphTexts.Add(strAux);

            strAux = $"PERÍODO: {ranges[0].IniDate:dd/MM/yyyy} a {ranges[ranges.Count - 1].EndDate:dd/MM/yyyy}";
            paragraphTexts.Add(strAux);

            foreach (var paragraphText in paragraphTexts)
            {
                AddPAragraph(paragraph, paragraphText, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphRight);
            }
            #endregion

            AddPAragraph(paragraph, "Banese – Banco do Estado de Sergipe", 150, 150, 1, 20, WdParagraphAlignment.wdAlignParagraphCenter);

            strAux = "Aracaju, " + DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
            AddPAragraph(paragraph, strAux, 150, 150, 0, 14, WdParagraphAlignment.wdAlignParagraphRight);
        }
        #endregion

        #region CreateFollowPages
        public static void CreateFollowPages(Document document, FornecedorDTO partner, List<SprintBaseDTO> sprints, Paragraph paragraph, List<ColaboradorDTO> devTeam = null)
        {
            string strAux;
            string strObs = string.Empty;
            string lastSprint = string.Empty;

            for (int i = 0; i < sprints.Count; i++)
            {
                if (i + 1 < sprints.Count && sprints[i].Range.Name == sprints[i+1].Range.Name)
                {
                    strObs = sprints[i].Obs;
                }
                else
                {
                    if (i > 0)
                    {
                        document.Words.Last.InsertBreak(WdBreakType.wdPageBreak);
                    }

                    //Cabecalho da sprint
                    strObs += " " + sprints[i].Obs;
                    strAux = $"SPRINT {sprints[i].Range.Name} ({sprints[i].Range.IniDate:dd/MM/yyyy} a {sprints[i].Range.EndDate:dd/MM/yyyy})";
                    AddPAragraph(paragraph, strAux, 30, 30, 1, 14, WdParagraphAlignment.wdAlignParagraphJustify);

                    //Imagem da sprint
                    if (!string.IsNullOrEmpty(sprints[i].ImagePath))
                    {
                        paragraph.Range.InlineShapes.AddPicture(sprints[i].ImagePath);
                        paragraph.Range.InsertParagraphAfter(); 
                    }

                    if (devTeam != null)
                    {
                        //Time de desenvolvimento
                        AddPAragraph(paragraph, "TIME DE DESENVOLVIMENTO:", 30, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);

                        foreach (var dev in devTeam)
                        {
                            strAux = dev.Name;
                            if (partner
                                .Contracts.Any(contract => contract
                                .Collaborators.Any(colaborator => colaborator.Name == dev.Name)))
                            {
                                AddPAragraph(paragraph, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify, WdColorIndex.wdYellow);
                            }
                            else
                            {
                                AddPAragraph(paragraph, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
                            }
                        } 
                    }
                    //OBS da sprint
                    strAux = $"* {strObs}";
                    AddPAragraph(paragraph, strAux, 30, 30, 0, 10, WdParagraphAlignment.wdAlignParagraphJustify);
                    strObs = string.Empty;
                }
            }
        }
        #endregion

        #region CreateLastPageContent
        public static void SetLastPageText(Document document, Paragraph para1, FornecedorDTO partner)
        {
            UtilDTO.BILLING_TYPE billingType = partner.BillingType;
            string strAux;
            document.Words.Last.InsertBreak(WdBreakType.wdPageBreak);

            AddPAragraph(para1, "DETALHES DO FATURAMENTO", 10, 0, 1, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            if (billingType == UtilDTO.BILLING_TYPE.UST ||
                billingType == UtilDTO.BILLING_TYPE.UST_HORA ||
                billingType == UtilDTO.BILLING_TYPE.UST_DEVOPS)
            {
                strAux = "Valor da UST: R$" + partner.UstValue;
                AddPAragraph(para1, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            }
            //POG para Inlfuir. Melhorar se necessário
            if (billingType == UtilDTO.BILLING_TYPE.UST_HORA || billingType == UtilDTO.BILLING_TYPE.HORA)
            {
                strAux = "Valor da hora: R$" + partner.Contracts[0].HourValue;
                AddPAragraph(para1, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
                strAux = "Contrato: " + partner.Contracts[0].Name;
                AddPAragraph(para1, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            }
            foreach (var contract in partner.Contracts)
            {
                strAux = $"Contrato / SAP: {contract.Name} / {contract.NumeroSAP}";
                AddPAragraph(para1, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            }
        }

        public static void SetLastPageSignature(Paragraph paragraph, ConfigXmlDTO config)
        {
            AddPAragraph(paragraph, "Atenciosamente,", 150, 30, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            AddPAragraph(paragraph, "_______________________________________________________", 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(paragraph, config.AuthorName, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(paragraph, "Gerente de suporte - " + config.AreaName + " - " + config.TeamName, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
        }
        #endregion

        #region Sobrecarga desnecessaria. Apagar um.
        /// <summary>
        /// Método para criar novos parágrafos no documento Word
        /// </summary>
        /// <param name="text">Texto a ser adicionado no parágrafo</param>
        /// <param name="spaceBefore">Formatação do parágrafo. Espaçamento a ser adicionado antes do parágraço</param>
        /// <param name="spaceAfter">Formatação do parágrafo. Espaçamento a ser adicionado depois do parágraço</param>
        /// <param name="flagFontBold">Formatação da fonte. Inteiro que identifica se o texto deve estar em negrito. 0 - Texto normal; 1 - Texto em negrito</param>
        /// <param name="fontSize">Formatação da fonte. Tamanho da fonte presente no parágrafo</param>
        /// <param name="paragraphAlignment">Formatação do parágrafo. Alinhamento a sser utilizado para o parágrafo a ser adicionado</param>
        /// <param name="doc">Documento a ser inserido o parágrafo</param>
        /// <param name="missing"></param>
        public static void AddPAragraph(string text, int spaceBefore, int spaceAfter, int flagFontBold, int fontSize, WdParagraphAlignment paragraphAlignment, Document doc, ref object missing)
        {
            Paragraph paragraph = doc.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = text;
            paragraph.Format.SpaceBefore = spaceBefore;
            paragraph.Format.SpaceAfter = spaceAfter;
            paragraph.Range.Font.Bold = flagFontBold;
            paragraph.Range.Font.Size = fontSize;
            paragraph.Format.Alignment = paragraphAlignment;
            paragraph.Range.InsertParagraphAfter();
        }

        public static void AddPAragraph(Paragraph paragraph, string text, int spaceBefore, int spaceAfter, int flagFontBold, int fontSize, WdParagraphAlignment paragraphAlignment, WdColorIndex highlightColor = WdColorIndex.wdAuto)
        {
            paragraph.Range.Text = text;
            paragraph.Format.SpaceBefore = spaceBefore;
            paragraph.Format.SpaceAfter = spaceAfter;
            paragraph.Range.Font.Bold = flagFontBold;
            paragraph.Range.Font.Size = fontSize;
            paragraph.Range.HighlightColorIndex = highlightColor;
            paragraph.Format.Alignment = paragraphAlignment;
            paragraph.Range.InsertParagraphAfter();
        }
        #endregion

        #region CreateSummaryTable
        #region SetGenericTableHeader
        public static void SetGenericTableHeader(ref Table table, List<string> headers)
        {
            int column = 1;

            foreach (var header in headers)
            {
                table.Cell(1, column).Range.Text = header;
                column++;
            }

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Shading.BackgroundPatternColor = WdColor.wdColorGray25;
            table.Rows[1].Alignment = WdRowAlignment.wdAlignRowCenter;
        }
        #endregion

        #region SetSummaryTableTotal
        public static void SetSummaryTableTotal(ref Table summaryTable, int columns, int line, double totalPoints, double ustValue, ref object missing)
        {
            summaryTable.Rows.Add(missing);
            summaryTable.Rows[line].Cells[1].Range.Text = "TOTAL A SER FATUADO:";
            summaryTable.Rows[line].Cells[1].Merge(summaryTable.Rows[line].Cells[columns - 2]);
            summaryTable.Rows[line].Cells[2].Range.Text = totalPoints.ToString(decimalFormat);
            summaryTable.Rows[line].Cells[2].Range.Font.Bold = 1;
            summaryTable.Rows[line].Cells[3].Range.Text = string.Format("{0:C}", Math.Round(totalPoints, 3) * ustValue);
            summaryTable.Rows[line].Cells[3].Range.Font.Bold = 1;

            //summaryTable.Range.Cells.AutoFit();
            //summaryTable.Range.Cells.DistributeHeight();
            summaryTable.Range.ParagraphFormat.SpaceAfter = 0;
        }
        #endregion
        #endregion

        #region SetDocumentFooter
        public static void SetDocumentFooter(Document document)
        {
            foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
            {
                //Get the footer range and add the footer details.  
                Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdGray50;
                footerRange.Font.Size = 10;
                footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = "BANESE - Banco do Estado de Sergipe";
            }
        }
        #endregion

        #region SetDocumentHeader
        public static void SetDocumentHeader(Document document, FornecedorDTO partner, ConfigXmlDTO config)
        {
            foreach (Section section in document.Sections)
            {
                //Get the header range and add the header details.  
                Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.Text = "";
                if (partner.CaminhoLogomarca != string.Empty)
                {
                    headerRange.InlineShapes.AddPicture(partner.CaminhoLogomarca);
                }
                else
                {
                    headerRange.Font.Size = 10;
                    headerRange.Text = $"{partner.Name} - {config.AreaName} - {config.TeamName}".ToUpper();
                }
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
            }
        }
        #endregion

        #region AUX
        public static Range EndOfDocument(Document doc, ref object missing)
        {
            return doc.Range(doc.Content.End - 1, ref missing);
        }

        public static string SetDocumentName(List<SprintBaseDTO> sprints, ConfigXmlDTO config, string partnerName, UtilDTO.REPORT_TYPE reportType)
        {
            string outputDocName = $"Relatório Ágil -";
            foreach (var sprint in sprints)
            {
                outputDocName += $" {sprint.Range.Name}";
            }
            outputDocName += $" - {config.AreaName}-{config.TeamName} - {partnerName} - {reportType}.docx";

            return outputDocName;
        }

        public static Application CreateWinWord()
        {
            Application winword = new Application
            {
                ShowAnimation = false,
                //Set status for word application is to be visible or not.  
                Visible = false
            };

            return winword;
        }
        #endregion
    }
}
