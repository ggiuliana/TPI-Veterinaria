using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class EstudioClient : BaseApiClient
    {
        public static async Task<EstudioDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"estudios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EstudioDTO>();
        }

        public static async Task<List<EstudioDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("estudios");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<EstudioDTO>>()
                   ?? new List<EstudioDTO>();
        }

        public static async Task<EstudioDTO?> AddAsync(EstudioDTO dto)
        {
            var response = await client.PostAsJsonAsync("estudios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EstudioDTO>();
        }

        public static async Task<bool> UpdateAsync(EstudioDTO dto)
        {
            var response = await client.PutAsJsonAsync("estudios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"estudios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}