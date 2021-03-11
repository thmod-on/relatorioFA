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
        private const string configFile = "RelatorioFA.xml";

        public static ConfigDTO LoadConfig(string outputDocPath)
        {
            ConfigDTO config;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigDTO));

                using (FileStream fileStream = new FileStream(Path.Combine(outputDocPath, configFile), FileMode.Open))
                {
                    config = (ConfigDTO)serializer.Deserialize(fileStream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"ERRO:\n\nArquivo {configFile} não encontrado em {outputDocPath}.\n\nFavor selecione o local do arquivo utilizando o botão no canto superior esquerdo do programa.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante carregamento do arquivo de configuração.", ex);
            }

            return config;
        }
    }
}
