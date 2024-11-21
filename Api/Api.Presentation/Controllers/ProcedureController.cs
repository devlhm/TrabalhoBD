using Api.Application.Interface.Service;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedureController(IProcedureService procedureService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Schedule([FromBody] Procedure procedure)
    {
        if (await procedureService.Schedule(procedure))
            return Ok();
        
        return BadRequest();
    }

    [HttpGet]
    [Route("getAllFromMonth")]
    public async Task<IActionResult> GetAllFromMonth([FromQuery] int year, [FromQuery] int month)
    {
        return Ok(await procedureService.GetAllFromMonth(year, month));
    }
}