using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;


        public CategoryServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;

        }
        public async Task<IActionResult> AddCategory(Category category)
        {
            try
            {
                var result = await _unitOfWork.Category.Add(category);
                if (result is OkResult)
                {
                    return new OkObjectResult(category);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Category.Delete(category);
                return new BadRequestObjectResult($"There is a problem during adding a new category \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteCategory(int Id)
        {
            try
            {
                Category category = _unitOfWork.Category.GetById(Id);
                if (category == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }
                _unitOfWork.Category.Delete(category);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem during adding a new color \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult GetAllCategories(int Page, int PageSize)
        {
            try
            { 
                // get Categories
                var gettingCategoriesResult = _unitOfWork.Category.GetAllCategories(Page, PageSize);
                if (gettingCategoriesResult is not OkObjectResult CategoriesResult)
                {
                    return gettingCategoriesResult;
                }
                List<ProductsDTO> CategoriesInfoList = CategoriesResult.Value as List<ProductsDTO>;

                if (CategoriesInfoList == null || CategoriesInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no doctor");
                }

                // Load doctor images
                var CategoriesInfo = CategoriesInfoList.Select(d => new
                {
                    d.Name,
                }).ToList();

                return new OkObjectResult(CategoriesInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Categories info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.Category.IsExist(c => c.Id == category.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {category.Id} is not found");
                }
                var result = _unitOfWork.Category.Update(category);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }
    }
}
