using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReviewsServices : IReviewsServices
    {
        public Task<IActionResult> AddReview(ReviewsDTO Review)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteReview(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateReview(int id, ReviewsDTO ReviewsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
