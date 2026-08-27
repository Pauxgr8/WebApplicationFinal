using Newtonsoft.Json;
using System;
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
        public bool EliminarUsuario(int id, string usuario)

        {

            using (HttpClient client = new HttpClient())

            {

                var respuesta = client.DeleteAsync(

                    api + "Usuario/" + id +

                    "?usuarioModificacion=" + usuario).Result;

                return respuesta.IsSuccessStatusCode;

            }

        }
        //========================
        // GET CLIENTES
        //========================
        public List<Cliente> ObtenerClientes()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "Cliente").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<Cliente>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
        }

        //========================
        // POST CLIENTE
        //========================
        public bool CrearCliente(Cliente cliente)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(cliente);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PostAsync(api + "Cliente", contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }
        //========================
        // POST GENERO
        //========================
        public bool CrearGenero(Genero genero)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(genero);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PostAsync(api + "Genero", contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // PUT CLIENTE
        //========================
        public bool ModificarCliente(Cliente cliente)
        {
            using (HttpClient http = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(cliente);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = http.PutAsync(
                    api + "Cliente/" + cliente.IdCliente,
                    contenido).Result;

               
               return respuesta.IsSuccessStatusCode;
            }
        }
        //========================
        // PUT GENERO
        //========================
        public bool ModificarGenero(Genero genero)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(genero);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PutAsync(
                    api + "Genero/" + genero.IdGenero,
                    contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // DELETE CLIENTE
        //========================
        public bool EliminarCliente(int id, string usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.DeleteAsync(
                    api + "Cliente/" + id +
                    "?usuarioModificacion=" + usuario).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // DELETE GENERO
        //========================
        public bool EliminarGenero(int id, string usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.DeleteAsync(
                    api + "Genero/" + id +
                    "?usuarioModificacion=" + usuario).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // GET GENEROS
        //========================
        public List<Genero> ObtenerGeneros()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "Genero").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<Genero>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Genero>>(json);
            }
        }

        //========================

        // GET ENCUESTAS

        //========================

        public List<Encuesta> ObtenerEncuestas()

        {

            using (HttpClient client = new HttpClient())

            {

                var respuesta = client.GetAsync(api + "Encuesta").Result;

                if (!respuesta.IsSuccessStatusCode)

                    return new List<Encuesta>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Encuesta>>(json);

            }

        }

        //========================
        // POST ENCUESTA
        //========================
        public bool CrearEncuesta(Encuesta encuesta)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(encuesta);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PostAsync(api + "Encuesta", contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // PUT ENCUESTA
        //========================
        public bool ModificarEncuesta(Encuesta encuesta)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(encuesta);

                var contenido = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var respuesta = client.PutAsync(
                    api + "Encuesta/" + encuesta.IdEncuesta,
                    contenido).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }
        //========================
        // DELETE ENCUESTA
        //========================
        public bool EliminarEncuesta(int id, string usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.DeleteAsync(
                    api + "Encuesta/" + id +
                    "?usuarioModificacion=" + usuario).Result;

                return respuesta.IsSuccessStatusCode;
            }
        }

        //========================
        // GET NIVEL EDUCATIVO
        //========================
        public List<NivelEducativo> ObtenerNivelEducativo()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "NivelEducativo").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<NivelEducativo>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<NivelEducativo>>(json);
            }
        }
        //========================
        // GET RANGO EDAD
        //========================
        public List<RangoEdad> ObtenerRangoEdad()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "RangoEdad").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<RangoEdad>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<RangoEdad>>(json);
            }
        }
        //========================
        // GET RANGO INGRESOS
        //========================
        public List<RangoIngresos> ObtenerRangoIngresos()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "RangoIngresos").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<RangoIngresos>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<RangoIngresos>>(json);
            }
        }
        //========================
        // GET TIPO PRESTAMOS
        //========================
        public List<TipoPrestamo> ObtenerTipoPrestamos()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "TipoPrestamo").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<TipoPrestamo>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<TipoPrestamo>>(json);
            }
        }
        //========================
        // GET PLAZOS
        //========================
        public List<Plazo> ObtenerPlazos()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "Plazo").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<Plazo>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Plazo>>(json);
            }
        }
        //========================
        // GET TASAS INTERES
        //========================
        public List<TasaInteres> ObtenerTasasInteres()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "TasaInteres").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<TasaInteres>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<TasaInteres>>(json);
            }
        }

        //========================
        // GET CAPACIDAD PAGO
        //========================
        public List<CapacidadPago> ObtenerCapacidadesPago()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "CapacidadPago").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<CapacidadPago>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<CapacidadPago>>(json);
            }
        }

        //========================
        // GET MEDIO CONTRATACION
        //========================
        public List<MedioContratacion> ObtenerMediosContratacion()
        {
            using (HttpClient client = new HttpClient())
            {
                var respuesta = client.GetAsync(api + "MedioContratacion").Result;

                if (!respuesta.IsSuccessStatusCode)
                    return new List<MedioContratacion>();

                string json = respuesta.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<MedioContratacion>>(json);
            }
        }

        public bool CrearRespuesta(Respuesta respuesta)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);

                var response = client.PostAsJsonAsync("Respuesta", respuesta).Result;

                return response.IsSuccessStatusCode;
            }
        }
        public List<Respuesta> ObtenerRespuestas()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "Respuesta").Result;

                if (!response.IsSuccessStatusCode)
                    return new List<Respuesta>();

                string json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Respuesta>>(json);
            }
        }

        public List<MisEncuestas> ObtenerMisEncuestas(int idUsuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "Encuesta/mis-encuestas/" + idUsuario).Result;

                if (!response.IsSuccessStatusCode)
                    return new List<MisEncuestas>();
                
                string json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<MisEncuestas>>(json);
            }
        }
    }
}

