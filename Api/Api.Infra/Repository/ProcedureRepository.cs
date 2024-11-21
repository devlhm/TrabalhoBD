using Api.Application.Interface.Repository;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Api.Infra.Repository;

public class ProcedureRepository(IConfiguration configuration) : IProcedureRepository
{
    private readonly string _connectionString =
        configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException();

    public async Task<bool> Create(Procedure procedure)
    {
        try
        {
            await using NpgsqlConnection connection = new(_connectionString);
            await connection.ExecuteAsync(
                "INSERT INTO procedimento (id, name, date, patient_id) VALUES (@Id, @Name, @Date, @PatientId)",
                procedure);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<List<Procedure>> GetAllFromMonth(int year, int month)
    {
        try
        {
            await using NpgsqlConnection connection = new(_connectionString);
            return (await connection.QueryAsync<Procedure>(
                $"SELECT * FROM procedimento WHERE EXTRACT(YEAR from data) = @Year AND EXTRACT(MONTH from data) = @Month",
                new { Month = month, Year = year })).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}