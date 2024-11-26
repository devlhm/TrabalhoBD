namespace Api.Application;

using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task Create(Cliente client)
    {
        await clientRepository.Create(client);
    }

    public async Task DeleteByCpf(string cpf)
    {
        await clientRepository.DeleteByCpf(cpf);
    }

    public async Task<List<Cliente>> GetAll()
    {
        return await clientRepository.GetAll();
    }

    public async Task<Cliente?> GetByCpf(string cpf)
    {
        return await clientRepository.GetByCpf(cpf);
    }

    public async Task Update(Cliente client)
    {
        await clientRepository.Update(client);
    }
}