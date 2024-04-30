using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IActionResult GetAllCategories(int Page, int PageSize, Func<CategoryDTO, bool> criteria = null)
        {
            try
            {
                IEnumerable<CategoryDTO> CategoriesInfo = _context.Set<Category>().Select(p => new CategoryDTO
                {
                    Images=p.Images,
                    Name =p.Name,
                });

                if (criteria != null)
                {
                    CategoriesInfo = CategoriesInfo.Where(criteria);
                }

                if (Page != 0)
                    CategoriesInfo = CategoriesInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    CategoriesInfo = CategoriesInfo.Take(PageSize);

                return new OkObjectResult(CategoriesInfo.ToList());

            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
