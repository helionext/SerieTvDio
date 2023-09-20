using static System.Console;
using SeriesTv.Classes;
using System.Data;
using SeriesTv.Enum;


var repositorio = new SerieRepositorio();

string opcaoUsuario = ObterOpcaoUsuario();

while(opcaoUsuario.ToUpper() != "X")
{
    switch(opcaoUsuario)
    {
        case "1":
           ListarSerie();
           break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    opcaoUsuario = ObterOpcaoUsuario();
}

void ListarSerie()
{
    WriteLine("Listar séries");

    var lista = repositorio.Listar();

    if(lista.Count == 0)
    {
        WriteLine("Não existe nenhuma série cadastrada");
        return;
    }
    
    foreach(var serie in lista)
    {
        WriteLine($"ID: {serie.GetId()} - {serie.GetTitulo()}");
    }

}

void InserirSerie()
{
    WriteLine("Inserir nova série");

    foreach(int i in Enum.GetValues(typeof(Genero)))
    {
        WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
    }

    Write("Digite o genero entre as opções acima: ");
    Genero genero = (Genero) int.Parse(ReadLine());

    Write("Digite o Tiulo da Série: ");
    string titulo = ReadLine();

    Write("Digite o Ano de Inicio da Série: ");
    int ano = int.Parse(ReadLine());

    Write("Digite a descrição da série: ");
    string descricao = ReadLine();

    Serie novaSerie = new Serie(repositorio.ProximoId(), genero, titulo, descricao, ano);

    repositorio.Inserir(novaSerie);
}

void AtualizarSerie()
{
    WriteLine("Atualizar serie");
    Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach(int i in Enum.GetValues(typeof(Genero)))
    {
        WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
    }

    Write("Digite o genero entre as opções acima: ");
    Genero genero = (Genero) int.Parse(ReadLine());

    Write("Digite o Tiulo da Série: ");
    string titulo = ReadLine();

    Write("Digite o Ano de Inicio da Série: ");
    int ano = int.Parse(ReadLine());

    Write("Digite a descrição da série: ");
    string descricao = ReadLine();

    Serie serieAtualizada = new Serie(repositorio.ProximoId(), genero, titulo, descricao, ano);

    repositorio.Atualizar(indiceSerie, serieAtualizada);
    WriteLine("Série atualizada");
}

void ExcluirSerie()
{
    WriteLine("Excluir série");
    Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Excluir(indiceSerie);
    WriteLine("Série Exlcuida");
}

void VisualizarSerie()
{
    Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);
    
    WriteLine(serie);
}


static string ObterOpcaoUsuario()
{
    WriteLine();
    WriteLine("Dio Séries a seu dispor!!!");

    WriteLine("1 - Listar séries");
    WriteLine("2 - Inserir nova serie");
    WriteLine("3 - Atualizar série");
    WriteLine("4 - Excluir série");
    WriteLine("5 - Visualizar série");
    WriteLine("C - Limpar tela");
    WriteLine("X - Sair");
    WriteLine();
    Write("Informe a opção desejada: ");

    string opcaoUsuario = ReadLine();

    return opcaoUsuario;
}