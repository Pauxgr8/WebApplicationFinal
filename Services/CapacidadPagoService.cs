using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public class CapacidadPagoService : ICapacidadPagoService
    {
        public async Task<List<CapacidadPago>> ObtenerCapacidadesAsync()
        {
            using (var cliente = new HttpClient())
            {
                cliente.Timeout = TimeSpan.FromSeconds(30);

                var json = await cliente.GetStringAsync(
                    "https://localhost:7179/api/CapacidadPago");

                return JsonConvert.DeserializeObject<List<CapacidadPago>>(json);
            }
        }

        public async Task<CapacidadPago> ObtenerPorIdAsync(int id)
        {
            using (var cliente = new HttpClient())
            {
                cliente.Timeout = TimeSpan.FromSeconds(30);

                var json = await cliente.GetStringAsync(
                    $"https://localhost:7179/api/CapacidadPago/{id}");

                return JsonConvert.DeserializeObject<CapacidadPago>(json);
            }
        }

        public Task CrearAsync(CapacidadPago capacidad)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarAsync(CapacidadPago capacidad)
        {
            throw new NotImplementedException();
        }

        public Task EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}