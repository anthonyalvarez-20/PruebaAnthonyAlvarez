//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaAnthonyAlvarez.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seguro_Persona
    {
        public int IdSeguroPersona { get; set; }
        public int CodigoSeguro { get; set; }
        public int IdPersona { get; set; }
    
        public virtual Asegurados Asegurados { get; set; }
        public virtual Seguro Seguro { get; set; }
    }
}
