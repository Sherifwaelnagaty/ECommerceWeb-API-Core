using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Reviews
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public Rates Rating { get; set; }

        [ForeignKey("FK_Reviews_ApplicationUser_UserId")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("FK_Reviews_Products_ProductId")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
