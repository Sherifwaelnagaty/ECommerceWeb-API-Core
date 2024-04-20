using AutoMapper;
using Core;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsServices : IProductsServices
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ProductsServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;

        }
        public Task<IActionResult> AddProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllProducts(int Page, int PageSize, string search)
        {
            try
            {
                Func<ProductsDTO, bool> criteria = null;

                if (!string.IsNullOrEmpty(search))
                    criteria = (d => d.Colors.Contains(search) || d.Brand.Contains(search) ||
                                d.Description.Contains(search) || d.Category.Contains(search) ||
                                d.Name.Contains(search)); 

                // get doctors
                var gettingDoctorsResult = _unitOfWork.Products.GetAllProducts(Page, PageSize, criteria);
                if (gettingDoctorsResult is not OkObjectResult doctorsResult)
                {
                    return gettingDoctorsResult;
                }
                List<ProductsDTO> doctorsInfoList = doctorsResult.Value as List<ProductsDTO>;

                if (doctorsInfoList == null || doctorsInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no doctor");
                }

                // Load doctor images
                var doctorsInfo = doctorsInfoList.Select(d => new
                {
                    Image = GetImage(d.Images),
                    d.Name,
                    d.Description,
                    d.Price,
                    d.Quantity,
                    d.Brand,
                    d.Category,
                    d.Colors,
                }).ToList();

                return new OkObjectResult(doctorsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctors info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        protected Image GetImage(List<Image> images)
        {
            if (images == null || images.Count == 0)
            {
                return null;
            }

            // For simplicity, return the first image in the list
            return images[0];
        }
        public IActionResult GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetProductByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
