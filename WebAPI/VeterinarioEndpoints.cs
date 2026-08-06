using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class VeterinarioEndpoints
    {
        public static void MapVeterinarioEndpoints(this WebApplication app)
        {
            app.MapGet("/veterinarios/{id}", async (int id, IVeterinarioService veterinarioService) =>
            {
                VeterinarioDTO? dto = await veterinarioService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetVeterinario")
            .Produces<VeterinarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/veterinarios", async (IVeterinarioService veterinarioService) =>
            {
                var dtos = await veterinarioService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllVeterinarios")
            .Produces<List<VeterinarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/veterinarios", async (VeterinarioDTO dto, IVeterinarioService veterinarioService) =>
            {
                try
                {
                    VeterinarioDTO veterinarioDto = await veterinarioService.AddAsync(dto);
                    return Results.Created($"/veterinarios/{veterinarioDto.IdVeterinario}", veterinarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddVeterinario")
            .Produces<VeterinarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/veterinarios", async (VeterinarioDTO dto, IVeterinarioService veterinarioService) =>
            {
                try
                {
                    var found = await veterinarioService.UpdateAsync(dto);
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
            .WithName("UpdateVeterinarios")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/veterinarios/{id}", async (int id, IVeterinarioService veterinarioService) =>
            {
                var deleted = await veterinarioService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteVeterinarios")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

