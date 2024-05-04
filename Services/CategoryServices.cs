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
        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            Category categories = _mapper.Map <Category>(category);
            try
            {
                var result = await _unitOfWork.Category.Add(categories);
                if (result is OkResult)
                {
                    return new OkObjectResult(categories);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Category.Delete(categories);
                return new BadRequestObjectResult($"There is a problem during adding a new product \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllCategories(int Page, int PageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCategory(int id, CategoryDTO CategoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
