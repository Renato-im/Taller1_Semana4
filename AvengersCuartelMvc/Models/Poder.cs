using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersCuartelMvc.Models
{
    public class Poder
    {
        [Key]
        public int PoderId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Heroe> Heroes { get; set; }
    }
}