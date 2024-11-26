

using Api.Application.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BillingController(IBillingService billingService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLastYearBilling()
    {
        try {
            var billing = await billingService.GetLastYearBilling();
            return Ok(billing);
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}
