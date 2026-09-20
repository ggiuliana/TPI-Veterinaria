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
        public class ErrorResponse { public string Error { get; set; } }
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

        public static async Task<UsuarioCreateDTO?> AddAsync(UsuarioCreateDTO dto)
        {
            var response = await client.PostAsJsonAsync("usuarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioCreateDTO>();
        }

        public static async Task<bool> UpdateAsync(UsuarioCreateDTO dto)
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

        public static async Task<(bool Exito, string Mensaje)> RegisterVetAsync(VeterinarioRegisterDTO dto)
        {
            var response = await client.PostAsJsonAsync("usuarios/register/vet", dto);

            if (response.IsSuccessStatusCode)
            {
                return (true, "Veterinario registrado correctamente");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                return (false, errorResult?.Error ?? "Error de validación al registrar.");
            }

            return (false, "Error inesperado en el servidor.");
        }

        public static async Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto)
        {
            var response = await client.PostAsJsonAsync("usuarios/register/duenio", dto);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}