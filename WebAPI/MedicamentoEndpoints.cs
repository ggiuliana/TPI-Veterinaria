using DTOs;
using ServiciosApp;

namespace WebAPI
{
    public static class MedicamentoEndpoints
    {
        public static void MapMedicamentoEndpoints(this WebApplication app)
        {
            app.MapGet("/medicamentos/{id}", async (int id, IMedicamentoService medicamentoService) =>
            {
                MedicamentoDTO? dto = await medicamentoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetMedicamento")
            .Produces<MedicamentoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/medicamentos", async (IMedicamentoService medicamentoService) =>
            {
                var dtos = await medicamentoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllMedicamentos")
            .Produces<List<MedicamentoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/medicamentos", async (MedicamentoDTO dto, IMedicamentoService medicamentoService) =>
            {
                try
                {
                    MedicamentoDTO medicamentodto = await medicamentoService.AddAsync(dto);
                    return Results.Created($"/medicamentos/{medicamentodto.IdMedicamento}", medicamentodto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMedicamento")
            .Produces<MedicamentoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/medicamentos", async (MedicamentoDTO dto, IMedicamentoService medicamentoService) =>
            {
                try
                {
                    var found = await medicamentoService.UpdateAsync(dto);

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
            .WithName("UpdateMedicamentos")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/medicamentos/{id}", async (int id, IMedicamentoService medicamentoService) =>
            {
                var deleted = await medicamentoService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteMedicamentos")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}
