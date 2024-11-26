using Api.Application.Interface.Repository;
using Api.Domain.Enums;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Infra.Repository;

public class ProfessionalRepository(IConfiguration configuration) : BaseRepository(configuration), IProfessionalRepository
{
    public async Task Create(Profissional professional)
    {
        try {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("INSERT INTO profissional (cpf, rg, nome, tipo, crm, cnec) VALUES (@Cpf, @Rg, @Nome, @Tipo, @Crm, @Cnec)", professional);
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task DeleteByCpf(string cpf)
    {
        try {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM profissional WHERE cpf = @Cpf", new { Cpf = cpf });
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Profissional>> GetAll()
    {
        try {
            using var connection = GetConnection();
            return (await connection.QueryAsync<Profissional>("SELECT * FROM profissional")).ToList();
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public Task<IEnumerable<Profissional>> GetAllByType(EProfessionalType type)
    {
        throw new NotImplementedException();
    }

    public async Task<Profissional?> GetByCpf(string cpf)
    {
        try {
            await using var connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Profissional>("SELECT * FROM profissional WHERE cpf = @Cpf", new { Cpf = cpf });
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task Update(Profissional professional)
    {
        try {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("UPDATE profissional SET rg = @Rg, nome = @Nome, tipo = @Tipo, crm = @Crm, cnec = @Cnec WHERE cpf = @Cpf", professional);
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}