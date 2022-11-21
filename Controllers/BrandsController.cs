using BikeApi.Contracts;
using BikeApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IBrandRepository _prodRepository;
    public BrandsController(IBrandRepository prodRepository)
    {
        _prodRepository = prodRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBrandsAsync()
    {
        try
        {
            var brands = await _prodRepository.GetBrandsAsync();

            if (!brands.Any())
                return NotFound("Brands not found.");

            return Ok(brands);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetBrandById")]
    public async Task<IActionResult> GetBrandAsync(int id)
    {
        try
        {
            var brand = await _prodRepository.GetBrandByIdAsync(id);

            return brand is null
                ? NotFound("Brand not found.")
                : Ok(brand);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrandAsync(Brand brand)
    {
        try
        {
            var createdBrand = await _prodRepository.CreateBrandAsync(brand);

            return CreatedAtRoute("GetBrandById", new { id = createdBrand.Id }, createdBrand);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrandAsync(int id, Brand brand)
    {
        try
        {
            var dbBrand = await _prodRepository.GetBrandByIdAsync(id);

            if (dbBrand is null) return NotFound("Brand not found.");

            await _prodRepository.UpdateBrandAsync(id, brand);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrandAsync(int id)
    {
        try
        {
            var dbBrand = await _prodRepository.GetBrandByIdAsync(id);

            if (dbBrand is null) return NotFound("Brand not found.");

            await _prodRepository.DeleteBrandAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
