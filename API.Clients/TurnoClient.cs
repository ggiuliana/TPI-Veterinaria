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
        public TurnoClient(IAuthService authService) : base(authService)
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

        public async Task<List<TurnoDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("turnos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TurnoDTO>>()
                   ?? new List<TurnoDTO>();
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
