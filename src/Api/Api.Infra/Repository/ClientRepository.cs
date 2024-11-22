using Api.Application.Interface.Repository;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Infra.Repository;

public class ClientRepository(IConfiguration configuration): BaseRepository(configuration), IClientRepository
{
    public async Task Create(Cliente client)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("INSERT INTO cliente VALUES(@Cpf, @Rg, @Nome, @DataNascimento)", client);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while accessing database {ex.Message}");
        }
    }

    public async Task<List<Cliente>> GetAll()
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Cliente>("SELECT * FROM cliente")).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while accessing database {ex.Message}");
        }
    }
}