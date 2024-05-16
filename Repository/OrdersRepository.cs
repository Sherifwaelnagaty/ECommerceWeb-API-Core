using Core.Domain;
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
