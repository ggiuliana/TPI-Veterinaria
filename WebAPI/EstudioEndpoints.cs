using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class EstudioEndpoints
    {
        public static void MapEstudioEndpoints(this WebApplication app)
        {
            app.MapGet("/estudios/{id}", async (int id, IEstudioService estudioService) =>
            {
                EstudioDTO? dto = await estudioService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEstudio")
            .Produces<EstudioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/estudios", async (IEstudioService estudioService) =>
            {
                var dtos = await estudioService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllEstudios")
            .Produces<List<EstudioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/estudios", async (EstudioDTO dto, IEstudioService estudioService) =>
            {
                try
                {
                    EstudioDTO estudiodto = await estudioService.AddAsync(dto);
                    return Results.Created($"/estudios/{estudiodto.IdEstudio}", estudiodto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEstudio")
            .Produces<EstudioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/estudios", async (EstudioDTO dto, IEstudioService estudioService) =>
            {
                try
                {
                    var found = await estudioService.UpdateAsync(dto);

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
            .WithName("UpdateEstudios")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/estudios/{id}", async (int id, IEstudioService estudioService) =>
            {
                var deleted = await estudioService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteEstudios")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

