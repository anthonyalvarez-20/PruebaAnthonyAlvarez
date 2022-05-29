using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAnthonyAlvarez.Models.ViewModels
{
    public class RespuestaJson
    {
        public string codrespuesta = "500";
        public dynamic data = new ArrayList();
        public string mensaje = "";
    }
}