using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class ControleDocDevOps : ControleDoc
    {
        #region GenerateOpsDoc
        public static void GenerateOpsDoc(ConfigDocDTO config, List<SprintDevOpsDTO> sprintDevOpsList, FornecedorDTO partner, string outputDocPath)
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
                Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                CreateFirstPage(para1, ranges, config);
                CreateFollowPages(document, partner, baseSprints, para1);
                CreateLastPage(document, para1, sprintDevOpsList, missing, config, partner);
                SaveAndClose(ref document, ref winword, outputDocName, outputDocPath, missing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
