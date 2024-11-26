using Api.Domain.Enums;

namespace Api.Domain.Models;

public class InvoiceEntries
{
    public required List<InvoiceProductEntry> Products {get;set;}
    public required List<Procedimento> Procedures {get;set;}
};