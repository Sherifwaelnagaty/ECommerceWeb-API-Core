using AutoMapper;
using Core;
using Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
namespace DependencyInjection
{
    public static class DependencyConfig
    {
        public static IServiceCollection ConfigureDependencies(IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();


            //Services.AddIdentity<ApplicationUser, IdentityRole>(
                //options => options.Password.RequireDigit = true
                //).
               //AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddTransient<IUnitOfWork, UnitOfWork>();
            Services.AddTransient<IProductsServices,ProductsServices>();

            // inject auto mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<MappingUserDtTOProfile>();
            });
            IMapper _mapper = mapperConfig.CreateMapper();
            Services.AddSingleton(_mapper);

            // patch
            Services.AddControllers().AddNewtonsoftJson();

            return Services;
        }
    }
}