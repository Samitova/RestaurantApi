﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Authentication.Commands.Register;
using Restaurant.Application.Authentication.Common;
using Restaurant.Application.Authentication.Common.Behaviors;
using System.Reflection;

namespace Restaurant.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services) 
    {       
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));       
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
