using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjGenero
    {
        public string Genero {get;set;}
        public string Desc_Genero { get; set; }
    }
    public class Genero
    {
        public const string Masculino = "M";
        public const string Femenino = "F";
        public const string NoDecir = "No";

        public const string Desc_Masculino = "Masculino";
        public const string Desc_Femenino = "Femenino";
        public const string Desc_NoDecir = "Prefiero No Decirlo";

        public static List<ObjGenero> ConsultaListaGenero()
        {
            List<ObjGenero> ListaGenero = new List<ObjGenero>() ;
            ListaGenero.Add(new ObjGenero() { Genero = Masculino, Desc_Genero = Desc_Masculino });
            ListaGenero.Add(new ObjGenero() { Genero = Femenino, Desc_Genero = Desc_Femenino });
            ListaGenero.Add(new ObjGenero() { Genero = NoDecir, Desc_Genero = Desc_NoDecir });

            return ListaGenero;
        }

        public static string ConsultaDescripcionGenero(string Genero)
        {
            string retorno = "";
            switch (Genero)
            {
                case Masculino: retorno = Desc_Masculino; break;
                case Femenino: retorno = Desc_Femenino; break;
                case NoDecir: retorno = Desc_NoDecir; break;
            }
            return retorno;
        }
    }
}