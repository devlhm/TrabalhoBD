using Api.Domain.Models;

namespace Api.Application.Interface.Repository
{
    public interface IProductRepository
    {
        Task Create(Produto product);
        Task<List<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task Update(Produto product);
        Task Delete(int id);
        Task<List<MonthBilling>> GetLastYearBilling();
    }
}