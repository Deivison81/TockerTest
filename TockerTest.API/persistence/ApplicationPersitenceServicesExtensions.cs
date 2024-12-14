using Microsoft.EntityFrameworkCore;
using TockerTest.API.Contract.Persitence;
using TockerTest.API.Models;
using TockerTest.API.persistence.Repository;

namespace TockerTest.API.persistence
{
    public static class ApplicationPersitenceServicesExtensions
    {
        public static IServiceCollection AddApplicationPersitenceServicesExtensions(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<TockenDbcontext>(options =>
                    options.UseInMemoryDatabase("InMemoyDb"));


            services.AddScoped<IGenericRepository<User>, GenericRepository>();

            return services;
        }
    }
}
