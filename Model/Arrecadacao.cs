using Dapper.Contrib.Extensions;

[Table("[Arrecadacoes]")]
public class Arrecadacao : BaseClass
{
    // public int Id{get;set;}
    public int EstacaoDoAno{get;set;}
    public int AreaDeArrecadacao{get;set;}
    public int Arrecadado{get;set;}
    public int Quantidade{get;set;}
}