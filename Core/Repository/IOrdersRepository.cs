using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IOrdersRepository:IBaseRepository<Orders>
    {
        IActionResult GetAllOrders(int Page, int PageSize, Func<OrdersDTO, bool> criteria = null);
        IActionResult GetAvgOrder();
        IActionResult GetSalesSum();
        IActionResult GetMinMaxOrder();
    }
}
