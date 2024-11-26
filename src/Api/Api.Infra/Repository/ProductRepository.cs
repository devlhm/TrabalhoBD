namespace Api.Infra.Repository;

using Api.Application.Interface.Repository;
using Api.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

public class ProductRepository(IConfiguration configuration) : BaseRepository(configuration), IProductRepository
{
    public async Task Create(Produto product)
    {
        try
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "INSERT INTO produto (nome, marca, funcionalidade, tipo, valor_unitario, id_fornecedor, quantidade) VALUES (@Nome, @Marca, @Funcionalidade, @Tipo, @ValorUnitario, @IdFornecedor, @Quantidade)",
                new { product.Nome, product.Marca, product.Funcionalidade, product.Tipo, product.ValorUnitario, product.IdFornecedor, product.Quantidade }
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
            await connection.ExecuteAsync("DELETE FROM produto WHERE id = @Id", new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<List<Produto>> GetAll()
    {
        try
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Produto>("SELECT * FROM produto")).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task<Produto?> GetById(int id)
    {
        try
        {
            await using var connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Produto>("SELECT * FROM produto WHERE id = @Id", new { Id = id });
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
            return (await connection.QueryAsync<MonthBilling>(@"SELECT date_trunc('month', data_emissao) as month, sum(fp.quantidade * p.valor_unitario) as total
                    FROM fatura f
                    join fatura_produto fp on f.id = fp.id_fatura 
                    join produto p on fp.id_produto = p.id
	                GROUP BY date_trunc('month', data_emissao)
	                having date_trunc('month', data_emissao) >= now() - interval '1 year' order by date_trunc('month', data_emissao) asc")).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }

    public async Task Update(Produto product)
    {
        try
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync(
                "UPDATE produto SET nome = @Nome, marca = @Marca, funcionalidade = @Funcionalidade, tipo = @Tipo, valor_unitario = @ValorUnitario, id_fornecedor = @IdFornecedor, quantidade = @Quantidade WHERE id = @Id",
                new { product.Id, product.Nome, product.Marca, product.Funcionalidade, product.Tipo, product.ValorUnitario, product.IdFornecedor, product.Quantidade }
            );
        }
        catch (Exception ex)
        {
            throw new Exception($"Error accessing database: {ex.Message}");
        }
    }
}