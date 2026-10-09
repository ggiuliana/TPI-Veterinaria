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
        public UsuarioClient(IAuthService authService) : base(authService)
        {
        }

        public class ErrorResponse { public string Error { get; set; } }
        public async Task<UsuarioDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync($"usuarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public async Task<List<UsuarioDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync("usuarios");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>()
                   ?? new List<UsuarioDTO>();
        }

        public async Task<UsuarioCreateDTO?> AddAsync(UsuarioCreateDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("usuarios", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioCreateDTO>();
        }

        public async Task<bool> UpdateAsync(UsuarioCreateDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync("usuarios", dto);

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
            var response = await client.DeleteAsync($"usuarios/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<(bool Exito, string Mensaje)> RegisterVetAsync(VeterinarioRegisterDTO dto)
        {
            using var client = await CreateHttpClientAsync();
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

        public async Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto)
        {
            using var client = await CreateHttpClientAsync();
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