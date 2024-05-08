using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Food_Delivery_ECommerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly CategoryServices _categoriesServices;
        public CategoriesController(CategoryServices categoriesservices)
        {
            _categoriesServices = categoriesservices;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _categoriesServices.AddCategory(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] int id, [FromForm] Category category)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id Is Required");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            return await _categoriesServices.UpdateCategory(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromForm] int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("id", "The Id is Invalid. Must be greater than 0.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return _categoriesServices.DeleteCategory(id);
        }
    }
}
