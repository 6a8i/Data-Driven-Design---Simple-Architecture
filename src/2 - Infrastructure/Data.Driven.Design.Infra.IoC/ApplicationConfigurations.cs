using AutoMapper;
using Data.Driven.Design.API.Models.Custumer;
using Data.Driven.Design.Application.Services;
using Data.Driven.Design.Application.Services.Custumer;
using Data.Driven.Design.Application.Validations;
using Data.Driven.Design.Application.Validations.Custumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Driven.Design.Infra.IoC
{
    public class ApplicationConfigurations
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public ApplicationConfigurations(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        public ApplicationConfigurations ConfigureServices()
        {
            _services.AddAutoMapper(typeof(MapProfile));

            // Singleton

            // Scoped
            _services.AddScoped<ICustumerService, CustumerService>();
            _services.AddScoped<ILoadDataBase, LoadDataBase>();

            // Transient
            _services.AddTransient<ICustomValidator<InsertCustumer.Request>, InsertCustumerValidator>();
            return this;
        }
    }
}
