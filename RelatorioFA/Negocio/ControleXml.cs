﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RelatorioFA.DTO;

namespace RelatorioFA.Negocio
{
    public class ControleXml
    {
        public static void GenerateConfigXmlFile(string outputPath, string outputName, ConfigXmlDTO config)
        {
            object filename = Path.Combine(outputPath, outputName);
            using (XmlWriter writer = XmlWriter.Create(filename.ToString()))
            {
                writer.WriteStartElement("Config");
                writer.WriteElementString("NomeArea", config.AreaName);
                writer.WriteElementString("NomeTime", config.TeamName);
                writer.WriteElementString("Autor", config.AuthorName);
                if (config.BaneseDes.Count > 0)
                {
                    foreach (var dev in config.BaneseDes)
                    {
                        writer.WriteStartElement("DesenvBanese");
                        writer.WriteElementString("Nome", dev.Name);
                        writer.WriteElementString("UmTurno", dev.WorksHalfDay ? "true" : "false");
                        writer.WriteEndElement();//DesenvBanese 
                    }
                }
                foreach (var partner in config.Partners)
                {
                    if (partner.Name != UtilDTO.ROLES.HOUSE.ToString())
                    {
                        writer.WriteStartElement("Fornecedor");
                        writer.WriteElementString("NomeFornecedor", partner.Name);
                        writer.WriteElementString("CaminhoLogomarca", partner.CaminhoLogomarca);
                        foreach (var contract in partner.Contracts)
                        {
                            writer.WriteStartElement("Contrato");
                            writer.WriteElementString("NumeroSAP", contract.SapNumber);
                            writer.WriteElementString("ValorUst", UtilDTO.ConvertDoubleToStringWithDotAtDecimal(contract.UstValue));
                            foreach (var batch in contract.Batches)
                            {
                                writer.WriteStartElement("Lote");
                                writer.WriteElementString("NomeLote", batch.Name);
                                foreach (var role in batch.Roles)
                                {
                                    writer.WriteStartElement("Cargo");
                                    writer.WriteElementString("NomeCargo", role.Name);
                                    writer.WriteElementString("FatorAjuste", UtilDTO.ConvertDoubleToStringWithDotAtDecimal(role.Factor));
                                    foreach (var dev in role.Collaborators)
                                    {
                                        writer.WriteStartElement("Colaborador");
                                        writer.WriteElementString("Nome", dev.Name);
                                        writer.WriteElementString("UmTurno", dev.WorksHalfDay ? "true" : "false");
                                        writer.WriteEndElement();//Colaborador
                                    }
                                    writer.WriteEndElement();//Cargo
                                }
                                writer.WriteEndElement();//Lote
                            }
                            writer.WriteEndElement();//Contrato
                        }
                    }
                    writer.WriteEndElement();//Fornecedor
                }
                writer.WriteEndElement();//Config
                writer.Flush();
            }
        }
    }
}
