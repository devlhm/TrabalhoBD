using Api.Domain.Models;

namespace Api.Application.Interface.Service
{
    public interface IProductService
    {
        Task<List<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task Create(Produto product);
        Task Update(Produto product);
        Task Delete(int id);
        Task Sell(string cpf, int productId, int quantity);
        Task<List<MonthBilling>> GetLastYearBilling();
    }
}