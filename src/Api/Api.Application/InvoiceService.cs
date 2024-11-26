using System.Reflection;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application;

public class InvoiceService(IInvoiceRepository invoiceRepository): IInvoiceService
{
    private const int DaysToExpire = 10;

    public async Task<List<Fatura>> GetClientInvoicesByStatus(string cpf, EInvoiceStatus status)
    {
        return await invoiceRepository.GetInvoicesByStatus(cpf, status);
    }

    public async Task<Fatura> Create(string cpf)
    {
        Fatura fatura = new()
        {
            CpfCliente = cpf,
            DataEmissao = DateTime.Today,
            DataVencimento = DateTime.Today.AddDays(DaysToExpire),
            Status = EInvoiceStatus.Open
        };
        
        var id = await invoiceRepository.Create(fatura);
        fatura.Id = id;

        return fatura;
    }

    public async Task UpdateStatus(int idFatura, EInvoiceStatus status)
    {
        await invoiceRepository.UpdateStatus(idFatura, status);
    }

    public async Task<InvoiceEntries> GetInvoiceEntries(int id) {
        var productEntries = await invoiceRepository.GetInvoiceProducts(id);
        
        foreach(var entry in productEntries)
            entry.Total = entry.Product.ValorUnitario * entry.Quantity;

        var procedures = await invoiceRepository.GetInvoiceProcedures(id);

        return new InvoiceEntries
        {
            Products = productEntries,
            Procedures = procedures,
        };
    }

    public async Task<List<Fatura>> GetAllFromClient(string cpf)
    {
        var invoices = await invoiceRepository.GetAllFromClient(cpf);

        foreach(var invoice in invoices) {
            invoice.Entries = await GetInvoiceEntries((int) invoice.Id!);
            invoice.Total = invoice.Entries.Products.Sum(p => (decimal) p.Total!) + invoice.Entries.Procedures.Sum(p => p.Valor);
        }

        return invoices;
    }

    public async Task AddProductEntry(FaturaProduto entry)
    {
        await invoiceRepository.AddProductEntry(entry);
    }
}