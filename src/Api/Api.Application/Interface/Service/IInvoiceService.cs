using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IInvoiceService
{
    Task<List<Fatura>> GetClientInvoicesByStatus(string cpf, EInvoiceStatus status);
    Task<Fatura> Create(string cpf);
    Task UpdateStatus(string cpf, EInvoiceStatus status);
}