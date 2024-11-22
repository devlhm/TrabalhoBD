using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application.Interface.Repository;

public interface IProfessionalRepository
{
    Task Create(Profissional professional);
    Task DeleteByCpf(string cpf);
    Task<IEnumerable<Profissional>> GetAllByType(EProfessionalType type);
}