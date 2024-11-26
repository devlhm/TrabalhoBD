

using Api.Application.Interface.Service;
using Api.Domain.Models;
using Api.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await productService.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await productService.GetById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Produto request)
    {
        try
        {
            await productService.Create(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Produto request)
    {
        try
        {
            await productService.Update(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await productService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("sell")]
    public async Task<IActionResult> Sell([FromBody] SellRequest request)
    {
        try
        {
            await productService.Sell(request.Cpf, request.ProductId, request.Quantity);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    
}