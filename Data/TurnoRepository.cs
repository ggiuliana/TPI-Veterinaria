using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;
using System.Data;
using System.Data.Common;

namespace Data
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly VeterinariaContext context;

        public TurnoRepository(VeterinariaContext context) => this.context = context;

        public async Task AddAsync(Turno turno)
        {
            context.Turnos.Add(turno);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var turno = await context.Turnos.FindAsync(id);
            if (turno != null)
            {
                context.Turnos.Remove(turno);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Turno?> GetAsync(int id)
        {           
            return await context.Turnos
                .Include(t => t.Veterinario) 
                .Include(t => t.Mascota)    
                .FirstOrDefaultAsync(t => t.IdTurno == id);
        }
        public async Task<IEnumerable<Turno>> GetByVeterinarioIdAsync(int idVeterinario)
        {
            return await context.Turnos
                .Include(t => t.Veterinario)
                .Include(t => t.Mascota)
                .Where(t => t.IdVeterinario == idVeterinario)
                .ToListAsync();
        }
        public async Task<IEnumerable<Turno>> GetDisponiblesAsync()
        {
            return await context.Turnos
                .Include(t => t.Veterinario)
                .Include(t => t.Mascota)
                .Where(t => t.EstadoTurno == "Disponible" && t.FechaTurno >= DateOnly.FromDateTime(DateTime.Today))
                .OrderBy(t => t.FechaTurno)
                .ThenBy(t => t.HoraTurno)
                .ToListAsync();
        }
        public async Task<IEnumerable<Turno>> GetTurnosFiltradosAsync(int? idVeterinario, string? estado, DateOnly? fechaDesde, DateOnly? fechaHasta)
        {
            var turnos = new List<Turno>();

            string connectionString = context.Database.GetConnectionString()
                ?? throw new ArgumentException("No hay cadena de conexión.");

            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();

            var query = @"
                SELECT 
                    t.IdTurno, t.FechaTurno, t.HoraTurno, t.EstadoTurno, t.Observaciones,
         
                    t.IdVeterinario, 
                    v.NombrePersona AS NomVet, v.Apellido AS ApeVet, v.Telefono AS TelVet, 
                    v.Mail AS MailVet, v.Dni AS DniVet, v.Direccion AS DirVet, v.Matricula, v.Especialidad,

                    t.IdMascota, m.NombreMascota, m.Especie, m.Raza, m.Castrado, m.Sexo, m.FechaNac, m.IdDuenio,

                    d.NombrePersona AS NomDuenio, d.Apellido AS ApeDuenio, d.Telefono AS TelDuenio, 
                    d.Mail AS MailDuenio, d.Dni AS DniDuenio, d.Direccion AS DirDuenio
            
                FROM dbo.Turnos t
                INNER JOIN dbo.Personas v ON t.IdVeterinario = v.IdPersona
                LEFT JOIN dbo.Mascotas m ON t.IdMascota = m.IdMascota
                LEFT JOIN dbo.Personas d ON m.IdDuenio = d.IdPersona
                WHERE 1=1";

            if (idVeterinario.HasValue)
            {
                query += " AND t.IdVeterinario = @IdVeterinario";
                command.Parameters.AddWithValue("@IdVeterinario", idVeterinario.Value);
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query += " AND t.EstadoTurno = @EstadoTurno";
                command.Parameters.AddWithValue("@EstadoTurno", estado);
            }

            if (fechaDesde.HasValue)
            {
                query += " AND t.FechaTurno >= @FechaDesde";
                command.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.ToDateTime(TimeOnly.MinValue));
            }

            if (fechaHasta.HasValue)
            {
                query += " AND t.FechaTurno <= @FechaHasta";
                command.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.ToDateTime(TimeOnly.MinValue));
            }

            command.CommandText = query;

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int ordIdTurno = reader.GetOrdinal("IdTurno");
                    int ordFecha = reader.GetOrdinal("FechaTurno");
                    int ordHora = reader.GetOrdinal("HoraTurno");
                    int ordEstado = reader.GetOrdinal("EstadoTurno");
                    int ordObs = reader.GetOrdinal("Observaciones");

                    int ordIdVet = reader.GetOrdinal("IdVeterinario");
                    int ordNomVet = reader.GetOrdinal("NomVet"); 
                    int ordApeVet = reader.GetOrdinal("ApeVet");
                    int ordTelVet = reader.GetOrdinal("TelVet");
                    int ordMailVet = reader.GetOrdinal("MailVet");
                    int ordDniVet = reader.GetOrdinal("DniVet");
                    int ordDirVet = reader.GetOrdinal("DirVet");
                    int ordMatVet = reader.GetOrdinal("Matricula");
                    int ordEspVet = reader.GetOrdinal("Especialidad");

                    int ordIdMascota = reader.GetOrdinal("IdMascota");
                    int ordNomMascota = reader.GetOrdinal("NombreMascota");
                    int ordEspecie = reader.GetOrdinal("Especie");
                    int ordRaza = reader.GetOrdinal("Raza");
                    int ordCastrado = reader.GetOrdinal("Castrado");
                    int ordSexo = reader.GetOrdinal("Sexo");
                    int ordFechaNac = reader.GetOrdinal("FechaNac");

                    int ordIdDuenio = reader.GetOrdinal("IdDuenio");
                    int ordNomDuenio = reader.GetOrdinal("NomDuenio");
                    int ordApeDuenio = reader.GetOrdinal("ApeDuenio");
                    int ordTelDuenio = reader.GetOrdinal("TelDuenio");
                    int ordMailDuenio = reader.GetOrdinal("MailDuenio");
                    int ordDniDuenio = reader.GetOrdinal("DniDuenio");
                    int ordDirDuenio = reader.GetOrdinal("DirDuenio");

                    int vetId = reader.GetInt32(ordIdVet);
                    var veterinario = new Veterinario(
                        idPersona: reader.GetInt32(ordIdVet),
                        nombrePersona: reader.GetString(ordNomVet),
                        apellido: reader.GetString(ordApeVet),
                        telefono: reader.GetString(ordTelVet),
                        mail: reader.GetString(ordMailVet),
                        dni: reader.GetString(ordDniVet),
                        direccion: reader.GetString(ordDirVet),
                        matricula: reader.GetString(ordMatVet),
                        especialidad: reader.GetString(ordEspVet)
                    );

                    var turno = new Turno(
                        idTurno: reader.GetInt32(ordIdTurno),
                        fechaTurno: DateOnly.FromDateTime(reader.GetDateTime(ordFecha)),
                        horaTurno: TimeOnly.FromTimeSpan(reader.GetFieldValue<TimeSpan>(ordHora)),
                        estadoTurno: reader.GetString(ordEstado),
                        veterinario: veterinario
                    );

                    if (!reader.IsDBNull(ordObs))
                    {
                        turno.SetObservaciones(reader.GetString(ordObs));
                    }

                    if (!reader.IsDBNull(ordIdMascota))
                    {
                        Duenio duenio;

                        if (!reader.IsDBNull(ordIdDuenio))
                        {
                            duenio = new Duenio(
                                idPersona: reader.GetInt32(ordIdDuenio),
                                nombrePersona: reader.GetString(ordNomDuenio),
                                apellido: reader.GetString(ordApeDuenio),
                                telefono: reader.IsDBNull(ordTelDuenio) ? string.Empty : reader.GetString(ordTelDuenio),
                                mail: reader.IsDBNull(ordMailDuenio) ? string.Empty : reader.GetString(ordMailDuenio),
                                dni: reader.IsDBNull(ordDniDuenio) ? string.Empty : reader.GetString(ordDniDuenio),
                                direccion: reader.IsDBNull(ordDirDuenio) ? string.Empty : reader.GetString(ordDirDuenio)
                            );
                        }
                        else
                        {
                            duenio = new Duenio(0, "Sin asignar", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                        }
                        int idMascota = reader.GetInt32(ordIdMascota);

                        var mascota = new Mascota(
                            idMascota: reader.GetInt32(ordIdMascota),
                            nombreMascota: reader.GetString(ordNomMascota),
                            especie: reader.IsDBNull(ordEspecie) ? string.Empty : reader.GetString(ordEspecie),
                            raza: reader.IsDBNull(ordRaza) ? string.Empty : reader.GetString(ordRaza),
                            castrado: reader.GetBoolean(ordCastrado),
                            sexo: reader.GetString(ordSexo)[0],
                            fechaNac: reader.GetDateTime(ordFechaNac),
                            duenio: duenio
                        );

                        turno.SetMascota(mascota);
                    }

                    if (!reader.IsDBNull(ordObs))
                    {
                        string observaciones = reader.GetString(ordObs);
                        turno.SetObservaciones(observaciones);
                    }

                    turnos.Add(turno);
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }

            return turnos;
        }
        public async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await context.Turnos
               .Include(t => t.Veterinario)
               .Include(t => t.Mascota)
               .ToListAsync();
        }
        public async Task<bool> UpdateAsync(Turno turno)
        {
            var existingTurno = await context.Turnos.FirstOrDefaultAsync(t => t.IdTurno == turno.IdTurno);
            if (existingTurno != null)
            {
                existingTurno.SetFechaTurno(turno.FechaTurno);
                existingTurno.SetHoraTurno(turno.HoraTurno);
                existingTurno.SetEstadoTurno(turno.EstadoTurno);
                existingTurno.SetVeterinario(turno.Veterinario);


                if (turno.Mascota != null)
                {
                    existingTurno.SetMascota(turno.Mascota);
                }
                if (turno.Observaciones != null)
                {
                    existingTurno.SetObservaciones(turno.Observaciones);
                }
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
