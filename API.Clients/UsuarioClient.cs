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
    public class UsuarioClient : BaseApiClient
    {
        public static async Task<UsuarioDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"usuarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public static async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("usuarios");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>()
                   ?? new List<UsuarioDTO>();
        }

        public static async Task<UsuarioDTO?> AddAsync(UsuarioDTO dto)
        {
            var response = await client.PostAsJsonAsync("usuarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public static async Task<bool> UpdateAsync(UsuarioDTO dto)
        {
            var response = await client.PutAsJsonAsync("usuarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
        
        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"usuarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}