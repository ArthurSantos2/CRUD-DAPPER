using Dapper.Contrib.Extensions;

[Table("[Estacoes]")]
public class Estacoes : BaseClass
{
    //aqui poderia ser um enum? ver possibilidade na implementação para console. Se fosse uma lista em uma view era baun
    // public int Id{get;set;}
    public string Estacao{get;set;}
}