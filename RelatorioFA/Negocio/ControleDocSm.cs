using Microsoft.Office.Interop.Word;
using RelatorioFA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelatorioFA.Negocio
{
    public class ControleDocSm : ControleDoc
    {
        public static void CreateSmDoc(ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract, string outputDocPath, List<SprintSmDTO> sprints)
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

                devTeam.AddRange(from cont in partner.Contracts
                                 from category in cont.Categories
                                 where category.Name == UtilDTO.ROLES.SM_FIXO.ToString() ||
                                       category.Name == UtilDTO.ROLES.SM_MEDIA.ToString()
                                 from dev in category.Collaborators
                                 select dev);

                string outputDocName = SetDocumentName(baseSprints, config, partner.Name, UtilDTO.REPORT_TYPE.SM);

                Application winword = CreateWinWord();

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(paragraph, ranges, config, contract.SapNumber);
                CreateFollowPages(document, partner, baseSprints, paragraph, devTeam);
                CreateLastPage(document, paragraph, sprints, missing, config, partner, contract);
                SetDocumentHeader(document, partner, config);
                SetDocumentFooter(document);
                SaveAndClose(ref document, ref winword, outputDocName, outputDocPath, missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CreateLastPage(Document document, Paragraph paragraph, List<SprintSmDTO> sprints, object missing, ConfigXmlDTO config, FornecedorDTO partner, ContratoDTO contract)
        {
            SetLastPageText(document, paragraph, partner, contract.UstValue);

            //(TODO) Cada time tem 1 SM, Melhorar  o DTO para representar
            if (contract.Categories.Any(category => category.Name == UtilDTO.ROLES.SM_FIXO.ToString()))
            {
                CreateSummaryTableUstSmSettled(document, sprints, ref missing, contract.UstValue);
            }
            else
            {
                if (contract.Categories.Any(category => category.Name == UtilDTO.ROLES.SM_MEDIA.ToString()))
                {
                    CreateSummaryTableUstSmShared(document, sprints, ref missing, contract.UstValue);
                }
            }
           
            SetLastPageSignature(paragraph, config);
        }

        #region CreateSummaryTableUstSmSettled
        private static void CreateSummaryTableUstSmSettled(Document document, List<SprintSmDTO> sprints, ref object missing, double ustValue)
        {
            double totalPoints = 0;
            int columns = 7;

            Table smTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            smTable.Borders.Enable = 1;
            smTable.Range.Font.Size = 8;

            int line = SetTableHeaderUstSm(ref smTable, UtilDTO.CATEGORY.DESPESA);
            
            foreach (var sprint in sprints)
            {
                smTable.Rows.Add(missing);
                smTable.Rows[line].Range.Font.Bold = 0;
                smTable.Rows[line].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
                smTable.Rows[line].Cells[1].Range.Text = sprint.Range.Name;//Sprint
                smTable.Rows[line].Cells[2].Range.Text = (sprint.AcceptedPointsTeam1).ToString();//A
                smTable.Rows[line].Cells[3].Range.Text = sprint.TeamSize.ToString(decimalFormat);//B
                smTable.Rows[line].Cells[4].Range.Text = sprint.EmployeesCount.ToString();//C
                smTable.Rows[line].Cells[5].Range.Text = sprint.SmPoints.ToString();//D
                smTable.Rows[line].Cells[6].Range.Text = (sprint.EmployeesCount * sprint.SmPoints).ToString();//E

                totalPoints += sprint.SmPoints;
                line++;
            }

            SetSummaryTableTotal(ref smTable, columns, line, totalPoints, ustValue, ref missing);
        }

        #region SetTableHeaderUstSm
        private static int SetTableHeaderUstSm(ref Table smTable, UtilDTO.CATEGORY category)
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
            return SetGenericTableHeader(ref smTable, headers, category);
        }
        #endregion
        #endregion

        private static void CreateSummaryTableUstSmShared(Document document, List<SprintSmDTO> sprints, ref object missing, double ustValue)
        {
            double totalPoints = 0;
            int columns = 9;
            int qtdBaseLines = (sprints.Count() * 2) + 2;//Multiplica por 2 devido a quantidade de times atendidos pelo SM e soma com 2 para compensar o cabecalho da tabela

            Table smTable = document.Tables.Add(EndOfDocument(document, ref missing), 1, columns, ref missing, ref missing);
            smTable.Borders.Enable = 1;
            smTable.Range.Font.Size = 8;
            int startLine = SetTableHeaderUstSmShared(ref smTable);

            //Definir esqueleto
            for (int i = startLine; i <= qtdBaseLines; i++)
            {
                smTable.Rows.Add(missing);
                smTable.Rows[i].Range.Font.Bold = 0;
                smTable.Rows[i].Shading.BackgroundPatternColor = WdColor.wdColorWhite;
            }

            //Adicionar merges
            Cell cel;
            int[] columnsToSpan = { 5, 6, 7, 8, 9 };
            for (int i = startLine; i < qtdBaseLines; i++)
            {
                if (i % 2 != 0)//depende da quantidade de linhas do cabeçalho. Na hora de adicionar os dados também
                {
                    int rowSpanStart = i;
                    int rowSpanEnd = i + 1;
                    foreach (var col in columnsToSpan)
                    {
                        cel = smTable.Cell(rowSpanStart, col);
                        cel.Merge(smTable.Cell(rowSpanEnd, col));
                    }
                }
            }

            //Adicionar os dados
            foreach (var sprint in sprints)
            {
                for (int i = 0; i < 2; i++)
                {
                    smTable.Cell(startLine, 1).Range.Text = sprint.Range.Name;//Sprint
                    smTable.Cell(startLine, 2).Range.Text = i != 0 ? sprint.AcceptedPointsTeam1.ToString() : sprint.AcceptedPointsTeam2.ToString();//A
                    smTable.Cell(startLine, 3).Range.Text = i != 0 ? sprint.DevTeamSize1.ToString() : sprint.DevTeamSize2.ToString();//B
                    smTable.Cell(startLine, 4).Range.Text = i != 0 ? sprint.AverageTeam1.ToString(decimalFormat) : sprint.AverageTeam2.ToString(decimalFormat);//C
                    if (startLine % 2 != 0)
                    {
                        smTable.Cell(startLine, 5).Range.Text = sprint.AverageSprint.ToString(decimalFormat);//D
                        smTable.Cell(startLine, 6).Range.Text = sprint.Contracts[0].Categories[0].Factor.ToString(decimalFormat);//E
                        smTable.Cell(startLine, 7).Range.Text = "1,000";//F
                        smTable.Cell(startLine, 8).Range.Text = sprint.SmPoints.ToString(decimalFormat);//G

                        totalPoints += sprint.SmPoints;
                    }

                    startLine++;
                }
            }

            SetSummaryTableTotal(ref smTable, columns, startLine, totalPoints, ustValue, ref missing);
        }

        #region SetTableHeaderUstSmShared
        private static int SetTableHeaderUstSmShared(ref Table smTable)
        {
            List<string> headers = new List<string>
            {
                "Sprint",
                "A. Pts entregues",
                "B. Tamanho do time",
                "C. Média de pontos\n(A / B)",
                "D. Média de pontos / sprint\n((Cn + Cn) / 2)",
                "E. Fator de ajuste",
                "F. UST das cerimônias",
                "G. Pontos ajustados\n(D * E + F)",
                "A ser faturado\n(G * UST)"
            };
            return SetGenericTableHeader(ref smTable, headers, UtilDTO.CATEGORY.DESPESA);
        } 
        #endregion
    }
}
