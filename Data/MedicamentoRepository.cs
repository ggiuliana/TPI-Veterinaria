using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;
using System.Data;

namespace Data
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly VeterinariaContext context;

        public MedicamentoRepository(VeterinariaContext context) => this.context = context;

        public async Task AddAsync(Medicamento medicamento)
        {
            context.Medicamentos.Add(medicamento);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var medicamento = await context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                context.Medicamentos.Remove(medicamento);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Medicamento?> GetAsync(int id)
        {
            return await context.Medicamentos.FirstOrDefaultAsync(t => t.IdMedicamento == id);
        }
        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await context.Medicamentos.ToListAsync();
        }
        public async Task<(IEnumerable<Medicamento> Agotados, IEnumerable<Medicamento> StockBajo, IEnumerable<Medicamento> StockSuficiente)> GetMedicamentosClasificadosPorStockAdoAsync()
        {
            var agotados = new List<Medicamento>();
            var stockBajo = new List<Medicamento>();
            var stockSuficiente = new List<Medicamento>();

            string connectionString = context.Database.GetConnectionString()
                ?? "Server=(localdb)\\mssqllocaldb;Database=VeterinariaDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT 
                    m.IdMedicamento, 
                    m.NombreMedicamento, 
                    m.CantidadRestante
                FROM dbo.Medicamentos m";

            try
            {
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    int ordId = reader.GetOrdinal("IdMedicamento");
                    int ordNombre = reader.GetOrdinal("NombreMedicamento");
                    int ordCantidad = reader.GetOrdinal("CantidadRestante");

                    int id = reader.GetInt32(ordId);
                    string nombre = reader.GetString(ordNombre);
                    int cantidad = reader.GetInt32(ordCantidad);

                    var medicamento = new Medicamento(id, nombre, cantidad);

                    if (cantidad == 0)
                    {
                        agotados.Add(medicamento);
                    }
                    else if (cantidad < 5)
                    {
                        stockBajo.Add(medicamento);
                    }
                    else
                    {
                        stockSuficiente.Add(medicamento);
                    }
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }

            return (agotados, stockBajo, stockSuficiente);
        }
        public async Task<bool> UpdateAsync(Medicamento medicamento)
        {
            var existingMedicamento = await context.Medicamentos.FirstOrDefaultAsync(t => t.IdMedicamento == medicamento.IdMedicamento);
            if (existingMedicamento != null)
            {
                existingMedicamento.SetNombreMedicamento(medicamento.NombreMedicamento);
                existingMedicamento.SetCantidadRestante(medicamento.CantidadRestante);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<Medicamento>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await context.Medicamentos.Where(m => ids.Contains(m.IdMedicamento)).ToListAsync();
        }
        public async Task<bool> EstaEnUsoAsync(int id)
        {
            return await context.MedicamentoConsulta.AnyAsync(mc => mc.IdMedicamento == id);
        }
    }
}
