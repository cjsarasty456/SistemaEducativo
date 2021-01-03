using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaEducativo.Models.Constantes
{
    public class ObjNivelPersonal
    {
        public string Nivel { get; set; }
        public string Des_Nivel { get; set; }
    }
    public class NivelPersonal
    {
        public const string NoAplica = "NoAplica";
        public const string Preescolar = "Preescolar";
        public const string Primaria = "Primaria";
        public const string Secundaria = "Secundaria";
        public const string MediaTecnica = "MediaTecnica";
        public const string Des_NoAplica = "No Aplica";
        public const string Des_Preescolar = "Preescolar";
        public const string Des_Primaria = "Primaria";
        public const string Des_Secundaria = "Secundaria";
        public const string Des_MediaTecnica = "Media Técnica";



        public static List<ObjNivelPersonal> ConsultaListaNivelPersonal()
        {
            List<ObjNivelPersonal> ListaNivelPersonal = new List<ObjNivelPersonal>() ;
            ListaNivelPersonal.Add(new ObjNivelPersonal() { Nivel= NoAplica, Des_Nivel = Des_NoAplica });
            ListaNivelPersonal.Add(new ObjNivelPersonal() { Nivel = Preescolar, Des_Nivel = Des_Preescolar });
            ListaNivelPersonal.Add(new ObjNivelPersonal() { Nivel = Primaria, Des_Nivel = Des_Primaria });
            ListaNivelPersonal.Add(new ObjNivelPersonal() { Nivel = Secundaria, Des_Nivel = Des_Secundaria });
            ListaNivelPersonal.Add(new ObjNivelPersonal() { Nivel = MediaTecnica, Des_Nivel = Des_MediaTecnica });
            return ListaNivelPersonal;
        }
    }
}