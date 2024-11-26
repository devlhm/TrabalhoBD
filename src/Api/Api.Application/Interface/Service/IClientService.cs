using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IClientService
{
    Task Create(Cliente client);
    Task<List<Cliente>> GetAll();
    Task<Cliente?> GetByCpf(string cpf);
    Task Update(Cliente client);
    Task DeleteByCpf(string cpf);
    
}