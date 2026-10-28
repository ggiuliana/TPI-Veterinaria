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
            .WithOpenApi()
            .RequireAuthorization("TurnosLeer");

            app.MapGet("/turnos/vet/{id}", async (int id, ITurnoService turnoService) =>
            {
                var dtos = await turnoService.GetByVeterinarioIdAsync(id);

                if (dtos == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dtos);
            })
            .WithName("GetTurnoByVeterinario")
            .Produces<TurnoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("TurnosLeer");

            app.MapGet("/turnos", async (ITurnoService turnoService) =>
            {
                var dtos = await turnoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllTurnos")
            .Produces<List<TurnoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("TurnosLeer");

            app.MapGet("/turnos/disponibles", async (ITurnoService turnoService) =>
            {
                var dtos = await turnoService.GetDisponiblesAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllTurnosDisponibles")
            .Produces<List<TurnoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("TurnosLeer");

            app.MapGet("/turnos/filtrar", async (int? idVeterinario, string? estado, DateOnly? fechaDesde, DateOnly? fechaHasta, ITurnoService turnoService) =>
            {
                try
                {
                    var dtos = await turnoService.GetTurnosFiltradosAsync(idVeterinario, estado, fechaDesde, fechaHasta);
                    return Results.Ok(dtos);
                }
                catch (UnauthorizedAccessException)
                {
                    return Results.Forbid();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetTurnosFiltrados")
            .Produces<List<TurnoDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .WithOpenApi()
            .RequireAuthorization("TurnosLeer");

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
            .WithOpenApi()
            .RequireAuthorization("TurnosAgregar");

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
            .WithOpenApi()
            .RequireAuthorization("TurnosActualizar");

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
            .WithOpenApi()
            .RequireAuthorization("TurnosEliminar");

        }
    }
}

