using Application.Common.interfaces.Authentication;
using Application.Common.interfaces.Persistence;
using BuberDinner.infrastructure.Persistence;
using BuberDinner.infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,ConfigurationManager configuration){
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtGenerator,JwtGeneratorImp>();
        services.AddSingleton<IDateTimeProvider,DateTimeProviderImp>();
        services.AddScoped<IUserRepository,userRepository>();
        return services;
    }
}