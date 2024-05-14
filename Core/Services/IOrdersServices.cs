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

        Task<IActionResult> AddOrder(OrdersDTO Order);
        Task<IActionResult> UpdateOrder(int id, OrdersDTO OrdersDTO);
        IActionResult DeleteOrder(int Id);
    }
}
