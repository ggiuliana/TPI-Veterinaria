using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class UsuarioClient : BaseApiClient
    {
        public UsuarioClient(IAuthService authService) : base(authService)
        {
        }

        public class ErrorResponse { public string Error { get; set; } = string.Empty; }
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

        public async Task<bool> RegisterVetAsync(VeterinarioRegisterDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("usuarios/register/vet", dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                try
                {
                    using var jsonDoc = JsonDocument.Parse(errorContent);
                    if (jsonDoc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
                        throw new Exception(errorElement.GetString());
                    }
                }
                catch (JsonException)
                {
                    throw new Exception(errorContent);
                }

                throw new Exception("Error desconocido al registrar.");
            }

            return true;
        }

        public async Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("usuarios/register/duenio", dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                try
                {
                    using var jsonDoc = JsonDocument.Parse(errorContent);
                    if (jsonDoc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
                        throw new Exception(errorElement.GetString());
                    }
                }
                catch (JsonException)
                {
                    throw new Exception(errorContent);
                }

                throw new Exception("Error desconocido al registrar.");
            }

            return true;
        }
    }
}