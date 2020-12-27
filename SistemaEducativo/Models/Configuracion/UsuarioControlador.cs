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
        public class ViewPerfil
    {
        public int Id { get; set; }
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
        [Required]
        public string CodDepartamentoExpedicion { get; set; }
        [Required]
        public string CodMunicipioExpedicion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }

    public class ViewUsuario
    {
        public string IdUser { get; set; }
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
        [Required]
        public string CodDepartamentoExpedicion { get; set; }
        [Required]
        public string CodMunicipioExpedicion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int IdInstitucionEducativa { get; set; }
        [Required]
        public int IdSede { get; set; }
        public string AreaDesempeno { get; set; }
        [Required]
        public int IdGradoVinculacion { get; set; }
        public string GradoVinculacion { get; set; }
        [Required]
        public int IdTipoVinculacion { get; set; }
        [Required]
        public DateTime FechaVinculacion { get; set; }
        public string ZonaAtender { get; set; }
        public string CargoBase { get; set; }
        public string Nivel { get; set; }
        public int GradoEscalafon { get; set; }
        public string Titulo { get; set; }
        public int IdRol { get; set; }


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
                                   Sede = SedeControlador.ConsultaSede(P.IdSede).Nombre
                               };
                return consulta.ToList();
            }
        }

        public void ActualizarPefil(ViewPerfil Perfil)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                string MensajeError = "";
                try
                {
                    var PerfilUsuario = (from P in db.PerfilUsuario
                                         where P.id.Equals(Perfil.Id)
                                         select P
                                    ).FirstOrDefault();
                    PerfilUsuario.PrimerNombre = Perfil.PrimerNombre;
                    PerfilUsuario.SegundoNombre = Perfil.SegundoNombre;
                    PerfilUsuario.PrimerApellido = Perfil.PrimerApellido;
                    PerfilUsuario.SegundoApellido = Perfil.SegundoApellido;
                    PerfilUsuario.TipoDocumento = Perfil.TipoDocumento;
                    PerfilUsuario.Documento = Perfil.Documento;
                    PerfilUsuario.FechaNacimiento = Perfil.FechaNacimiento;
                    PerfilUsuario.CodDepartamentoExpedicion = Perfil.CodDepartamentoExpedicion;
                    PerfilUsuario.CodMunicipioExpedicion = Perfil.CodMunicipioExpedicion;
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MensajeError = e.ToString();
                }
            }
        }
        public void NuevoUsuario(ViewUsuario perfilUsuario)
        {
            using (ConfiguracionDataContext db = new ConfiguracionDataContext())
            {
                PerfilUsuario VPerfilUsuario = new PerfilUsuario();
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
                VPerfilUsuario.AreaDesempeno = perfilUsuario.AreaDesempeno;
                VPerfilUsuario.IdTipoVinculacion = perfilUsuario.IdTipoVinculacion;
                VPerfilUsuario.FechaVinculacion = perfilUsuario.FechaVinculacion;
                VPerfilUsuario.ZonaAtender = perfilUsuario.ZonaAtender;
                VPerfilUsuario.CargoBase = perfilUsuario.CargoBase;
                VPerfilUsuario.Nivel = perfilUsuario.Nivel;
                VPerfilUsuario.GradoEscalafon = perfilUsuario.GradoEscalafon;
                VPerfilUsuario.Titulo = perfilUsuario.Titulo;
                VPerfilUsuario.idRol = perfilUsuario.IdRol;
                db.SubmitChanges();
            }
        }
    }
}