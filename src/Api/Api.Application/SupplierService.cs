using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;

namespace Api.Application
{
    public class SupplierService(ISupplierRepository supplierRepository) : ISupplierService
    {

        public async Task Create(Fornecedor supplier)
        {
            await supplierRepository.Create(supplier);
        }

        public async Task Delete(int id)
        {
            await supplierRepository.Delete(id);
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            return await supplierRepository.GetAll();
        }

        public async Task<Fornecedor?> GetById(int id)
        {
            return await supplierRepository.GetById(id);
        }

        public async Task Update(Fornecedor supplier)
        {
            await supplierRepository.Update(supplier);
        }
    }
}