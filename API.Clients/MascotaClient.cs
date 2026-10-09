using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class MascotaClient : BaseApiClient
    {
        public MascotaClient(IAuthService authService) : base(authService)
        {
        }

        public async Task<MascotaDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"mascotas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MascotaDTO>();
        }

        public async Task<List<MascotaDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("mascotas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MascotaDTO>>()
                   ?? new List<MascotaDTO>();
        }

        public async Task<List<MascotaDTO>> GetAllByDuenioAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"mascotas/duenio/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MascotaDTO>>()
                   ?? new List<MascotaDTO>();
        }

        public async Task<MascotaDTO?> AddAsync(MascotaDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("mascotas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MascotaDTO>();
        }

        public async Task<bool> UpdateAsync(MascotaDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync("mascotas", dto);

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
            var response = await client.DeleteAsync($"mascotas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
