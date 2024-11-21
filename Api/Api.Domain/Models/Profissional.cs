using Api.Domain.Enums;

namespace Api.Domain.Models;

public class Profissional
{
    public required string Cpf { get; set; }
    public required string Rg { get; set; }
    public required string Nome { get; set; }
    public required EProfessionalType Tipo { get; set; }
    public string? Crm { get; set; }
    public string? Cnec { get; set; }
    
    // TODO: ver como vou tratar o salário
}