using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController(IClientService clientService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] Cliente client)
    {
        try
        {
            await clientService.Create(client);
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
            var clients = await clientService.GetAll();
            return Ok(clients);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}