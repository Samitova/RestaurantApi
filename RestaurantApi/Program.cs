using Microsoft.AspNetCore.Mvc.Infrastructure;
using Restaurant.Api.Common.Errors;
using Restaurant.Application;
using Restaurant.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddAplication();
    builder.Services.AddInfrastructure(builder.Configuration);    
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSingleton<ProblemDetailsFactory, RestaurantProblemDetaiksFactory>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseExceptionHandler("/error");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

