using System.Dynamic;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IProcedureRepository
{
    Task<bool> Create(Procedure procedure);
    Task<List<Procedure>> GetAllFromMonth(int month, int year);
}