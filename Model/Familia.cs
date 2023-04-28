using Dapper.Contrib.Extensions;

[Table("[Familias]")]
public class Familia : BaseClass
{
    // public int Id{get;set;}
    public string NomeDaFamilia{get;set;}
}