using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Enums;
using Api.Domain.Models;

namespace Api.Application;

public class ProcedureService(IProcedureRepository procedureRepository, IInvoiceService invoiceService) : IProcedureService
{
    public async Task Schedule(Procedimento procedimento)
    {

        var invoice = (await invoiceService.GetClientInvoicesByStatus(procedimento.CpfCliente, EInvoiceStatus.Open)).FirstOrDefault();

        if (invoice == null)
            throw new KeyNotFoundException("Não foi encontrada uma fatura aberta para o cliente.");;
            
        procedimento.IdFatura = invoice.Id;

        await procedureRepository.Create(procedimento);
    }
    
    public async Task<List<Procedimento>> GetAllFromMonth(int year, int month)
    {
        return await procedureRepository.GetAllFromMonth(year, month);
    }

    public async Task CancelAppointment(int id)
    {
        await procedureRepository.DeleteById(id);
    }
}