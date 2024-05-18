using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrdersServices
    {
        IActionResult GetAvgOrder();
        IActionResult GetSalesSum();
        IActionResult GetMinMaxOrder();
        IActionResult GetAllOrders(int Page, int PageSize);
        Task<IActionResult> GetOrderById(int Id);
        Task<IActionResult> AddOrder(OrdersDTO orders);
        Task<IActionResult> UpdateOrder(Orders orders);
        IActionResult DeleteOrder(int Id);
    }
}
