using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IColorServices
    {
        Task<IActionResult> AddColor(ColorDTO Color);
        Task<IActionResult> UpdateColor(int id, ColorDTO ColorsDTO);
        IActionResult DeleteColor(int Id);
        IActionResult GetAllColors(int Page, int PageSize, string search);
    }
}
