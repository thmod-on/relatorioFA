﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelatorioFA.DTO;
using System.IO;

namespace RelatorioFA.Negocio
{
    public class ControleDoc
    {
        public static void GenerateAllDocs(ConfigDTO config, List<SprintDTO> sprints, List<ColaboradorDTO> devTeam, string outputDocPath)
        {
            try
            {
                string baseOutputDocName = $"Relatório Ágil -";
                string outputDocName = string.Empty;

                foreach (var sprint in sprints)
                {
                    baseOutputDocName += $" {sprint.Range.Name}";
                }

                foreach (var partner in config.Partners)
                {
                    outputDocName = baseOutputDocName;
                    outputDocName += $" - {partner.Name} - {config.TeamName}.docx";
                    //Create an instance for word app  
                    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application
                    {
                        ShowAnimation = false,
                        //Set status for word application is to be visible or not.  
                        Visible = false
                    };

                    //Create a missing variable for missing value  
                    object missing = System.Reflection.Missing.Value;

                    //Create a new document  
                    Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                    SetDocumentContent(document, ref missing, sprints, devTeam, config.TeamName, config.AuthorName, partner, partner.BillingType);
                    SetDocumentHeader(document, partner.Name, config.TeamName);
                    SetDocumentFooter(document);
                    SaveAndClose(ref document, ref winword, outputDocName, outputDocPath, missing); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region SaveAndClose
        private static void SaveAndClose(ref Document document, ref Application winword, string outputDocName, string outputDocPath, object missing)
        {
            //ExportAndCloseDocument(winword, document, );
            //Save the document
            object filename = Path.Combine(outputDocPath, outputDocName);
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            //document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            //winword = null;
        }
        #endregion

        #region SetDocumentContent
        private static void SetDocumentContent(Document document, ref Object missing, List<SprintDTO> sprints, List<ColaboradorDTO> devTeam, string teamName, string author, FornecedorDTO partner, UtilDTO.BILLING_TYPE billingType)
        {
            Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

            CreateFirstPage(para1, sprints, teamName);
            
            CreateFollowPages(sprints, devTeam, para1);

            CreateLastPage(document, para1, sprints, missing, author, teamName, billingType, partner);
        }

        #region CreateFirstPage
        private static void CreateFirstPage(Paragraph para1, List<SprintDTO> sprints, string teamName)
        {
            string strAux;
            List<string> paragraphTexts = new List<string>();

            AddPAragraph(para1, "RELATÓRIO DE ATIVIDADES", 20, 150, 1, 20, WdParagraphAlignment.wdAlignParagraphCenter);

            #region Identificação das sprints
            strAux = "ATIVIDADES DESENVOLVIDAS NAS SPRINTS: ";
            int sprintsCount = 1;
            foreach (var sprint in sprints)
            {
                strAux += sprint.Range.Name;
                if (sprintsCount < sprints.Count())
                {
                    strAux += ", ";
                }
                sprintsCount++;
            }
            paragraphTexts.Add(strAux);

            strAux = "TIME: " + teamName;
            paragraphTexts.Add(strAux);
            
            strAux = $"PERÍODO: {sprints[0].Range.IniDate.ToString("dd/MM/yyyy")} a {sprints[sprints.Count - 1].Range.EndDate.ToString("dd/MM/yyyy")}";
            paragraphTexts.Add(strAux);

            foreach (var paragraphText in paragraphTexts)
            {
                AddPAragraph(para1, paragraphText, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphRight);
            }
            #endregion

            AddPAragraph(para1, "Banese – Banco do Estado de Sergipe", 150, 150, 1, 20, WdParagraphAlignment.wdAlignParagraphCenter);
            
            strAux = "Aracaju, " + DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
            AddPAragraph(para1, strAux, 150, 150, 0, 14, WdParagraphAlignment.wdAlignParagraphRight);
        }
        #endregion

        #region CreateLastPage
        private static void CreateLastPage(Document document, Paragraph para1, List<SprintDTO> sprints, object missing, string author, string teamName,UtilDTO.BILLING_TYPE billingType, FornecedorDTO partner)
        {
            string strAux;
            document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

            AddPAragraph(para1, "DETALHES DO FATURAMENTO", 10, 0, 1, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            if (billingType == UtilDTO.BILLING_TYPE.UST || billingType == UtilDTO.BILLING_TYPE.UST_HORA)
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
            
            switch (billingType)
            {
                case (UtilDTO.BILLING_TYPE.UST):
                    CreateSummaryTableUst(document, sprints, partner.Contracts, missing, partner.UstValue);
                    break;
                case (UtilDTO.BILLING_TYPE.UST_HORA):
                    CreateSummaryTableUstHour(document, para1.Range, sprints, partner.Contracts, missing);
                    break;
                default:
                    break;
            }            

            //assinatura
            AddPAragraph(para1, "Atenciosamente,", 150, 30, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            AddPAragraph(para1, "_________________________________________________", 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(para1, author, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(para1, teamName, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
        }
        #endregion

        #region CreateFollowPages
        private static void CreateFollowPages(List<SprintDTO> sprints, List<ColaboradorDTO> devTeam, Paragraph paragraph)
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
                    strObs += " " + sprints[i].Obs;
                    strAux = $"SPRINT {sprints[i].Range.Name} ({sprints[i].Range.IniDate.ToString("dd/MM/yyyy")} a {sprints[i].Range.EndDate.ToString("dd/MM/yyyy")})";
                    AddPAragraph(paragraph, strAux, 30, 30, 1, 14, WdParagraphAlignment.wdAlignParagraphJustify);

                    AddPAragraph(paragraph, "TIME DE DESENVOLVIMENTO:", 30, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);

                    foreach (var dev in devTeam)
                    {
                        strAux = dev.Name;
                        AddPAragraph(paragraph, strAux, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
                    }
                    //Detalhes da sprint
                    strAux = $"* {strObs}";
                    AddPAragraph(paragraph, strAux, 30, 30, 0, 10, WdParagraphAlignment.wdAlignParagraphJustify);
                    strObs = string.Empty;
                }
            }
        }
        #endregion
        #endregion

        #region AddPAragraph
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
        private static void AddPAragraph(string text, int spaceBefore, int spaceAfter, int flagFontBold, int fontSize, WdParagraphAlignment paragraphAlignment, Document doc, ref object missing)
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

        private static void AddPAragraph(Paragraph paragraph, string text, int spaceBefore, int spaceAfter, int flagFontBold, int fontSize, WdParagraphAlignment paragraphAlignment)
        {
            paragraph.Range.Text = text;
            paragraph.Format.SpaceBefore = spaceBefore;
            paragraph.Format.SpaceAfter = spaceAfter;
            paragraph.Range.Font.Bold = flagFontBold;
            paragraph.Range.Font.Size = fontSize;
            paragraph.Format.Alignment = paragraphAlignment;
            paragraph.Range.InsertParagraphAfter();
        }
        #endregion

        #region CreateSummaryTable
        #region CreateSummaryTableUst
        private static void CreateSummaryTableUst(Document document, List<SprintDTO> sprints, List<ContratoDTO> contracts, object missing, double ustValue)
        {
            #region DevTable
            if (contracts.Any(x => x.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString()))
            {
                CreateSummaryTableUstDevExpenses(document, sprints, contracts, ref missing, ustValue);
                AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
                CreateSummaryTableUstDevInvestment(document, sprints, contracts, ref missing, ustValue);
            }
            #endregion

            #region SMTable - Fixo
            if (contracts.Any(x => x.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString()))
            {
                CreateSummaryTableUstSmSettled(document, sprints, contracts, ref missing, ustValue);
            }
            #endregion
        }

        #region CreateSummaryTableUstDev
        #region CreateSummaryTableUstDevExpenses
        private static void CreateSummaryTableUstDevExpenses(Document document, List<SprintDTO> sprints, List<ContratoDTO> contracts, ref object missing, double ustValue)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 9;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstDevExp(ref summaryTable);

            foreach (var contract in contracts)
            {
                if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                {
                    int sprintIndex = 0;
                    foreach (var cs in contract.ContractSprint)
                    {
                        summaryTable.Rows.Add(missing);
                        summaryTable.Rows[line].Range.Font.Bold = 0;
                        summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                        summaryTable.Rows[line].Cells[1].Range.Text = sprints[sprintIndex].Range.Name + "\n" + contract.Name;
                        summaryTable.Rows[line].Cells[2].Range.Text = sprints[sprintIndex].AcceptedPointsExpenses.ToString();
                        summaryTable.Rows[line].Cells[3].Range.Text = sprints[sprintIndex].TeamSize.ToString();
                        summaryTable.Rows[line].Cells[4].Range.Text = cs.EmployeesCount.ToString();
                        summaryTable.Rows[line].Cells[5].Range.Text = sprints[sprintIndex].PointsPerTeamMemberExpenses.ToString();
                        summaryTable.Rows[line].Cells[6].Range.Text = contract.Factor.ToString();
                        summaryTable.Rows[line].Cells[7].Range.Text = sprints[sprintIndex].CerimonialPoint == UtilDTO.CERIMONIAL_POINT.DESPESA ? "1" : "0";
                        summaryTable.Rows[line].Cells[8].Range.Text = cs.PointsPerPartnerExpenses.ToString();

                        totalPoints += cs.PointsPerPartnerExpenses;
                        line++;
                        sprintIndex++;
                    }
                }
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, ustValue, ref missing);
        }
        #region SetTableHeaderUstDevExp
        private static void SetTableHeaderUstDevExp(ref Table table)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues DES",
                "B. Tamanho do time",
                "C. Qtd funcionários empresa",
                "D. Pts por membro do time\n(A / B)",
                "E. Fator de ajuste",
                "F. UST pelas cerimônias",
                "G. Total de pontos\n( D + F) * E",
                " - "
            };
            SetGenericTableHeader(ref table, headers);
        }
        #endregion
        #endregion

        #region CreateSummaryTableUstDevInvestment
        private static void CreateSummaryTableUstDevInvestment(Document document, List<SprintDTO> sprints, List<ContratoDTO> contracts, ref object missing, double ustValue)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 9;

            Table summaryTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);

            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstDevInv(ref summaryTable);

            foreach (var contract in contracts)
            {
                if (contract.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString() && contract.Name != UtilDTO.CONTRACTS.SM_MEDIA.ToString())
                {
                    int sprintIndex = 0;
                    foreach (var cs in contract.ContractSprint)
                    {
                        summaryTable.Rows.Add(missing);
                        summaryTable.Rows[line].Range.Font.Bold = 0;
                        summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                        summaryTable.Rows[line].Cells[1].Range.Text = sprints[sprintIndex].Range.Name + "\n" + contract.Name;
                        summaryTable.Rows[line].Cells[2].Range.Text = sprints[sprintIndex].AcceptedPointsInvestment.ToString();
                        summaryTable.Rows[line].Cells[3].Range.Text = sprints[sprintIndex].TeamSize.ToString();
                        summaryTable.Rows[line].Cells[4].Range.Text = cs.EmployeesCount.ToString();
                        summaryTable.Rows[line].Cells[5].Range.Text = sprints[sprintIndex].PointsPerTeamMemberInvestment.ToString();
                        summaryTable.Rows[line].Cells[6].Range.Text = contract.Factor.ToString();
                        summaryTable.Rows[line].Cells[7].Range.Text = sprints[sprintIndex].CerimonialPoint == UtilDTO.CERIMONIAL_POINT.INVESTIMENTO ? "1" : "0";
                        summaryTable.Rows[line].Cells[8].Range.Text = cs.PointsPerPartnerExpenses.ToString();

                        totalPoints += cs.PointsPerPartnerExpenses;
                        line++;
                        sprintIndex++;
                    }
                }
            }

            SetSummaryTableTotal(ref summaryTable, columns, line, totalPoints, ustValue, ref missing);
        }
        #region SetTableHeaderUstDevInv
        private static void SetTableHeaderUstDevInv(ref Table table)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues INV",
                "B. Tamanho do time",
                "C. Qtd funcionários empresa",
                "D. Pts por membro do time\n(A / B)",
                "E. Fator de ajuste",
                "F. UST pelas cerimônias",
                "G. Total de pontos\n( D + F) * E",
                " - "
            };
            SetGenericTableHeader(ref table, headers);
        }
        #endregion 
        #endregion
        #endregion
        #endregion

        #region CreateSummaryTableUstSmSettled
        private static void CreateSummaryTableUstSmSettled(Document document, List<SprintDTO> sprints, List<ContratoDTO> contracts, ref object missing, double ustValue)
        {
            int line = 2;
            double totalPoints = 0;
            int columns = 7;

            ContratoDTO smContract = new ContratoDTO();
            smContract = contracts.Find(x => x.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString());
            Table smTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            smTable.Borders.Enable = 1;
            smTable.Range.Font.Size = 8;

            SetTableHeaderUstSm(ref smTable);

            line = 2;
            totalPoints = 0;

            int sprintIndex = 0;
            foreach (var cs in smContract.ContractSprint)
            {
                smTable.Rows.Add(missing);
                smTable.Rows[line].Range.Font.Bold = 0;
                smTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                smTable.Rows[line].Cells[1].Range.Text = sprints[sprintIndex].Range.Name;
                smTable.Rows[line].Cells[2].Range.Text = (sprints[sprintIndex].AcceptedPointsExpenses + sprints[sprintIndex].AcceptedPointsInvestment).ToString();
                smTable.Rows[line].Cells[3].Range.Text = sprints[sprintIndex].TeamSize.ToString();
                smTable.Rows[line].Cells[4].Range.Text = cs.EmployeesCount.ToString();
                smTable.Rows[line].Cells[5].Range.Text = cs.PointsPerPartnerExpenses.ToString();
                smTable.Rows[line].Cells[6].Range.Text = cs.PointsPerPartnerExpenses.ToString();

                totalPoints += cs.PointsPerPartnerExpenses;
                line++;
                sprintIndex++;
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
        
        #region CreateSummaryTableUstHour
        private static void CreateSummaryTableUstHour(Document document, Range range, List<SprintDTO> sprints, List<ContratoDTO> contracts, object missing)
        {
            Table summaryTable = document.Tables.Add(range, 1, 9, ref missing, ref missing);
            summaryTable.Borders.Enable = 1;
            summaryTable.Range.Font.Size = 8;

            SetTableHeaderUstHour(ref summaryTable);

            int line = 2;
            double totalBilling = 0;

            foreach (var contract in contracts)
            {
                int sprintIndex = 0;
                foreach (var cs in contract.ContractSprint)
                {
                    summaryTable.Rows.Add(missing);
                    summaryTable.Rows[line].Range.Font.Bold = 0;
                    summaryTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                    summaryTable.Rows[line].Cells[1].Range.Text = sprints[sprintIndex].Range.Name;
                    summaryTable.Rows[line].Cells[2].Range.Text = sprints[sprintIndex].AcceptedPointsExpenses.ToString();
                    summaryTable.Rows[line].Cells[3].Range.Text = sprints[sprintIndex].TeamSize.ToString();
                    summaryTable.Rows[line].Cells[4].Range.Text = cs.EmployeesCount.ToString();
                    summaryTable.Rows[line].Cells[5].Range.Text = sprints[sprintIndex].PointsPerTeamMemberExpenses.ToString();
                    summaryTable.Rows[line].Cells[6].Range.Text = cs.PointsPerPartnerExpenses.ToString();
                    summaryTable.Rows[line].Cells[7].Range.Text = contract.Factor.ToString();
                    summaryTable.Rows[line].Cells[8].Range.Text = cs.Hours.ToString();
                    summaryTable.Rows[line].Cells[9].Range.Text = "99";//string.Format("{0:C}", cs.BillingExpenses);

                    //totalBilling += cs.BillingExpenses;
                    line++;
                    sprintIndex++;
                }
            }

            summaryTable.Rows.Add(missing);
            summaryTable.Rows[line].Cells[1].Range.Text = "TOTAL:";
            summaryTable.Rows[line].Cells[1].Merge(summaryTable.Rows[line].Cells[8]);
            summaryTable.Rows[line].Cells[2].Range.Text = string.Format("{0:C}", totalBilling);
            summaryTable.Rows[line].Cells[2].Range.Font.Bold = 1;

            //summaryTable.Range.Cells.AutoFit();
            //summaryTable.Range.Cells.DistributeHeight();
            summaryTable.Range.ParagraphFormat.SpaceAfter = 0;
        }

        private static void SetTableHeaderUstHour(ref Table table)
        {
            table.Cell(1, 1).Range.Text = "Sprint";
            table.Cell(1, 2).Range.Text = "A. Pts entregues";
            table.Cell(1, 3).Range.Text = "B. Tamanho do time";
            table.Cell(1, 4).Range.Text = "C. Qtd funcionários empresa";
            table.Cell(1, 5).Range.Text = "D. Pts por membro do time + 1\n(A / B)+1";
            table.Cell(1, 6).Range.Text = "E. Pontos fornecedor\n(C * D)";
            table.Cell(1, 7).Range.Text = "F. Fator de ajuste";
            table.Cell(1, 8).Range.Text = "G. Horas na sprint\n(E * UST / Valor hora)";
            table.Cell(1, 9).Range.Text = "A ser faturado\n(F * G * Valor hora)";

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Shading.BackgroundPatternColor = WdColor.wdColorGray25;
            table.Rows[1].Alignment = WdRowAlignment.wdAlignRowCenter;
        }
        #endregion

        #region SetGenericTableHeader
        private static void SetGenericTableHeader(ref Table table, List<string> headers)
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
        private static void SetSummaryTableTotal(ref Table summaryTable, int columns, int line, double totalPoints, double ustValue, ref object missing)
        {
            summaryTable.Rows.Add(missing);
            summaryTable.Rows[line].Cells[1].Range.Text = "TOTAL A SER FATUADO:\n(G * Valor da UST)";
            summaryTable.Rows[line].Cells[1].Merge(summaryTable.Rows[line].Cells[columns - 2]);
            summaryTable.Rows[line].Cells[2].Range.Text = totalPoints.ToString();
            summaryTable.Rows[line].Cells[2].Range.Font.Bold = 1;
            summaryTable.Rows[line].Cells[3].Range.Text = string.Format("{0:C}", totalPoints * ustValue);
            summaryTable.Rows[line].Cells[3].Range.Font.Bold = 1;

            //summaryTable.Range.Cells.AutoFit();
            //summaryTable.Range.Cells.DistributeHeight();
            summaryTable.Range.ParagraphFormat.SpaceAfter = 0;
        }
        #endregion
        #endregion

        #region SetDocumentFooter
        private static void SetDocumentFooter(Document document)
        {
            foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
            {
                //Get the footer range and add the footer details.  
                Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                footerRange.Font.Size = 10;
                footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = "BANESE - Banco do Estado de Sergipe";
            }
        }
        #endregion

        #region SetDocumentHeader
        private static void SetDocumentHeader(Document document, string partnerName, string teamName)
        {
            foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
            {
                //Get the header range and add the header details.  
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                headerRange.Font.Size = 10;
                headerRange.Text = $"{partnerName} - {teamName}".ToUpper();
            }
        }
        #endregion

        private static Range EndOfDocument(Document doc, ref object missing)
        {
            return doc.Range(doc.Content.End - 1, ref missing);
        }
 
    }
}
