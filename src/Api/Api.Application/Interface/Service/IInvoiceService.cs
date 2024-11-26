using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IInvoiceService
{
    Task<List<Fatura>> GetClientInvoicesByStatus(string cpf, EInvoiceStatus status);
    Task<Fatura> Create(string cpf);
    Task UpdateStatus(int idFatura, EInvoiceStatus status);
    Task<InvoiceEntries> GetInvoiceEntries(int id);
    Task<List<Fatura>> GetAllFromClient(string cpf);
    Task AddProductEntry(FaturaProduto entry);
}