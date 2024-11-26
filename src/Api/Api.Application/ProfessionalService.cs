using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application;

public class ProfessionalService(IProfessionalRepository professionalRepository) : IProfessionalService
{
    public async Task Create(Profissional professional)
    {
        await professionalRepository.Create(professional);
    }

    public async Task<Profissional?> GetByCpf(string cpf)
    {
        var professional = await professionalRepository.GetByCpf(cpf);
        if (professional != null) professional.Registro = professional.Tipo switch
        {
            EProfessionalType.Dermatologista => professional.Crm,
            EProfessionalType.Esteticista => professional.Cnec,
            _ => ""
        };
        return professional;
    }

    public async Task DeleteByCpf(string cpf)
    {
        await professionalRepository.DeleteByCpf(cpf);
    }

    public async Task<List<Profissional>> GetAll()
    {
        var professionals = await professionalRepository.GetAll();

        return professionals.Select(professional =>
        {
            professional.Registro = professional.Tipo switch
            {
                EProfessionalType.Dermatologista => professional.Crm,
                EProfessionalType.Esteticista => professional.Cnec,
                _ => ""
            };
            return professional;
        }).ToList();
    }

    public async Task Update(Profissional professional)
    {
        await professionalRepository.Update(professional);
    }
}