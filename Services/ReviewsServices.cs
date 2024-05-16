using AutoMapper;
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
    public class ReviewsServices : IReviewsServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public ReviewsServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;

        }
        public async Task<IActionResult> AddReview(ReviewsDTO Review)
        {
            Reviews reviews = _mapper.Map<Reviews>(Review);
            try
            {
                var result = await _unitOfWork.Reviews.Add(reviews);
                if (result is OkResult)
                {
                    return new OkObjectResult(reviews);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Reviews.Delete(reviews);
                return new BadRequestObjectResult($"There is a problem during adding a new color \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public IActionResult DeleteReview(int Id)
        {
            try
            {
                Reviews review = _unitOfWork.Reviews.GetById(Id);
                if (review == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }
                _unitOfWork.Reviews.Delete(review);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem during adding a new color \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}");
            }
        }

        public async Task<IActionResult> UpdateReview(Reviews reviews)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.Reviews.IsExist(c => c.Id == reviews.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {reviews.Id} is not found");
                }
                var result = _unitOfWork.Reviews.Update(reviews);

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
