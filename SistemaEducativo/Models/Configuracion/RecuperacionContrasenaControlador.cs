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
    public class RecuperacionContrasenaViewModel
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string Token { get; set; }
        public DateTime Vencimiento { get; set; }
    }
    public class RecuperacionContrasenaControlador
    {
        //public static List<CargoBaseViewModel> ConsultaListaCargoBase()
        //{
        //    using (ConfiguracionDataContext db = new ConfiguracionDataContext())
        //    {
        //        var consulta = from C in db.RecuperacionContrasena
        //                       where 
        //                       select new CargoBaseViewModel
        //                       {
        //                           Id = C.Id,
        //                           Nombre = C.Nombre
        //                       };
        //        return consulta.ToList();
        //    }
        //}
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
            public static RecuperacionContrasenaViewModel ConsultaRecuperacionContrasena(string IdUser,string Token)
            {
                using (ConfiguracionDataContext db = new ConfiguracionDataContext())
                {
                var consulta = from R in db.RecuperacionContrasena
                               where R.idUser.Equals(IdUser) && R.Token.Equals(Token)
                               orderby R.Vencimiento descending
                               select new RecuperacionContrasenaViewModel
                               {
                                   Id = R.id,
                                   IdUser=R.idUser,
                                   Vencimiento=R.Vencimiento
                                   };
                    
                   return consulta.FirstOrDefault();
                }
            }

        public static RecuperacionContrasenaViewModel ConsultaRecuperacionContrasenaId(string Id)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var consulta = from R in db.RecuperacionContrasena
                               where R.id.Equals(Id)
                               select new RecuperacionContrasenaViewModel
                               {
                                   Id = R.id,
                                   IdUser = R.idUser,
                                   Vencimiento = R.Vencimiento
                               };

                return consulta.FirstOrDefault();
            }
        }
        public static void NuevaRecuperacionContrasena(RecuperacionContrasenaViewModel ORecuperacionContrasena)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                string MensajeError = "";
                try
                {
                    RecuperacionContrasena Recuperacion = new RecuperacionContrasena();
                    do
                    {
                        Recuperacion.id = Guid.NewGuid().ToString();
                    } while (ConsultaRecuperacionContrasenaId(Recuperacion.id) != null);
                    Recuperacion.idUser = ORecuperacionContrasena.IdUser;
                    Recuperacion.Token = ORecuperacionContrasena.Token;
                    Recuperacion.Vencimiento = DateTime.Now.AddHours(2);

                    db.RecuperacionContrasena.InsertOnSubmit(Recuperacion);
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MensajeError = e.ToString();
                }
            }
        }
        public static string EliminarRecuperacion(string IdUser)
        {
            var MensajeError = "";
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var RecuperacionContrasena = (from s in db.RecuperacionContrasena
                                              where s.idUser.Equals(IdUser)
                                              select s
                                      );
                if (RecuperacionContrasena != null)
                {
                    db.RecuperacionContrasena.DeleteAllOnSubmit(RecuperacionContrasena);
                    db.SubmitChanges();
                }
            }
            return MensajeError;
        }

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
        //}
    }
}