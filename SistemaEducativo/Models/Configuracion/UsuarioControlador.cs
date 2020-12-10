using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaEducativo.Models.Configuracion
{
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
        public int IdUser { get; set; }
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
        [Required]
        public int IdTipoVinculacion { get; set; }
        [Required]
        public DateTime FechaVinculacion { get; set; }
        public string ZonaAtender { get; set; }
        public string CargoBase { get; set; }
        public int Nivel { get; set; }
        public int GradoEscalafon { get; set; }
        public string Titulo { get; set; }
        public int IdRol { get; set; }


    }

    public class UsuarioControlador
    {
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
        public void NuevoUsuario(ViewUsuario Usuario)
        {

        }
    }
}