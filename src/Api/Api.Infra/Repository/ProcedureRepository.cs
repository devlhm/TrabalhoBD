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

    public async Task<List<Procedimento>> GetAll()
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Procedimento>(@"SELECT * FROM procedimento")).ToList();
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

    public async Task Update(Procedimento procedimento)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync(
                @"UPDATE procedimento SET nome = @Nome, valor = @Valor, data = @Data, hora = @Hora, cpf_profissional = @CpfProfissional, id_fatura = @IdFatura WHERE id = @Id",
                new {Id = procedimento.Id, Nome = procedimento.Nome, Valor = procedimento.Valor, Data = procedimento.Data, Hora = procedimento.Hora, CpfProfissional = procedimento.CpfProfissional, procedimento.IdFatura});
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<MonthBilling>> GetLastYearBilling()
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<MonthBilling>(@"
                SELECT date_trunc('month', data_emissao) as month, sum(p.valor) as total
                    FROM fatura f
                    join procedimento p on f.id = p.id_fatura 
	                GROUP BY date_trunc('month', data_emissao)
	                having date_trunc('month', data_emissao) >= now() - interval '1 year' order by date_trunc('month', data_emissao) asc;
            ")).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}