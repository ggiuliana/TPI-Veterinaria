using DTOs;
using ServiciosApp;

namespace WebAPI
{
    public static class ConsultaEndpoints
    {
        public static void MapConsultaEndpoints(this WebApplication app)
        {
            app.MapGet("/consultas/{id}", async (int id, IConsultaService consultaService) =>
            {
                ConsultaDTO? dto = await consultaService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetConsulta")
            .Produces<ConsultaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/consultas", async (IConsultaService consultaService) =>
            {
                var dtos = await consultaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllConsultas")
            .Produces<List<ConsultaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/consultas", async (ConsultaDTO dto, IConsultaService consultaService) =>
            {
                try
                {
                    ConsultaDTO consultadto = await consultaService.AddAsync(dto);
                    return Results.Created($"/consultas/{consultadto.IdConsulta}", consultadto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddConsulta")
            .Produces<ConsultaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/consultas", async (ConsultaDTO dto, IConsultaService consultaService) =>
            {
                try
                {
                    var found = await consultaService.UpdateAsync(dto);

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
            .WithName("UpdateConsultas")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/consultas/{id}", async (int id, IConsultaService consultaService) =>
            {
                var deleted = await consultaService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteConsultas")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
