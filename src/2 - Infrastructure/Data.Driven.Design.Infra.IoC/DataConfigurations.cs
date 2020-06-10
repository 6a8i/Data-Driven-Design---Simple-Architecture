using Data.Driven.Design.Application.IRepository;
using Data.Driven.Design.Infra.Data;
using Data.Driven.Design.Infra.Data.Contexts;
using Data.Driven.Design.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Driven.Design.Infra.IoC
{
    public class DataConfigurations
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public DataConfigurations(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        public DataConfigurations ConfigureServices()
        {
            _services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("DataDrivenDesignDataBase"));

            // Singleton

            // Scoped
            _services.AddScoped<Context>();
            _services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            _services.AddScoped<ICustumerRepository, CustumerRepository>();

            // Transient

            return this;
        }
    }
}
