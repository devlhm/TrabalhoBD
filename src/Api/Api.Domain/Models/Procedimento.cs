using Api.Domain.Enums;

namespace Api.Domain.Models;

public class Procedimento
{
    public int? Id { get; set; }
    public int? IdFatura { get; set; }
    public required string Nome { get; set; }
    public required decimal Valor { get; set; }
    public required string CpfProfissional { get; set; }
    public required DateTime Data { get; set; }
    public required TimeSpan Hora { get; set; }
    public required string CpfCliente { get; set; }
};