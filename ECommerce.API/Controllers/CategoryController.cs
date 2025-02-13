using ECommerce.Business.Service;
using ECommerce.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
/*
 API katmanı:
Kullanıcıların veya diğer uygulamaların, iş mantığına HTTP protokolü üzerinden erişmesini sağlar.
 
 */
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid || category.Id != id)
            {
                return BadRequest(ModelState);
            }

            _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
