using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;

namespace Api.Application;

public class ProcedureService(IProcedureRepository procedureRepository) : IProcedureService
{
    public async Task<bool> Schedule(Procedure procedure)
    {
        return await procedureRepository.Create(procedure);    
    }
    
    public async Task<List<Procedure>> GetAllFromMonth(int year, int month)
    {
        return await procedureRepository.GetAllFromMonth(year, month);
    }
}