using BikeApi.Contracts;
using BikeApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BikeApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _prodRepository;
    public ProductsController(IProductRepository prodRepository)
    {
        _prodRepository = prodRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        try
        {
            var products = await _prodRepository.GetProductsAsync();

            if (!products.Any())
                return NotFound("Products not found.");

            return Ok(products);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetProductAsync(int id)
    {
        try
        {
            var product = await _prodRepository.GetProductByIdAsync(id);

            return product is null
                ? NotFound("Product not found.")
                : Ok(product);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductForCreationDTO product)
    {
        try
        {
            var createdProduct = await _prodRepository.CreateProductAsync(product);

            return CreatedAtRoute("GetById", new { id = createdProduct.Id }, createdProduct);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, ProductForUpdateDTO product)
    {
        try
        {
            var dbProduct = await _prodRepository.GetProductByIdAsync(id);

            if (dbProduct is null) return NotFound("Product not found.");

            await _prodRepository.UpdateProductAsync(id, product);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        try
        {
            var dbProduct = await _prodRepository.GetProductByIdAsync(id);

            if (dbProduct is null) return NotFound("Product not found.");

            await _prodRepository.DeleteProductAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
