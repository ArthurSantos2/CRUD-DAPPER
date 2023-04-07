using System.Data;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";

//cadastrar áreas(deve existir familias e poder de familia e feudo cadastrados -> 
//se fosse com view poderia redirecionar para criá-las)/familias/feudos/arrecadacoes(deve ter estação,areas e produto cadastrado) /
//produtos/membros da familia (deve ter familia cadastrada)
//alterar dados de areas (deve listar as opcoes de Poder da familia na area e familias e feudos)/
//alterar arrecadacoes(deve listar produtos, estações e areas)
//estações não se alteram. alterar membros/produtos/feudos
//os métodos de exlusão puramente só podem ser feito em: membros
//não é possível excluir uma área sem excluir sua arrecadação




Menu();

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

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
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


//funcionando com dataset, fica de exemplo
static void ModificarProduto(int id, Produto produto)
{

    // if (produto == null)
    // {
    //     throw new ApplicationException
    // }

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();

    string pesquisar = @"SELECT * FROM Produtos";
    SqlCommand comandando = new SqlCommand(pesquisar, conexaoBD);
        
    DataSet dataSet = new DataSet();
    //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
    SqlDataAdapter adapter = new SqlDataAdapter(comandando);
    
    adapter.Fill(dataSet, "Produtos");

    // Verificar se um dado específico existe na tabela
    DataTable dataTable = dataSet.Tables["Produtos"];
    bool exists = dataTable.AsEnumerable().Any(row => row.Field<int>("Id") == id);
    if (exists)
    {
        string modificar = @$"UPDATE Produtos SET Produto = @produto WHERE ID = {id}";
        SqlCommand comando = new SqlCommand(modificar, conexaoBD);
        comando.Parameters.AddWithValue("@Produto", produto.NomeDoProduto);
        comando.Parameters.AddWithValue("@ID", id);

        int linhasModificadas = comando.ExecuteNonQuery();

        Retorno(linhasModificadas, " Modificado");
    }
    else
    {
    Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
    Console.WriteLine("Redirecionando para o menu atual...");
    Thread.Sleep(3000);
    Console.Clear();
    MenuProduto();
    }

    }
}
//refatorado e aplicado nos demais de update.
static void ModificarFeudo(int id, MeuFeudo nome)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM MeusFeudos WHERE ID = {id}";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@ID", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @"UPDATE MeusFeudos SET Nome = @Nome WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@Nome", nome.Nome);
        comandoModificar.Parameters.AddWithValue("@ID", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarFamilia(int id, Familia nomeFamilia)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Familias WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @"UPDATE Familias SET NomeDaFamilia = @nomeFamilia WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nomeFamilia", nomeFamilia.NomeDaFamilia);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarMembro(int id, Membro membro)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Membros WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuMembro();
        }

        string pesquisa = @$"SELECT COUNT(*) FROM Familias WHERE ID = @identificador";
        SqlCommand comandoPesquisar = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@identificador", membro.Familia);
        
        int qtdRegistro = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuMembro();
        }

        
        string modificar = @"UPDATE Membros SET Nome = @nome, Familia = @familia WHERE ID = @identificado";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nome", membro.Nome);
        comandoModificar.Parameters.AddWithValue("@familia", membro.Familia);
        comandoModificar.Parameters.AddWithValue("@identificado", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarPoderFamilia(int id, PoderDaFamilia nivel)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @"UPDATE PoderDaFamilia SET NivelDePoder = @nivel WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nivel", nivel.NivelDePoder);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarArrecadacao(int id, Arrecadacao arrecadacao)
{
    //seria interessante ter uma validação nos dados que tem relacionamento para não quebrar, porém desnecessário no momento
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Arrecadacoes WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        //não colocarei estação do ano
        string modificar = @"UPDATE Arrecadacoes SET AreaDeArrecadacao = @areadearrecadacao, Arrecadado = @arrecadado, Quantidade = @quantidade WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@areadearrecadacao", arrecadacao.AreaDeArrecadacao);
        comandoModificar.Parameters.AddWithValue("@arrecadado", arrecadacao.Arrecadado);
        comandoModificar.Parameters.AddWithValue("@quantidade", arrecadacao.Quantidade);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarArea(int id, Area area)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Areas WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);

         string pesquisarFamilia = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
        SqlCommand comandoPesquisaFamilia = new SqlCommand(pesquisarFamilia, conexaoBD);
        comandoPesquisaFamilia.Parameters.AddWithValue("@familia", area.FamiliaDaArea);
        
        string pesquisarPoder = @"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @poder";
        SqlCommand comandoPesquisaPoder = new SqlCommand(pesquisarPoder, conexaoBD);
        comandoPesquisaPoder.Parameters.AddWithValue("@poder", area.NivelDaFamilia);

        string pesquisarFeudo = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @feudo";
        SqlCommand comandoPesquisaFeudo = new SqlCommand(pesquisarFeudo, conexaoBD);
        comandoPesquisaFeudo.Parameters.AddWithValue("@Feudo", area.FeudoPertencente);

        int qtdRegistrosFamilia = (int)comandoPesquisaFamilia.ExecuteScalar();
        int qtdRegistrosPoder = (int)comandoPesquisaPoder.ExecuteScalar();
        int qtdRegistrosFeudo = (int)comandoPesquisaFeudo.ExecuteScalar();
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();

        if (qtdRegistros == 0 || qtdRegistrosFamilia == 0 || qtdRegistrosPoder == 0 || qtdRegistrosFeudo == 0)
        {
            Console.WriteLine("O ID passado não inexiste. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @$"UPDATE Areas SET FamiliaDaArea = @familiaDaArea, NivelDaFamilia = @nivelDaFamilia, NomeDaArea = @nomeDaArea, FeudoPertencente = @feudoPertencente WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@familiaDaArea", area.FamiliaDaArea);
        comandoModificar.Parameters.AddWithValue("@nivelDaFamilia", area.NivelDaFamilia);
        comandoModificar.Parameters.AddWithValue("@nomeDaArea", area.NomeDaArea);
        comandoModificar.Parameters.AddWithValue("@feudoPertencente", area.FeudoPertencente);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}



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



static void DeletarMembro(int id)
{
    
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();
    string excluir = @$"DELETE FROM Membros WHERE ID = {id}";
    SqlCommand comando = new SqlCommand(excluir, conexaoBD);

    int linhaExcluida = comando.ExecuteNonQuery();

    Retorno(linhaExcluida, "deletada");
    }
}

static void DeletarArrecadacao(int id)
{
    
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();
    string excluir = @$"DELETE FROM Arrecadacoes WHERE ID = {id}";
    SqlCommand comando = new SqlCommand(excluir, conexaoBD);

    int linhaExcluida = comando.ExecuteNonQuery();

    Retorno(linhaExcluida, "deletada");
    }
}

//DeletarArea área necessita que ao deletar leve antes as arrecadações vinculadas a área
static void DeletarArea(int id)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();

        string excluir = @$"DELETE Arrecadacoes
                            FROM Arrecadacoes
                            JOIN Areas ON Arrecadacoes.AreaDeArrecadacao = Areas.ID
                            WHERE Arrecadacoes.AreaDeArrecadacao = {id}
        
                            DELETE Areas FROM Areas WHERE Areas.ID = {id}";
        SqlCommand comando = new SqlCommand(excluir, conexaoBD);
        

        int linhaExcluida = comando.ExecuteNonQuery();

        Retorno(linhaExcluida, "Modificadas");
    }
}

//erro resolvido com interpolação
static void ExtinguirFamilia(int id)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();

        string excluir = @$"DELETE Areas
                            FROM Areas
                            JOIN Familias ON Areas.FamiliaDaArea = Familias.ID 
                            JOIN Membros ON Familias.ID = Membros.Familia 
                            WHERE Areas.FamiliaDaArea = {id};

                            DELETE Membros
                            FROM Membros
                            JOIN Familias ON Familias.ID = Membros.Familia 
                            WHERE Membros.Familia = {id};

                            DELETE Familias
                            FROM Familias
                            WHERE Familias.ID = {id};
                            ";
        SqlCommand comando = new SqlCommand(excluir, conexaoBD);
        

        int linhaExcluida = comando.ExecuteNonQuery();

        Retorno(linhaExcluida, "Modificadas");
        
        
    }
}



static void SalvarProduto(Produto produto)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO Produtos(Produto) VALUES(@Produto)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Produto", produto.NomeDoProduto));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarPoder(PoderDaFamilia poder)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //sempre que não interpola $ quebra ?????????
        string insercao = @$"INSERT INTO PoderDaFamilia(NivelDePoder) VALUES(@poder)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@poder", poder.NivelDePoder));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarFeudo(MeuFeudo nome)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO MeusFeudos(Nome) VALUES(@Nome)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Nome", nome.Nome));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarFamilia(Familia nome)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @$"INSERT INTO Familias(NomeDaFamilia) VALUES(@nome)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@nome", nome.NomeDaFamilia));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}

static void SalvarMembro(Membro membro)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        conexaoBD.Open();
        
        string pesquisar = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@familia", membro.Familia);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
    
        string insercao = @$"INSERT INTO Membros(Nome,Familia) VALUES(@nome,@familia)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@nome", membro.Nome));
        comando.Parameters.Add(new SqlParameter("@familia", membro.Familia));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}

static void SalvarArrecadacao(Arrecadacao arrecadacao)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        conexaoBD.Open();
        
        string pesquisarEstacao = @"SELECT COUNT(*) FROM Estacoes WHERE ID = @estacao";
        SqlCommand comandoPesquisaEstacao = new SqlCommand(pesquisarEstacao, conexaoBD);
        comandoPesquisaEstacao.Parameters.AddWithValue("@estacao", arrecadacao.EstacaoDoAno);
        
        string pesquisarAreaDeArrecadacao = @"SELECT COUNT(*) FROM Areas WHERE ID = @AreaDeArrecadacao";
        SqlCommand comandoPesquisaAreaDeArrecadacao = new SqlCommand(pesquisarAreaDeArrecadacao, conexaoBD);
        comandoPesquisaAreaDeArrecadacao.Parameters.AddWithValue("@AreaDeArrecadacao", arrecadacao.AreaDeArrecadacao);

        string pesquisarArrecadado = @"SELECT COUNT(*) FROM Produtos WHERE ID = @Arrecadado";
        SqlCommand comandoPesquisaArrecadado = new SqlCommand(pesquisarArrecadado, conexaoBD);
        comandoPesquisaArrecadado.Parameters.AddWithValue("@Arrecadado", arrecadacao.Arrecadado);


        int qtdRegistrosEstacao = (int)comandoPesquisaEstacao.ExecuteScalar();
        int qtdRegistrosAreaDeArrecadacao = (int)comandoPesquisaAreaDeArrecadacao.ExecuteScalar();
        int qtdRegistrosArrecadado = (int)comandoPesquisaArrecadado.ExecuteScalar();

        if (qtdRegistrosEstacao == 0 || qtdRegistrosAreaDeArrecadacao == 0 || qtdRegistrosArrecadado == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
    
        string insercao = @$"INSERT INTO Arrecadacoes(EstacaoDoAno, AreaDeArrecadacao, Arrecadado, Quantidade) VALUES(@estacao,@areadearrecadacao,@arrecadado,@quantidade)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.AddWithValue("@estacao", arrecadacao.EstacaoDoAno);
        comando.Parameters.AddWithValue("@areadearrecadacao", arrecadacao.AreaDeArrecadacao);
        comando.Parameters.AddWithValue("@arrecadado", arrecadacao.Arrecadado);
        comando.Parameters.AddWithValue("@quantidade", arrecadacao.Quantidade);
    
        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}

static void SalvarArea(Area area)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        conexaoBD.Open();
        
        string pesquisarFamilia = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
        SqlCommand comandoPesquisaFamilia = new SqlCommand(pesquisarFamilia, conexaoBD);
        comandoPesquisaFamilia.Parameters.AddWithValue("@familia", area.FamiliaDaArea);
        
        string pesquisarPoder = @"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @poder";
        SqlCommand comandoPesquisaPoder = new SqlCommand(pesquisarPoder, conexaoBD);
        comandoPesquisaPoder.Parameters.AddWithValue("@poder", area.NivelDaFamilia);

        string pesquisarFeudo = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @feudo";
        SqlCommand comandoPesquisaFeudo = new SqlCommand(pesquisarFeudo, conexaoBD);
        comandoPesquisaFeudo.Parameters.AddWithValue("@Feudo", area.FeudoPertencente);


        int qtdRegistrosFamilia = (int)comandoPesquisaFamilia.ExecuteScalar();
        int qtdRegistrosPoder = (int)comandoPesquisaPoder.ExecuteScalar();
        int qtdRegistrosFeudo = (int)comandoPesquisaFeudo.ExecuteScalar();

        if (qtdRegistrosFamilia == 0 || qtdRegistrosPoder == 0 || qtdRegistrosFeudo == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
    
        string insercao = @$"INSERT INTO Areas(FamiliaDaArea, NivelDaFamilia, NomeDaArea, FeudoPertencente) VALUES(@familiaDaArea,@nivelDaFamilia,@nomeDaArea,@feudoPertencente)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.AddWithValue("@familiaDaArea", area.FamiliaDaArea);
        comando.Parameters.AddWithValue("@nivelDaFamilia", area.NivelDaFamilia);
        comando.Parameters.AddWithValue("@nomeDaArea", area.NomeDaArea);
        comando.Parameters.AddWithValue("@feudoPertencente", area.FeudoPertencente);
    
        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}


//dataset, a sua utilização é ampla pela possibilidade de ser preenchido com diferentes 
//fontes, ex: um xml. O uso de DataSet's é interessante em determinados contexto, porém não o atual
//funcionando com dataset, fica de exemplo 
static void RetornarFeudos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string pesquisar = @"SELECT * FROM MeusFeudos";
        SqlCommand comando = new SqlCommand(pesquisar, conexaoBD);
        
        //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        
        
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
        Console.WriteLine($"Feudo: {row["Nome"]} //// Identificador (ID): {row ["ID"]}");
        
        }

    
    }
}

//funcionando com datatable, fica de exemplo
static void RetornarFamilias()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string consulta = @"SELECT NomeDaFamilia, ID FROM Familias";
        SqlCommand comando = new SqlCommand(consulta, conexaoBD);

        //puxa o conjunto de dados do banco de dados para um DataTable. O método .Fill preenche o datatable com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);

        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"Nome da Família: {row["NomeDaFamilia"]} //// Identificador (ID): {row["ID"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarProdutos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar = @"SELECT * FROM Produtos";
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Produto: {reader["Produto"]} //// Identificador (ID): {reader["ID"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarPoderFamilia()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar =  @"SELECT * FROM PoderDaFamilia";
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Nivel da Família: {reader["NivelDePoder"]} //// Identificador (ID): {reader ["ID"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarMembros()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar = @"SELECT * FROM Membros";;
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Nome do membro: {reader["Nome"]} //// Identificador (ID): {reader ["ID"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarAreasSeletivo()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar = @"SELECT ID, NomeDaArea FROM Areas";;
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        
        var reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Nome da área: {reader["NomeDaArea"]} //// Identificador (ID): {reader ["ID"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarAreas()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar = @"select Areas.ID, Familias.NomeDaFamilia,PoderDaFamilia.NivelDePoder, Areas.NomeDaArea, MeusFeudos.Nome
                        from Areas 
                        JOIN MeusFeudos on MeusFeudos.ID = Areas.FeudoPertencente
                        JOIN Familias on Familias.ID = Areas.FamiliaDaArea
                        JOIN PoderDaFamilia on PoderDaFamilia.ID = Areas.NivelDaFamilia";
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($@"-----Identificador (ID): {reader ["ID"]} / Familia da área: {reader["NomeDaFamilia"]} /  Poder da família: {reader["NivelDePoder"]} \n/
                                Nome da área: {reader["NomeDaArea"]} / Pertence ao feudo: {reader["Nome"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarEstacoes()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string listar = @"SELECT * FROM Estacoes";
        SqlCommand comando = new SqlCommand(listar, conexaoBD);
        var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Identificador (ID): {reader["ID"]} - Estação: {reader["Estacao"]}");
        }
    }
}

//refatorado, menor, mais simples e com economia de dados em memória
static void RetornarArrecadacao()
{
    
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();
    string listar = @"select Arrecadacoes.ID,Areas.NomeDaArea,Produtos.Produto, Arrecadacoes.Quantidade 
                    from Arrecadacoes 
                    JOIN Areas on Areas.ID = Arrecadacoes.AreaDeArrecadacao
                    JOIN Produtos on Arrecadacoes.Arrecadado = Produtos.ID";
    SqlCommand comando = new SqlCommand(listar, conexaoBD);

    var reader = comando.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Identificador (ID): {reader["ID"]} - Área de Arrecadação: {reader["NomeDaArea"]} - Produto: {reader["Produto"]} - Quantidade: {reader["Quantidade"]}");
    }
    
    }
    
}

static void Retorno(int linhasAfetadas, string foiFeitoOque)
{
            
    Console.WriteLine($"{linhasAfetadas} linha(s) {foiFeitoOque}(s)");

}
