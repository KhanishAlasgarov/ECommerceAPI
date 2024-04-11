using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Domain.Enums;
using ECommerceAPI.Infrastructure.Services.Storage;
using ECommerceAPI.Infrastructure.Services.Storage.Azure;
using ECommerceAPI.Infrastructure.Services.Storage.Local;
using ECommerceAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Reflection.Metadata;

namespace ECommerceAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<ITokenHandler, TokenHandler>();

        return services;
    }

    public static void AddStorage<TStorage>(this IServiceCollection services) where TStorage : class, IStorage
    {
        services.AddScoped<IStorage, TStorage>();
    }

    public static void AddStorage(this IServiceCollection services, StorageType type)
    {

        switch (type)
        {
            case StorageType.Local:
                services.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure:
                services.AddScoped<IStorage, AzureStorage>();
                break;

            default:
                services.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}