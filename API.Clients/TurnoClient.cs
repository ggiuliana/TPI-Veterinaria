using DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class TurnoClient : BaseApiClient
    {
        public TurnoClient(IAuthService authService, IConfiguration configuration) : base(authService, configuration)
        {
        }

        public async Task<TurnoDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"turnos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TurnoDTO>();
        }

        public async Task<List<TurnoDTO>?> GetByVeterinarioIdAsync(int idVeterinario)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"turnos/vet/{idVeterinario}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>();
        }

        public async Task<List<TurnoDTO>?> GetDisponiblesAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"turnos/disponibles");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>();
        }

        public async Task<List<TurnoDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("turnos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>()
                   ?? new List<TurnoDTO>();
        }

        public async Task<List<TurnoDTO>> GetTurnosFiltradosAsync(int? idVeterinario, string? estado, DateOnly? fechaDesde, DateOnly? fechaHasta)
        {
            using var client = await CreateHttpClientAsync();

            var queryParams = new List<string>();

            if (idVeterinario.HasValue)
            {
                queryParams.Add($"idVeterinario={idVeterinario.Value}");
            }

            if (!string.IsNullOrWhiteSpace(estado))
            {
                queryParams.Add($"estado={Uri.EscapeDataString(estado)}");
            }

            if (fechaDesde.HasValue)
            {
                queryParams.Add($"fechaDesde={fechaDesde.Value:yyyy-MM-dd}");
            }

            if (fechaHasta.HasValue)
            {
                queryParams.Add($"fechaHasta={fechaHasta.Value:yyyy-MM-dd}");
            }

            string url = "turnos/filtrar";

            if (queryParams.Count > 0)
            {
                url += "?" + string.Join("&", queryParams);
            }

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("Los dueños y veterinarios no tienen permiso para usar este filtro.");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string errorDetalle = await response.Content.ReadAsStringAsync();
                throw new ArgumentException($"Error de validación: {errorDetalle}");
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>() ?? new List<TurnoDTO>();
        }
        public async Task<TurnoDTO?> AddAsync(TurnoDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("turnos", dto);

            if (!response.IsSuccessStatusCode)
            {
                string errorDetalle = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error de validación 400: {errorDetalle}");
            }

            return await response.Content.ReadFromJsonAsync<TurnoDTO>();
        }

        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync("turnos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
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
