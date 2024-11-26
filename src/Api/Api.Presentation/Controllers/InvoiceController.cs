using Api.Application.Interface.Service;
using Api.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController(IInvoiceService invoiceService): ControllerBase
{
    [HttpPost]
    [Route("{cpf}")]
    public async Task<IActionResult> Create([FromRoute] string cpf)
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
            await invoiceService.UpdateStatus(request.InvoiceId, request.Status);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("{cpf}")]
    public async Task<IActionResult> GetAllFromClient([FromRoute] string cpf)
    {
        try
        {
            var invoices = await invoiceService.GetAllFromClient(cpf);
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}