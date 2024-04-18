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
    public class ProductsRepository : IProductsRepository, BaseRepository<Products>
    {
        public Task<IActionResult> Add(Products entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Products entity)
        {
            throw new NotImplementedException();
        }
        public IActionResult GetAllProducts(int Page, int PageSize, Func<ProductsDTO, bool> criteria = null)
        {
            throw new NotImplementedException();
        }
        public Products GetById(int id)
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
        public IActionResult Update(Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
