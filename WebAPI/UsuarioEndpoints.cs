using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/usuarios/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                UsuarioResponseDTO? dto = await usuarioService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetUsuario")
            .Produces<UsuarioCreateDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/usuarios", async (IUsuarioService usuarioService) =>
            {
                var dtos = await usuarioService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioCreateDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/usuarios", async (UsuarioCreateDTO dto, IUsuarioService usuarioService) =>
            {
                try
                {
                    UsuarioCreateDTO usuarioDto = await usuarioService.AddAsync(dto);
                    return Results.Created($"/usuarios/{usuarioDto.IdUsuario}", usuarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuario")
            .Produces<UsuarioCreateDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/usuarios", async (UsuarioCreateDTO dto, IUsuarioService usuarioService) =>
            {
                try
                {
                    var found = await usuarioService.UpdateAsync(dto);
                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateUsuarios")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/usuarios/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                var deleted = await usuarioService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteUsuarios")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/usuarios/login", async (LoginDTO dto, IUsuarioService usuarioService) =>
            {
                var usuario = await usuarioService.Login(dto);
                if (usuario == null)
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(usuario);
            })
            .WithName("LoginUsuario")
            .Produces<UsuarioResponseDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }
    }
}

