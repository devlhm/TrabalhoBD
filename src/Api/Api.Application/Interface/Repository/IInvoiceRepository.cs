using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IInvoiceRepository
{
    Task<List<Fatura>> GetInvoicesByStatus(string cpf, EInvoiceStatus status);
    Task UpdateStatus(int idFatura, EInvoiceStatus status);
    Task<int> Create(Fatura fatura);
    Task<List<InvoiceProductEntry>> GetInvoiceProducts(int id);
    Task<List<Procedimento>> GetInvoiceProcedures(int id);

    Task<List<Fatura>> GetAllFromClient(string cpf);
    Task AddProductEntry(FaturaProduto entry);
}