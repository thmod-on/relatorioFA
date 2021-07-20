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
        public SobreForm(Form parentForm)
        {
            InitializeComponent();
            ResizeParent(parentForm);
            LoadUpdatesDescription();
        }

        private void ResizeParent(Form containerForm)
        {
            containerForm.Size = new System.Drawing.Size(this.Width, this.Height + 20);
            containerForm.MinimumSize = new Size(this.Width, this.Height + 20);
        }

        private void LoadUpdatesDescription()
        {
            txbUpdates.AppendText("+ ---------------------+\n  Versão 4.10  \n + ---------------------+\n - A mudança dessa vez foi grande mas parte fica por debaixo dos panos.\n   . Foram muitas noites e finais de semana mas a tela de geração de vários relatórios refeita para seguir o novo layout;   . A estrutura de objetos foi refeita para tentar deixar mais claro;\n   . Muitas lógicas foram refeitas mas o caminho feliz parece estar funcionando. Admito, ainda precisa mais testes ^^' kkkk");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.9.2  \n + ---------------------+\n - Dessa vez a revisão ficou no relatório de DevOps. Mudança pequen mas não menos importante.\n   . Adicionei uma validação para a quantidade de plantonistas (agora precisa ter tamanho mínimo);\n   . Alterei a forma de cálculo do pagamento (talvez isso mude novamente depois);\n   . Adicionei o contrato SAP no relatório.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.9.1  \n + ---------------------+\n - O dev solitário ataca novamente Oo\n   . Percebendo que o fluxo de atualização de arquivo de configuração não estava funcionando corretamente nosso bravo dev revisou diversos casos e corrigiu vários bugs que dificultavam a edição de um arquivo já existente. Obrigado mais uma vez dev solitário =]");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.9.0  \n + ---------------------+\n - Nesta mega mudança de fluxo nossa EUquipe de UX quebrou muito a cabeça para bolar uma forma mais simples de utilizar a ferramenta. Algumas pessoas acharam complicado o modo de funcionamento, muitos campos na tela, pouco feedback. Esta foi nosso primeira grande mudança. Esperamos de coração agradar ao máximo de gente possível.\n - Nossa EUquipe de desenvolvimento caprichou para que a adição ou edição de dados fosse a mais confiável possível (A EUquipe de testes estava ocupada relaxando rsrsrsrs.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.8.0  \n + ---------------------+\n - Adicionada nova tela para geração de relatório avulso de DevOps;\n - Pequenas correções no core;\n - Melhorias em métodos existentes e lógicas antigas.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.7.1  \n + ---------------------+\n - Adicionado controle para colaboradores que trabalham apenas um turno. OBS.: Atualize o arquivo de configuração preenchendo o campo correspondente!\n - Correção ao selecionar um fornecedor na tela de configuração;\n - Correção ao carregar os dados de um colaborador na tela de configuração.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.7.0  \n + ---------------------+\n - Atualizado form para controle de arquivo xml de configuração;\n - Adicionada possibilidade para o usuário editar um arquivo de configuração existente.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.6.2  \n + ---------------------+\n - Alterada a cor da mensagem do rodapé do documento;\n - Cada sprint agora é gerada em uma página");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.6.1  \n + ---------------------+\n - Melhoria no redimensionamento dos formulários;\n - Na tela de relatórios, ao selecionar uma sprint ele irá trazer a maioria dos dados PARA CONFERÊNCIA;\n - Tela de atualizações dando preferência para as mais recentes.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.6.0  \n + ---------------------+\n - Reformulado layout da tela de relatórios para deixar mais intuitiva;\n - Possibilidade de carregar um imagem par cada sprint para ser adicionada ao relatório;\n - Adição dos zeros à direit na tabela de resumo mesmo quando a conta é exata (algum caaso pode ter ficado de fora).");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.5.0  \n + ---------------------+\n - Tratado erro ao adicionar imagem que já existe;\n - Adicionara logo do parceiro no cabeçalho do arquivo;\n - Realçado o nome do colaborador referente ao relatório do parceiro.");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.4.0  \n + ---------------------+\n - Adicionada importação de imagem para a logo do fornecedor (ainda não é adicionada ao relatório, apenas no arquivo de configuração);\n - Alterada tela de geração de relatório para aceitar pontos de investimento e despesa;\n - Refeita lógica das tabelas para simplificar a manutenção do código;\n - Refeitas as tabelas para gerar sempre investimento e despesa (SM_FIXO, PADRAO, PLENO, SENIOR, UST_HORA)");
            txbUpdates.AppendText("\n\n + ---------------------+\n  Versão 4.3.0  \n + ---------------------+\n - Tela de geração de configuração permite o SM_FIXO; Realizar mudanças necessárias nas lógicas do time e de leitura do arquivo de configuração para aceitar o SM_FIXO; Gerar o doc com SM_FIXO");
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

            txbUpdates.SelectionStart = 0;
            txbUpdates.SelectionLength = 0;
        }
    }
}
