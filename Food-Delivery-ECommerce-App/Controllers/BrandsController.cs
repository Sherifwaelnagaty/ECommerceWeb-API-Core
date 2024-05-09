using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Food_Delivery_ECommerce_App.Controllers
{
    public class BrandsController : ControllerBase
    {
        private readonly BrandServices _brandsServices;
        public BrandsController(BrandServices brandsServices)
        {
            _brandsServices = brandsServices;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddBrand([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _brandsServices.AddBrand(brand);
        }
        [HttpPut("{id}")]
        public Task<IActionResult> UpdateBrand([FromForm] int id, [FromForm] Brand brand)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id Is Required");
            }
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(BadRequest(ModelState));
            };
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(BadRequest(ModelState));
            };
            return Task.FromResult(_brandsServices.UpdateBrand(brand));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBrand([FromForm] int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("id", "The Id is Invalid. Must be greater than 0.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return _brandsServices.DeleteBrand(id);
        }
    }
}
