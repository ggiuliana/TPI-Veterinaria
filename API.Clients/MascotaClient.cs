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
        public static async Task<MascotaDTO?> GetAsync(int id)
        {
            var response = await client.GetAsync($"mascotas/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MascotaDTO>();
        }

        public static async Task<List<MascotaDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("mascotas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MascotaDTO>>()
                   ?? new List<MascotaDTO>();
        }

        public static async Task<List<MascotaDTO>> GetAllByDuenioAsync(int id)
        { 
            var response = await client.GetAsync($"mascotas/duenio/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MascotaDTO>>()
                   ?? new List<MascotaDTO>();
        }

        public static async Task<MascotaDTO?> AddAsync(MascotaDTO dto)
        {
            var response = await client.PostAsJsonAsync("mascotas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MascotaDTO>();
        }

        public static async Task<bool> UpdateAsync(MascotaDTO dto)
        {
            var response = await client.PutAsJsonAsync("mascotas", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
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
