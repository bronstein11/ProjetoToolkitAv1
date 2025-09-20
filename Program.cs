using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace ProjetoToolkit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Executar();
        }
    }

    public class MenuPrincipal
    {
        public void Executar()
        {
            bool continuar = true;
            
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== PROJETO TOOLKIT - AV1 FUNDAMENTOS PRÁTICOS ===");
                Console.WriteLine();
                Console.WriteLine("1. Verificador de Alfabeto e Cadeia");
                Console.WriteLine("2. Classificador T/I/N por JSON");
                Console.WriteLine("3. Programa de Decisão: 'Termina com b?'");
                Console.WriteLine("4. Avaliador Proposicional Básico");
                Console.WriteLine("5. Reconhecedor de Linguagens");
                Console.WriteLine("0. Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        new VerificadorAlfabeto().Executar();
                        break;
                    case "2":
                        new ClassificadorTIN().Executar();
                        break;
                    case "3":
                        new DecidirTerminaComB().Executar();
                        break;
                    case "4":
                        new AvaliadorProposicional().Executar();
                        break;
                    case "5":
                        new ReconhecedorLinguagens().Executar();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    // ITEM 1: Verificador de Alfabeto e Cadeia
    public class VerificadorAlfabeto
    {
        private readonly HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 1: VERIFICADOR DE ALFABETO E CADEIA ===");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            // Verificar símbolo individual
            Console.Write("Digite um símbolo para verificar: ");
            string? entrada = Console.ReadLine();
            
            if (string.IsNullOrEmpty(entrada) || entrada.Length != 1)
            {
                Console.WriteLine("Entrada inválida! Digite apenas um símbolo.");
            }
            else
            {
                char simbolo = entrada[0];
                bool pertenceAlfabeto = VerificarSimbolo(simbolo);
                Console.WriteLine($"Símbolo '{simbolo}' {(pertenceAlfabeto ? "PERTENCE" : "NÃO PERTENCE")} ao alfabeto Σ");
            }

            Console.WriteLine();

            // Verificar cadeia completa
            Console.Write("Digite uma cadeia para verificar: ");
            string? cadeia = Console.ReadLine() ?? "";
            
            bool cadeiaValida = VerificarCadeia(cadeia);
            Console.WriteLine($"Cadeia '{cadeia}' é {(cadeiaValida ? "VÁLIDA" : "INVÁLIDA")} para Σ*");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool VerificarSimbolo(char simbolo)
        {
            return alfabeto.Contains(simbolo);
        }

        private bool VerificarCadeia(string cadeia)
        {
            return cadeia.All(c => alfabeto.Contains(c));
        }
    }

    // ITEM 2: Classificador T/I/N por JSON
    public class ClassificadorTIN
    {
        private readonly List<ProblemaComputacional> problemas;

        public ClassificadorTIN()
        {
            string jsonProblemas = """
            [
                {
                    "nome": "Ordenação de lista",
                    "descricao": "Ordenar uma lista de números em ordem crescente",
                    "classificacao": "T"
                },
                {
                    "nome": "Problema do Caixeiro Viajante",
                    "descricao": "Encontrar o menor caminho que visita todas as cidades",
                    "classificacao": "I"
                },
                {
                    "nome": "Problema da Parada",
                    "descricao": "Determinar se um programa irá parar para uma entrada",
                    "classificacao": "N"
                },
                {
                    "nome": "Busca em array",
                    "descricao": "Encontrar um elemento específico em um array",
                    "classificacao": "T"
                },
                {
                    "nome": "Satisfatibilidade Booleana (SAT)",
                    "descricao": "Determinar se uma fórmula booleana pode ser satisfeita",
                    "classificacao": "I"
                },
                {
                    "nome": "Problema da Correspondência de Post",
                    "descricao": "Encontrar sequência que produz mesma string em dois conjuntos",
                    "classificacao": "N"
                }
            ]
            """;

            problemas = JsonSerializer.Deserialize<List<ProblemaComputacional>>(jsonProblemas) 
                       ?? new List<ProblemaComputacional>();
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 2: CLASSIFICADOR T/I/N POR JSON ===");
            Console.WriteLine("Classifique cada problema como:");
            Console.WriteLine("T - Tratável | I - Intratável | N - Não Computável");
            Console.WriteLine();

            int acertos = 0;
            int total = problemas.Count;

            foreach (ProblemaComputacional problema in problemas)
            {
                Console.WriteLine($"Problema: {problema.Nome}");
                Console.WriteLine($"Descrição: {problema.Descricao}");
                Console.Write("Sua classificação (T/I/N): ");
                
                string? resposta = Console.ReadLine()?.ToUpper();
                
                if (resposta == problema.Classificacao)
                {
                    Console.WriteLine("✓ CORRETO!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ INCORRETO! Resposta correta: {problema.Classificacao}");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("=== RESUMO FINAL ===");
            Console.WriteLine($"Acertos: {acertos}/{total}");
            Console.WriteLine($"Percentual: {(double)acertos / total * 100:F1}%");
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    public class ProblemaComputacional
    {
        public string nome { get; set; } = "";
        public string descricao { get; set; } = "";
        public string classificacao { get; set; } = "";
        
        // Propriedades para compatibilidade
        public string Nome => nome;
        public string Descricao => descricao;  
        public string Classificacao => classificacao;
    }

    // ITEM 3: Programa de Decisão - Termina com 'b'?
    public class DecidirTerminaComB
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 3: PROGRAMA DE DECISÃO - 'TERMINA COM B?' ===");
            Console.WriteLine("Verifica se uma cadeia sobre Σ = {a, b} termina com 'b'");
            Console.WriteLine();

            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine() ?? "";

            // Validar se a cadeia pertence ao alfabeto
            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("ERRO: Cadeia contém símbolos não pertencentes ao alfabeto Σ = {a, b}");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            string resultado = DecidirTerminaComB_Funcao(cadeia);
            Console.WriteLine($"Resultado: {resultado}");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };
            return cadeia.All(c => alfabeto.Contains(c));
        }

        private string DecidirTerminaComB_Funcao(string cadeia)
        {
            // Caso vazio
            if (string.IsNullOrEmpty(cadeia))
            {
                return "NAO";
            }

            // Verificar se termina com 'b'
            return cadeia[cadeia.Length - 1] == 'b' ? "SIM" : "NAO";
        }
    }

    // ITEM 4: Avaliador Proposicional Básico
    public class AvaliadorProposicional
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 4: AVALIADOR PROPOSICIONAL BÁSICO ===");
            Console.WriteLine();

            bool continuar = true;
            
            while (continuar)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Avaliar fórmula com valores específicos");
                Console.WriteLine("2. Gerar tabela-verdade completa");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("Opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AvaliarComValores();
                        break;
                    case "2":
                        GerarTabelaVerdade();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void AvaliarComValores()
        {
            Console.WriteLine();
            Console.WriteLine("Digite os valores das proposições:");
            
            Console.Write("P (true/false): ");
            bool P = LerBooleano();
            
            Console.Write("Q (true/false): ");
            bool Q = LerBooleano();
            
            Console.Write("R (true/false): ");
            bool R = LerBooleano();

            Console.WriteLine();
            Console.WriteLine("Escolha uma fórmula:");
            Console.WriteLine("1. P ∧ Q (conjunção)");
            Console.WriteLine("2. P ∨ Q (disjunção)");
            Console.WriteLine("3. P → Q (implicação)");
            Console.WriteLine("4. (P ∧ Q) → R (implicação composta)");
            Console.Write("Fórmula: ");

            string? escolha = Console.ReadLine();
            bool resultado = false;
            string formula = "";

            switch (escolha)
            {
                case "1":
                    resultado = P && Q;
                    formula = "P ∧ Q";
                    break;
                case "2":
                    resultado = P || Q;
                    formula = "P ∨ Q";
                    break;
                case "3":
                    resultado = !P || Q;
                    formula = "P → Q";
                    break;
                case "4":
                    resultado = !(P && Q) || R;
                    formula = "(P ∧ Q) → R";
                    break;
                default:
                    Console.WriteLine("Fórmula inválida!");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine($"Fórmula: {formula}");
            Console.WriteLine($"P = {P}, Q = {Q}, R = {R}");
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine();
        }

        private void GerarTabelaVerdade()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma fórmula para gerar tabela-verdade:");
            Console.WriteLine("1. P ∧ Q");
            Console.WriteLine("2. P ∨ Q");
            Console.WriteLine("3. P → Q");
            Console.WriteLine("4. (P ∧ Q) → R");
            Console.Write("Fórmula: ");

            string? escolha = Console.ReadLine();
            
            Console.WriteLine();

            switch (escolha)
            {
                case "1":
                    GerarTabelaConjuncao();
                    break;
                case "2":
                    GerarTabelaDisjuncao();
                    break;
                case "3":
                    GerarTabelaImplicacao();
                    break;
                case "4":
                    GerarTabelaImplicacaoComposta();
                    break;
                default:
                    Console.WriteLine("Fórmula inválida!");
                    return;
            }
            
            Console.WriteLine();
        }

        private void GerarTabelaConjuncao()
        {
            Console.WriteLine("Tabela-verdade para P ∧ Q:");
            Console.WriteLine("P\tQ\tP∧Q");
            Console.WriteLine("T\tT\t" + (true && true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (true && false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (false && true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (false && false ? "T" : "F"));
        }

        private void GerarTabelaDisjuncao()
        {
            Console.WriteLine("Tabela-verdade para P ∨ Q:");
            Console.WriteLine("P\tQ\tP∨Q");
            Console.WriteLine("T\tT\t" + (true || true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (true || false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (false || true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (false || false ? "T" : "F"));
        }

        private void GerarTabelaImplicacao()
        {
            Console.WriteLine("Tabela-verdade para P → Q:");
            Console.WriteLine("P\tQ\tP→Q");
            Console.WriteLine("T\tT\t" + (!true || true ? "T" : "F"));
            Console.WriteLine("T\tF\t" + (!true || false ? "T" : "F"));
            Console.WriteLine("F\tT\t" + (!false || true ? "T" : "F"));
            Console.WriteLine("F\tF\t" + (!false || false ? "T" : "F"));
        }

        private void GerarTabelaImplicacaoComposta()
        {
            Console.WriteLine("Tabela-verdade para (P ∧ Q) → R:");
            Console.WriteLine("P\tQ\tR\tP∧Q\t(P∧Q)→R");
            
            bool[] valores = { true, false };
            
            foreach (bool p in valores)
            {
                foreach (bool q in valores)
                {
                    foreach (bool r in valores)
                    {
                        bool conjuncao = p && q;
                        bool implicacao = !conjuncao || r;
                        Console.WriteLine($"{(p ? "T" : "F")}\t{(q ? "T" : "F")}\t{(r ? "T" : "F")}\t{(conjuncao ? "T" : "F")}\t{(implicacao ? "T" : "F")}");
                    }
                }
            }
        }

        private bool LerBooleano()
        {
            string? input = Console.ReadLine()?.ToLower();
            return input == "true" || input == "t" || input == "1";
        }
    }

    // ITEM 5: Reconhecedor de Linguagens
    public class ReconhecedorLinguagens
    {
        private readonly HashSet<char> alfabeto = new HashSet<char> { 'a', 'b' };

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM 5: RECONHECEDOR DE LINGUAGENS ===");
            Console.WriteLine("Alfabeto Σ = {a, b}");
            Console.WriteLine();

            Console.WriteLine("Escolha uma linguagem:");
            Console.WriteLine("1. L_par_a = {w | w tem número par de 'a's}");
            Console.WriteLine("2. L = {w | w = ab*} (inicia com 'a' seguido de zero ou mais 'b's)");
            Console.Write("Opção: ");

            string? opcao = Console.ReadLine();
            
            Console.Write("Digite a cadeia para verificar: ");
            string? cadeia = Console.ReadLine() ?? "";

            // Validar alfabeto antes da decisão
            if (!ValidarAlfabeto(cadeia))
            {
                Console.WriteLine("REJEITA - Cadeia contém símbolos não pertencentes ao alfabeto Σ");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            string resultado = "";

            switch (opcao)
            {
                case "1":
                    resultado = ReconhecerL_par_a(cadeia);
                    Console.WriteLine($"L_par_a: {resultado}");
                    break;
                case "2":
                    resultado = ReconhecerL_ab_estrela(cadeia);
                    Console.WriteLine($"L = ab*: {resultado}");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private bool ValidarAlfabeto(string cadeia)
        {
            return cadeia.All(c => alfabeto.Contains(c));
        }

        private string ReconhecerL_par_a(string cadeia)
        {
            int contadorA = cadeia.Count(c => c == 'a');
            return contadorA % 2 == 0 ? "ACEITA" : "REJEITA";
        }

        private string ReconhecerL_ab_estrela(string cadeia)
        {
            // Cadeia vazia não pertence (deve começar com 'a')
            if (string.IsNullOrEmpty(cadeia))
            {
                return "REJEITA";
            }

            // Deve começar com 'a'
            if (cadeia[0] != 'a')
            {
                return "REJEITA";
            }

            // O resto deve ser apenas 'b's (ou vazio)
            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                {
                    return "REJEITA";
                }
            }

            return "ACEITA";
        }
    }
}