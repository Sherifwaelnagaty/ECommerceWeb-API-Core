using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<IActionResult> Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                return new OkObjectResult(entity);
            }
            catch(Exception e)
            {
                return new ObjectResult($"An error occurred while adding: {e.Message}")
                {
                    StatusCode = 500,
                };
            }
        }

        public IActionResult Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return new OkObjectResult("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while adding: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByName(string name)
        {
            return _context.Set<T>().Find(name);
        }
        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Any(criteria);
        }

        public IActionResult Update(T entity)
        {
            try
            {
                _context.Update(entity);
                return new OkObjectResult(entity);
            }
            catch (Exception e)
            {
                return new ObjectResult($"An error occurred while Deleting \n: {e.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
