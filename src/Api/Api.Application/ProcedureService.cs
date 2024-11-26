using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application;

public class ProcedureService(IProcedureRepository procedureRepository, IProfessionalService professionalService, IInvoiceService invoiceService, IClientService clientService) : IProcedureService
{
    public async Task Schedule(Procedimento procedimento)
    {

        _ = await clientService.GetByCpf(procedimento.CpfCliente) ?? throw new KeyNotFoundException("Cliente não encontrado.");

        var invoice = (await invoiceService.GetClientInvoicesByStatus(procedimento.CpfCliente, EInvoiceStatus.Open)).FirstOrDefault() ??
            throw new KeyNotFoundException("Não foi encontrada uma fatura aberta para o cliente.");
            
        _ = await professionalService.GetByCpf(procedimento.CpfProfissional) ?? throw new KeyNotFoundException("Profissional não encontrado.");

        procedimento.IdFatura = invoice.Id;

        await procedureRepository.Create(procedimento);
    }
    
    public async Task<List<Procedimento>> GetAll()
    {
        return await procedureRepository.GetAll();
    }

    public async Task CancelAppointment(int id)
    {
        await procedureRepository.DeleteById(id);
    }

    public async Task UpdateAppointment(Procedimento procedimento)
    {
        _ = await professionalService.GetByCpf(procedimento.CpfProfissional) ?? throw new KeyNotFoundException("Profissional não encontrado.");

        await procedureRepository.Update(procedimento);
    }

    public async Task<List<MonthBilling>> GetLastYearBilling()
    {
        return await procedureRepository.GetLastYearBilling();
    }
}