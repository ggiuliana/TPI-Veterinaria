using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class TipoVacunaClient : BaseApiClient
    {
        public static async Task<TipoVacunaDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"tipovacunas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TipoVacunaDTO>();
        }

        public static async Task<List<TipoVacunaDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("tipovacunas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TipoVacunaDTO>>()
                   ?? new List<TipoVacunaDTO>();
        }

        public static async Task<TipoVacunaDTO?> AddAsync(TipoVacunaDTO dto)
        {
            var response = await client.PostAsJsonAsync("tipovacunas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TipoVacunaDTO>();
        }

        public static async Task<bool> UpdateAsync(TipoVacunaDTO dto)
        {
            var response = await client.PutAsJsonAsync("tipovacunas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"tipovacunas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}