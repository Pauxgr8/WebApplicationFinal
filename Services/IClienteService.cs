using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObtenerClientesAsync();

        Task<Cliente> ObtenerPorIdAsync(int id);

        Task CrearAsync(Cliente cliente);

        Task ActualizarAsync(Cliente cliente);

        Task EliminarAsync(int id);
    }
}