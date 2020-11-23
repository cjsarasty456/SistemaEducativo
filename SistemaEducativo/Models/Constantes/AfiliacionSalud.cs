using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjAfiliacionSalud
    {
        public string Afiliacion { get; set; }
    }
    public class AfiliacionSalud
    {
        public const string Contributivo = "Contributivo";
        public const string Subsidiado = "Subsidiado";

        public static List<ObjAfiliacionSalud> ConsultaListaAfiliacionSalud()
        {
            List<ObjAfiliacionSalud> ListaAfiliacionSalud = new List<ObjAfiliacionSalud>() ;
            ListaAfiliacionSalud.Add(new ObjAfiliacionSalud() { Afiliacion = Contributivo });
            ListaAfiliacionSalud.Add(new ObjAfiliacionSalud() { Afiliacion = Subsidiado });
            return ListaAfiliacionSalud;
        }
    }
}