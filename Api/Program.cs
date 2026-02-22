using Database.Infrastructure;
using Database.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<Context>("sqldb");

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<Context>();
        context.Database.EnsureCreated();

        if(!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Password = "123456",
            });
            context.SaveChanges();
        }

    }
}

app.UseHttpsRedirection();

app.MapGet("/health", Results.NoContent)
    .WithName("HealthCheck");

app.Run();
