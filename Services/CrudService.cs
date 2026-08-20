using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public class CrudService
    {
        private readonly string api = "https://localhost:7179/api/";

        //======================
        // GET
        //======================
        public List<Usuario> ObtenerUsuarios()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "Usuario").Result;

                if (!response.IsSuccessStatusCode)
                    return new List<Usuario>();

                string json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
        }

        //======================
        // POST
        //======================

        public bool CrearUsuario(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(usuario);

                var contenido = new StringContent(
                    json,
                    System.Text.Encoding.UTF8,
                    "application/json");

                var respuesta = client.PostAsync(api + "Usuario", contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }
        //======================
        // PUT
        //======================
        public bool ModificarUsuario(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(usuario);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PutAsync(
                    api + "Usuario/" + usuario.IdUsuario,
                    contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }
        //======================
        // DELETE
        //======================
        public async Task<bool> EliminarUsuario(int id, string usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(
                    api + "Usuario/" + id +
                    "?usuarioModificacion=" + usuario);

                return response.IsSuccessStatusCode;
            }
        }
    }
}