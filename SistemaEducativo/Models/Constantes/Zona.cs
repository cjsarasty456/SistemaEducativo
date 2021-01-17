using System.Collections.Generic;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjZona
    {
        public string Zona { get; set; }
        public string Desc_Zona { get; set; }
    }
    public class Zona
    {
        public const string Rural = "R";
        public const string Urbana = "U";

        public const string Desc_Rural = "Rural";
        public const string Desc_Urbana = "Urbana";

        public static List<ObjZona> ConsultaListaZona()
        {
            List<ObjZona> ListaJornada = new List<ObjZona>() ;
            ListaJornada.Add(new ObjZona() { Zona = Rural, Desc_Zona = Desc_Rural });
            ListaJornada.Add(new ObjZona() { Zona = Urbana, Desc_Zona = Desc_Urbana });
            return ListaJornada;
        }

        public static string DescribirZona(string Zona)
        {
            switch (Zona)
            {
                case Rural:
                    return Desc_Rural;
                case Urbana:
                    return Desc_Urbana;
                default:
                    return "";
            }
        }
    }
}