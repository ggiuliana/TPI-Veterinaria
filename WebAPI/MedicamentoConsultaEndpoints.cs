using DTOs;
using ServiciosApp;

namespace WebAPI
{
    public static class MedicamentoConsultaEndpoints
    {
        public static void MapMedicamentoConsultaEndpoints(this WebApplication app)
        {
            app.MapGet("/medicamentoconsultas/consulta/{idConsulta}", async (int idConsulta, IMedicamentoConsultaService service) =>
            {
                var dtos = await service.GetByConsultaIdAsync(idConsulta);

                return Results.Ok(dtos);
            })
            .WithName("GetMedicamentosByConsulta")
            .Produces<List<MedicamentoConsultaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("ConsultasLeer");

            app.MapPost("/medicamentoconsultas", async (MedicamentoConsultaDTO dto, IMedicamentoConsultaService service) =>
            {
                try
                {
                    await service.AddAsync(dto);
                    return Results.Ok(new { mensaje = "Medicamento recetado y stock descontado correctamente." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMedicamentoConsulta")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ConsultasAgregar");

            app.MapDelete("/medicamentoconsultas/{idConsulta}/{idMedicamento}", async (int idConsulta, int idMedicamento, IMedicamentoConsultaService service) =>
            {
                try
                {
                    await service.DeleteAsync(idConsulta, idMedicamento);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeleteMedicamentoConsulta")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ConsultasEliminar");
        }
    }
}
