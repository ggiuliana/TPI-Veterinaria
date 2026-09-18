using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class TurnoEndpoints
    {
        public static void MapTurnoEndpoints(this WebApplication app)
        {
            app.MapGet("/turnos/{id}", async (int id, ITurnoService turnoService) =>
            {
                TurnoDTO? dto = await turnoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetTurno")
            .Produces<TurnoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/turnos", async (ITurnoService turnoService) =>
            {
                var dtos = await turnoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllTurnos")
            .Produces<List<TurnoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/turnos", async (TurnoDTO dto, ITurnoService turnoService) =>
            {
                try
                {
                    TurnoDTO turnodto = await turnoService.AddAsync(dto);
                    return Results.Created($"/turnos/{turnodto.IdTurno}", turnodto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddTurno")
            .Produces<TurnoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/turnos", async (TurnoDTO dto, ITurnoService turnoService) =>
            {
                try
                {
                    var found = await turnoService.UpdateAsync(dto);

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
            .WithName("UpdateTurnos")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/turnos/{id}", async (int id, ITurnoService turnoService) =>
            {
                var deleted = await turnoService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteTurnos")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

