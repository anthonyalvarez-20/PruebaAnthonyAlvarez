using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAnthonyAlvarez.Models.ViewModels
{
    public class AseguradoViewModel
    {
        public int IdPersona { get; set; }
        public string Cedula { get; set; }
        public string NombrePersona { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
    }
}