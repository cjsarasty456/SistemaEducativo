using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaEducativo.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "¿Recordar este explorador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            FechaNacimiento = DateTime.Now;
            FechaVinculacion = DateTime.Now;
        }
        public string Id { get; set; }
        public string IdUser { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Departamento Expedición")]
        public string CodDepartamentoExpedicion { get; set; }

        [Required]
        [Display(Name = "Municipio Expedición")]
        public string CodMunicipioExpedicion { get; set; }
        [Required]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Fecha Vinculación")]
        public DateTime FechaVinculacion { get; set; }

        [Required]
        [Display(Name = "Tipo Vinculación")]
        public int idTipoVinculacion { get; set; }

        [Required]
        [Display(Name = "Zona Atender")]
        public string ZonaAtender { get; set; }

        [Required]
        [Display(Name = "Cargo Base")]
        public int CargoBase { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        [Required]
        [Display(Name = "Área Desempeño")]
        public List<int> AreaDesempeno { get; set; }

        [Required(ErrorMessage = "La institución Educativa es obligatoria")]
        [Display(Name = "Institución Educativa")]
        public int IdInstitucionEducativa { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required]
        [Display(Name = "Grado Escalafón")]
        public int GradoEscalafon { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        //[Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
    public class UpdateRegisterViewModel
    {
        public string Id { get; set; }
        public string IdUser { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Departamento Expedición")]
        public string CodDepartamentoExpedicion { get; set; }

        [Required]
        [Display(Name = "Municipio Expedición")]
        public string CodMunicipioExpedicion { get; set; }
        [Required]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Fecha Vinculación")]
        public DateTime FechaVinculacion { get; set; }

        [Required]
        [Display(Name = "Tipo Vinculación")]
        public int idTipoVinculacion { get; set; }

        [Required]
        [Display(Name = "Zona Atender")]
        public string ZonaAtender { get; set; }

        [Required]
        [Display(Name = "Cargo Base")]
        public int CargoBase { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        [Required]
        [Display(Name = "Área Desempeño")]
        public List<int> AreaDesempeno { get; set; }

        [Required(ErrorMessage = "La institución Educativa es obligatoria")]
        [Display(Name = "Institución Educativa")]
        public int IdInstitucionEducativa { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required]
        [Display(Name = "Grado Escalafón")]
        public int GradoEscalafon { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}