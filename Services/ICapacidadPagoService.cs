using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public interface ICapacidadPagoService
    {
        Task<List<CapacidadPago>> ObtenerCapacidadesAsync();

        Task<CapacidadPago> ObtenerPorIdAsync(int id);

        Task CrearAsync(CapacidadPago capacidad);

        Task ActualizarAsync(CapacidadPago capacidad);

        Task EliminarAsync(int id);
    }
}