using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersBovedaMvc.Models
{
    public class Boveda
    {
        [Key]
        public int bovedaID { get; set; }
        [Required]
        [MaxLength(60)]
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public virtual ICollection<Artefacto> Artefactos { get; set; }
    }
}