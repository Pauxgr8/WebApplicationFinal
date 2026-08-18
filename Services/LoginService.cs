using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationFinal.Models;
namespace WebApplicationFinal.Services
{
    public class LoginService
    {
        private readonly string api = "https://localhost:7179/api/Login";

        public LoginResponse Login(LoginRequest request)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(request);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var response = client.PostAsync(api, content).Result;

                if (!response.IsSuccessStatusCode)
                    return null;

                var resultado = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<LoginResponse>(resultado);
            }
        }
    }
}