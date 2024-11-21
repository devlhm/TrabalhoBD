using System.Dynamic;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IProcedureRepository
{
    Task Create(Procedimento procedimento);
    Task<List<Procedimento>> GetAllFromMonth(int month, int year);
    Task DeleteById(int id);
}