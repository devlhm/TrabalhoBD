using System.Dynamic;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IProcedureRepository
{
    Task Create(Procedimento procedimento);
    Task<List<Procedimento>> GetAll();
    Task DeleteById(int id);

    Task Update(Procedimento procedimento);
    Task<List<MonthBilling>> GetLastYearBilling();
}