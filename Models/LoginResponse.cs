using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFinal.Models
{
    public class LoginResponse
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Usuario { get; set; }

        public int IdRol { get; set; }

        public string Rol { get; set; }
    }
}