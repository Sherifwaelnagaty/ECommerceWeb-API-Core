using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class OrdersDTO
    {
        public int Id;
        public List<string> orderItems;
        public string shippingAddress;
        public OrderStatus status;
        public PaymentMethod paymentMethod;
        public DateTime deliveredAt;
        public decimal totalPrice;
    }
}
