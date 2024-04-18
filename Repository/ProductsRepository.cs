﻿using Core;
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
            try
            {
                IEnumerable<ProductsDTO> ProductsInfo = _context.Set<Products>().Select(product => new ProductsDTO
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Sizes = product.Sizes,
                    Description = product.Description,
                    Category = product.Category,
                    Colors = product.Colors,
                    Brand = product.Brand,
                    Reviews = product.Reviews
                });
                if (criteria != null)
                {
                    ProductsInfo = ProductsInfo.Where(criteria);
                }

                if (Page != 0)
                    ProductsInfo = ProductsInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    ProductsInfo = ProductsInfo.Take(PageSize);

                return new OkObjectResult(ProductsInfo.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}")
                {
                    StatusCode = 500
                };
            }
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
