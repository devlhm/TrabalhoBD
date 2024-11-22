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

    public async Task UpdateStatus(string cpf, EInvoiceStatus status)
    {
        await invoiceRepository.UpdateStatus(cpf, status);
    }
}