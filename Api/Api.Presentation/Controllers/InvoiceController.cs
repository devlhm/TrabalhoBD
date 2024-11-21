using Api.Application.Interface.Service;
using Api.Application.Requests;
using Api.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController(IInvoiceService invoiceService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string cpf)
    {
        try
        {
            var invoice = await invoiceService.Create(cpf);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("getAllByStatus")]
    public async Task<IActionResult> GetClientInvoicesByStatus([FromBody] GetClientInvoicesByStatusRequest request)
    {
        try
        {
            var invoices = await invoiceService.GetClientInvoicesByStatus(request.Cpf, request.Status);
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("updateStatus")]
    public async Task<IActionResult> UpdateStatus(UpdateInvoiceStatusRequest request)
    {
        try
        {
            await invoiceService.UpdateStatus(request.Cpf, request.Status);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    // TODO: comunicar pagamento? cancelar?
}