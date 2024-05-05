using AutoMapper;
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
        public Task<IActionResult> AddColor(ColorDTO Color)
        {
            throw new NotImplementedException();
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
