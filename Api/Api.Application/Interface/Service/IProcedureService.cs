using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IProcedureService
{
    Task Schedule(Procedimento procedimento);
    Task<List<Procedimento>> GetAllFromMonth(int year, int month);
    Task CancelAppointment(int id);
}