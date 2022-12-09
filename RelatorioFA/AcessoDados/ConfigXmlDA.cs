using RelatorioFA.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RelatorioFA.AcessoDados
{
    public class ConfigXmlDA
    {
        public static ConfigXmlDTO LoadConfig(string filePath)
        {
            ConfigXmlDTO config;
            if (filePath.Substring(filePath.Length - 4).ToUpper() != ".XML")
            {
                filePath = Path.Combine(filePath, UtilDTO.configFileName); 
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigXmlDTO));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    config = (ConfigXmlDTO)serializer.Deserialize(fileStream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"ERRO:\n\nArquivo {UtilDTO.configFileName} não encontrado em {filePath}.\n\nFavor selecione o local do arquivo utilizando o botão correspondente.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante carregamento do arquivo de configuração.", ex);
            }

            return config;
        }
    }
}
