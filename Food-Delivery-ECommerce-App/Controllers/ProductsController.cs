using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsServices _services;
        public ProductsController(ProductsServices services)
        {
            _services = services;
        }
        [HttpGet("")]
        public IActionResult GetAllProducts(int page, int pageSize, string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _services.GetAllProducts(page, pageSize, search);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddProduct(ProductsDTO products)
        {
            if (products == null)
            {
                return BadRequest("Price and appointment are required");

            }

            if (products.Price <= 0)
            {
                return BadRequest("Invalid Price");
            }

            if (products.Quantity >= 0)
            {
                return BadRequest("Quantity have to me more than 0 ");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _services.AddProduct(products);
               
        }
        [HttpDelete("Product")]
        public IActionResult DeleteProduct([FromForm] int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError("id", "id Is Required");
                }
                else if (id < 0)
                {
                    ModelState.AddModelError("id", "id Is Invalid. Id must be greater than 0");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };
                return _services.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Deleting the Doctor:\n" +
                    $"  {ex.Message} \n  {ex.Message}");
            }
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromForm] int id, [FromForm] ProductsDTO productDTO)
        {
            if (productDTO.Images == null || productDTO.Images.Count == 0)
            {
                ModelState.AddModelError("productDTO.Image", "Image Is Required");
            }

            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id Is Required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _services.UpdateProduct(id, productDTO);
        }
    }
}
