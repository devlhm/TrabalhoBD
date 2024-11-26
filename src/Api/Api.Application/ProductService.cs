namespace Api.Application;

using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Enums;
using Api.Domain.Models;

public class ProductService(IProductRepository productRepository, ISupplierService supplierService, IInvoiceService invoiceService) : IProductService
{
    public async Task Create(Produto product)
    {
        _ = await supplierService.GetById(product.IdFornecedor) ?? throw new KeyNotFoundException("Fornecedor não encontrado.");

        await productRepository.Create(product);
    }

    public async Task Delete(int id)
    {
        await productRepository.Delete(id);
    }

    public async Task<List<Produto>> GetAll()
    {
        return await productRepository.GetAll();
    }

    public async Task<Produto?> GetById(int id)
    {
        return await productRepository.GetById(id);
    }

    public async Task Update(Produto product)
    {
        _ = await supplierService.GetById(product.IdFornecedor) ?? throw new KeyNotFoundException("Fornecedor não encontrado.");

        await productRepository.Update(product);
    }

    public async Task Sell(string cpf, int productId, int quantity)
    {
        var product = await productRepository.GetById(productId) ?? throw new KeyNotFoundException("Produto não encontrado.");

        if (product.Quantidade < quantity)
        {
            throw new InvalidOperationException("Quantidade insuficiente em estoque.");
        }

        var invoice = (await invoiceService.GetClientInvoicesByStatus(cpf, EInvoiceStatus.Open)).FirstOrDefault() ??
            throw new KeyNotFoundException("Não foi encontrada uma fatura aberta para o cliente.");

        FaturaProduto productEntry = new()
        {
            IdFatura = (int) invoice.Id!,
            IdProduto = productId,
            Quantidade = quantity
        };

        await invoiceService.AddProductEntry(productEntry);

        product.Quantidade -= quantity;

        await productRepository.Update(product);
    }

    public async Task<List<MonthBilling>> GetLastYearBilling()
    {
        return await productRepository.GetLastYearBilling();
    }
}