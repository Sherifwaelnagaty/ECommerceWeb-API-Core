using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Core.DTO
{
    public class ProductsDTO
    {
        public string Name;
        public string Description;
        public string Category;
        public string Brand;
        public string Colors;
        public Sizes Sizes;
        public decimal Price;
        public List<Image> Images;
        public string Reviews;
        public int Quantity;
    }

}
