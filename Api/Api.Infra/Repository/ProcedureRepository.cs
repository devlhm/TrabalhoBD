using Api.Application.Interface.Repository;
using Api.Domain.Enums;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Api.Infra.Repository;

public class ProcedureRepository(IConfiguration configuration) : BaseRepository(configuration), IProcedureRepository
{
    public async Task Create(Procedimento procedimento)
    {
        try
        {
            await using var connection = GetConnection();
            
            await connection.ExecuteAsync(
                @"INSERT INTO procedimento (nome, valor, data, hora, cpf_profissional, id_fatura, cpf_cliente)
                    VALUES (@Nome, @Valor, @Data, @Hora, @CpfProfissional, @IdFatura, @CpfCliente)",
                procedimento);
        }
        catch (Exception ex)
        {
            throw new Exception($"$Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Procedimento>> GetAllFromMonth(int year, int month)
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Procedimento>(
                @"SELECT * FROM procedimento WHERE EXTRACT(YEAR from data) = @Year AND EXTRACT(MONTH from data) = @Month",
                new { Month = month, Year = year })).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task DeleteById(int id)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM procedimento WHERE id = @Id",
                new {Id = id});
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}