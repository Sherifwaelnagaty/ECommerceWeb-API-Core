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
    public class OrdersRepository : IOrdersRepository
    {
        public Task<IActionResult> Add(Orders entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Orders entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAvgOrder()
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Orders GetByName(string name)
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

        public bool IsExist(Expression<Func<Orders, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Orders entity)
        {
            throw new NotImplementedException();
        }
    }
}
