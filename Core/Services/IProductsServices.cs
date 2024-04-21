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
        Task<IActionResult> UpdateProduct(int id, ProductsDTO productsDTO);
        IActionResult DeleteProduct(int Id);
        IActionResult GetAllProducts(int Page, int PageSize, string search);
        IActionResult GetProductById(int ProductId);
        IActionResult GetProductByName(string Name);
    }
}
