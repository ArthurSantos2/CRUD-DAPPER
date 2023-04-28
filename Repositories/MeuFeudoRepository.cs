public class MeuFeudoRepository : RepositoryBase<MeuFeudo>
{
    
    public override Task Criar(MeuFeudo entity)
    {
        Console.WriteLine($"aqui:{entity.Nome}");
        return base.Criar(entity);
    }
    public override Task Atualizar(MeuFeudo entity)
    {
        return base.Atualizar(entity);
    }
    
}