using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaEducativo.Models.General
{
    public class SedeViewModel
    {
        public int? Id { get; set; }
        [Required (ErrorMessage ="El Valor es Requerido")]
        [StringLength(30,ErrorMessage ="El nombre de la sede debe ser maximo 30")]
        [Display(Name = "Nombre Sede")]
        public string Nombre { get; set; }
        public string Modalidad { get; set; }
    }
}