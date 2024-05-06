using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductsRepository Products { get; }
        public ICategoryRepository Category { get; }    
        public IBrandRepository Brand { get; }
        public IColorRepository Color { get; }
        int Complete();
    }
}
