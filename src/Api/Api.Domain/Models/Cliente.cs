namespace Api.Domain.Models;

public class Cliente
{
    public required string Cpf { get; set; }
    public required string Rg { get; set; }
    public required string Nome { get; set; }
    public required DateTime DataNascimento { get; set; }
}