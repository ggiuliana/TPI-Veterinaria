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
        public static async Task<MedicamentoDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"medicamentos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicamentoDTO>();
        }

        public static async Task<List<MedicamentoDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("medicamentos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MedicamentoDTO>>()
                   ?? new List<MedicamentoDTO>();
        }

        public static async Task<MedicamentoDTO?> AddAsync(MedicamentoDTO dto)
        {
            var response = await client.PostAsJsonAsync("medicamentos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicamentoDTO>();
        }

        public static async Task<bool> UpdateAsync(MedicamentoDTO dto)
        {
            var response = await client.PutAsJsonAsync("medicamentos", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"medicamentos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
