using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class DueñoEndpoints
    {
        public static void MapDueñoEndpoints(this WebApplication app)
        {
            app.MapGet("/duenos/{id}", async (int id, IDueñoService dueñoService) =>
            {
                DueñoDTO? dto = await dueñoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetDueno")
            .Produces<DueñoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/duenos", async (IDueñoService dueñoService) =>
            {
                var dtos = await dueñoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllDuenos")
            .Produces<List<DueñoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/duenos", async (DueñoDTO dto, IDueñoService dueñoService) =>
            {
                try
                {
                    DueñoDTO dueñodto = await dueñoService.AddAsync(dto);
                    return Results.Created($"/duenos/{dueñodto.IdDueño}", dueñodto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDueno")
            .Produces<DueñoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/duenos", async (DueñoDTO dto, IDueñoService dueñoService) =>
            {
                try
                {
                    var found = await dueñoService.UpdateAsync(dto);

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
            .WithName("UpdateCliente")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/duenos/{id}", async (int id, IDueñoService dueñoService) =>
            {
                var deleted = await dueñoService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCliente")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

