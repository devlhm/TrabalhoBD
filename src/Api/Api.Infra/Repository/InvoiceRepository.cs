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

    public async Task UpdateStatus(int idFatura, EInvoiceStatus status)
    {
        try
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync("UPDATE fatura SET status = @Status WHERE id = @Id",
                new { Id = idFatura, status = (int) status });
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

    public async Task<List<InvoiceProductEntry>> GetInvoiceProducts(int id)
    {
        try {
            await using var connection = GetConnection();
            List<FaturaProduto> entries = (await connection.QueryAsync<FaturaProduto>(@"SELECT * FROM fatura_produto WHERE id_fatura = @Id", new { Id = id })).ToList();

            List<InvoiceProductEntry> products = new();

            foreach(var entry in entries) {
                var product = await connection.QueryFirstAsync<Produto>("SELECT * FROM produto WHERE id = @Id", new { Id = entry.IdProduto });
                products.Add(new InvoiceProductEntry
                {
                    Product = product!,
                    Quantity = entry.Quantidade
                });
            }

            return products;
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Procedimento>> GetInvoiceProcedures(int id)
    {
        try {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Procedimento>(@"SELECT * FROM procedimento WHERE id_fatura = @id", new { id })).ToList();
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Fatura>> GetAllFromClient(string cpf)
    {
        try {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Fatura>(@"SELECT * FROM fatura WHERE cpf_cliente = @cpf", new { cpf })).ToList();
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task AddProductEntry(FaturaProduto entry)
    {
        try {
            await using var connection = GetConnection();

            var faturaProduto = await connection.QueryFirstOrDefaultAsync<FaturaProduto>(@"SELECT * FROM fatura_produto WHERE id_fatura = @IdFatura AND id_produto = @IdProduto", entry);

            if(faturaProduto != null) {
                faturaProduto.Quantidade += entry.Quantidade;
                await connection.ExecuteAsync("UPDATE fatura_produto SET quantidade = @Quantidade WHERE id_fatura = @IdFatura AND id_produto = @IdProduto", faturaProduto);
                return;
            }

            await connection.ExecuteAsync("INSERT INTO fatura_produto(id_fatura, id_produto, quantidade) VALUES(@IdFatura, @IdProduto, @Quantidade)", entry);
        } catch(Exception ex) {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}