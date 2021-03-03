using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3,":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario =  ObterOpcaoUsuario();
            }
             Console.WriteLine("Obrigado por utilizar nossos serviços.");
             Console.ReadLine();
        }
    

    private static void ListarSeries()
    {
        Console.WriteLine("listar Series");

        var Lista = repositorio.Lista();
        
        if (Lista.Count == 0)
        { 
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }
        foreach (var serie in Lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine("#id {0}: - {1} {2}", serie.retornaID(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
        }
    
    }

    private static void InserirSeries()
    {
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
        }
        Console.Write("Digite o genêro entre as opões acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo da Série ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio da Série ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao =  Console.ReadLine();

        Serie novaSerie = new Serie(id:repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano:entradaAno,
                                    descricao: entradaDescricao);
    
        repositorio.Insere(novaSerie);
    
    }

    private static void VisualizarSeries()
    {
        Console.Write("Digite o id da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static void ExcluirSerie()
     {
            Console.Write("Digite o id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
     }

    private static void AtualizarSerie()
    {
        Console.Write("Digite o id da Série:");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
        }
        Console.Write("Digite o genêro entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio da Série: ");
        int entradaAno= int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

         Serie atualizaSerie = new Serie(id:indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano:entradaAno,
                                    descricao: entradaDescricao);
    
        repositorio.Atualiza(indiceSerie, atualizaSerie);      

    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("dio Séries a seu dispor!!!");
        Console.WriteLine("Informe a opção Desejada");

        Console.WriteLine("1 - Listar Séries");
        Console.WriteLine("2 - Inserir nova Série");
        Console.WriteLine("3 - Atualizar Série");
        Console.WriteLine("4 - Excluir Séries");
        Console.WriteLine("5 - Visualizar Séries");
        Console.WriteLine("C - Limpar Tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();
    
        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
}
    }

