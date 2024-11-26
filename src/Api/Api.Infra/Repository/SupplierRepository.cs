namespace Api.Infra.Repository;

using System.Collections.Generic;
using Api.Application.Interface.Repository;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

public class SupplierRepository(IConfiguration configuration) : BaseRepository(configuration), ISupplierRepository
{

    public async Task Create(Fornecedor fornecedor)
    {
        try
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "INSERT INTO fornecedor (nome) VALUES (@Nome)",
                fornecedor
            );

        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM fornecedor WHERE id = @Id", new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Fornecedor>> GetAll()
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Fornecedor>("SELECT * FROM fornecedor")).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<Fornecedor?> GetById(int id)
    {
        try
        {
            await using var connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Fornecedor>("SELECT * FROM fornecedor WHERE id = @Id", new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task Update(Fornecedor fornecedor)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync(
                "UPDATE fornecedor SET nome = @Nome WHERE id = @Id",
                fornecedor
            );
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}