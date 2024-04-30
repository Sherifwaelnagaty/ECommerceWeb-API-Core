using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }

        [ForeignKey("FK_Color_ApplicationUser_UserId")]
        public int UserId { get; set; }

        [ForeignKey("FK_Color_Products_ProductId")]
        public int ProductId { get; set; }

    }
}
