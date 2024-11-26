using Api.Domain.Enums;

namespace Api.Domain.Models;

public class FaturaProduto
{
    public int IdFatura { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
};