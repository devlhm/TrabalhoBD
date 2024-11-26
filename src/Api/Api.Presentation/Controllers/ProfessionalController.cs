using Api.Application.Interface.Service;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await professionalService.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{cpf}")]
    public async Task<IActionResult> DeleteByCpf([FromRoute] string cpf)
    {
        try
        {
            await professionalService.DeleteByCpf(cpf);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Profissional professional)
    {
        try
        {
            await professionalService.Update(professional);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}