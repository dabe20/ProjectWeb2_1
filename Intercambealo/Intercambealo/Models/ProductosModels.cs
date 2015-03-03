using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intercambealo.Models
{
    public class ProductosModels
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public int cedula { get; set; }
        public int Foto { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}