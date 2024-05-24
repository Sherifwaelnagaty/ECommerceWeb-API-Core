using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IActionResult GetAllOrders(int Page, int PageSize, Func<OrdersDTO, bool> criteria = null)
        {
            try
            {
                IEnumerable<OrdersDTO> OrdersInfo = _context.Set<Orders>().Select(order => new OrdersDTO
                {
                    orderItems = order.OrderItems,
                    deliveredAt =order.DeliveredAt,
                    paymentMethod = order.PaymentMethod,
                    shippingAddress = order.ShippingAddress,
                    status = order.Status,
                    totalPrice = order.TotalPrice,
                });
                if (criteria != null)
                {
                    OrdersInfo = OrdersInfo.Where(criteria);
                }

                if (Page != 0)
                    OrdersInfo = OrdersInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    OrdersInfo = OrdersInfo.Take(PageSize);

                return new OkObjectResult(OrdersInfo.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetAvgOrder()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetMinMaxOrder()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetSalesSumCrtl()
        {
            throw new NotImplementedException();
        }
    }
}
