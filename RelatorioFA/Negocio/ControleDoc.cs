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

        #region GenerateDevDoc
        public void GenerateDevDoc(ConfigDocDTO config, FornecedorDTO partner, List<SprintDevDTO> sprints)
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
                CreateLastPage(document, para1, baseSprints, missing, config, partner);
                SetDocumentHeader(document, partner.Name, partner.CaminhoLogomarca, config.TeamName);
                SetDocumentFooter(document);
                SaveAndClose(ref document, ref winword, outputDocName, config.OutputDocPath, missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        #region SaveAndClose
        private static void SaveAndClose(ref Document document, ref Application winword, string outputDocName, string outputDocPath, object missing)
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
        public static void CreateFirstPage(Paragraph paragraph, List<IntervaloDTO> ranges, ConfigDocDTO config)
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

        #region CreateLastPage
        private static void CreateLastPage(Document document, Paragraph para1, List<SprintBaseDTO> sprints, object missing, ConfigDocDTO config, FornecedorDTO partner)
        {
            UtilDTO.BILLING_TYPE billingType = partner.BillingType;
            SetLastPageText(document, para1, partner, billingType);

            switch (billingType)
            {
                case (UtilDTO.BILLING_TYPE.UST):
                    CreateSummaryTableUst(document, sprints, missing, partner.UstValue);
                    break;
                case (UtilDTO.BILLING_TYPE.UST_HORA):
                    CreateSummaryTableUstHour(document, sprints, partner.Contracts, missing);
                    break;
                default:
                    break;
            }

            SetLastPageSignature(para1, config);
        }

        private static void CreateLastPage(Document document, Paragraph para1, List<SprintDevOpsDTO> sprintsDevOps, object missing, ConfigDocDTO config, FornecedorDTO partner) 
        {
            UtilDTO.BILLING_TYPE billingType = partner.BillingType;

            SetLastPageText(document, para1, partner, billingType);
            CreateSummaryTableUstDevOps(document, sprintsDevOps, missing, partner);
            SetLastPageSignature(para1, config);
        }

        private static void SetLastPageText(Document document, Paragraph para1, FornecedorDTO partner, UtilDTO.BILLING_TYPE billingType)
        {
            string strAux;
            document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

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

        private static void SetLastPageSignature(Paragraph para1, ConfigDocDTO config)
        {
            AddPAragraph(para1, "Atenciosamente,", 150, 30, 0, 14, WdParagraphAlignment.wdAlignParagraphJustify);
            AddPAragraph(para1, "_________________________________________________", 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(para1, config.AuthorName, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
            AddPAragraph(para1, config.TeamName, 0, 0, 0, 14, WdParagraphAlignment.wdAlignParagraphCenter);
        }
        #endregion

        #region CreateFollowPages
        private static void CreateFollowPages(Document document, FornecedorDTO partner, List<SprintBaseDTO> sprints, Paragraph paragraph, List<ColaboradorDTO> devTeam = null)
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
                    if (sprints[i].ImagePath != string.Empty)
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
                    //Detalhes da sprint
                    strAux = $"* {strObs}";
                    AddPAragraph(paragraph, strAux, 30, 30, 0, 10, WdParagraphAlignment.wdAlignParagraphJustify);
                    strObs = string.Empty;
                }
            }
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

        private static void AddPAragraph(Paragraph paragraph, string text, int spaceBefore, int spaceAfter, int flagFontBold, int fontSize, WdParagraphAlignment paragraphAlignment, WdColorIndex highlightColor = WdColorIndex.wdAuto)
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

        #region CreateSummaryTableUst
        private static void CreateSummaryTableUst(Document document, List<SprintDevDTO> sprints, object missing, double ustValue)
        {
            #region DevTable
            if (contracts.Any(x => x.Name != UtilDTO.CONTRACTS.SM_FIXO.ToString()))
            {
                CreateSummaryTableUstDev(document, sprints, ref missing, ustValue, UtilDTO.CATEGORY.DES);
                AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
                CreateSummaryTableUstDev(document, sprints, ref missing, ustValue, UtilDTO.CATEGORY.INV);
            }
            #endregion

            #region SMTable - Fixo
            if (contracts.Any(x => x.Name == UtilDTO.CONTRACTS.SM_FIXO.ToString()))
            {
                CreateSummaryTableUstSmSettled(document, sprints, ref missing, ustValue);
            }
            #endregion
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

        #region CreateSummaryTableUstSmSettled
        private static void CreateSummaryTableUstSmSettled(Document document, List<SprintSmDTO> sprints, ref object missing, double ustValue)
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
        
        #region CreateSummaryTableUstHour
        private static void CreateSummaryTableUstHour(Document document, List<SprintBaseDTO> sprints, List<ContratoDTO> contracts, object missing)
        {
            foreach (var contract in contracts)
            {
                CreateSummaryTableUstHour(document, sprints, contract, missing, UtilDTO.CATEGORY.DES);
                AddPAragraph(" ", 3, 3, 0, 8, WdParagraphAlignment.wdAlignParagraphLeft, document, ref missing);
                CreateSummaryTableUstHour(document, sprints, contract, missing, UtilDTO.CATEGORY.INV); 
            }
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
            summaryTable.Rows[line].Cells[3].Range.Text = string.Format("{0:C}", totalHours * contract.HourValue);
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
            summaryTable.Rows[line].Cells[1].Range.Text = "TOTAL A SER FATUADO:";
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
                footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdGray50;
                footerRange.Font.Size = 10;
                footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = "BANESE - Banco do Estado de Sergipe";
            }
        }
        #endregion

        #region SetDocumentHeader
        private static void SetDocumentHeader(Document document, string partnerName, string logoPath, string teamName)
        {
            foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
            {
                //Get the header range and add the header details.  
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                headerRange.Text = "";
                if (logoPath != string.Empty)
                {
                    headerRange.InlineShapes.AddPicture(logoPath);
                }
                else
                {
                    headerRange.Font.Size = 10;
                    headerRange.Text = $"{partnerName} - {teamName}".ToUpper();
                }
                headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                //headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
            }
        }
        #endregion

        #region AUX
        private static Range EndOfDocument(Document doc, ref object missing)
        {
            return doc.Range(doc.Content.End - 1, ref missing);
        }

        public static string GetDocumentName(List<SprintBaseDTO> sprints, ConfigDocDTO config, string partnerName)
        {
            string outputDocName = $"Relatório Ágil -";
            foreach (var sprint in sprints)
            {
                outputDocName += $" {sprint.Range.Name}";
            }
            outputDocName += $" - {config.AreaName}-{config.TeamName} - {partnerName}.docx";

            return outputDocName;
        } 
        #endregion
    }
}
