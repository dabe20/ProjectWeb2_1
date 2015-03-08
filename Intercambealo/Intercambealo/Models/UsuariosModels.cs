using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intercambealo.Models
{
    public class UsuariosModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Contraseña { get; set; }
        public int ConfirContraseña { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
    }
}