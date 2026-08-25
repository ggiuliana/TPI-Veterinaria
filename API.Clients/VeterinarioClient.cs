using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using System.Net.Http.Json; 

namespace API.Clients
{
    public class VeterinarioClient : BaseApiClient
    {
        public static async Task<VeterinarioDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"veterinarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<VeterinarioDTO>();
        }

        public static async Task<List<VeterinarioDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("veterinarios");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<VeterinarioDTO>>()
                   ?? new List<VeterinarioDTO>();
        }

        public static async Task<VeterinarioDTO?> AddAsync(VeterinarioDTO dto)
        {
            var response = await client.PostAsJsonAsync("veterinarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<VeterinarioDTO>();
        }

        public static async Task<bool> UpdateAsync(VeterinarioDTO dto)
        {
            var response = await client.PutAsJsonAsync("veterinarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"veterinarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}