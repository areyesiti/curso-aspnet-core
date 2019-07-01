using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CoreGram.Data;
using CoreGram.Helpers;
using CoreGram.Middlewares;
using CoreGram.Registers;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreGram
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración para el cors
            services.AddCors();

            // Configuraciones para Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Registro del DbContext
            services.AddDbContext<DataContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Otras configuraciones
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    //options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                });

            // Otra forma de obtener AppSettings
            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);
            //var appSettings = appSettingsSection.Get<AppSettings>();


            // Registro de generics
            //services.addGenericRegisters();

            // Registro de repositorios en Startup
            //services.AddTransient(typeof(UserRepository));
            //services.AddTransient<UserRepository>();            

            // Registro del servicio de autenticación
            services.addAuthenticationRegisters(Configuration);

            // Registro de los servicios propios
            services.addCustomRegisters();

            // Registro y configuración de swagger
            services.addSwaggerRegisters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hola desde el primer middleware");
            //    await next.Invoke();
            //    Console.WriteLine("Adiós desde el primer middleware");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hola desde el segundo middleware");
            //    await next.Invoke();
            //    Console.WriteLine("Adiós desde el segundo middleware");
            //});


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Configuración del cors
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseErrorHandlerMiddleware();

            // Habilitamos el middleware para la autenticación
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
