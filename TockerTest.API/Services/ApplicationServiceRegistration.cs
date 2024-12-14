using FluentValidation;
using TockerTest.API.Contract.Services;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;
using TockerTest.API.Validation;

namespace TockerTest.API.Services
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection service) 
        {
            service.AddScoped<IGenericServices, UserServices>();
            service.AddTransient<IValidator<VMUser>, ValidatorUser>();
            
            return service;
        }
    }
} 
