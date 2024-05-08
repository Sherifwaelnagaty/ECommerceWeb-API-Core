using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICategoryServices
    {
        Task<IActionResult> AddCategory(Category category);
        Task<IActionResult> UpdateCategory(Category category);
        IActionResult DeleteCategory(int Id);
        IActionResult GetAllCategories(int Page, int PageSize);
    }
}
