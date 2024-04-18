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
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IActionResult> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
