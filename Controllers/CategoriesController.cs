using BikeApi.Contracts;
using BikeApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _prodRepository;
    public CategoriesController(ICategoryRepository prodRepository)
    {
        _prodRepository = prodRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        try
        {
            var categories = await _prodRepository.GetCategoriesAsync();

            if (!categories.Any())
                return NotFound("Categories not found.");

            return Ok(categories);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        try
        {
            var category = await _prodRepository.GetCategoryByIdAsync(id);

            return category is null
                ? NotFound("Category not found.")
                : Ok(category);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(Category category)
    {
        try
        {
            var createdCategory = await _prodRepository.CreateCategoryAsync(category);

            return CreatedAtRoute("GetCategoryById", new { id = createdCategory.Id }, createdCategory);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync(int id, Category category)
    {
        try
        {
            var dbCategory = await _prodRepository.GetCategoryByIdAsync(id);

            if (dbCategory is null) return NotFound("Category not found.");

            await _prodRepository.UpdateCategoryAsync(id, category);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        try
        {
            var dbCategory = await _prodRepository.GetCategoryByIdAsync(id);

            if (dbCategory is null) return NotFound("Category not found.");

            await _prodRepository.DeleteCategoryAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
