using System;
using System.IO;
using System.Reflection;
using Data.Driven.Design.API.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Data.Driven.Design.API.Configurations
{
    public class SwaggerConfigurations
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;
        private readonly IApplicationBuilder _app;
        public SwaggerOptions SwaggerOptions { get; set; } = new SwaggerOptions();

        public SwaggerConfigurations(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
            Bind();
        }

        public SwaggerConfigurations(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _app = app;
            Bind();
        }

        private void Bind()
        {
            _configuration.GetSection("SwaggerOptions").Bind(SwaggerOptions);
        }

        public SwaggerConfigurations ConfigureServices()
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            _services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(SwaggerOptions.Version,
                              new OpenApiInfo
                              {
                                  Title = SwaggerOptions.Title,
                                  Version = SwaggerOptions.Version,
                                  Description = SwaggerOptions.Description
                              });

                // Prevents the swagger from conflicting between two models with the same name but different namespaces
                s.CustomSchemaIds(x => x.FullName);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            return this;
        }

        public SwaggerConfigurations Configure()
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            _app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            _app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"{SwaggerOptions.Endpoint}", $"{SwaggerOptions.Title}");
                s.RoutePrefix = SwaggerOptions.RoutePrefix;
            });

            return this;
        }
    }
}
