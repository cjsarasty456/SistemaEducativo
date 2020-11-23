using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEducativo.Models.General.Objetos
{
    public class ObjMensaje
    {
        public string TituloMensaje { get; set; }
        public string CuerpoMensaje { get; set; }
        public string tipoMensaje { get; set; }
    }
    public class ObjTipoMensaje
    {
        public string TipoMensaje { get; set; }
    }
    public class TipoMensaje
    { 
        public const string success = "success";
        public const string danger = "danger";
        public const string warning = "warning";

        public List<ObjTipoMensaje> ListaTipoMensaje()
        {
            List<ObjTipoMensaje> ListaTipo = new List<ObjTipoMensaje> ();
            ListaTipo.Add(new ObjTipoMensaje() { TipoMensaje = success });
            ListaTipo.Add(new ObjTipoMensaje() { TipoMensaje = danger });
            ListaTipo.Add(new ObjTipoMensaje() { TipoMensaje = warning });
            return ListaTipo;
        }
        
    }
    public class Mensaje
    {
        public static string EscribirMensaje(ObjMensaje mensaje)
        {
            if (mensaje.CuerpoMensaje != "")
                return "toastr." + mensaje.tipoMensaje + "(&quot;" + mensaje.CuerpoMensaje + "&quot;,&quot;" + mensaje.TituloMensaje + "&quot;);";
            else
                return "";
        }
    }
}