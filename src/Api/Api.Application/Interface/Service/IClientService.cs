using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IClientService
{
    Task Create(Cliente client);
    Task<List<Cliente>> GetAll();
    
}