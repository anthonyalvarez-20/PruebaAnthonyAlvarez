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
    
    public partial class Seguro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seguro()
        {
            this.Seguro_Persona = new HashSet<Seguro_Persona>();
        }
    
        public int CodigoSeguro { get; set; }
        public string NombreSeguro { get; set; }
        public string Prima { get; set; }
        public string SumaAseguradora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seguro_Persona> Seguro_Persona { get; set; }
    }
}