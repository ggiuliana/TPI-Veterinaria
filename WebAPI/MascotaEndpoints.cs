using DTOs;
using ServiciosApp;

namespace WebAPI
{
    public static class MascotaEndpoints
    {
        public static void MapMascotaEndpoints(this WebApplication app)
        {
            app.MapGet("/mascotas/{id}", async (int id, IMascotaService mascotaService) =>
            {
                MascotaDTO? dto = await mascotaService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetMascotas")
            .Produces<MascotaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/mascotas", async (IMascotaService mascotaService) =>
            {
                var dtos = await mascotaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllMascotas")
            .Produces<List<MascotaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/mascotas/duenio/{id}", async (int id, IMascotaService mascotaService) =>
            {
                var dtos = await mascotaService.GetAllByDuenioAsync(id);

                return Results.Ok(dtos);
            })
            .WithName("GetMascotasByDuenio")
            .Produces<List<MascotaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/mascotas", async (MascotaDTO dto, IMascotaService mascotaService) =>
            {
                try
                {
                    MascotaDTO mascotadto = await mascotaService.AddAsync(dto);
                    return Results.Created($"/mascotas/{mascotadto.IdMascota}", mascotadto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMascota")
            .Produces<MascotaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/mascotas", async (MascotaDTO dto, IMascotaService mascotaService) =>
            {
                try
                {
                    var found = await mascotaService.UpdateAsync(dto);

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
            .WithName("UpdateMascota")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/mascotas/{id}", async (int id, IMascotaService mascotaService) =>
            {
                var deleted = await mascotaService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteMascota")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}
