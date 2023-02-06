﻿using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Restaurant.Api.Common.Errors;
using Restaurant.Api.Common.Mapping;

namespace Restaurant.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, RestaurantProblemDetaiksFactory>();
        services.AddMappings();
        return services;
    }
}