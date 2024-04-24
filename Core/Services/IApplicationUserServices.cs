using Core.Enums;
using Core.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IApplicationUserServices
    {
        Task<Auth> RegisterAsync(Register model);
        Task<Auth> LoginAsync(Login model);
        Task<string> AddRoleAsync(AddRole model);

    }
}
