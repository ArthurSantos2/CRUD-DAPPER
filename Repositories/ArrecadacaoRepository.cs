using Dapper.Contrib.Extensions;

public class ArrecadacaoRepository : RepositoryBase<Arrecadacao>
{
    
    public override Task Criar(Arrecadacao entity)
    {
        Console.WriteLine($"aqui:{entity.Quantidade}");
        return base.Criar(entity);
    }
    public override Task Atualizar(Arrecadacao entity)
    {
        return base.Atualizar(entity);
    }

    public virtual async Task<bool> Deletar(int id)
    {
      var delete = _connection.Get<Arrecadacao>(id);
      try
      {
        await base.Deletar(delete,id);
        return true;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine($"Digitou errado, veja: {e.Message}");
        return false;
      }
    }
    
}