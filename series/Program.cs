using System;

namespace series
{
    class Program
    {
        static SerieRepo repositorio = new SerieRepo();
        static void Main(string[] args)
        {
            string opcao = menu();

            while (!opcao.Equals("X"))
            {
                switch (opcao)
                {
                    case "1":
                        {
                            InserirSerie();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Listando as Series existentes:");
                            Console.WriteLine();
                            ListarSeries();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Excluindo a Serie:");
                            ExcluirSerie(GetId());
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Atualizando a Serie:");
                            int id = GetId();
                            Console.WriteLine("Informações atuais:");
                            VisualizarSerie(id); 
                            Console.WriteLine();                          
                            Console.WriteLine("Início das modificações:");
                            AtualizarSerie(id);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Visualizando a Serie:");
                            VisualizarSerie(GetId());
                            break;
                        }
                    case "C":
                        {
                            Console.Clear();
                            break;
                        }

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine();
                        break;
                }

                opcao = menu();

            }
            Console.WriteLine();
            Console.WriteLine("Obrigado por acessar DIO Series!");
            Console.WriteLine();

            static string menu()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo ao DIO Series!");
                Console.WriteLine();
                Console.WriteLine("Informe a opcao desejada:");
                Console.WriteLine("[1] PARA INSERIR NOVA SERIE");
                Console.WriteLine("[2] PARA LISTAR TODAS SERIES");
                Console.WriteLine("[3] PARA EXCLUIR SERIE");
                Console.WriteLine("[4] PARA ATUALIZAR SERIE");
                Console.WriteLine("[5] PARA VISUALIZAR SERIE");
                Console.WriteLine("[C] PARA LIMPAR A TELA");
                Console.WriteLine("[x] PARA ENCERRAR");
                Console.WriteLine();
                string opcao = Console.ReadLine().ToUpper();
                return opcao;
            }
        }

        private static void InserirSerie()
        {

            Console.Write("Inserindo nova Serie: ");
            Console.WriteLine();
            int inGenero, inAno;
            string inTitulo, inDescricao;
            CriarSerie(out inGenero, out inTitulo, out inDescricao, out inAno);

            Series NovaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)inGenero,
                                          descricao: inDescricao,
                                          titulo: inTitulo,
                                          ano: inAno
                                          );

            repositorio.Inserir(NovaSerie);

        }

        private static void CriarSerie(out int inGenero, out string inTitulo, out string inDescricao, out int inAno)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite, conforme o código acima, o Gênero da serie:");
            inGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título da Serie: ");
            inTitulo = Console.ReadLine();
            Console.Write("Digite a Descrição da Serie: ");
            inDescricao = Console.ReadLine();
            Console.Write("Digite o Ano de lançamento da Serie: ");
            inAno = int.Parse(Console.ReadLine());
        }

        private static void AtualizarSerie(int id)
        {
            int inGenero, inAno;
            string inTitulo, inDescricao;
            CriarSerie(out inGenero, out inTitulo, out inDescricao, out inAno);

            Series AtualizaSerie = new Series(id: id,
                                          genero: (Genero)inGenero,
                                          descricao: inDescricao,
                                          titulo: inTitulo,
                                          ano: inAno
                                          );

            repositorio.Atualizar(AtualizaSerie, id);
        }

        private static void ExcluirSerie(int id)
        {
            repositorio.Excluir(id);
            ListarSeries();
        }
        private static void VisualizarSerie(int id)
        {
            Console.WriteLine(repositorio.RetornoPorID(id));
        }

        private static int GetId()
        {
            Console.Write("Digite o código da Serie:");
            int inId = int.Parse(Console.ReadLine());            
            return inId;
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie existente.");
                Console.WriteLine();
                return;
            }

            foreach (var serie in lista)
            {

                Console.WriteLine("#ID: {0} - {1}  {2}", serie.RetornaId(), serie.RetornaTitulo(),
                                                          (serie.RetornaExcluido() ? "- EXCLUIDA" : ""));
            }

        }

    }
}

