using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum Gender { Male, Female, }
    public enum DiscountType
    {
        percentage,
        value,
    }
    public enum UserRole
    {
        User,
        Admin
    }
    public enum BookingState
    {
        Pending,
        Completed,
        Cancelled
    }
    public enum Sizes
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL
    }
    public enum PaymentMethod
    {
        Cash,
        Visa
    }
    public enum OrderStatus
    {
        pending,
        processing,
        shipped,
        delivered
    }
    public enum Rates
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

}
