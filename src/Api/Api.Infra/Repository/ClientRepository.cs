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
    public async Task DeleteByCpf(string cpf)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM cliente WHERE cpf = @Cpf", new { Cpf = cpf });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while accessing database {ex.Message}");
        }
    }

    public async Task Update(Cliente client)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("UPDATE cliente SET rg = @Rg, nome = @Nome, data_nascimento = @DataNascimento WHERE cpf = @Cpf", client);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while accessing database {ex.Message}");
        }
    }

    public async Task<Cliente?> GetByCpf(string cpf)
    {
        try
        {
            await using var connection = GetConnection();
            return await connection.QuerySingleOrDefaultAsync<Cliente>("SELECT * FROM cliente WHERE cpf = @Cpf", new { Cpf = cpf });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while accessing database {ex.Message}");
        }
    }
}