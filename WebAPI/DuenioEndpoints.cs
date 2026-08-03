using ServiciosApp;
using DTOs;

namespace WebAPI
{
    public static class DuenioEndpoints
    {
        public static void MapDuenioEndpoints(this WebApplication app)
        {
            app.MapGet("/duenos/{id}", async (int id, IDuenioService duenioService) =>
            {
                DuenioDTO? dto = await duenioService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetDuenio")
            .Produces<DuenioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/duenios", async (IDuenioService duenioService) =>
            {
                var dtos = await duenioService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllDuenios")
            .Produces<List<DuenioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/duenios", async (DuenioDTO dto, IDuenioService duenioService) =>
            {
                try
                {
                    DuenioDTO dueniodto = await duenioService.AddAsync(dto);
                    return Results.Created($"/duenos/{dueniodto.IdDuenio}", dueniodto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDuenio")
            .Produces<DuenioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/duenios", async (DuenioDTO dto, IDuenioService duenioService) =>
            {
                try
                {
                    var found = await duenioService.UpdateAsync(dto);

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
            .WithName("UpdateDuenios")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/duenios/{id}", async (int id, IDuenioService duenioService) =>
            {
                var deleted = await duenioService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteDuenios")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

