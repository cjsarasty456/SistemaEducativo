using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjGrado
    {
        public string Grado { get; set; }
    }
    public class Grado
    {
        public const string Preescolar = "Preescolar";
        public const string Primero = "Primero";
        public const string Segundo = "Segundo";
        public const string Tercero = "Tercero";
        public const string Cuarto = "Cuarto";
        public const string Quinto = "Quinto";
        public const string Sexto = "Sexto";
        public const string Septimo = "Séptimo";
        public const string Octavo = "Octavo";
        public const string Noveno = "Noveno";
        public const string Decimo = "Decimo";
        public const string Once = "Once";
        public const string CLEIR3= "CLEIR3";
        public const string CLEIR4= "CLEIR4";
        public const string CLEIR5= "CLEIR5";
        public const string CLEIR6= "CLEIR6";


        public static List<ObjGrado> ConsultaListaGrado()
        {
            List<ObjGrado> ListaGrado = new List<ObjGrado>() ;
            ListaGrado.Add(new ObjGrado() { Grado = Preescolar});
            ListaGrado.Add(new ObjGrado() { Grado = Primero });
            ListaGrado.Add(new ObjGrado() { Grado = Segundo });
            ListaGrado.Add(new ObjGrado() { Grado = Tercero });
            ListaGrado.Add(new ObjGrado() { Grado = Cuarto });
            ListaGrado.Add(new ObjGrado() { Grado = Quinto });
            ListaGrado.Add(new ObjGrado() { Grado = Sexto });
            ListaGrado.Add(new ObjGrado() { Grado = Septimo });
            ListaGrado.Add(new ObjGrado() { Grado = Octavo });
            ListaGrado.Add(new ObjGrado() { Grado = Noveno });
            ListaGrado.Add(new ObjGrado() { Grado = Decimo });
            ListaGrado.Add(new ObjGrado() { Grado = Once });
            ListaGrado.Add(new ObjGrado() { Grado = CLEIR3 });
            ListaGrado.Add(new ObjGrado() { Grado = CLEIR4 });
            ListaGrado.Add(new ObjGrado() { Grado = CLEIR5 });
            ListaGrado.Add(new ObjGrado() { Grado = CLEIR6 });

            return ListaGrado;
        }
    }
}