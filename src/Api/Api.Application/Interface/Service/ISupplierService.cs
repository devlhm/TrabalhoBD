using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;

namespace Api.Application.Interface.Service
{
    public interface ISupplierService
    {
        Task<Fornecedor?> GetById(int id);
        Task<List<Fornecedor>> GetAll();
        Task Create(Fornecedor supplier);
        Task Update(Fornecedor supplier);
        Task Delete(int id);
    }
}