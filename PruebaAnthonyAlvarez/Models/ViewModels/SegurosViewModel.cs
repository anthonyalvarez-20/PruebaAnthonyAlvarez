using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaAnthonyAlvarez.Models.ViewModels
{
    public class SegurosViewModel
    {
        public int CodigoSeguro { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "NombreSeguro")]
        public string NombreSeguro { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Prima")]
        public string Prima { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "SumaAseguradora")]
        public string SumaAseguradora { get; set; }

    }
}