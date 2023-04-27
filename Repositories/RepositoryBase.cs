

using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class RepositoryBase<T> where T : BaseClass
{
   private SqlConnection _connection = new SqlConnection("Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True");
   public async Task Criar(T entity)
   {
       try
      {
         Console.WriteLine("Inseriu");
         await _connection.InsertAsync<T>(entity);
      }
      catch (ArgumentException e)
      {
         Console.WriteLine($"Digitou errado, veja: {e.Message}");
      }
   }
   public async Task Atualizar(T entity)
   {
      try
      {
         Console.WriteLine("Atualizou");
         await _connection.UpdateAsync<T>(entity);
      }
      catch (ArgumentException e)
      {
        Console.WriteLine($"Digitou errado, veja: {e.Message}");
      }
   }
   //testar se funciona
   public virtual async Task<bool> Deletar(T entity, int id)
   {
      var delete = _connection.Get<T>(id);
      try
      {
         await _connection.DeleteAsync<T>(delete);
         Console.WriteLine("Excluiu");
         return true;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine($"Digitou errado, veja: {e.Message}");
        return false;
      }
   }
   public IEnumerable<T> TrazerTodos()
    {
      return _connection.GetAll<T>();
    }

}