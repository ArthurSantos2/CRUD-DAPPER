using Dapper.Contrib.Extensions;

[Table("[Areas]")]
public class Area : BaseClass
{
    // public int Id{get;set;}
    public int FamiliaDaArea{get;set;}
    public int NivelDaFamilia{get;set;}
    public string NomeDaArea{get;set;}
    public int FeudoPertencente{get;set;}
}