using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersServices : IOrdersServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public OrdersServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;

        }
        public Task<IActionResult> AddOrder(OrdersDTO Order)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> UpdateOrder(Orders Orders)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.Orders.IsExist(c => c.Id == Orders.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {Orders.Id} is not found");
                }
                var result = _unitOfWork.Orders.Update(Orders);

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
