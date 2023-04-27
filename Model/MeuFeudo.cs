using Dapper.Contrib.Extensions;

[Table("[MeusFeudos]")]
public class MeuFeudo : BaseClass
{
    // public int Id{get;set;}
    public string Nome{get;set;}
}