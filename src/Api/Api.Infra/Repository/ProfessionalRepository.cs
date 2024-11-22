using Api.Application.Interface.Repository;
using Api.Domain.Enums;
using Api.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Infra.Repository;

public class ProfessionalRepository(IConfiguration configuration) : BaseRepository(configuration), IProfessionalRepository
{
    public Task Create(Profissional professional)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByCpf(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Profissional>> GetAllByType(EProfessionalType type)
    {
        throw new NotImplementedException();
    }
}