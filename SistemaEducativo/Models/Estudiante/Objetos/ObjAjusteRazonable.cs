using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEducativo.Models.Estudiante.Objetos
{
    public class ObjAjusteRazonable
    {
        public int id { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string IdEstudiante { get; set; }
        public int Edad { get; set; }
        public string DescripcionExpectativas { get; set; }
        public string DescripcionTerminos { get; set; }
        public string DescripcionCompetencias { get; set; }
        public int IdMateria { get; set; }
        public string Objetivo { get; set; }
        public string Barreras { get;set; }
        public int IdAyuda { get; set; }
        public string Evaluacion { get; set; }
    }
}