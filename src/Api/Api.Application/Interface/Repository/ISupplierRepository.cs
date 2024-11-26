using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository
{
    public interface ISupplierRepository
    {
        Task<Fornecedor?> GetById(int id);
        Task<List<Fornecedor>> GetAll();
        Task Create(Fornecedor fornecedor);
        Task Update(Fornecedor fornecedor);
        Task Delete(int id);
    }
}