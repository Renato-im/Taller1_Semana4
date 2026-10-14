using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersMisionesMvc.Models
{
    public class Mision
    {
        [Key]
        public int MisionId { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Amenaza { get; set; }

        public string Estado { get; set; }

        // Clave foránea hacia Heroe
        public int HeroeId { get; set; }

        // Propiedad de navegación
        public virtual Heroe Heroe { get; set; }
    }
}