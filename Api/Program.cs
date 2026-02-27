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

user.MapPost("add", async (HttpContext httpContext, CancellationToken cancellationToken) =>
{
    using var reader = new StreamReader(httpContext.Request.Body);
    var key = await reader
        .ReadToEndAsync(cancellationToken)
        .ConfigureAwait(false);

    ArgumentNullException.ThrowIfNull(key);

    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

    await dbContext.Database
        .EnsureCreatedAsync(cancellationToken)
        .ConfigureAwait(false);

    dbContext.Users.Add(new User { Key = key });

    await dbContext
        .SaveChangesAsync(cancellationToken)
        .ConfigureAwait(false);

    return Results.Created();
});

app.Run();
