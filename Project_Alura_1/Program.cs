

using System.Security.AccessControl;

//List<string> listaDasBandas = new List<string> {"Black Sabbath","Foo Figthers"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>> {

    { "AC/DC", new List<int> { 10,9 } },
    { "Foo Figthers", new List<int> {10,4,7 } }


};

void ExibirMensagemDeBoasVindas()
{
    string mensagemDeBoasVindas = @"

███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░  ███████╗██╗░░██╗██████╗░██╗░░░░░░█████╗░██████╗░███████╗██████╗░
████╗░████║██║░░░██║██╔════╝██║██╔══██╗  ██╔════╝╚██╗██╔╝██╔══██╗██║░░░░░██╔══██╗██╔══██╗██╔════╝██╔══██╗
██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝  █████╗░░░╚███╔╝░██████╔╝██║░░░░░██║░░██║██║░░██║█████╗░░██████╔╝
██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗  ██╔══╝░░░██╔██╗░██╔═══╝░██║░░░░░██║░░██║██║░░██║██╔══╝░░██╔══██╗
██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝  ███████╗██╔╝╚██╗██║░░░░░███████╗╚█████╔╝██████╔╝███████╗██║░░██║
╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░  ╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚══════╝░╚════╝░╚═════╝░╚══════╝╚═╝░░╚═╝
";

    Console.WriteLine(mensagemDeBoasVindas);

}


void ExibirOpcoesDoMenu()
{
    ExibirMensagemDeBoasVindas();

    Console.WriteLine("\nOlá! O que deseja fazer?: ");
    Console.WriteLine("* Opção (1) para registrar uma banda ");
    Console.WriteLine("* Opção (2) para mostrar todas as bandas");
    Console.WriteLine("* Opção (3) para avaliar uma banda");
    Console.WriteLine("* Opção (4) para exibir a média ");

    Console.Write("\nDigite aqui: ");

    string opcaoEscolhida = Console.ReadLine()!;

    switch (int.Parse(opcaoEscolhida))
    {
        case 1: Console.WriteLine("\nVocê escolheu a opção " + opcaoEscolhida);
                RegistrarBanda();
            break;                                       
        case 2: Console.WriteLine("\nVocê escolheu a opção " + opcaoEscolhida);
                ExibirBandas();
            break;                                       
        case 3: Console.WriteLine("\nVocê escolheu a opção " + opcaoEscolhida);
                AvaliarBandas();
            break;                                       
        case 4: Console.WriteLine("\nVocê escolheu a opção " + opcaoEscolhida);
                ExibirMedia();
            break;
        default: Console.WriteLine("\nOpção inválida");
            break;
    }

}


void RegistrarBanda() {

    Console.Clear();
    Console.WriteLine("\n****Registro de banda****");

    Console.Write("Digite o nome da banda que deseja registar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda,new List<int>());


    Console.WriteLine($"A banda {nomeDaBanda} foi registrado com sucesso!");

    FimOperacao();
}

void ExibirBandas() {

    Console.Clear();
    Console.WriteLine("\n****Lista de bandas****");

    foreach (var banda in bandasRegistradas)
    {
        Console.WriteLine(banda.Key);
    }

    FimOperacao();
}

void AvaliarBandas() {
    int count = 0;

    Console.Clear();
    Console.WriteLine("****Avaliação de bandas****");

    Console.WriteLine("\nQual banda você deseja avaliar?");

    foreach (var banda in bandasRegistradas) {
        count ++;

        Console.WriteLine($"\nDigite ({count}) para avaliar a banda: {banda.Key}");

    }

    Console.Write("\nDigite aqui: ");
    string bandaEscolhida = Console.ReadLine()!;

    Console.WriteLine($"Você escolheu a banda {bandasRegistradas.ElementAt(int.Parse(bandaEscolhida) - 1).Key}\n");
    Console.Write("Qual nota você deseja atribuir? ");
    int notaAtribuida = int.Parse(Console.ReadLine()!);

    bandasRegistradas[bandasRegistradas.ElementAt(int.Parse(bandaEscolhida) - 1).Key].Add(notaAtribuida);


    Console.WriteLine($"\n Nota {notaAtribuida} atribuida a banda {bandasRegistradas.ElementAt(int.Parse(bandaEscolhida) - 1).Key} com sucesso!! ");
    FimOperacao();
}

void ExibirMedia() {

    Console.Clear();
    Console.WriteLine("\n****Media de bandas****");

    foreach (var bandas in bandasRegistradas) {

        Console.WriteLine($"\nAs notas da banda {bandas.Key} são: " + string.Join(",",bandasRegistradas[bandas.Key]));

        //int mediaNota = bandasRegistradas[bandas.Key].Sum() / bandasRegistradas[bandas.Key].Count();

        Console.WriteLine("Portanto a avaliação média da banda é: " + bandasRegistradas[bandas.Key].Sum() / bandasRegistradas[bandas.Key].Count()); 

    
    }

    FimOperacao();
}


void FimOperacao() { 

    Console.WriteLine("\nPara voltar ao menu pressione qualquer tecla.");
    Console.ReadKey();
    Console.Clear() ;
    ExibirOpcoesDoMenu();
}
ExibirOpcoesDoMenu();