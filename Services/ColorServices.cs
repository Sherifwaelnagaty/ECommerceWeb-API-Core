﻿using AutoMapper;
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
            try
            {
                Color color = _unitOfWork.Color.GetById(Id);
                if (color == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }
                _unitOfWork.Color.Delete(color);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem during adding a new color \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult GetAllColors(int Page, int PageSize)
        {
            try
            {

                // get Color
                var gettingColorResult = _unitOfWork.Color.GetAllColors(Page, PageSize);
                if (gettingColorResult is not OkObjectResult ColorResult)
                {
                    return gettingColorResult;
                }
                List<ColorDTO> ColorInfoList = ColorResult.Value as List<ColorDTO>;

                if (ColorInfoList == null || ColorInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no doctor");
                }

                var ColorInfo = ColorInfoList.Select(d => new
                {
                    d.Name,
                }).ToList();

                return new OkObjectResult(ColorInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Color info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> UpdateColor(int id, ColorDTO ColorsDTO)
        {
            try
            {
                // Retrieve the Color by id
                Color colors = _unitOfWork.Color.GetById(id);
                if (colors == null)
                {
                    return new NotFoundObjectResult($"There is no Color with id: {id}.");
                }

                // Update Color properties based on ColorsDTO
                colors.Name = ColorsDTO.Name;

                var result = _unitOfWork.Color.Update(colors);
                _unitOfWork.Complete();

                if (result is not OkResult)
                {
                    return new OkObjectResult(colors);
                }
                return new OkObjectResult(colors);
            }
            catch (Exception ex)
            {
                // Return error message in case of exception
                return new ObjectResult($"An error occurred while Updating color \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
