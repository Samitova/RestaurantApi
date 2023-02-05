using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services) 
    {       
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}
