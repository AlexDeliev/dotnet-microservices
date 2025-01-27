using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Play.Catalog.Service.Entities;
using Play.Common.MongoDB;
using Play.Common.Settings;
using Play.Common.MassTransit;

namespace Play.Catalog.Service
{
    public class Startup
    {
        // AllowedOriginSetting field to store the AllowedOrigin setting.
        private const string AllowedOriginSetting = "AllowedOrigin";
        // ServiceSettings field to store the ServiceSettings object.
        private ServiceSettings serviceSettings;

        // Constructor that takes an IConfiguration object.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            // Get the ServiceSettings from the appsettings.json file.
            serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            // Register the GuidSerializer with the BsonSerializer.
            services.AddMongo()
                .AddMongoRepository<Item>("items")
                .AddMassTransitWithRabbitMq();
          
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Play.Catalog.Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Get the AllowedOrigin setting from the ServiceSettings object.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// If the environment is Development, use the DeveloperExceptionPage.
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Play.Catalog.Service v1"));
                // If the environment is Development, use the SwaggerUI middleware to serve the Swagger UI.
                var allowedOrigin = Configuration[AllowedOriginSetting];
                app.UseCors(builder =>
                {
                    builder.WithOrigins(Configuration[AllowedOriginSetting])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
