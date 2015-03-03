using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intercambealo.Models
{
    public class TransaccionesModels
    {
        public int Id { get; set; }
        public string ProdOfrecido { get; set; }
        public string ProdInteres { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}