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
    public class BrandServices : IBrandServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;


        public BrandServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;

        }
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            Brand brands = _mapper.Map<Brand>(brand);
            try
            {
                var result = await _unitOfWork.Brand.Add(brands);
                if (result is OkResult)
                {
                    return new OkObjectResult(brands);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Brand.Delete(brands);
                return new BadRequestObjectResult($"There is a problem during adding a new brand \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteBrand(int Id)
        {
            try
            {
                Brand brand = _unitOfWork.Brand.GetById(Id);
                if (brand == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }
                _unitOfWork.Brand.Delete(brand);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem during adding a new brand \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult GetAllBrands(int Page, int PageSize)
        {
            try
            {
                // get Brands
                var gettingBrandsResult = _unitOfWork.Brand.GetAllBrands(Page, PageSize);
                if (gettingBrandsResult is not OkObjectResult BrandsResult)
                {
                    return gettingBrandsResult;
                }
                List<BrandDTO> BrandsInfoList = BrandsResult.Value as List<BrandDTO>;

                if (BrandsInfoList == null || BrandsInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no doctor");
                }

                // Load doctor images
                var BrandsInfo = BrandsInfoList.Select(d => new
                {
                    d.Name,
                }).ToList();

                return new OkObjectResult(BrandsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Brands info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult UpdateBrand(Brand brand)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.Brand.IsExist(c => c.Id == brand.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {brand.Id} is not found");
                }
                var result = _unitOfWork.Brand.Update(brand);

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
