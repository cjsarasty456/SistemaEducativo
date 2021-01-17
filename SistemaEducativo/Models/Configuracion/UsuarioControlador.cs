using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEducativo.Models.General;
using System.ComponentModel.DataAnnotations;

namespace SistemaEducativo.Models.Configuracion
{
    public class ViewListaUsuario
    {
        public string Id { get; set; }
        [Required]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        public string Documento { get; set; }
        public string InstitucionEducativa { get; set; }
        public string Sede { get; set; }
    }

    public class UsuarioControlador
    {
        public static List<ViewListaUsuario> ConsultaListaUsuarios()
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var consulta = from P in db.PerfilUsuario
                               where P.Eliminado == false
                               select new ViewListaUsuario
                               {
                                   Id = P.id,
                                   PrimerNombre=P.PrimerNombre,
                                   SegundoNombre= P.SegundoNombre,
                                   PrimerApellido= P.PrimerApellido,
                                   SegundoApellido = P.SegundoApellido,
                                   TipoDocumento = P.TipoDocumento,
                                   Documento= P.Documento,
                                   InstitucionEducativa = "San Luis",
                                   Sede = SedeControlador.ConsultaSede(P.IdSede).Nombre,

                               };
                return consulta.ToList();
            }
        }

        public static UpdateRegisterViewModel ConsultaUsuario(string IdUsuario)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                var consulta = from P in db.PerfilUsuario
                               where P.Eliminado == false &&
                               P.IdUser.Equals(IdUsuario)
                               join U in db.AspNetUsers
                               on   P.IdUser equals U.Id
                               select new UpdateRegisterViewModel
                               {
                                   Id=P.id,
                                   IdUser = P.IdUser,
                                   TipoDocumento = P.TipoDocumento,
                                   Documento = P.Documento,
                                   PrimerNombre = P.PrimerNombre,
                                   SegundoNombre = P.SegundoNombre,
                                   PrimerApellido = P.PrimerApellido,
                                   SegundoApellido = P.SegundoApellido,
                                   CodDepartamentoExpedicion=P.CodDepartamentoExpedicion,
                                   CodMunicipioExpedicion= P.CodMunicipioExpedicion,
                                   FechaNacimiento=P.FechaNacimiento,
                                   IdInstitucionEducativa=P.IdInstitucionEducativa,
                                   IdSede = P.IdSede,
                                   idTipoVinculacion=P.IdTipoVinculacion,
                                   FechaVinculacion=P.FechaVinculacion,
                                   ZonaAtender=P.ZonaAtender,
                                   CargoBase=P.CargoBase,
                                   Nivel=P.Nivel,
                                   GradoEscalafon=P.GradoEscalafon,
                                   Titulo=P.Titulo,
                                   IdRol=P.idRol,
                                   FechaCreacion=P.FechaCreacion,
                                   FechaModificacion=P.FechaModificacion,
                                   Email=U.Email

                               };
                var Registro = consulta.FirstOrDefault();
                Registro.AreaDesempeno = RegistroAreaDesempenoControlador.ConsultaListaCargoBase(Registro.IdUser);
                return Registro;
            }
        }

        public static void ActualizarPefil(UpdateRegisterViewModel Perfil)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                string MensajeError = "";
                try
                {
                    var PerfilUsuario = (from P in db.PerfilUsuario
                                         where P.id.Equals(Perfil.IdUser)
                                         select P
                                    ).FirstOrDefault();
                    PerfilUsuario.id = Perfil.IdUser;
                    PerfilUsuario.IdUser = Perfil.IdUser;
                    PerfilUsuario.PrimerNombre = Perfil.PrimerNombre;
                    PerfilUsuario.SegundoNombre = Perfil.SegundoNombre;
                    PerfilUsuario.PrimerApellido = Perfil.PrimerApellido;
                    PerfilUsuario.SegundoApellido = Perfil.SegundoApellido;
                    //PerfilUsuario.TipoDocumento = Perfil.TipoDocumento;
                    PerfilUsuario.Documento = Perfil.Documento;
                    PerfilUsuario.FechaNacimiento = Perfil.FechaNacimiento;
                    PerfilUsuario.CodDepartamentoExpedicion = Perfil.CodDepartamentoExpedicion;
                    PerfilUsuario.CodMunicipioExpedicion = Perfil.CodMunicipioExpedicion;
                    PerfilUsuario.FechaNacimiento = Perfil.FechaNacimiento;
                    PerfilUsuario.IdInstitucionEducativa = Perfil.IdInstitucionEducativa;
                    PerfilUsuario.IdSede = Perfil.IdSede;
                    PerfilUsuario.IdTipoVinculacion = Perfil.idTipoVinculacion;
                    PerfilUsuario.FechaVinculacion = Perfil.FechaVinculacion;
                    PerfilUsuario.ZonaAtender = Perfil.ZonaAtender;
                    PerfilUsuario.CargoBase = Perfil.CargoBase;
                    PerfilUsuario.Nivel = Perfil.Nivel;
                    PerfilUsuario.GradoEscalafon = Perfil.GradoEscalafon;
                    PerfilUsuario.Titulo = Perfil.Titulo;
                    //PerfilUsuario.idRol = Perfil.IdRol;
                    //PerfilUsuario.FechaCreacion = Perfil.FechaCreacion;
                    PerfilUsuario.FechaModificacion = DateTime.Now;
                    RegistroAreaDesempenoControlador.NuevoRegistroAreas(Perfil.IdUser, Perfil.AreaDesempeno);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MensajeError = e.ToString();
                }
            }
        }
        public static void NuevoUsuario(RegisterViewModel perfilUsuario)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                try
                {
                    PerfilUsuario VPerfilUsuario = new PerfilUsuario();
                    VPerfilUsuario.id = perfilUsuario.IdUser;
                    VPerfilUsuario.IdUser = perfilUsuario.IdUser;
                    VPerfilUsuario.TipoDocumento = perfilUsuario.TipoDocumento;
                    VPerfilUsuario.Documento = perfilUsuario.Documento;
                    VPerfilUsuario.PrimerNombre = perfilUsuario.PrimerNombre;
                    VPerfilUsuario.SegundoNombre = perfilUsuario.SegundoNombre;
                    VPerfilUsuario.PrimerApellido = perfilUsuario.PrimerApellido;
                    VPerfilUsuario.SegundoApellido = perfilUsuario.SegundoApellido;
                    VPerfilUsuario.CodDepartamentoExpedicion = perfilUsuario.CodDepartamentoExpedicion;
                    VPerfilUsuario.CodMunicipioExpedicion = perfilUsuario.CodMunicipioExpedicion;
                    VPerfilUsuario.FechaNacimiento = perfilUsuario.FechaNacimiento;
                    VPerfilUsuario.IdInstitucionEducativa = perfilUsuario.IdInstitucionEducativa;
                    VPerfilUsuario.IdSede = perfilUsuario.IdSede;
                    VPerfilUsuario.IdTipoVinculacion = perfilUsuario.idTipoVinculacion;
                    VPerfilUsuario.FechaVinculacion = perfilUsuario.FechaVinculacion;
                    VPerfilUsuario.ZonaAtender = perfilUsuario.ZonaAtender;
                    VPerfilUsuario.CargoBase = perfilUsuario.CargoBase;
                    VPerfilUsuario.Nivel = perfilUsuario.Nivel;
                    VPerfilUsuario.GradoEscalafon = perfilUsuario.GradoEscalafon;
                    VPerfilUsuario.Titulo = perfilUsuario.Titulo;
                    VPerfilUsuario.idRol = perfilUsuario.IdRol;
                    VPerfilUsuario.FechaCreacion = DateTime.Now;
                    VPerfilUsuario.FechaModificacion = VPerfilUsuario.FechaCreacion;
                    db.PerfilUsuario.InsertOnSubmit(VPerfilUsuario);
                    db.SubmitChanges();
                    RegistroAreaDesempenoControlador.NuevoRegistroAreas(perfilUsuario.IdUser, perfilUsuario.AreaDesempeno);
                }catch(Exception e)
                {
                    var mensaje = e.ToString();
                }
            }
        }
    }
}