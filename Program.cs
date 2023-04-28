using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;


const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";


Menu();
// RetornarProdutos();

static void Menu()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar ou modificar um produto, digite: PRODUTO");
    Console.WriteLine("Para cadastrar ou modificar um feudo, digite: FEUDO");
    Console.WriteLine("Se você quer extinguir uma família por inteiro, digite: BANIR");
    Console.WriteLine("Para cadastrar ou modificar uma família, digite: FAMILIA");
    Console.WriteLine("Para cadastrar, deletar ou modificar um membro, digite: MEMBRO");
    Console.WriteLine("Para cadastrar ou modificar um nível de poder de família, digite: PODER");
    Console.WriteLine("Para cadastrar, deletar ou modificar uma arrecadação, digite: ARRECADACAO");
    Console.WriteLine("Para cadastrar ou modificar uma area, digite: AREA");

    Console.WriteLine("Se você está não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
    }
    
    option = option.ToUpper();

    switch (option)
    {
        case "PRODUTO":
        Console.Clear();
        MenuProduto();
        break;
        case "FEUDO":
        Console.Clear();
        MenuFeudo();
        break;
        case "BANIR":
        Console.Clear();
        MenuExtinguir();
        break;
        case "FAMILIA":
        Console.Clear();
        MenuFamilia();
        break;
        case "MEMBRO":
        Console.Clear();
        MenuMembro();
        break;
        case "PODER":
        Console.Clear();
        MenuPoderFamilia();
        break;
        case "ARRECADACAO":
        Console.Clear();
        MenuArrecadacao();
        break;
        case "AREA":
        Console.Clear();
        MenuArea();
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
        break;
        
    }
}

static void MenuFeudo()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações dos seus feudos?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar um novo feudo, digite: CADASTRAR");
    Console.WriteLine("Para alterar um feudo, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarFeudo(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha o feudo e digite o ID que identifica ele");
        RetornarFeudos();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var feudoModificado = ModificarFeudoModelo(id);
        ModificarFeudo(feudoModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
        break;
        
    }
}

static void MenuProduto()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com os produtos?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um produto, digite: Modificar");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarProduto();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha o produto e digite o ID que identifica ele");
        RetornarProdutos();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var produtoModificado = ModificarProdutoModelo(id);
        ModificarProduto(produtoModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void MenuMembro()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com os membros?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um membro, digite: Modificar");
    Console.WriteLine("Para excluir um, digite: EXCLUIR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarMembro();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha o membro e digite o ID que identifica ele");
        RetornarMembros();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var membroModificado = ModificarMembroModelo(id);
        ModificarMembro(membroModificado);
        break;
        case "EXCLUIR":
        Console.WriteLine("Escolha o membro a ser deletado e digite o ID que identifica ele");
        RetornarMembros();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        DeletarMembro(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void MenuExtinguir()
{
    Console.WriteLine("Bom dia, Senhor Feudal. Você estar aqui significa que algo muito grave irá ocorrer");
    Console.WriteLine("Em todo caso, espero que tenha misericórdia");
    Console.WriteLine("Para Extinguir uma família e tudo relacionado a ela, digite: BANIR");
    
    Console.WriteLine("Se você teve misericórdia e não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "BANIR":
        Console.Clear();
        Console.WriteLine("Escolha a família e digite o ID que identifica ela");
        RetornarFamilias();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        ExtinguirFamilia(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
        break;
        
    }
}

static void MenuFamilia()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações das famílias?");
    Console.WriteLine("Para cadastrar uma nova familia, digite: CADASTRAR");
    Console.WriteLine("Para alterar o nome de uma família, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarFamilia(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha a família e digite o ID que identifica ela");
        RetornarFamilias();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var familiaModificada = ModificarFamiliaModelo(id);
        ModificarFamilia(familiaModificada);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFamilia();
        break;
        
    }
}

static void MenuPoderFamilia()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações dos níveis de poder das famílias?");
    Console.WriteLine("Para cadastrar um novo nível, digite: CADASTRAR");
    Console.WriteLine("Para alterar a nomenclatura de um nível, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarPoderFamiliar(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha o nível a ser alterado e digite o ID que identifica ela");
        RetornarPoderFamilia();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var poderModificado = ModificarPoderFamiliaModelo(id);
        ModificarPoderFamilia(poderModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFamilia();
        break;
        
    }
}

static void MenuArrecadacao()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as arrecadações?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um membro, digite: MODIFICAR");
    Console.WriteLine("Para excluir um, digite: EXCLUIR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarArrecadacao();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha a arrecadação e digite o ID que identifica ela");
        RetornarArrecadacao();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var arrecadacaoModificada = ModificarArrecadacaoModelo(id);
        ModificarArrecadacao(arrecadacaoModificada);
        break;
        case "EXCLUIR":
        Console.WriteLine("Escolha a arrecadacao a ser deletada e digite o ID que identifica ela");
        RetornarArrecadacao();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        DeletarArrecadacao(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void MenuArea()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as áreas?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um membro, digite: MODIFICAR");
    Console.WriteLine("Para excluir um, digite: EXCLUIR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarArea();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha a área e digite o ID que identifica ela");
        RetornarAreas();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var areaModificada = ModificarAreaModelo(id);
        ModificarArea(areaModificada);
        break;
        case "EXCLUIR":
        Console.WriteLine("Escolha a arrecadacao a ser deletada e digite o ID que identifica ela");
        RetornarAreas();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        DeletarArea(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void CriarProduto()
{
    var produtos = new Produtos();
    
    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    produtos.Produto= Console.ReadLine();

    SalvarProduto(produtos);
  
}

static void CriarPoderFamiliar()
{
    var poder = new PoderDaFamilia();

    Console.WriteLine("Área de criação de nível de poder");
    Console.WriteLine("Digite a nomenclatura do novo nível");
    poder.NivelDePoder = Console.ReadLine();

    SalvarPoder(poder);
  
}

static void CriarFeudo()
{
    var feudo = new MeuFeudo();

    Console.WriteLine("Área de criação de feudos");
    Console.WriteLine("Digite o nome do feudo abaixo:");
    feudo.Nome = Console.ReadLine();

    SalvarFeudo(feudo);
    
}

static void CriarMembro()
{
    var membro = new Membro();

    Console.WriteLine("Área de inserção de Membros");
    Console.WriteLine("Digite o nome do membro abaixo:");
    membro.Nome = Console.ReadLine();
    Console.WriteLine("Escolha a família abaixo e digite seu ID:");
    RetornarFamilias();
    membro.Familia = int.Parse(Console.ReadLine());

    SalvarMembro(membro);
    
}

static void CriarFamilia()
{
    var familia = new Familia();

    Console.WriteLine("Área de inserção de Famílias");
    Console.WriteLine("Digite o nome da família abaixo:");
    familia.NomeDaFamilia = Console.ReadLine();

    SalvarFamilia(familia);
}

static void CriarArrecadacao()
{
    var arrecadado = new Arrecadacao();
    Console.WriteLine("Olá, Senhor Feudal. Iremos criar uma nova arrecadação agora");
    Console.WriteLine("Por gentileza, escolher uma das estações do ano e digitar seu id:");
    RetornarEstacoes();
    Console.WriteLine("PODE DIGITAR:");
    arrecadado.EstacaoDoAno = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Por gentileza, veja as áreas e digite o id da área escolhida");
    RetornarAreasSeletivo();
    Console.WriteLine("PODE DIGITAR:");
    arrecadado.AreaDeArrecadacao = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Por gentileza, veja os produtos e digite o id do produto escolhido");
    RetornarProdutos();
    arrecadado.Arrecadado = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Digite a quantidade a ser inserida:");
    arrecadado.Quantidade = int.Parse(Console.ReadLine());
    Console.Clear();
    
    SalvarArrecadacao(arrecadado);
}

static void CriarArea()
{
    var area = new Area();
    Console.WriteLine("Olá, Senhor Feudal. Iremos criar uma nova Área agora");
    Console.WriteLine("Por gentileza, escolher uma das famílias para a área e digitar seu id:");
    RetornarFamilias();
    Console.WriteLine("PODE DIGITAR:");
    area.FamiliaDaArea = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Por gentileza, veja os níveis de poder de uma família e digite o id do escolhido");
    RetornarPoderFamilia();
    Console.WriteLine("PODE DIGITAR:");
    area.NivelDaFamilia = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Por gentileza, digite o nome da área");
    area.NomeDaArea = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Digite a que feudo irá pertencer");
    RetornarFeudos();
    area.FeudoPertencente = int.Parse(Console.ReadLine());
    Console.Clear();
    
    SalvarArea(area);
}

static void ModificarProduto(Produtos produto)
{
    var repository = new RepositoryBase<Produtos>();
    repository.Atualizar(produto);
}

static void ModificarFeudo(MeuFeudo nome)
{
    var repository = new RepositoryBase<MeuFeudo>();
    repository.Atualizar(nome);
}

static void ModificarFamilia(Familia nomeFamilia)
{
    var repository = new RepositoryBase<Familia>();
    repository.Atualizar(nomeFamilia);
}

static void ModificarMembro(Membro membro)
{
    var repository = new RepositoryBase<Membro>();
    repository.Atualizar(membro);
}

static void ModificarPoderFamilia(PoderDaFamilia nivel)
{
    var repository = new RepositoryBase<PoderDaFamilia>();
    repository.Atualizar(nivel);
}

static void ModificarArrecadacao(Arrecadacao arrecadacao)
{
    var repository = new RepositoryBase<Arrecadacao>();
    repository.Atualizar(arrecadacao);
}
 
static void ModificarArea(Area area)
{
    var repository = new RepositoryBase<Area>();
    repository.Atualizar(area);
}

static Arrecadacao ModificarArrecadacaoModelo(int id)
{
    var arrecadado = new Arrecadacao();
    arrecadado.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar uma arrecadação agora");
    Console.WriteLine("Por gentileza, veja as áreas e digite o id da área escolhida");
    RetornarAreasSeletivo();
    arrecadado.AreaDeArrecadacao = int.Parse(Console.ReadLine());
    Console.WriteLine("Por gentileza, veja os produtos e digite o id do produto escolhido");
    RetornarProdutos();
    arrecadado.Arrecadado = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a quantidade atualizada:");
    arrecadado.Quantidade = int.Parse(Console.ReadLine());
    return arrecadado;
}

static Familia ModificarFamiliaModelo(int id)
{
    var familia = new Familia();
    familia.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar uma família agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    familia.NomeDaFamilia = Console.ReadLine();
    return familia;
}

static Membro ModificarMembroModelo(int id)
{
    var membro = new Membro();
    membro.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um membro agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    membro.Nome = Console.ReadLine();
    Console.WriteLine("Escolha a família abaixo para mudar e digite seu ID:");
    RetornarFamilias();
    membro.Familia = int.Parse(Console.ReadLine());

    return membro;
}

static PoderDaFamilia ModificarPoderFamiliaModelo(int id)
{
    var poder = new PoderDaFamilia();
    poder.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um dos níveis de poder");
    Console.WriteLine("Por gentileza, escreva o novo nome");
    poder.NivelDePoder = Console.ReadLine();
    return poder;
}

static Produtos ModificarProdutoModelo(int id)
{
    var produtos = new Produtos();
    produtos.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o produto agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o produto");
    produtos.Produto = Console.ReadLine();
    return produtos;
}

static MeuFeudo ModificarFeudoModelo(int id)
{
    var feudo = new MeuFeudo();
    feudo.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o feudo agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o feudo");
    feudo.Nome = Console.ReadLine();
    return feudo;
}

static Area ModificarAreaModelo(int id)
{
    var area = new Area();
    area.Id = id;
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar uma area agora");
    Console.WriteLine("Por gentileza, veja as familias e digite o id da escolhida");
    RetornarFamilias();
    area.FamiliaDaArea = int.Parse(Console.ReadLine());
    Console.WriteLine("Por gentileza, veja os niveis de familia em uma área e digite o id da escolhida");
    RetornarPoderFamilia();
    area.NivelDaFamilia = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite novo nome da área atualizada:");
    area.NomeDaArea = Console.ReadLine();
    Console.WriteLine("Digite para qual feudo vai pertencer atualizada:");
    RetornarFeudos();
    area.FeudoPertencente = int.Parse(Console.ReadLine());
    return area;
}

static void DeletarMembro(int id)
{
    var membro = new Membro();
    var repository = new RepositoryBase<Membro>();
    repository.Deletar(membro,id);
}

static void DeletarArrecadacao(int id)
{
    var arrecadacao = new Arrecadacao();
    var repository = new RepositoryBase<Arrecadacao>();
    repository.Deletar(arrecadacao,id);
}

static void DeletarArea(int id)
{
    string excluir = @"DELETE Arrecadacoes
                            FROM Arrecadacoes
                            JOIN Areas ON Arrecadacoes.AreaDeArrecadacao = Areas.ID
                            WHERE Arrecadacoes.AreaDeArrecadacao = @id
        
                            DELETE Areas FROM Areas WHERE Areas.ID = @identificador";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(excluir, new{id = id, identificador = id});

        Retorno(linhaSalvas, "deletada");
        
    }
    
}

static void ExtinguirFamilia(int id)
{
    string excluir = @"DELETE Areas
                            FROM Areas
                            JOIN Familias ON Areas.FamiliaDaArea = Familias.ID 
                            JOIN Membros ON Familias.ID = Membros.Familia 
                            WHERE Areas.FamiliaDaArea = @id;

                            DELETE Membros
                            FROM Membros
                            JOIN Familias ON Familias.ID = Membros.Familia 
                            WHERE Membros.Familia = @identificar;

                            DELETE Familias
                            FROM Familias
                            WHERE Familias.ID = @identificador;
                            ";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(excluir, new{id = id, identificar = id, identificador = id});

        Retorno(linhaSalvas, "deletada");
    }
}

//com repository. não está salvando ???
static void SalvarProduto(Produtos produto)
{
   var repository = new RepositoryBase<Produtos>();
   repository.Criar(produto);
}

//com repository. não está salvando ???
static void SalvarPoder(PoderDaFamilia poder)
{
    var repository = new RepositoryBase<PoderDaFamilia>();
    repository.Criar(poder);
}

//com repository. não está salvando ???
static void SalvarFeudo(MeuFeudo nome)
{
    var repository = new RepositoryBase<MeuFeudo>();
    repository.Criar(nome);
}

//com repository. não está salvando ???
static void SalvarFamilia(Familia nome)
{
    var repository = new RepositoryBase<Familia>();
    repository.Criar(nome);
}

static void SalvarMembro(Membro membro)
{
    var repository = new RepositoryBase<Membro>();
    repository.Criar(membro);

}

static void SalvarArrecadacao(Arrecadacao arrecadacao)
{
    var repository = new RepositoryBase<Arrecadacao>();
    repository.Criar(arrecadacao);
}

static void SalvarArea(Area area)
{
    var repository = new RepositoryBase<Area>();
    repository.Criar(area);
}

static void RetornarFeudos()
{
    var repository = new RepositoryBase<MeuFeudo>();
    var feudos = repository.TrazerTodos();
    foreach(var feudo in feudos)
            Console.WriteLine($"Feudo: {feudo.Nome} ////// Identificador (ID):{feudo.Id}");
        
    
}

static void RetornarFamilias()
{
    var repository = new RepositoryBase<Familia>();
    var familia = repository.TrazerTodos();
    foreach (var familias in familia)
        Console.WriteLine($"Nome da Família: {familias.NomeDaFamilia} ////// Identificador (ID):{familias.Id}");
}

static void RetornarProdutos()
{
    var repository = new RepositoryBase<Produtos>();
    var produtos = repository.TrazerTodos();
    foreach (var produto in produtos)
            Console.WriteLine($"Nome: {produto.Produto} ////// Identificador:{produto.Id}");
        
}

static void RetornarPoderFamilia()
{
    var repository = new RepositoryBase<PoderDaFamilia>();
    var poder = repository.TrazerTodos();
    foreach (var poderDasFamilias in poder)
        Console.WriteLine($"Poder da família: {poderDasFamilias.NivelDePoder} ////// Identificador:{poderDasFamilias.Id}");
}

static void RetornarMembros()
{
    var repository = new RepositoryBase<Membro>();
    var membro = repository.TrazerTodos();
    foreach (var membros in membro)
        Console.WriteLine($"Nome: {membros.Nome} ////// Identificador:{membros.Id}");
        
    
}

static void RetornarAreasSeletivo()
{
   var repository = new RepositoryBase<Area>();
    var areas = repository.TrazerTodos();
    foreach (var area in areas)
            Console.WriteLine($"Nome da área: {area.NomeDaArea} ////// Identificador:{area.Id}");
}

static void RetornarAreas()
{
    var repository = new RepositoryBase<Area>();
    var areas = repository.TrazerTodos();
    foreach (var area in areas)
        Console.WriteLine($@"-----Identificador (ID): {area.Id} / Familia da área: {area.FamiliaDaArea} /  Poder da família: {area.NivelDaFamilia} Nome da área: {area.NomeDaArea} / Pertence ao feudo: {area.FeudoPertencente}");
}

static void RetornarEstacoes()
{
    var repository = new RepositoryBase<Estacoes>();
    var estacao = repository.TrazerTodos();
        foreach (var estacoes in estacao)
            Console.WriteLine($"Nome: {estacoes.Estacao} ////// Identificador:{estacoes.Id}");
        
    
}

static void RetornarArrecadacao()
{
    var repository = new RepositoryBase<Arrecadacao>();
    var arrecadacao = repository.TrazerTodos();
        foreach (var arrecadacoes in arrecadacao) 
            Console.WriteLine($@"-----Identificador (ID): {arrecadacoes.Id} / Área de Arrecadação: {arrecadacoes.AreaDeArrecadacao} /  Cód. Produto: {arrecadacoes.Arrecadado} Quantidade: {arrecadacoes.Quantidade}");
    
}

static void Retorno(int linhasAfetadas, string foiFeitoOque)
{
            
    Console.WriteLine($"{linhasAfetadas} linha(s) {foiFeitoOque}(s)");

}
