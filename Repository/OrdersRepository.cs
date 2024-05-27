using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
            try
            {
                var averageOrderTotal = _context.Orders.Average(order => order.TotalPrice);
                return new OkObjectResult(averageOrderTotal);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }


        public IActionResult GetMinMaxOrder()
        {
            try
            {
                // Find the order with the minimum total price
                var minOrder = _context.Orders.OrderBy(order => order.TotalPrice).FirstOrDefault();

                // Find the order with the maximum total price
                var maxOrder = _context.Orders.OrderByDescending(order => order.TotalPrice).FirstOrDefault();

                // Return both minOrderDTO and maxOrderDTO in the response
                return new OkObjectResult(new { MinOrder = minOrder, MaxOrder = maxOrder });
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }


        public IActionResult GetSalesSum()
        {
            try
            {
                var totalSales = _context.Orders.Sum(order => order.TotalPrice);
                return new OkObjectResult(totalSales);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }

    }
}
