using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";

//acessando os dados. Ainda fazer o CRUD

using (var conexaoBD = new SqlConnection(connectionString))
{
    conexaoBD.Open();
    using(var comando = new SqlCommand())
    {
        comando.Connection = conexaoBD;
        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = "Select [ID], [NomeDaArea] FROM [Areas]";

        var reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}");
        }
    }
}

