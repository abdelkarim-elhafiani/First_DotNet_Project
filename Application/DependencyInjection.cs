using Application.Common.interfaces.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationQueryService,AuthenticationQueryServiceImp>();
        services.AddScoped<IAuthenticationCommandService,AuthenticationCommandServiceImp>();
        return services;
    }
}