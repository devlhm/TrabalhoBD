namespace Api.Domain.Models;

public class Produto
{
    public int? Id { get; set; }
    public required string Marca { get; set; }
    public required string Nome { get; set; }
    public required string Funcionalidade { get; set; }
    public required string Tipo { get; set; }
    public required int Quantidade { get; set; }
    public required decimal ValorUnitario { get; set; }
    public required int IdFornecedor { get; set; }
};