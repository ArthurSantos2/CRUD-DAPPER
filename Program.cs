using System.Data;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";

//acessando os dados. Ainda fazer o CRUD
//cadastrar áreas(deve existir familias e poder de familia e feudo cadastrados -> 
//se fosse com view poderia redirecionar para criá-las)/familias/feudos/arrecadacoes(deve ter estação,areas e produto cadastrado) /
//produtos/membros da familia (deve ter familia cadastrada)
//alterar dados de areas (deve listar as opcoes de Poder da familia na area e familias e feudos)/
//alterar arrecadacoes(deve listar produtos, estações e areas)
//estações não se alteram. alterar membros/produtos/feudos
//os métodos de exlusão só podem ser feito em: membros 



//maneira de raciocinio diferente para criar com ADO.NET
// using (var conexaoBD = new SqlConnection(connectionString))
// {
//     conexaoBD.Open();
//     using(var comando = new SqlCommand())
//     {
//         comando.Connection = conexaoBD;
//         comando.CommandType = System.Data.CommandType.Text;
//         comando.CommandText = "Select [ID], [NomeDaArea] FROM [Areas]";

//         var reader = comando.ExecuteReader();
//         while (reader.Read())
//         {
//             Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}");
//         }
//     }
// }





Menu();

static void Menu()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, excluir ou modificar um produto, digite: PRODUTO");
    Console.WriteLine("Para cadastrar, excluir ou modificar um feudo, digite: FEUDO");
    

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



static void CriarProduto()
{
    var produto = new Produto();

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    produto.NomeDoProduto = Console.ReadLine();

    SalvarProduto(produto);
  
}



static void CriarFeudo()
{
    var feudo = new MeuFeudo();

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    feudo.Nome = Console.ReadLine();

    SalvarFeudo(feudo);
    
}

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
        string modificar = @"UPDATE Produtos SET Produto = @produto WHERE ID = @id";
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

//método com padrão diferente do de produto, melhorado.
static void ModificarFeudo(int id, MeuFeudo nome)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @"SELECT COUNT(*) FROM MeusFeudos WHERE ID = @id";
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
            return;
        }
        
        string modificar = @"UPDATE MeusFeudos SET Nome = @nome WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@Nome", nome.Nome);
        comandoModificar.Parameters.AddWithValue("@ID", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
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



static void Deletar(int id)
{
    //codigo exemplo, produto nao poder ser excluido por ter relações
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();
    string excluir = @"DELETE FROM Produtos WHERE ID = @id";
    SqlCommand comando = new SqlCommand(excluir, conexaoBD);

    int linhaExcluida = comando.ExecuteNonQuery();
    }
}



static void SalvarProduto(Produto produto)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO Produtos(Produto) VALUES(@produto)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Produto", produto.NomeDoProduto));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarFeudo(MeuFeudo nome)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO MeusFeudos(Nome) VALUES(@nome)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Nome", nome.Nome));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void RetornarFeudos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
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



static void RetornarProdutos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        //cria-se o comando sql
        string pesquisar = @"SELECT * FROM Produtos";
        SqlCommand comando = new SqlCommand(pesquisar, conexaoBD);
        
        //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        
        
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
        Console.WriteLine($"Produto: {row["Produto"]} //// Identificador (ID): {row ["ID"]}");
        
        }

    
    }
}



static void Retorno(int linhasAfetadas, string foiFeitoOque)
{
            
    Console.WriteLine($"{linhasAfetadas} linha(s) {foiFeitoOque}(s)");

}
