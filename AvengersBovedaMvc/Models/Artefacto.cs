using AvengersBovedaMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace  AvengersBovedaMvc.Models
{
    public class Artefacto
    {
        [Key]
        public int artefactoID { get; set; }
        [Required]
        [MaxLength(60)]
        public string nombre { get; set; }
        public string poseedor { get; set; }
        [Range(1, 100)]
        public int energia { get; set; }
        public virtual ICollection<Boveda> Bovedas { get; set; }
    }
}