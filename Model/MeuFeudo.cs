using Dapper.Contrib.Extensions;

[Table("[MeusFeudos]")]
public class MeuFeudo
{
    public int Id{get;set;}
    public string Nome{get;set;}
}