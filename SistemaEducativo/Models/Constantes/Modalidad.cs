using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjModalidad
    {
        public string Modalidad { get; set; }
    }
    public class Modalidad
    {
        public const string EscuelaNueva = "Escuela Nueva";
        public const string PostPrimaria = "PostPrimaria";
        public const string S3011 = "3011";
        public const string Tradicional = "Tradicional";

        public static List<ObjModalidad> ConsultaListaModalidad()
        {
            List<ObjModalidad> ListaModalidad = new List<ObjModalidad>() ;
            ListaModalidad.Add(new ObjModalidad() { Modalidad = EscuelaNueva });
            ListaModalidad.Add(new ObjModalidad() { Modalidad = PostPrimaria });
            ListaModalidad.Add(new ObjModalidad() { Modalidad = S3011 });
            ListaModalidad.Add(new ObjModalidad() { Modalidad = Tradicional });
            return ListaModalidad;
        }
    }
}