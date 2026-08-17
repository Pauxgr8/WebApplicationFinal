using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(ApiConfig.BaseUrl);
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            var response = await _httpClient.GetAsync("Cliente");

            if (!response.IsSuccessStatusCode)
                return new List<Cliente>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Cliente>>(json);
        }

        public async Task<Cliente> ObtenerPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Cliente/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Cliente>(json);
        }

        public async Task CrearAsync(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);

            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("Cliente", contenido);
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);

            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"Cliente/{cliente.IdCliente}", contenido);
        }

        public async Task EliminarAsync(int id)
        {
            await _httpClient.DeleteAsync($"Cliente/{id}");
        }
    }
}