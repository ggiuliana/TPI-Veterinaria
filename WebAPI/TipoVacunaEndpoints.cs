using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class TipoVacunaEndpoints
    {
        public static void MapTipoVacunaEndpoints(this WebApplication app)
        {
            app.MapGet("/tipovacunas/{id}", async (int id, ITipoVacunaService tipovacunaService) =>
            {
                TipoVacunaDTO? dto = await tipovacunaService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetTipoVacuna")
            .Produces<TipoVacunaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/tipovacunas", async (ITipoVacunaService tipovacunaService) =>
            {
                var dtos = await tipovacunaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllTipoVacunas")
            .Produces<List<TipoVacunaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/tipovacunas", async (TipoVacunaDTO dto, ITipoVacunaService tipovacunaService) =>
            {
                try
                {
                    TipoVacunaDTO tipovacunadto = await tipovacunaService.AddAsync(dto);
                    return Results.Created($"/tipovacunas/{tipovacunadto.IdTipoVacuna}", tipovacunadto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddTipoVacuna")
            .Produces<TipoVacunaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/tipovacunas", async (TipoVacunaDTO dto, ITipoVacunaService tipovacunaService) =>
            {
                try
                {
                    var found = await tipovacunaService.UpdateAsync(dto);

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
            .WithName("UpdateTipoVacunas")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/tipovacunas/{id}", async (int id, ITipoVacunaService tipovacunaService) =>
            {
                var deleted = await tipovacunaService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteTipoVacunas")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

