using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersServices : IOrdersServices
    {
        public Task<IActionResult> AddOrder(OrdersDTO Order)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateOrder(int id, OrdersDTO OrdersDTO)
        {
            throw new NotImplementedException();
        }
    }
}
