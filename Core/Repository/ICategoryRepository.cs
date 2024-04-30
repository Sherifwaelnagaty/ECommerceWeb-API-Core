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
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        IActionResult GetAllCategories(int Page, int PageSize,
                                                Func<CategoryDTO, bool> criteria = null);
    }
}
