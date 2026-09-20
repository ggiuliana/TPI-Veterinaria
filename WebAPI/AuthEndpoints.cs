using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async (LoginRequest request, AuthService authService) =>
            {
                try
                {
                    var response = await authService.LoginAsync(request);

                    if (response == null)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error durante el login: {ex.Message}");
                }
            })
            .WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            .AllowAnonymous();
        }
    }
}