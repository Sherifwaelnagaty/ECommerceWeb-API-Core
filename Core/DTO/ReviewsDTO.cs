using Core.Domain;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ReviewsDTO
    {
        public int Id;
        public string Message;
        public Rates Rating;
        public int UserId;
        public ApplicationUser User;
        public int ProductId;
        public Products Products;
    }
}
