using System;

namespace TrabalhoAlgoritmos;

public class Program
{
    private static readonly ArvoreBinaria arvore = new();
    private static readonly Grafo grafo = new();

    public static void Main(string[] args)
    {
        MenuPrincipal();
    }

    private static void MenuPrincipal()
    {
        var continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1 - Trabalhar com Árvore Binária");
            Console.WriteLine("2 - Trabalhar com Grafos");
            Console.WriteLine("0 - Sair do programa");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out var opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número do menu.");
                Pausar();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    MenuArvore();
                    break;
                case 2:
                    MenuGrafo();
                    break;
                case 0:
                    continuar = false;
                    Console.WriteLine("Encerrando o programa. Até mais!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Pausar();
                    break;
            }
        }
    }

    private static void MenuArvore()
    {
        var voltar = false;

        while (!voltar)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("MENU ÁRVORE BINÁRIA");
            Console.WriteLine("1 - Criar nova árvore (resetar)");
            Console.WriteLine("2 - Inserir nó");
            Console.WriteLine("3 - Buscar valor");
            Console.WriteLine("4 - Maior valor");
            Console.WriteLine("5 - Menor valor");
            Console.WriteLine("6 - Imprimir árvore (em ordem)");
            Console.WriteLine("9 - Voltar ao menu principal");
            Console.WriteLine("-------------------------------------------------");

            var opcao = LerInteiro("Escolha uma opção: ");

            switch (opcao)
            {
                case 1:
                    arvore.CriarArvore();
                    Console.WriteLine("Árvore criada (reiniciada).");
                    break;
                case 2:
                    var valorInserir = LerInteiro("Digite o valor a ser inserido na árvore: ");
                    arvore.Inserir(valorInserir);
                    Console.WriteLine("Valor inserido com sucesso.");
                    break;
                case 3:
                    if (arvore.EstaVazia)
                    {
                        Console.WriteLine("A árvore está vazia. Insira valores antes de buscar.");
                        break;
                    }

                    var valorBuscar = LerInteiro("Digite o valor a ser buscado: ");
                    var encontrado = arvore.Buscar(valorBuscar);
                    Console.WriteLine(encontrado ? "Valor encontrado na árvore." : "Valor não encontrado.");
                    break;
                case 4:
                    MostrarValorExtremo(arvore.MaiorValor(), "maior");
                    break;
                case 5:
                    MostrarValorExtremo(arvore.MenorValor(), "menor");
                    break;
                case 6:
                    var valores = arvore.ObterValoresEmOrdem();
                    if (valores.Count == 0)
                    {
                        Console.WriteLine("A árvore está vazia.");
                    }
                    else
                    {
                        Console.WriteLine("Árvore em ordem: " + string.Join(" ", valores));
                    }
                    break;
                case 9:
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (!voltar)
            {
                Pausar();
            }
        }
    }

    private static void MenuGrafo()
    {
        var voltar = false;

        while (!voltar)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("MENU GRAFOS");
            Console.WriteLine("1 - Criar grafo");
            Console.WriteLine("2 - Adicionar aresta (não direcionada)");
            Console.WriteLine("3 - Adicionar arco (direcionada)");
            Console.WriteLine("4 - Buscar aresta/arco");
            Console.WriteLine("5 - Imprimir grafo");
            Console.WriteLine("9 - Voltar ao menu principal");
            Console.WriteLine("-------------------------------------------------");

            var opcao = LerInteiro("Escolha uma opção: ");

            switch (opcao)
            {
                case 1:
                    var quantidade = LerInteiro("Digite o número de vértices do grafo: ");
                    if (quantidade <= 0)
                    {
                        Console.WriteLine("Quantidade inválida. Use um número inteiro positivo.");
                    }
                    else
                    {
                        grafo.CriarGrafo(quantidade);
                        Console.WriteLine("Grafo criado com sucesso com " + quantidade + " vértices.");
                    }
                    break;
                case 2:
                    if (!grafo.FoiCriado)
                    {
                        Console.WriteLine("O grafo ainda não foi criado. Crie-o antes de adicionar arestas.");
                        break;
                    }

                    var origemAresta = LerInteiro("Digite o vértice de origem: ");
                    var destinoAresta = LerInteiro("Digite o vértice de destino: ");

                    if (ValidarVertices(origemAresta, destinoAresta))
                    {
                        grafo.AdicionarAresta(origemAresta, destinoAresta);
                        Console.WriteLine("Aresta adicionada com sucesso.");
                    }
                    break;
                case 3:
                    if (!grafo.FoiCriado)
                    {
                        Console.WriteLine("O grafo ainda não foi criado. Crie-o antes de adicionar arcos.");
                        break;
                    }

                    var origemArco = LerInteiro("Digite o vértice de origem: ");
                    var destinoArco = LerInteiro("Digite o vértice de destino: ");

                    if (ValidarVertices(origemArco, destinoArco))
                    {
                        grafo.AdicionarArco(origemArco, destinoArco);
                        Console.WriteLine("Arco adicionado com sucesso.");
                    }
                    break;
                case 4:
                    if (!grafo.FoiCriado)
                    {
                        Console.WriteLine("O grafo ainda não foi criado. Crie-o antes de buscar arestas.");
                        break;
                    }

                    var origemBusca = LerInteiro("Digite o vértice de origem: ");
                    var destinoBusca = LerInteiro("Digite o vértice de destino: ");

                    if (ValidarVertices(origemBusca, destinoBusca))
                    {
                        var existe = grafo.ExisteAresta(origemBusca, destinoBusca);
                        Console.WriteLine(existe
                            ? "Existe aresta/arco entre os vértices informados."
                            : "Não existe aresta entre esses vértices.");
                    }
                    break;
                case 5:
                    if (!grafo.FoiCriado)
                    {
                        Console.WriteLine("O grafo ainda não foi criado. Crie-o antes de imprimir.");
                        break;
                    }

                    Console.WriteLine("Representação do grafo (lista de adjacência):");
                    foreach (var par in grafo.ObterAdjacencias())
                    {
                        var vizinhos = par.Value.Count > 0 ? string.Join(" ", par.Value) : "(sem vizinhos)";
                        Console.WriteLine(par.Key + ": " + vizinhos);
                    }
                    break;
                case 9:
                    voltar = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (!voltar)
            {
                Pausar();
            }
        }
    }

    private static bool ValidarVertices(int origem, int destino)
    {
        if (!grafo.VerticeValido(origem) || !grafo.VerticeValido(destino))
        {
            Console.WriteLine("Vértices inválidos. Utilize valores entre 0 e " + (grafo.QuantidadeVertices - 1) + ".");
            return false;
        }

        return true;
    }

    private static void MostrarValorExtremo(int? valor, string descricao)
    {
        if (valor is null)
        {
            Console.WriteLine("A árvore está vazia. Insira valores antes de consultar o " + descricao + " valor.");
        }
        else
        {
            Console.WriteLine("O " + descricao + " valor é: " + valor);
        }
    }

    private static int LerInteiro(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            var entrada = Console.ReadLine();

            if (int.TryParse(entrada, out var valor))
            {
                return valor;
            }

            Console.WriteLine("Entrada inválida. Digite um número inteiro.");
        }
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(true);
    }
}
