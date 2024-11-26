using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IProfessionalRepository
{
    Task Create(Profissional professional);
    Task DeleteByCpf(string cpf);
    Task<Profissional?> GetByCpf(string cpf);
    Task<List<Profissional>> GetAll();
    Task Update(Profissional professional);
}