using Microsoft.AspNetCore.Mvc;
using NmqPracticeApi.DTOs;
using NmqPracticeApi.Models;
using NmqPracticeApi.Services;

namespace NmqPracticeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        var products = _productService.GetAll();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);

        if (product is null)
        {
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });
        }

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(CreateProductDto dto)
    {
        var product = _productService.Create(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateProductDto dto)
    {
        var updated = _productService.Update(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _productService.Delete(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });
        }

        return NoContent();
    }
}