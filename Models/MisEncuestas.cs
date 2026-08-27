using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFinal.Models
{
    public class MisEncuestas
    {
        public int IdEncuesta { get; set; }

        public DateTime FechaEncuesta { get; set; }

        public string Cliente { get; set; }

        public string TipoPrestamo { get; set; }

        public string Plazo { get; set; }

        public string Tasa { get; set; }

        public string CapacidadPago { get; set; }

        public string MedioContratacion { get; set; }
    }
}