﻿using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Domain
{
    public class Products
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Colors is required.")]
        public string Colors { get; set; }

        [Required(ErrorMessage = "Sizes is required.")]
        [EnumDataType(typeof(Sizes))]
        public Sizes Sizes { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        public string Images { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [ForeignKey("FK_Products_Reviews_ReviewsId")]
        public int ReviewsId { get; set; }
        public Reviews Reviews { get; set; }
    }
}