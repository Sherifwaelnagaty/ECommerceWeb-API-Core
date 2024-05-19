using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        public async Task<IActionResult> AddOrder(OrdersDTO orders)
        {
            Orders order = _mapper.Map<Orders>(orders);
            try
            {
                var result = await _unitOfWork.Orders.Add(order);
                if (result is OkResult)
                {
                    return new OkObjectResult(order);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Orders.Delete(order);
                return new BadRequestObjectResult($"There is a problem during adding a new order \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteOrder(int Id)
        {
            try
            {
                Orders order = _unitOfWork.Orders.GetById(Id);
                if (order == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }
                _unitOfWork.Orders.Delete(order);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem during adding a new order \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult GetAllOrders(int Page, int PageSize)
        {
            try
            {

                // get order
                var gettingorderResult = _unitOfWork.Orders.GetAllOrders(Page, PageSize);
                if (gettingorderResult is not OkObjectResult orderResult)
                {
                    return gettingorderResult;
                }
                List<OrdersDTO> orderInfoList = orderResult.Value as List<OrdersDTO>;

                if (orderInfoList == null || orderInfoList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no order");
                }

                var orderInfo = orderInfoList.Select(d => new
                {
                    d.orderItems,
                    d.paymentMethod,
                    d.shippingAddress,
                }).ToList();

                return new OkObjectResult(orderInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting order info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetAvgOrder()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetMinMaxOrder()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetOrderById(int Id)
        {
            try
            {
                Orders order = _unitOfWork.Orders.GetById(Id);
                if (order == null)
                {
                    return new NotFoundObjectResult($"Order with ID {Id} not found.");
                }

                return new OkObjectResult(order);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Orders info \n: {ex.Message}" +
                $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetSalesSum()
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
