using Dapper.Contrib.Extensions;

public class AreaRepository : RepositoryBase<Area>
{
    public override Task Criar(Area entity)
    {
        return base.Criar(entity);
    }
    public override Task Atualizar(Area entity)
    {
        return base.Atualizar(entity);
    }

    //por hora área não vai ter um delete, pensar em como concluir as regras que
    //obrigam excluir as arrecadações vinculadas antes de deletar a
    
    //nao faz sentido
    // public virtual async Task<bool> Deletar(int idArea, int id)
    // {
    //   var deleteArrecadacoes = _connection.Get<Arrecadacao>(id);
    //   var deleteArea = _connection.Get<Area>(idArea);
    //   try
    //   {
    //     await _connection.DeleteAsync<Arrecadacao>(deleteArrecadacoes);
    //     await _connection.DeleteAsync<Area>(deleteArea);
    //     return true;
    //   }
    //   catch (ArgumentException e)
    //   {
    //     Console.WriteLine($"Digitou errado, veja: {e.Message}");
    //     return false;
    //   }
    // }
}