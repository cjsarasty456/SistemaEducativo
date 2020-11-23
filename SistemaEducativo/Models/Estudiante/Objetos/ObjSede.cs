using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaEducativo.Models.Estudiante
{
    public class ObjSede
    {
        public int? Id { get; set; }
        [Required]
        [MinLength (5)]
        [MaxLength (30)]
        [Display (Name ="Nombre Sede")]
        public string Nombre { get; set; }
        public string Modalidad { get; set; }
    }
}