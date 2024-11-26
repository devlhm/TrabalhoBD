using Api.Domain.Enums;

namespace Api.Domain.Models;

public class InvoiceProductEntry
{
    public required Produto Product {get;set;}
    public int Quantity {get;set;}
    public decimal? Total {get;set;}
};