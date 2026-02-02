using ExpenseTrackerAPI.Handlers;

namespace ExpenseTrackerAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth")
            .WithTags("Authentication");

        group.MapPost("/register", AuthHandlers.Register);
        group.MapPost("/login", AuthHandlers.Login);
    }
}