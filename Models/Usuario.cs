using System;
using Newtonsoft.Json;

namespace WebApplicationFinal.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        public string NombreRol { get; set; }
        public string Nombre { get; set; }

        public string Correo { get; set; }

        [JsonProperty("usuario")]
        public string UsuarioLogin { get; set; }

        public string Contrasena { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string UsuarioModificacion { get; set; }
    }
}