using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjTipoDocumento
    {
        public string Tipo {get;set;}
        public string Desc_Tipo { get; set; }
    }
    public class TipoDocumento
    {
        public const string AS = "AS";
        public const string TI = "TI";
        public const string CC = "CC";
        public const string CE = "CE";
        public const string MS = "MS";
        public const string PA = "PA";
        public const string RC = "RC";

        public const string Desc_AS = "Adulto sin Identidad";
        public const string Desc_TI = "Tarjeta de Identidad";
        public const string Desc_CC = "Cedula de Ciudadanía";
        public const string Desc_CE = "Cedula de Extranjería";
        public const string Desc_MS = "Menor sin Identificación";
        public const string Desc_PA = "Pasaporte";
        public const string Desc_RC = "Registro Civil";

        public static List<ObjTipoDocumento> ConsultaListaTipoDocumento()
        {
            List<ObjTipoDocumento> ListaTipoDocumento =new List<ObjTipoDocumento>() ;
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo=AS ,Desc_Tipo=Desc_AS});
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = TI, Desc_Tipo = Desc_TI });
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = CC, Desc_Tipo = Desc_CC });
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = CE, Desc_Tipo = Desc_CE });
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = MS, Desc_Tipo = Desc_MS });
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = PA, Desc_Tipo = Desc_PA});
            ListaTipoDocumento.Add(new ObjTipoDocumento() { Tipo = RC, Desc_Tipo = Desc_RC });
            return ListaTipoDocumento;
        }

        public static string ConsultaDescripcionTipo(string Tipo)
        {
            string retorno = "";
            switch (Tipo)
            {
                case AS: retorno = Desc_AS; break;
                case TI: retorno = Desc_TI; break;
                case CC: retorno = Desc_CC; break;
                case CE: retorno = Desc_CE; break;
                case MS: retorno = Desc_MS; break;
                case PA: retorno = Desc_PA; break;
                case RC: retorno = Desc_RC; break;
            }
            return retorno;
        }

    }
}