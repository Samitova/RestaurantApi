using Restaurant.Api;
using Restaurant.Application;
using Restaurant.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddPresentation()
                    .AddAplication()
                    .AddInfrastructure(builder.Configuration);  
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
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

