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
    }
}
