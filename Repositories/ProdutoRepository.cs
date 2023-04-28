public class ProdutoRepository : RepositoryBase<Produtos>
{
    
    public override Task Criar(Produtos entity)
    {
        Console.WriteLine($"aqui:{entity.Produto}");
        return base.Criar(entity);
    }
    public override Task Atualizar(Produtos entity)
    {
        return base.Atualizar(entity);
    }
    
}