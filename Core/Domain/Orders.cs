using Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Domain
{
    public class Orders
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "OrderItems is required.")]
        public List<string> OrderItems { get; set; }

        [Required(ErrorMessage = "ShippingAddress is required.")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set;}

        [Required(ErrorMessage = "PaymentMethod is required.")]
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set;}

        [Required(ErrorMessage = "DeliveredAt is required.")]
        public DateTime DeliveredAt { get; set; }

        [Required(ErrorMessage = "TotalPrice is required.")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("FK_ApplicationUser_AspNetUsers_UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
