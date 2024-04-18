using Core;
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

namespace Repository
{
    public class ProductsRepository : BaseRepository<Products>,IProductsRepository 
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IActionResult GetAllProducts(int Page, int PageSize, Func<ProductsDTO, bool> criteria = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetProductByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string id)
        {
            throw new NotImplementedException();
        }
    }
}
