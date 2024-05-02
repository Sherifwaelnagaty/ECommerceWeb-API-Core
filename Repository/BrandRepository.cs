using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandRepository:BaseRepository<Brand>,IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IActionResult GetAllBrands(int Page, int PageSize, Func<BrandDTO, bool> criteria = null)
        {
            try
            {
                IEnumerable<BrandDTO> BrandsInfo = _context.Set<Brand>().Select(p => new BrandDTO
                {
                    Name = p.Name,
                });

                if (criteria != null)
                {
                    BrandsInfo = BrandsInfo.Where(criteria);
                }

                if (Page != 0)
                    BrandsInfo = BrandsInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    BrandsInfo = BrandsInfo.Take(PageSize);

                return new OkObjectResult(BrandsInfo.ToList());

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
