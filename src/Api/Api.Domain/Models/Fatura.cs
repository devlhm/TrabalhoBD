using Api.Domain.Enums;

namespace Api.Domain.Models;

public class Fatura
{
    public int? Id { get; set; }
    public required DateTime DataEmissao { get; set; }
    public required DateTime DataVencimento { get; set; }
    public required string CpfCliente { get; set; }
    public DateTime? DataPagamento { get; set; }
    public string? FormaPagamento { get; set; }
    public required EInvoiceStatus Status { get; set; }
    public decimal Total { get; set; }
    public InvoiceEntries? Entries {get;set;}
};