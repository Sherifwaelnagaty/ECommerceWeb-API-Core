using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IProductsServices
    {

        Task<IActionResult> AddProduct(Products product);
        IActionResult UpdateProduct(Products product);
        IActionResult DeleteProduct(int Id);
        IActionResult GetAllProducts(int Page, int PageSize,
                                                Func<ProductsDTO, bool> criteria = null);
        IActionResult GetProductById(int ProductId);
        IActionResult GetProductByName(string Name);
    }
}
