using Api.Application.Interface.Service;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedureController(IProcedureService procedureService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Schedule([FromBody] Procedimento request)
    {
        try
        {
            await procedureService.Schedule(request);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFromMonth([FromQuery] int year, [FromQuery] int month)
    {
        try
        {
            return Ok(await procedureService.GetAllFromMonth(year, month));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> CancelAppointment(int id)
    {
        try
        {
            await procedureService.CancelAppointment(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}