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
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IActionResult GetAllColors(int Page, int PageSize, Func<ColorDTO, bool> criteria = null)
        {
            try
            {
                IEnumerable<ColorDTO> ColorsInfo = _context.Set<Color>().Select(p => new ColorDTO
                {
                    Name = p.Name,
                });

                if (criteria != null)
                {
                    ColorsInfo = ColorsInfo.Where(criteria);
                }

                if (Page != 0)
                    ColorsInfo = ColorsInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    ColorsInfo = ColorsInfo.Take(PageSize);

                return new OkObjectResult(ColorsInfo.ToList());

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
