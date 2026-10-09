using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class ConsultaClient : BaseApiClient
    {
        public ConsultaClient(IAuthService authService) : base(authService)
        {
        }

        public async Task<ConsultaDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"consultas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ConsultaDTO>();
        }

        public async Task<List<ConsultaDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("consultas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ConsultaDTO>>()
                   ?? new List<ConsultaDTO>();
        }

        public async Task<ConsultaDTO?> AddAsync(ConsultaDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("consultas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ConsultaDTO>();
        }

        public async Task<bool> UpdateAsync(ConsultaDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync("consultas", dto);

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
            var response = await client.DeleteAsync($"consultas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
        public async Task<ConsultaDTO?> GetByIdTurnoAsync(int idTurno)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"consultas/turno/{idTurno}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ConsultaDTO>();
        }
    }
}
