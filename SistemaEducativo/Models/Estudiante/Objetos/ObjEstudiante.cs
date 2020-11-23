using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaEducativo.Models.Estudiante
{
    public class ObjEstudiante
    {
        public string Id { get; set; }
        //cabecera
        public DateTime FechaDiligencia { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string DepartamentoDiligencia { get; set; }
        public string MunicipioDiligencia { get; set; }
        public string NombreApellidoDiligencia { get; set; }
        public string RolDiligencia { get; set; }
        //información general
        [Required]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string DepartamentoNacimiento { get; set; }
        [Required]
        public string MunicipioNacimiento { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        [Required]
        [Display (Name ="Documento de identidad")]
        [MinLength (5, ErrorMessage ="La longitud minima debe ser 5")]
        [MaxLength(30, ErrorMessage = "La longitud minima debe ser 30")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string DocumentoIdentidad { get; set; }
        public string DepartamentoDomicilio { get; set; }
        public string MunicipioDomicilio { get; set; }
        public string Direccion { get; set; }
        public string BarrioVereda { get; set; }
        public string Telefono { get; set; }
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Ingreso un Correo Valido")]
        public string CorreoElectronico { get; set; }
        public bool ModalidadProtección { get; set; }
        public string ModalidadProtecciónCual { get; set; }
        public string Grado { get; set; }
        public string Ocupacion { get; set; }
        public bool GrupoEtnico { get; set; }
        public string GrupoEtnicoCual { get; set; }
        public bool VictimaConflictoArmado { get; set; }
        public bool VictimaConflictoArmadoCertificado { get; set; }
        public bool Discapacidad { get; set; }
        public bool DiscapacidadCertificado { get; set; }
        public bool RegistroCaracterizacionDiscapacidad { get; set; }
        public string Genero { get; set; }
        //Entorno Salud
        public string AfiliacionSistemaSalud { get; set; }
        //public string CodigoEPS { get; set; }
        public string EPS { get; set; }
        public bool AtendidoSalud { get; set; }
        public string AtendidoSaludCual { get; set; }
        public int? AtendidoSaludFrecuencia { get; set; }
        public bool DiagnosticoMedico { get; set; }
        public string DiagnosticoMedicoCual { get; set; }
        public bool TerapiaMedica { get; set; }
        public string TerapiaMedicaCual { get; set; }
        public int TerapiaMedicaFrecuencia { get; set; }
        //falta acomodar tres opciones de las terapias
        public bool RecibeTratamientoMedico { get; set; }
        public string RecibeTratamientoMedicoCual { get; set; }
        public bool ConsumeMedicamento { get; set; }
        public int ConsumeMedicamentoFrecuencia { get; set; }
        public string ConsumeMedicamentoHorario { get; set; }
        public string NombreMedicamento { get; set; }
        public string ConsumeMedicamentoHorarioClase { get; set; }
        public bool ElementoApoyo { get; set; }
        public string ElementoApoyoCual { get; set; }
        //Entorno Hogar
        public bool DependenciaPersona { get; set; }
        public string DependenciaPersonaQuien { get; set; }
        public string DependenciaPersonaNivelEducativo { get; set; }
        public bool PersonaCargo { get; set; }
        public string PersonaCargoQuien { get; set; }
        public string PersonaCuidadoraNombre { get; set; }
        public string PersonaCuidadoraParentesco { get; set; }
        public string PersonaCuidadoraNivelEducativo { get; set; }
        public string PersonaCuidadoraTelefono { get; set; }
        public string PersonaCuidadoraEmail { get; set; }
        public string NombrePersonaCrianza { get; set; }
        public bool RecibeSubsidio { get; set; }
        public string RecibeSubsidioCual { get; set; }
        //Entorno Educativo
        public bool MatriculadoInstitucionAnterior { get; set; }
        public string MatriculadoInstitucionAnteriorCual { get; set; }
        public string MatriculadoInstitucionAnteriorPorque { get; set; }
        public int CuantoSinEstudiar { get; set; }
        public string QueAprendio { get; set; }
        public string UltimoGrado { get; set; }
        public bool Aprobo { get; set; }
        public string ObervacionCambio { get; set; }
        public string RazonNoEstudio { get; set; }
        public bool ProgramasComplementario { get; set; }
        public string ProgramasComplementarioCual { get; set; }
        // Información Institución Educativa
        public int IdInstitucion { get; set; }
        public string Institucion { get; set; }
        public string Jornada { get; set; }
        public int IdSede { get; set; }
        public string NombreSede { get; set; }
        //Modelo?
        public string MedioTransporte { get; set; }
        public bool Eliminado { get; set; }
    }
}