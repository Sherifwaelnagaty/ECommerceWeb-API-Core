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

    }
}
