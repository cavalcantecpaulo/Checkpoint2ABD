using RegistraNuclearTech.Enums;

namespace RegistraNuclearTech.Models;

public class AcontecimentoNuclear
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public SetorAplicado Setor {  get; set; }
    public string Pais { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool ImpactoPositivo { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.Now;
}
