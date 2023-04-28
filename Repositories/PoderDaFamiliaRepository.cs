public class PoderDaFamiliaRepository : RepositoryBase<PoderDaFamilia>
{
    
    public override Task Criar(PoderDaFamilia entity)
    {
        Console.WriteLine($"aqui:{entity.NivelDePoder}");
        return base.Criar(entity);
    }
    public override Task Atualizar(PoderDaFamilia entity)
    {
        return base.Atualizar(entity);
    }
    
}