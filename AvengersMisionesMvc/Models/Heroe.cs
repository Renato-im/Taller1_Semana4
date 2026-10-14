using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersMisionesMvc.Models
{
    public class Heroe
    {
        [Key]
        public int HeroeId { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string NombreReal { get; set; }

        public virtual ICollection<Mision> Misiones { get; set; }
    }
}