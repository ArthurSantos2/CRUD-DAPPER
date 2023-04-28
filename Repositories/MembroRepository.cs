using Dapper.Contrib.Extensions;

public class MembroRepository : RepositoryBase<Membro>
{
    
    public override Task Criar(Membro entity)
    {
        Console.WriteLine($"aqui:{entity.Nome}");
        return base.Criar(entity);
    }
    public override Task Atualizar(Membro entity)
    {
        return base.Atualizar(entity);
    }
    public virtual async Task<bool> Deletar(int id)
    {
      var delete = _connection.Get<Membro>(id);
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