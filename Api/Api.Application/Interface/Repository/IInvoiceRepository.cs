using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IInvoiceRepository
{
    Task<List<Fatura>> GetInvoicesByStatus(string cpf, EInvoiceStatus status);
    Task UpdateStatus(string cpf, EInvoiceStatus status);
    Task<int> Create(Fatura fatura);
}