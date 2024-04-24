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

}
