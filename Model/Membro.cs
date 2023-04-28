
using Dapper.Contrib.Extensions;

[Table("[Membros]")]
public class Membro : BaseClass
{
    // public int Id{get;set;}
    public string Nome{get;set;}
    public int Familia{get;set;}
}