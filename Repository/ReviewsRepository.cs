using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReviewsRepository : BaseRepository<Reviews>, IReviewsRepository
    {
        public ReviewsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
