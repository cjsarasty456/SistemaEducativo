using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SistemaEducativo.Models.General;
using System.ComponentModel.DataAnnotations;
using SistemaEducativo.Models.Estudiante.Objetos;

namespace SistemaEducativo.Models.Configuracion
{
    public class AreaDesempenoViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El Cargo Base es requerido")]
        [Display(Name = "Área Desempeño")]
        public string Nombre { get; set; }
    }
    public class AreaDesempenoControlador
    {
        public static List<AreaDesempenoViewModel> ConsultaListaAreaDesempeno()
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var consulta = from A in db.AreaDesempeno
                               orderby A.Nombre ascending
                               select new AreaDesempenoViewModel
                               {
                                   Id = A.Id,
                                   Nombre = A.Nombre
                               };
                return consulta.ToList();
            }
        }
        //    public static List<SedeViewModel> ConsultaListaSedes(ref ObjPaginacion Paginacion)
        //    {
        //        using (GeneralModelDataContext db = new GeneralModelDataContext())
        //        {
        //            var consulta = from S in db.Sede
        //                           orderby S.Nombre ascending
        //                           where S.Eliminado==false
        //                           select new SedeViewModel
        //                           {
        //                                Id= S.Id,
        //                                Nombre=S.Nombre
        //                            };

        //            Paginacion.TotalRegistros = consulta.Count();
        //            consulta = consulta.Skip((Paginacion.PaginaActual - 1) * Paginacion.RegistrosPagina);
        //            consulta = consulta.Take(Paginacion.RegistrosPagina);
        //            return consulta.ToList();
        //        }
        //    }
        //    public static SedeViewModel ConsultaSede(int id)
        //    {
        //        using (GeneralModelDataContext db = new GeneralModelDataContext())
        //        {
        //            var consulta = from S in db.Sede
        //                           where S.Id==id
        //                           select new SedeViewModel
        //                           {
        //                               Id = S.Id,
        //                               Nombre = S.Nombre
        //                           };
        //            if (consulta.Count() == 0)
        //            {
        //                var retorno = new SedeViewModel();
        //                retorno.Id = 0;
        //                retorno.Nombre = "Sin Sede";
        //                return retorno;
        //            }
        //            else
        //            {
        //                return consulta.FirstOrDefault();
        //            }
        //        }
        //    }
        //    public static string NuevaSede(SedeViewModel ObjSede)
        //    {
        //        using (GeneralModelDataContext db = new GeneralModelDataContext())
        //        {
        //            string MensajeError = "";
        //            try
        //            {
        //                Sede sede = new Sede();
        //                sede.Nombre= ObjSede.Nombre;

        //                db.Sede.InsertOnSubmit(sede);
        //                db.SubmitChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                MensajeError = e.ToString();
        //            }
        //            return MensajeError;
        //        }
        //    }

        //    public static string EditarSede(SedeViewModel ObjSede)
        //    {
        //        using (GeneralModelDataContext db = new GeneralModelDataContext())
        //        {
        //            string MensajeError = "";
        //            try
        //            {
        //                var Sede = (from s in db.Sede
        //                                  where s.Id== ObjSede.Id
        //                                  select s
        //                                  ).FirstOrDefault();

        //                Sede.Nombre = ObjSede.Nombre;
        //                db.SubmitChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                MensajeError = e.ToString();
        //            }
        //            return MensajeError;
        //        }
        //    }

        //    public static string EliminarSede(int Id)
        //    {
        //        var MensajeError = "";
        //        using (GeneralModelDataContext db = new GeneralModelDataContext())
        //        {
        //            var Sede = (from s in db.Sede
        //                              where s.Id==Id
        //                              select s
        //                                  ).FirstOrDefault();
        //            if (Sede != null)
        //            {
        //                Sede.Eliminado = true;
        //                db.SubmitChanges();
        //            }
        //        }
        //        return MensajeError;
        //    }
        //}
    }
}