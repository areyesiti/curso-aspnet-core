using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreGram.Registers
{
    public static class SwaggerRegisters
    {
        public static IServiceCollection addSwaggerRegisters(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Instagram API",
                    Version = "v1",
                    Description = "Práctica del curso de ASP.NET Core",
                    Contact = new Contact
                    {
                        Name = "Alberto Reyes",
                        Email = "areyes@iti.es",
                        Url = "http://www.iti.es"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            return services;
        }
    }
}
