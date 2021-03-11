using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelatorioFA.AppWinForm
{
    public partial class SobreForm : Form
    {
        public SobreForm()
        {
            InitializeComponent();
            LoadUpdatesDescription();
        }

        private void LoadUpdatesDescription()
        {
            txbUpdates.AppendText("+ ---------------------+\n  Versão 4.3.0  \n + ---------------------+\n - Tela de geração de configuração permite o SM_FIXO; Realizar mudanças necessárias nas lógicas do time e de leitura do arquivo de configuração para aceitar o SM_FIXO; Gerar o doc com SM_FIXO");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.2.0  \n + ---------------------+\n - Adicionado botão para abrir a pasta destino dos relatórios;\n - Reefatoradas algumas variáveis para facilitar manutenção;\n - Simplificada interface do form de criação do arquivo de configuração.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.1.0  \n + ---------------------+\n - Mudanças na geraçlão do relatório:\n   . Escondido o tipo do contrato para simplificar a interface;\n   . Ao selecionar um colaborador o campo de ausências automaticamente é sselecionado;\n   . Caso algum contrato do fornecedor possua horas cadastradas ele será categorizado diferente para geração do relatório. OBS.: Este caso está funcionando mas com limitações. Caso necessite de ajustes ou melhorias podem reportar ou corrigir / evoluir.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.0.4  \n + ---------------------+\n - Adicionado log para acompanhamento durante preenchimento do arquivo de configuração;\n - Alteração para tratar quando usuário utiliza mais de uma linha no campo de OBS do cadastro da sprint.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.0.3  \n + ---------------------+\n - Tela de criação do arquivo de config:\n   . Adicionada orientação de como utilizar / mudar o contrato;\n   . Validação para impedir que seja criado um contrato sem colaborador;\n   . Correção na geração do xml para quando time não tem dev Banese\n   . Correção na geração do xml para valores double (valor da UST e fator).\n - Tela de geração de relatório\n   . Correção na posição do botão de carregamento do arquivo de config;   . Ao adicionar uma sprint, os dados da anterior são apagados dos campos de texto.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.0.2  \n + ---------------------+\n - Atualização no layout da tela de geração de relatórios;\n - Adição de botão para carregar arquivo de config na tela de relatórios;");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.0.1  \n + ---------------------+\n - Ajustes na tela de geração do arquivo de config\n   . Removido dados estátios usados nos testes;\n   . Melhorado indice do TAB;\n   . Corrigido comportamento da habilitação do botão de abrir documento.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.0.0  \n + ---------------------+\n - Refeita tela de geração do arquivo XML;\n - Adicionada opção para que usuário gere um arquivo de configuração preenchido;");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 3.0.0  \n + ---------------------+\n - Refeitos objetos e integrações para gerar um relatório mesmo para empresas com mais de um 'contrato'. Por ex.: Pleno e Sênior;\n - Desabilitada opção de geração de relatório avulso;\n - Refeita interface e simplificado seu uso;\n - Adicionada possibilidade de gerar relatório para todos os fornecedores.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 2.2.0  \n + ---------------------+\n - Adicionada possiblidade de gerar contrato por hora / UST.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 2.1.2  \n + ---------------------+\n - Mudança no layout, apenas pontos aceitos e não mais por investimento / despesa;\n - Adicionada categoria do ativo;\n - Adequado DOC para refletir estas mudançaas.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 2.1.1  \n + ---------------------+\n - Atualizado cálculo do tamanho do time considerando ausências;\n - Ajuste no layout e redimensionamento;\n - Correção no doc para que não imprima a sprint mais de uma vez.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 2.1.0  \n + ---------------------+\n - Novo ajuste de layout. Adição do álculo de dias da sprint. Ausências agora usa proporção de dias e não mais múltiplos de 0.5;\n - Correção no controle de ausências;\n - Adicionado nome dos intervalos das sprints no nome do arquivo gerado.");
            txbUpdates.AppendText("\n\n +----------------------+\n  Versão 2.0.1  \n + ---------------------+\n - Atualização no modelo de xml gerado;\n - Melhoria visual de alguns campos para cadastro de sprint.");
            txbUpdates.AppendText("\n\n +----------------------+\n  Versão 2.0.0  \n + ---------------------+\n - Refeitos objetos de transação;\n - Refeita interface para comportar pontos de investimento e despesa;\n - Refeita lógica da sprint. Agor a sprint é identificada pelo seu nome e o contrato adicionado;\n - Desabilitado menu de geraçõ do xml;\n - Alterada estrutura do xml de configurão.");
            txbUpdates.AppendText("\n\n +----------------------+\n  Versão 1.2.0  \n + ---------------------+\n - Geração do relatório\n   . Cálculo automático do tamnho do time baseado no arquivo de configuração;\n   . Arquivo doc agora lista todos devs do time cadastrados no arquivo de config.\n - Geração de modelo de xml agora funcional");
            txbUpdates.AppendText("\n\n +----------------------+\n  Versão 1.1.0  \n + ---------------------+\n - Adição das colunas de investimento e despesa no relatório;\n- Adição dos campo de controle de investimento e despea na interface;\n- Crição do container para separação das funcionalidades;\n- Adição do menu 'Sobre'");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 1.0.1  \n + ---------------------+\n - Versão inicial da aplicação; \n   . Carregamento do arquivo de configuração; \n   . Geração da versão inicial do relatório em DOCX");
        }
    }
}
