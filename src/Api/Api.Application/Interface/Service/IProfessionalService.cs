using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IProfessionalService
{
    Task Create(Profissional professional);
    Task DeleteByCpf(string cpf);
    Task<List<Profissional>> GetAll();
    Task<Profissional?> GetByCpf(string cpf);
    Task Update(Profissional professional);
}