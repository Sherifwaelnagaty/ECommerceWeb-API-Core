using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        IActionResult GetAllProducts(int Page, int PageSize,
                                                Func<ProductsDTO, bool> criteria = null);
    }
}
