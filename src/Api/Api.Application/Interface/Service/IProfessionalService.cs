using Api.Domain.Models;

namespace Api.Application.Interface.Service;

public interface IProfessionalService
{
    Task Create(Profissional professional);
    Task DeleteByCpf(string cpf);
}