using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjNivelDocente
    {
        public string Nivel {get;set;}
    }
    public class NivelDocente
    {
        public const string NoAplica = "No Aplica";
        public const string Preescolar = "Preescolar";
        public const string Primaria = "Primaria";
        public const string Secundaria = "Secundaria";
        public const string MediaTecnica = "Media Técnica";

        public static List<ObjNivelDocente> ConsultaListaNivelDocente()
        {
            List<ObjNivelDocente> ListaNivel = new List<ObjNivelDocente>() ;
            ListaNivel.Add(new ObjNivelDocente() { Nivel = NoAplica});
            ListaNivel.Add(new ObjNivelDocente() { Nivel = Preescolar });
            ListaNivel.Add(new ObjNivelDocente() { Nivel = Primaria });
            ListaNivel.Add(new ObjNivelDocente() { Nivel = Secundaria });
            ListaNivel.Add(new ObjNivelDocente() { Nivel = MediaTecnica });
            return ListaNivel;
        }
    }
}