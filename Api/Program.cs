using Database.Infrastructure;
using Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<Context>("sqldb");

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider
            .GetRequiredService<Context>()
            .Database
            .EnsureCreated();
    }
}

app.UseHttpsRedirection();

app.MapGet("health", Results.NoContent)
    .WithName("HealthCheck");

var user = app.MapGroup("user");

user.MapPost("add", UserEndpoints.AddUser)
    .WithName("AddUser");

app.Run();
