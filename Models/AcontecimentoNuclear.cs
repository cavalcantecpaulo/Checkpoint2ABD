using System.ComponentModel.DataAnnotations;
using RegistraNuclearTech.Enums;

namespace RegistraNuclearTech.Models;

public class AcontecimentoNuclear
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [Range(1890, 2030, ErrorMessage = "Informe um ano válido entre 1890 e 2030.")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "Selecione um setor válido.")]
    public SetorAplicado Setor { get; set; }

    [Required(ErrorMessage = "O país é obrigatório.")]
    public string Pais { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    public bool ImpactoPositivo { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.Now;
}
