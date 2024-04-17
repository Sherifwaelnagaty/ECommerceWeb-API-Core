using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Colors { get; set; }
        public Sizes Sizes { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public string Reviews { get; set; }
        public string Quantity { get; set; }
    }
}