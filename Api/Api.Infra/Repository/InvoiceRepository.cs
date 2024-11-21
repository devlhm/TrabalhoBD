using System.Data;
using Api.Application.Interface.Repository;
using Api.Domain.Enums;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Api.Infra.Repository;

public class InvoiceRepository(IConfiguration configuration) : BaseRepository(configuration), IInvoiceRepository
{
    public async Task<List<Fatura>> GetInvoicesByStatus(string cpf, EInvoiceStatus status)
    {
        try
        {
            await using var connection = GetConnection();

            return (await connection.QueryAsync<Fatura>(@"SELECT * FROM fatura WHERE cpf_cliente = @cpf AND status = @status",
                new { cpf, status = (int) status })).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task UpdateStatus(string cpf, EInvoiceStatus status)
    {
        try
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync("UPDATE fatura SET status = @Status WHERE cpf_cliente = @cpf",
                new { cpf, status = (int) status });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<int> Create(Fatura fatura)
    {
        try
        {
            await using var connection = GetConnection();

            return await connection.ExecuteScalarAsync<int>(
                """
                INSERT INTO fatura(data_emissao, data_vencimento, cpf_cliente, status)
                    VALUES(@DataEmissao, @DataVencimento, @CpfCliente, @Status)
                    RETURNING id;
                """
                , fatura);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}