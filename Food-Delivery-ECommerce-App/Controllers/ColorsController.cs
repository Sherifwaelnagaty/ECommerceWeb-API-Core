using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Food_Delivery_ECommerce_App.Controllers
{
    public class ColorsController: ControllerBase
    {
        private readonly ColorServices _colorsServices;
        public ColorsController(ColorServices colorsServices)
        {
            _colorsServices = colorsServices;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddColor([FromBody] Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _colorsServices.AddColor(color);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand([FromForm] int id, [FromForm] Color color)
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
            return _colorsServices.UpdateColor(color);
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

            return _colorsServices.DeleteColor(id);
        }
    }
}
