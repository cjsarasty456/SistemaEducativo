using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjNivelEducativo
    {
        public string Nivel {get;set;}
    }
    public class NivelEducativo
    {
        public const string Primaria = "Primaria";
        public const string Bachillerato = "Bachillerato";
        public const string Tecnico = "Técnico";
        public const string Universitario = "Universitario";

        public static List<ObjNivelEducativo> ConsultaListaNivelEducativo()
        {
            List<ObjNivelEducativo> ListaNivelEducativo = new List<ObjNivelEducativo>() ;
            ListaNivelEducativo.Add(new ObjNivelEducativo() { Nivel = Primaria });
            ListaNivelEducativo.Add(new ObjNivelEducativo() { Nivel = Bachillerato });
            ListaNivelEducativo.Add(new ObjNivelEducativo() { Nivel = Tecnico });
            ListaNivelEducativo.Add(new ObjNivelEducativo() { Nivel = Universitario });
            return ListaNivelEducativo;
        }
    }
}