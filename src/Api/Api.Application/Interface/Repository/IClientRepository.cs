using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IClientRepository
{
    Task Create(Cliente client);
    Task<List<Cliente>> GetAll();
}