using eShop.Discount.API.Services;
using eShop.Discount.Application.Handlers;
using eShop.Discount.Core.Repositories.Interfaces;
using eShop.Discount.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eShop.Discount.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDiscountCommandHandler).GetTypeInfo().Assembly));
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DiscountService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(
                        "Communication with gRPC endpoints must be made through a gRPC client.");
                });
            });
        }
    }
}
