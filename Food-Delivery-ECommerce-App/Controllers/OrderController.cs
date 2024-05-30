using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Food_Delivery_ECommerce_App.Controllers
{
    public class OrdersController:ControllerBase
    {
        private readonly OrdersServices _ordersServices;
        public OrdersController(OrdersServices OrderssServices)
        {
               _ordersServices = OrderssServices;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddOrders([FromBody] OrdersDTO Orders)
        {
           if (!ModelState.IsValid)
           {
                return BadRequest(ModelState);
           };

           return await _ordersServices.AddOrder(Orders);
        }
        [HttpPut("{id}")]
        public  Task<IActionResult> UpdateOrders([FromForm] int id, [FromForm] Orders Orders)
        {
           if (id == 0)
           {
                ModelState.AddModelError("Id", "Id Is Required");
           }
           return _ordersServices.UpdateOrder(Orders);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder([FromForm] int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("id", "The Id is Invalid. Must be greater than 0.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return _ordersServices.DeleteOrder(id);
        }
    }
}
