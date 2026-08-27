using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace WebApplicationFinal.Services
{
    public class EncuestaService
    {
        private readonly string url =
            "https://localhost:7179/api/Encuesta/";

        public List<Models.Encuesta> ObtenerMisEncuestas(int idUsuario)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url + "mis-encuestas/" + idUsuario).Result;

                if (!response.IsSuccessStatusCode)
                    return new List<Models.Encuesta>();

                string json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Models.Encuesta>>(json);
            }
        }
    }
}