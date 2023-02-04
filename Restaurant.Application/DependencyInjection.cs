using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services) 
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
