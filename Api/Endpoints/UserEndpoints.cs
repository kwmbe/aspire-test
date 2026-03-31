using Database.Infrastructure;
using Database.Models;

namespace Api.Endpoints;

internal static class UserEndpoints
{
    public static async Task<IResult> AddUser(Context dbContext, HttpContext httpContext, CancellationToken cancellationToken)
    {

        using var reader = new StreamReader(httpContext.Request.Body);
        var key = await reader
            .ReadToEndAsync(cancellationToken)
            .ConfigureAwait(false);

        await dbContext.Database
            .EnsureCreatedAsync(cancellationToken)
            .ConfigureAwait(false);

        var user = new User { Key = key };

        dbContext.Users.Add(user);

        await dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return Results.Created($"{httpContext.Request.Scheme}://{httpContext.Request.Host}/user/{user.Id}", user);
    }
}
