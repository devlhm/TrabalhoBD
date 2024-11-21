using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IProcedureService
{
    public Task<bool> Schedule(Procedure procedure);
    public Task<List<Procedure>> GetAllFromMonth(int year, int month);
}