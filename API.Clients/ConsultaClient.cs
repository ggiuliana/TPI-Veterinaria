using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class ConsultaCLient : BaseApiClient
    {
        public static async Task<ConsultaDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"consultas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ConsultaDTO>();
        }

        public static async Task<List<ConsultaDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("consultas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ConsultaDTO>>()
                   ?? new List<ConsultaDTO>();
        }

        public static async Task<ConsultaDTO?> AddAsync(ConsultaDTO dto)
        {
            var response = await client.PostAsJsonAsync("consultas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ConsultaDTO>();
        }

        public static async Task<bool> UpdateAsync(ConsultaDTO dto)
        {
            var response = await client.PutAsJsonAsync("consultas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"consultas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
