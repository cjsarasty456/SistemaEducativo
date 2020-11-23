using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjJornada
    {
        public string Jornada { get; set; }
    }
    public class Jornada
    {
        public const string JornadaUnica = "Jornada Única";
        public const string Sabatino = "Sabatino";

        public static List<ObjJornada> ConsultaListaJornada()
        {
            List<ObjJornada> ListaJornada = new List<ObjJornada>() ;
            ListaJornada.Add(new ObjJornada() { Jornada = JornadaUnica});
            ListaJornada.Add(new ObjJornada() { Jornada = Sabatino });
            return ListaJornada;
        }
    }
}