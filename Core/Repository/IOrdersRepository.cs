using Core.Domain;
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
        IActionResult GetAvgOrder();
        IActionResult GetSalesSumCrtl();
        IActionResult GetMinMaxOrder();
    }
}
