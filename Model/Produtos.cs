using Dapper.Contrib.Extensions;

[Table("[Produtos]")]
public class Produtos : BaseClass
{
    // public int Id{get;set;}
    
    public string Produto{get;set;}
}