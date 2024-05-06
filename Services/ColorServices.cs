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
    public class ColorServices : IColorServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;


        public ColorServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;

        }
        public async Task<IActionResult> AddColor(ColorDTO Color)
        {
            Color colors = _mapper.Map<Color>(Color);
            try
            {
                var result = await _unitOfWork.Color.Add(colors);
                if (result is OkResult)
                {
                    return new OkObjectResult(colors);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Color.Delete(colors);
                return new BadRequestObjectResult($"There is a problem during adding a new color \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteColor(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllColors(int Page, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateColor(int id, ColorDTO ColorsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
