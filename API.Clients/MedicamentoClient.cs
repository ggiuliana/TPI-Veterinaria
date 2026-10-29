using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class MedicamentoClient : BaseApiClient
    {
        public MedicamentoClient(IAuthService authService) : base(authService)
        {
        }

        public async Task<MedicamentoDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"medicamentos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicamentoDTO>();
        }

        public async Task<List<MedicamentoDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("medicamentos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MedicamentoDTO>>()
                   ?? new List<MedicamentoDTO>();
        }

        public async Task<MedicamentoDTO?> AddAsync(MedicamentoDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("medicamentos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicamentoDTO>();
        }

        public async Task<bool> UpdateAsync(MedicamentoDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync("medicamentos", dto);

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
            var response = await client.DeleteAsync($"medicamentos/{id}");

            await HandleUnauthorizedResponseAsync(response);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                try
                {
                    using var jsonDoc = System.Text.Json.JsonDocument.Parse(errorContent);
                    if (jsonDoc.RootElement.TryGetProperty("error", out System.Text.Json.JsonElement errorElement))
                    {
                        throw new Exception(errorElement.GetString());
                    }
                }
                catch (System.Text.Json.JsonException)
                {
                    throw new Exception(errorContent);
                }

                throw new Exception(errorContent);
            }

            return true;
        }
    }
}
