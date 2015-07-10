﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intercambealo.Models
{
    public class ProductosModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}