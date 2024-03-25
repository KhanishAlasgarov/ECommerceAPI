
using ECommerceAPI.Application;
using ECommerceAPI.Application.Filters;
 
using ECommerceAPI.Domain.Enums;
using ECommerceAPI.Infrastructure;
using ECommerceAPI.Infrastructure.Services.Storage.Local;
using ECommerceAPI.Persistance;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ECommerceAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddNewtonsoftJson(cfg => cfg.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);


            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });

            builder.Services.AddStorage(StorageType.Azure);

            builder.Services.AddApplicationService()
                            .AddInfrastructureService()
                            .AddPersistanceService(builder.Configuration);


            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("Vue proyektinin unvani").AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
