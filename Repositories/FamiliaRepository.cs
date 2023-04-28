public class FamiliaRepository : RepositoryBase<Familia>
{
    
    public override Task Criar(Familia entity)
    {
        Console.WriteLine($"aqui:{entity.NomeDaFamilia}");
        return base.Criar(entity);
    }
    public override Task Atualizar(Familia entity)
    {
        return base.Atualizar(entity);
    }
    
}