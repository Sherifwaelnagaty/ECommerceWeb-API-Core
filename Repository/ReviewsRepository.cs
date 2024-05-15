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
    public class ReviewsRepository : IReviewsRepository
    {
        public Task<IActionResult> Add(Reviews entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Reviews entity)
        {
            throw new NotImplementedException();
        }

        public Reviews GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Reviews GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Expression<Func<Reviews, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Reviews entity)
        {
            throw new NotImplementedException();
        }
    }
}
