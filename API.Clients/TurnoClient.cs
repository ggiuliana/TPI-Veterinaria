using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class TurnoClient : BaseApiClient
    {
        public static async Task<TurnoDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"turnos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TurnoDTO>();
        }

        public static async Task<List<TurnoDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("turnos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>()
                   ?? new List<TurnoDTO>();
        }

        public static async Task<TurnoDTO?> AddAsync(TurnoDTO dto)
        {
            /*var response = await client.PostAsJsonAsync("turnos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TurnoDTO>();*/
            var response = await client.PostAsJsonAsync("turnos", dto);

            if (!response.IsSuccessStatusCode)
            {
                // Esto va a leer el error exacto que manda .NET (ej: "The EstadoTurno field is required")
                string errorDetalle = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error de validación 400: {errorDetalle}");
            }

            return await response.Content.ReadFromJsonAsync<TurnoDTO>();
        }

        public static async Task<bool> UpdateAsync(TurnoDTO dto)
        {
            var response = await client.PutAsJsonAsync("turnos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"turnos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
