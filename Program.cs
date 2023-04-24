using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";

RetornarFeudos();

//esses não precisam mudar
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
        var feudoModificado = ModificarFeudoModelo();
        ModificarFeudo(id,feudoModificado);
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
        var produtoModificado = ModificarProdutoModelo();
        ModificarProduto(id,produtoModificado);
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
        var membroModificado = ModificarMembroModelo();
        ModificarMembro(id,membroModificado);
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
        var familiaModificada = ModificarFamiliaModelo();
        ModificarFamilia(id,familiaModificada);
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
        var poderModificado = ModificarPoderFamiliaModelo();
        ModificarPoderFamilia(id,poderModificado);
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
        var arrecadacaoModificada = ModificarArrecadacaoModelo();
        ModificarArrecadacao(id,arrecadacaoModificada);
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
        var areaModificada = ModificarAreaModelo();
        ModificarArea(id,areaModificada);
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


//esses não necessitam mudar
static void CriarProduto()
{
    var produto = new Produto();

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    produto.NomeDoProduto = Console.ReadLine();

    SalvarProduto(produto);
  
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


//atualizado
static void ModificarProduto(int id, Produto produto)
{
    
    string pesquisar = @"SELECT COUNT(*) FROM Produtos WHERE ID = @identificador";
    string modificar = @"UPDATE Produtos SET Produto = @produto WHERE ID = @id";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    if (qtdRegistros == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{produto = produto.NomeDoProduto, id = id});

    Retorno(linhaSalvas, "modificado");

    }
}

//atualizado para dapper.contrib
static void ModificarFeudo(int id, MeuFeudo nome)
{
    nome.Id = id;
    string pesquisar = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @identificador";
    
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    if (qtdRegistros == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    } 
    var linhaSalvas = conexaoBD.Update<MeuFeudo>(nome);

    Retorno(Convert.ToInt32(linhaSalvas), "modificado");

    }
}

//atualizado
static void ModificarFamilia(int id, Familia nomeFamilia)
{
    string pesquisar = @"SELECT COUNT(*) FROM Familias WHERE ID = @identificador";
    string modificar = @"UPDATE Familias SET NomeDaFamilia = @nomeFamilia WHERE ID = @id";
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    if (qtdRegistros == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFamilia();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{nomeFamilia = nomeFamilia.NomeDaFamilia, id = id});

    Retorno(linhaSalvas, "modificado");
    }
}

//atualizado
static void ModificarMembro(int id, Membro membro)
{
    string pesquisar = @"SELECT COUNT(*) FROM Membros WHERE ID = @identificador";
    string modificar = @"UPDATE Membros SET Nome = @nome, Familia = @familia WHERE ID = @id";
    string pesquisa = @"SELECT COUNT(*) FROM Familias WHERE ID = @identificado";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    int qtdRegistross = conexaoBD.ExecuteScalar<int>(pesquisa, new { identificado = membro.Familia});
    if (qtdRegistros == 0 || qtdRegistross == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuMembro();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{nome = membro.Nome, familia = membro.Familia, id = id});

    Retorno(linhaSalvas, "modificado");
    }
}

//atualizado
static void ModificarPoderFamilia(int id, PoderDaFamilia nivel)
{
    string pesquisar = @"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @identificador";
    string modificar = @"UPDATE PoderDaFamilia SET NivelDePoder = @nivel WHERE ID = @id";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    if (qtdRegistros == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuPoderFamilia();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{nivel = nivel.NivelDePoder, id = id});

    Retorno(linhaSalvas, "modificado");
    }
}

//Atualizado
static void ModificarArrecadacao(int id, Arrecadacao arrecadacao)
{
    string pesquisar = @$"SELECT COUNT(*) FROM Arrecadacoes WHERE ID = @identificador";
    string modificar = @"UPDATE Arrecadacoes SET AreaDeArrecadacao = @areadearrecadacao, Arrecadado = @arrecadado, Quantidade = @quantidade WHERE ID = @id";
    string pesquisa = @"SELECT COUNT(*) FROM Areas WHERE ID = @identificado";
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id });
    int qtdRegistross = conexaoBD.ExecuteScalar<int>(pesquisa, new { identificado = arrecadacao.AreaDeArrecadacao});
    if (qtdRegistros == 0 || qtdRegistross == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuArrecadacao();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{areadearrecadacao = arrecadacao.AreaDeArrecadacao, arrecadado = arrecadacao.Arrecadado, quantidade = arrecadacao.Quantidade, id = id});

    Retorno(linhaSalvas, "modificado");
    }
}
 
//Atualizado
static void ModificarArea(int id, Area area)
{
    string pesquisar = @$"SELECT COUNT(*) FROM Areas WHERE ID = @identificador";
    string pesquisarFamilia = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
    string pesquisarPoder = @"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @poder";
    string pesquisarFeudo = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @feudo";
    string modificar = @"UPDATE Areas SET FamiliaDaArea = @familiaDaArea, NivelDaFamilia = @nivelDaFamilia, NomeDaArea = @nomeDaArea, FeudoPertencente = @feudoPertencente WHERE ID = @id";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    
    int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { identificador = id});
    int qtdRegistrosFamilia = conexaoBD.ExecuteScalar<int>(pesquisarFamilia, new { familia = area.FamiliaDaArea });
    int qtdRegistrosPoder = conexaoBD.ExecuteScalar<int>(pesquisarPoder, new { poder = area.NivelDaFamilia });
    int qtdRegistrosFeudo = conexaoBD.ExecuteScalar<int>(pesquisarFeudo, new { feudo = area.FeudoPertencente });
     
    if (qtdRegistros == 0 || qtdRegistrosFamilia == 0 || qtdRegistrosPoder == 0 || qtdRegistrosFeudo == 0)
    {
        Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
        Console.WriteLine("Redirecionando para o menu atual...");
        Thread.Sleep(3000);
        //Console.Clear();
        MenuArea();
    } 

    var linhaSalvas = conexaoBD.Execute(modificar, new{familiaDaArea = area.FamiliaDaArea, nivelDaFamilia = area.NivelDaFamilia, nomeDaArea = area.NomeDaArea, feudoPertencente = area.FeudoPertencente, id = id});

    Retorno(linhaSalvas, "modificado");
    }
}


//não precisa mudar esses
static Arrecadacao ModificarArrecadacaoModelo()
{
    var arrecadado = new Arrecadacao();
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

static Familia ModificarFamiliaModelo()
{
    var familia = new Familia();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar uma família agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    familia.NomeDaFamilia = Console.ReadLine();
    return familia;
}

static Membro ModificarMembroModelo()
{
    var membro = new Membro();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um membro agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    membro.Nome = Console.ReadLine();
    Console.WriteLine("Escolha a família abaixo para mudar e digite seu ID:");
    RetornarFamilias();
    membro.Familia = int.Parse(Console.ReadLine());

    return membro;
}

static PoderDaFamilia ModificarPoderFamiliaModelo()
{
    var poder = new PoderDaFamilia();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um dos níveis de poder");
    Console.WriteLine("Por gentileza, escreva o novo nome");
    poder.NivelDePoder = Console.ReadLine();
    return poder;
}

static Produto ModificarProdutoModelo()
{
    var produto = new Produto();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o produto agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o produto");
    produto.NomeDoProduto = Console.ReadLine();
    return produto;
}

static MeuFeudo ModificarFeudoModelo()
{
    var feudo = new MeuFeudo();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o feudo agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o feudo");
    feudo.Nome = Console.ReadLine();
    return feudo;
}

static Area ModificarAreaModelo()
{
    var area = new Area();
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


//atualizado
static void DeletarMembro(int id)
{
    string excluir = @"DELETE FROM Membros WHERE ID = @id";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(excluir, new{id = id});

        Retorno(linhaSalvas, "deletada");
    }
    
}

//atualizado
static void DeletarArrecadacao(int id)
{
    string excluir = @"DELETE FROM Arrecadacoes WHERE ID = @id";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(excluir, new{id = id});

        Retorno(linhaSalvas, "deletada");
    }
}

//atualizado
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

//atualizado
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


//atualizado
static void SalvarProduto(Produto produto)
{

   var insercao = @"INSERT INTO Produtos(Produto) VALUES(@NomeDoProduto)";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(insercao, new{NomeDoProduto = produto.NomeDoProduto});

        Retorno(linhaSalvas, "criado");
    }
}

//atualizado
static void SalvarPoder(PoderDaFamilia poder)
{
    string insercao = @"INSERT INTO PoderDaFamilia(NivelDePoder) VALUES(@poder)";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var linhaSalvas = conexaoBD.Execute(insercao, new{poder = poder.NivelDePoder});
        

        Retorno(linhaSalvas, "criado");
    }
}

//atualizado com dapper.contrib
static void SalvarFeudo(MeuFeudo nome)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Insert<MeuFeudo>(nome);

        //aqui está retornando o id da linha criada
        Retorno(Convert.ToInt32(linhaSalvas), "criado");
    }

}

//atualizado
static void SalvarFamilia(Familia nome)
{
    string insercao = @"INSERT INTO Familias(NomeDaFamilia) VALUES(@nome)";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        var linhaSalvas = conexaoBD.Execute(insercao, new{nome = nome.NomeDaFamilia});

        Retorno(linhaSalvas, "criado");
    }
}

//atualizado
static void SalvarMembro(Membro membro)
{
    string insercao = @$"INSERT INTO Membros(Nome,Familia) VALUES(@nome,@familia)";

    string pesquisar = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
        

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        int qtdRegistros = conexaoBD.ExecuteScalar<int>(pesquisar, new { familia = membro.Familia });
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }

        var linhaSalvas = conexaoBD.Execute(insercao, new{nome = membro.Nome, familia = membro.Familia});

        Retorno(linhaSalvas, "criado");
    }
}

//atualizado
static void SalvarArrecadacao(Arrecadacao arrecadacao)
{
    string pesquisarEstacao = @"SELECT COUNT(*) FROM Estacoes WHERE ID = @estacao";
    string pesquisarAreaDeArrecadacao = @"SELECT COUNT(*) FROM Areas WHERE ID = @AreaDeArrecadacao";
    string pesquisarArrecadado = @"SELECT COUNT(*) FROM Produtos WHERE ID = @Arrecadado";

    string insercao = @"INSERT INTO Arrecadacoes(EstacaoDoAno, AreaDeArrecadacao, Arrecadado, Quantidade) 
                            VALUES(@estacao,@areadearrecadacao,@arrecadado,@quantidade)";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        int qtdRegistrosEstacao = conexaoBD.ExecuteScalar<int>(pesquisarEstacao, new { estacao = arrecadacao.EstacaoDoAno });
        int qtdRegistrosAreaDeArrecadacao = conexaoBD.ExecuteScalar<int>(pesquisarAreaDeArrecadacao, new { AreaDeArrecadacao = arrecadacao.AreaDeArrecadacao });
        int qtdRegistrosArrecadado = conexaoBD.ExecuteScalar<int>(pesquisarArrecadado, new { Arrecadado = arrecadacao.Arrecadado });

        if (qtdRegistrosEstacao == 0 || qtdRegistrosAreaDeArrecadacao == 0 || qtdRegistrosArrecadado == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
    
        var linhaSalvas = conexaoBD.Execute(insercao, new{estacao = arrecadacao.EstacaoDoAno, areadearrecadacao = arrecadacao.AreaDeArrecadacao, arrecadado = arrecadacao.Arrecadado, quantidade = arrecadacao.Quantidade});

        Retorno(linhaSalvas, "criado");
    }
}

//atualizado
static void SalvarArea(Area area)
{
    string insercao = @"INSERT INTO Areas(FamiliaDaArea, NivelDaFamilia, NomeDaArea, FeudoPertencente) 
                            VALUES(@familiaDaArea,@nivelDaFamilia,@nomeDaArea,@feudoPertencente)";

    string pesquisarFamilia = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
    string pesquisarPoder = @"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @poder";
    string pesquisarFeudo = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @feudo";

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        

        int qtdRegistrosFamilia = conexaoBD.ExecuteScalar<int>(pesquisarFamilia, new { familia = area.FamiliaDaArea });
        int qtdRegistrosPoder = conexaoBD.ExecuteScalar<int>(pesquisarPoder, new { poder = area.NivelDaFamilia });
        int qtdRegistrosFeudo = conexaoBD.ExecuteScalar<int>(pesquisarFeudo, new { feudo = area.FeudoPertencente });

        if (qtdRegistrosFamilia == 0 || qtdRegistrosPoder == 0 || qtdRegistrosFeudo == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        var linhaSalvas = conexaoBD.Execute(insercao, new{familiaDaArea = area.FamiliaDaArea, nivelDaFamilia = area.NivelDaFamilia, nomeDaArea = area.NomeDaArea, feudoPertencente = area.FeudoPertencente});

        Retorno(linhaSalvas, "criado");
    }
}


//utilizando dapper.contrib. Facilita não escrever a instrução
static void RetornarFeudos()
{
    using(var conexaoBD = new SqlConnection(connectionString))
    {
        var feudos = conexaoBD.GetAll<MeuFeudo>();

        foreach(var feudo in feudos)
        {
            Console.WriteLine($"Feudo: {feudo.Nome} ////// Identificador (ID):{feudo.Id}");
        }
    }
}

//atualizado
static void RetornarFamilias()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var familia = conexaoBD.Query<Familia>("SELECT [ID] AS [Id], [NomeDaFamilia] AS [NomeDaFamilia] FROM Familias");
    
        foreach (var familias in familia)
        {
            Console.WriteLine($"Nome da Família: {familias.NomeDaFamilia} ////// Identificador (ID):{familias.Id}");
        }
    }
}

//atualizado
static void RetornarProdutos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var produto = conexaoBD.Query<Produto>("SELECT [ID] AS [Id], [Produto] AS [NomeDoProduto] FROM Produtos");
    
        foreach (var produtos in produto)
        {
            Console.WriteLine($"Nome: {produtos.NomeDoProduto} ////// Identificador:{produtos.Id}");
        }

    }
}

//atualizado
static void RetornarPoderFamilia()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var poder = conexaoBD.Query<PoderDaFamilia>("SELECT [ID] AS [Id], [NivelDePoder] AS [NivelDePoder] FROM PoderDaFamilia");
    
        foreach (var poderDasFamilias in poder)
        {
            Console.WriteLine($"Poder da família: {poderDasFamilias.NivelDePoder} ////// Identificador:{poderDasFamilias.Id}");
        }
    }
}

//atualizado
static void RetornarMembros()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var membro = conexaoBD.Query<Membro>("SELECT [ID] AS [Id], [Nome] AS [Nome] FROM Membros");
    
        foreach (var membros in membro)
        {
            Console.WriteLine($"Nome: {membros.Nome} ////// Identificador:{membros.Id}");
        }
    }
}

//atualizado
static void RetornarAreasSeletivo()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var area = conexaoBD.Query<Area>("SELECT [ID] AS [Id], [NomeDaArea] AS [NomeDaArea] FROM Areas");
    
        foreach (var areas in area)
        {
            Console.WriteLine($"Nome da área: {areas.NomeDaArea} ////// Identificador:{areas.Id}");
        }

    }
}

//atualizado
static void RetornarAreas()
{
    //Aqui, para não utilizar o DYNAMIC, fiz uma classe generica com atributos genericos para passar os dados e ter segurança de tipo e resolver os diferentes métodos
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var areas = conexaoBD.Query<ClasseGenerica<string>>(@"select Areas.ID AS [Id], Familias.NomeDaFamilia AS [AtributoGenerico1], PoderDaFamilia.NivelDePoder [AtributoGenerico2], Areas.NomeDaArea [AtributoGenerico3], MeusFeudos.Nome [AtributoGenerico4]
                                                            from Areas 
                                                            JOIN MeusFeudos on MeusFeudos.ID = Areas.FeudoPertencente
                                                            JOIN Familias on Familias.ID = Areas.FamiliaDaArea
                                                            JOIN PoderDaFamilia on PoderDaFamilia.ID = Areas.NivelDaFamilia");

        foreach (var area in areas)
        {
            Console.WriteLine($@"-----Identificador (ID): {area.Id} / Familia da área: {area.AtributoGenerico1} /  Poder da família: {area.AtributoGenerico2} Nome da área: {area.AtributoGenerico3} / Pertence ao feudo: {area.AtributoGenerico4}");
        }
    }
}

//atualizado
static void RetornarEstacoes()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var estacao = conexaoBD.Query<Estacao>("SELECT ID [id], Estacao [EstacaoAtual] FROM Estacoes");
    
        foreach (var estacoes in estacao)
        {
            Console.WriteLine($"Nome: {estacoes.Id} ////// Identificador:{estacoes.EstacaoAtual}");
        }
    }
}

//atualizado
static void RetornarArrecadacao()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        var arrecadacao = conexaoBD.Query<ClasseGenerica<string>>(@"select Arrecadacoes.ID [ID],Areas.NomeDaArea [AtributoGenerico1],Produtos.Produto [AtributoGenerico2], Arrecadacoes.Quantidade [AtributoGenerico3]
                                                                from Arrecadacoes 
                                                                JOIN Areas on Areas.ID = Arrecadacoes.AreaDeArrecadacao
                                                                JOIN Produtos on Arrecadacoes.Arrecadado = Produtos.ID");

        foreach (var arrecadacoes in arrecadacao)
        {
            Console.WriteLine($@"-----Identificador (ID): {arrecadacoes.Id} / Área de Arrecadação: {arrecadacoes.AtributoGenerico1} /  Produto: {arrecadacoes.AtributoGenerico2} Quantidade: {arrecadacoes.AtributoGenerico3}");
        }
    }
}

static void Retorno(int linhasAfetadas, string foiFeitoOque)
{
            
    Console.WriteLine($"{linhasAfetadas} linha(s) {foiFeitoOque}(s)");

}
