using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IBillingService
{
    Task<Billing> GetLastYearBilling();
}