using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Services
{
    public class ReporteService
    {
        private readonly string api = "https://localhost:7179/api/Reportes/";

        public List<ReportePregunta1> ObtenerReporte1()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "1").Result;

                if (!response.IsSuccessStatusCode)
                    return new List<ReportePregunta1>();

                string json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<ReportePregunta1>>(json);
            }
        }
        public List<ReportePlazo> ObtenerReporte2()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "2").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReportePlazo>>(json);
                }

                return new List<ReportePlazo>();
            }
        }
        public List<ReportePlazosMayores36> ObtenerReporte3()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "3").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReportePlazosMayores36>>(json);
                }

                return new List<ReportePlazosMayores36>();
            }
        }
        public List<ReporteMontoPromedio> ObtenerReporte4()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "4").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReporteMontoPromedio>>(json);
                }
            }

            return new List<ReporteMontoPromedio>();
        }
        public List<ReporteIngresosBajos> ObtenerReporte5()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "5").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReporteIngresosBajos>>(json);
                }
            }

            return new List<ReporteIngresosBajos>();
        }
        public List<ReporteNivelEducativo> ObtenerReporte6()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "6").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReporteNivelEducativo>>(json);
                }
            }

            return new List<ReporteNivelEducativo>();
        }

        public List<ReporteMedioContratacion> ObtenerReporte7()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "7").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReporteMedioContratacion>>(json);
                }
            }

            return new List<ReporteMedioContratacion>();
        }
        public List<ReporteCantidad> ObtenerReporte8()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "8").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReporteCantidad>>(json);
                }
            }

            return new List<ReporteCantidad>();
        }
        public List<ReportePromedioPago> ObtenerReporte9()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "9").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReportePromedioPago>>(json);
                }
            }

            return new List<ReportePromedioPago>();
        }
        public List<ReportePrestamoPlazo> ObtenerReporte10()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "10").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReportePrestamoPlazo>>(json);
                }
            }

            return new List<ReportePrestamoPlazo>();
        }
        public List<ReporteTasaPromedio> ObtenerReporte11()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "11").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ReporteTasaPromedio>>(json);
                }
            }

            return new List<ReporteTasaPromedio>();
        }
        public List<ReportePrestamoUniversitario> ObtenerReporte12()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "12").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ReportePrestamoUniversitario>>(json);
                }
            }

            return new List<ReportePrestamoUniversitario>();
        }
        public List<ReporteDescripcion> ObtenerReporte13()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "13").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ReporteDescripcion>>(json);
                }
            }

            return new List<ReporteDescripcion>();
        }
        public List<ReporteEdadPrestamo> ObtenerReporte14()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "14").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ReporteEdadPrestamo>>(json);
                }
            }

            return new List<ReporteEdadPrestamo>();
        }
        public List<ReporteDescripcion> ObtenerReporte15()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(api + "15").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ReporteDescripcion>>(json);
                }
                return new List<ReporteDescripcion>();
            }
        }
        public List<ReportePregunta1> ObtenerReporte31(int idRangoEdad)

        {

            using (HttpClient client = new HttpClient())

            {

                var response = client.GetAsync(api + "31/" + idRangoEdad).Result;

                if (response.IsSuccessStatusCode)

                {

                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<ReportePregunta1>>(json);

                }

            }

            return new List<ReportePregunta1>();

        }

    }
}
