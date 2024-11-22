using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;

namespace Api.Application;

public class ProfessionalService(IProfessionalRepository professionalRepository): IProfessionalService
{
    public async Task Create(Profissional professional)
    {
        await professionalRepository.Create(professional);
    }

    public async Task DeleteByCpf(string cpf)
    {
        await professionalRepository.DeleteByCpf(cpf);
    }
}