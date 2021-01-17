using SistemaEducativo.Models.Estudiante.Objetos;
using SistemaEducativo.Models.Estudiante.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SistemaEducativo.Models.General;
using System.ComponentModel.DataAnnotations;

namespace SistemaEducativo.Models.Configuracion
{
    public class RegistroAreaDesempenoViewModel
    {
        public int IdAreaDesempeno { get; set; }
        public string IdUser { get; set; }
    }
    public class RegistroAreaDesempenoControlador
    {
        public static List<int> ConsultaListaCargoBase(string IdUser)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var consulta = from R in db.RegistroAreaDesempeno
                               where R.IdUsuario.Equals(IdUser)
                               select new RegistroAreaDesempenoViewModel
                               {
                                   IdAreaDesempeno = R.IdAreaDesempeno
                               };
                var Registros= consulta.ToList();
                var Retorno =new List<int>();
                foreach (var item in Registros)
                    Retorno.Add(item.IdAreaDesempeno);

                return Retorno;
            }
        }

        public static void NuevoRegistroAreas(string IdUser, List<int> RegistroArea)
        {
            EliminarRegistroAreaDesempeno(IdUser);
            foreach (var Item in RegistroArea)
            {
                var Registro = new RegistroAreaDesempenoViewModel();
                Registro.IdUser = IdUser;
                Registro.IdAreaDesempeno = Item;
                NuevoRegistroArea(Registro);
            }
        }

        public static string NuevoRegistroArea(RegistroAreaDesempenoViewModel RegistroArea)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                string MensajeError = "";
                try
                {
                    RegistroAreaDesempeno Registro = new RegistroAreaDesempeno();
                    Registro.IdUsuario = RegistroArea.IdUser;
                    Registro.IdAreaDesempeno = RegistroArea.IdAreaDesempeno;

                    db.RegistroAreaDesempeno.InsertOnSubmit(Registro);
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MensajeError = e.ToString();
                }
                return MensajeError;
            }
        }

        public static string EliminarRegistroAreaDesempeno(string IdUser)
        {
            var MensajeError = "";
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var Registro = from R in db.RegistroAreaDesempeno
                            where R.IdUsuario.Equals(IdUser)
                            select R;
                    db.SubmitChanges();
                db.RegistroAreaDesempeno.DeleteAllOnSubmit(Registro);
            }
            return MensajeError;
        }
    }
}