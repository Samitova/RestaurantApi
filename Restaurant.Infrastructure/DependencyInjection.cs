using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Application.Common.Interfaces.Authentication;
using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Application.Common.Interfaces.Services;
using Restaurant.Infrastructure.Authentication;
using Restaurant.Infrastructure.Persistence;
using Restaurant.Infrastructure.Persistence.Interceptors;
using Restaurant.Infrastructure.Persistence.Repositories;
using Restaurant.Infrastructure.Services;
using System;
using System.Text;

namespace Restaurant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager  configuration)
    {
        services.AddAuthentication(configuration);
        services.AddPersistant();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();        
        return services;
    }

    private static IServiceCollection AddPersistant(this IServiceCollection services)
    {       
        services.AddDbContext<RestaurantDbContext>(options =>
        options.UseSqlServer("Server=localhost;Database=Restaurant;User Id=sa;Password=123qwE45!;Encrypt=false;"));
        services.AddScoped<PublishDomainEventsInterseptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;
    }
    private static IServiceCollection AddAuthentication(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        JwtSettings jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);    
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer=true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        return services;      
    }
}