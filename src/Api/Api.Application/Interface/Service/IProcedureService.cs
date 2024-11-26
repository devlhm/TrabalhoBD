using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IProcedureService
{
    Task Schedule(Procedimento procedimento);
    Task<List<Procedimento>> GetAll();
    Task CancelAppointment(int id);
    Task UpdateAppointment(Procedimento procedimento);
    Task<List<MonthBilling>> GetLastYearBilling();
}