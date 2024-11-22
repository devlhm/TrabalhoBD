using Api.Application.Interface.Service;
using Api.Application.Requests;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessionalController(IProfessionalService professionalService): ControllerBase
{
    public async Task<IActionResult> Create([FromBody] Profissional professional)
    {
        try
        {
            await professionalService.Create(professional);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    public async Task<IActionResult> DeleteByCpf([FromBody] DeleteByCpfRequest request)
    {
        try
        {
            await professionalService.DeleteByCpf(request.Cpf);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}