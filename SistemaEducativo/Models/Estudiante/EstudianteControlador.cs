using SistemaEducativo.Models.Estudiante.Objetos;
using SistemaEducativo.Models.General;
using SistemaEducativo.Models.General.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Authentication;
using System.Web;


namespace SistemaEducativo.Models.Estudiante
{
    public class EstudianteControlador
    {
        public EstudianteControlador()
        {

        }
        public static List<ObjEstudiante> ConsultaListaEstudiante(ref ObjPaginacion Paginacion,string TipoDocumento, string Documento, int Sede )
        {
            //List<ObjEstudiante> Estudiantes = null;
            using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
            {
                var consulta = from E in db.Estudiante
                                orderby E.PrimerApellido ascending
                                where E.Eliminado == false
                                select new ObjEstudiante
                                {
                                    Id = E.id,
                                    TipoDocumentoIdentidad = E.TipoDocumentoIdentidad,
                                    DocumentoIdentidad = E.DocumentoIdentidad,
                                    PrimerNombre = E.PrimerNombre,
                                    SegundoNombre = E.SegundoNombre,
                                    PrimerApellido = E.PrimerApellido,
                                    SegundoApellido = E.SegundoApellido,
                                    Genero = E.Genero,
                                    Grado=E.Grado,
                                    IdSede=E.IdSede,
                                    NombreSede = SedeControlador.ConsultaSede(E.IdSede).Nombre,
                                    Jornada = E.Jornada
                                    
                                };
                if (TipoDocumento != "")
                    consulta = consulta.Where(E => E.TipoDocumentoIdentidad == TipoDocumento);
                if (Documento != "")
                    consulta = consulta.Where(E => E.DocumentoIdentidad.Contains(Documento));
                if (Sede != 0)
                    consulta = consulta.Where(E => E.IdSede == Sede);
                Paginacion.TotalRegistros = consulta.Count();
                consulta = consulta.Skip((Paginacion.PaginaActual-1) * Paginacion.RegistrosPagina);
                consulta = consulta.Take(Paginacion.RegistrosPagina);
                return consulta.ToList();
            }
        }
        public static ObjEstudiante ConsultaEstudiante(string id)
        {
            using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
            {
                var consulta = from E in db.Estudiante
                               where E.id.Equals(id)
                               select new ObjEstudiante
                               {
                                   Id = E.id,
                                   TipoDocumentoIdentidad = E.TipoDocumentoIdentidad,
                                   DocumentoIdentidad = E.DocumentoIdentidad,
                                   PrimerNombre = E.PrimerNombre,
                                   SegundoNombre = E.SegundoNombre,
                                   PrimerApellido = E.PrimerApellido,
                                   SegundoApellido = E.SegundoApellido,
                                   Genero = E.Genero,
                                   FechaNacimiento = E.FechaNacimiento,
                                   DepartamentoNacimiento = E.DepartamentoNacimiento,
                                   MunicipioNacimiento = E.MunicipioNacimiento,
                                   DepartamentoDomicilio = E.DepartamentoDomicilio,
                                   MunicipioDomicilio = E.MunicipioDomicilio,
                                   Direccion = E.Direccion,
                                   BarrioVereda = E.BarrioVereda,
                                   Telefono = E.Telefono,
                                   CorreoElectronico = E.CorreoElectronico,
                                   ModalidadProtección = E.ModalidadProteccion.GetValueOrDefault(false),
                                   ModalidadProtecciónCual = E.ModalidadProtecciónCual,
                                   Grado = E.Grado,
                                   Ocupacion = E.Ocupacion,
                                   GrupoEtnico = E.GrupoEtnico.GetValueOrDefault(false),
                                   GrupoEtnicoCual = E.GrupoEtnicoCual,
                                   VictimaConflictoArmado = E.VictimaConflictoArmado.GetValueOrDefault(false),
                                   VictimaConflictoArmadoCertificado = E.VictimaConflictoArmadoCertificado.GetValueOrDefault(false),
                                   Discapacidad = E.Discapacidad.GetValueOrDefault(false),
                                   DiscapacidadCertificado = E.DiscapacidadCertificado.GetValueOrDefault(false),
                                   RegistroCaracterizacionDiscapacidad = E.RegistroCaracterizacionDiscapacidad.GetValueOrDefault(false),
                                   AfiliacionSistemaSalud = E.AfiliacionSistemaSalud,
                                   EPS = E.EPS,
                                   AtendidoSalud = E.AtendidoSalud.GetValueOrDefault(false),
                                   AtendidoSaludCual = E.AtendidoSaludCual,
                                   AtendidoSaludFrecuencia = E.AtendidoSaludFrecuencia,
                                   DiagnosticoMedico = E.DiagnosticoMedico.GetValueOrDefault(false),
                                   DiagnosticoMedicoCual = E.DiagnosticoMedicoCual,
                                   TerapiaMedica = E.TerapiaMedica.GetValueOrDefault(false),
                                   TerapiaMedicaCual = E.TerapiaMedicaCual,
                                   TerapiaMedicaFrecuencia = E.TerapiaMedicaFrecuencia.GetValueOrDefault(0),
                                   RecibeTratamientoMedico = E.RecibeTratamientoMedico.GetValueOrDefault(false),
                                   RecibeTratamientoMedicoCual = E.RecibeTratamientoMedicoCual,
                                   ConsumeMedicamento = E.ConsumeMedicamento.GetValueOrDefault(false),
                                   ConsumeMedicamentoFrecuencia = E.ConsumeMedicamentoFrecuencia.GetValueOrDefault(0),
                                   ConsumeMedicamentoHorarioClase = E.ConsumeMedicamentoHorarioClase,
                                   NombreMedicamento = E.NombreMedicamento,
                                   ElementoApoyo = E.ElementoApoyo.GetValueOrDefault(false),
                                   ElementoApoyoCual = E.ElementoApoyoCual,
                                   DependenciaPersona = E.DependenciaPersona.GetValueOrDefault(false),
                                   DependenciaPersonaNivelEducativo = E.DependenciaPersonaNivelEducativo,
                                   DependenciaPersonaQuien = E.DependenciaPersonaQuien,
                                   PersonaCargo = E.PersonaCargo.GetValueOrDefault(false),
                                   PersonaCargoQuien = E.PersonaCargoQuien,
                                   PersonaCuidadoraNombre = E.PersonaCuidadoraNombre,
                                   PersonaCuidadoraParentesco = E.PersonaCuidadoraParentesco,
                                   PersonaCuidadoraNivelEducativo = E.PersonaCuidadoraNivelEducativo,
                                   PersonaCuidadoraTelefono = E.PersonaCuidadoraTelefono,
                                   PersonaCuidadoraEmail = E.PersonaCuidadoraEmail,
                                   NombrePersonaCrianza = E.NombrePersonaCrianza,
                                   RecibeSubsidio = E.RecibeSubsidio.GetValueOrDefault(false),
                                   RecibeSubsidioCual = E.RecibeSubsidioCual,
                                   MatriculadoInstitucionAnterior = E.MatriculadoInstitucionAnterior.GetValueOrDefault(false),
                                   MatriculadoInstitucionAnteriorCual = E.MatriculadoInstitucionAnteriorCual,
                                   MatriculadoInstitucionAnteriorPorque = E.MatriculadoInstitucionAnteriorPorque,
                                   CuantoSinEstudiar = E.CuantoSinEstudiar.GetValueOrDefault(0),
                                   QueAprendio = E.QueAprendio,
                                   UltimoGrado = E.UltimoGrado,
                                   Aprobo = E.Aprobo.GetValueOrDefault(false),
                                   ObervacionCambio = E.ObservacionCambio,
                                   RazonNoEstudio = E.RazonNoEstudio,
                                   ProgramasComplementario = E.ProgramaComplementario.GetValueOrDefault(false),
                                   ProgramasComplementarioCual = E.ProgramaComplementarioCual,
                                   IdInstitucion = E.IdInstitucion,
                                   IdSede = E.IdSede,
                                   NombreSede = SedeControlador.ConsultaSede(E.IdSede).Nombre,
                                   Jornada = E.Jornada,
                                   MedioTransporte = E.MedioTransporte,
                                   FechaDiligencia = E.FechaDiligencia.GetValueOrDefault(),
                                   FechaModificacion = E.FechaModificacion.GetValueOrDefault(),
                                   DepartamentoDiligencia = E.DepartamentoDiligencia,
                                   MunicipioDiligencia = E.MunicipioDiligencia,
                                   NombreApellidoDiligencia = E.NombreApellidoDiligencia,
                                   RolDiligencia = E.RolDiligencia,
                                   Eliminado = E.Eliminado
                               };
                return consulta.FirstOrDefault();
            }
        }
        public static ObjEstudiante ConsultaEstudiantePorDocumento(string TipoDocumento,string Numerodocumento)
        {
            using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
            {
                var consulta = from E in db.Estudiante
                               where E.TipoDocumentoIdentidad.Equals(TipoDocumento) && E.DocumentoIdentidad.Equals(Numerodocumento)
                               select new ObjEstudiante
                               {
                                   Id = E.id,
                                   TipoDocumentoIdentidad = E.TipoDocumentoIdentidad,
                                   DocumentoIdentidad = E.DocumentoIdentidad,
                                   PrimerNombre = E.PrimerNombre,
                                   SegundoNombre = E.SegundoNombre,
                                   PrimerApellido = E.PrimerApellido,
                                   SegundoApellido = E.SegundoApellido,
                                   Genero = E.Genero,
                                   FechaNacimiento = E.FechaNacimiento,
                                   DepartamentoNacimiento = E.DepartamentoNacimiento,
                                   MunicipioNacimiento = E.MunicipioNacimiento,
                                   DepartamentoDomicilio = E.DepartamentoDomicilio,
                                   MunicipioDomicilio = E.MunicipioDomicilio,
                                   Direccion = E.Direccion,
                                   BarrioVereda = E.BarrioVereda,
                                   Telefono = E.Telefono,
                                   CorreoElectronico = E.CorreoElectronico,
                                   ModalidadProtección = E.ModalidadProteccion.GetValueOrDefault(false),
                                   ModalidadProtecciónCual = E.ModalidadProtecciónCual,
                                   Grado = E.Grado,
                                   Ocupacion = E.Ocupacion,
                                   GrupoEtnico = E.GrupoEtnico.GetValueOrDefault(false),
                                   GrupoEtnicoCual = E.GrupoEtnicoCual,
                                   VictimaConflictoArmado = E.VictimaConflictoArmado.GetValueOrDefault(false),
                                   VictimaConflictoArmadoCertificado = E.VictimaConflictoArmadoCertificado.GetValueOrDefault(false),
                                   Discapacidad = E.Discapacidad.GetValueOrDefault(false),
                                   DiscapacidadCertificado = E.DiscapacidadCertificado.GetValueOrDefault(false),
                                   RegistroCaracterizacionDiscapacidad = E.RegistroCaracterizacionDiscapacidad.GetValueOrDefault(false),
                                   AfiliacionSistemaSalud = E.AfiliacionSistemaSalud,
                                   EPS = E.EPS,
                                   AtendidoSalud = E.AtendidoSalud.GetValueOrDefault(false),
                                   AtendidoSaludCual = E.AtendidoSaludCual,
                                   DiagnosticoMedico = E.DiagnosticoMedico.GetValueOrDefault(false),
                                   DiagnosticoMedicoCual = E.DiagnosticoMedicoCual,
                                   TerapiaMedica = E.TerapiaMedica.GetValueOrDefault(false),
                                   TerapiaMedicaCual = E.TerapiaMedicaCual,
                                   TerapiaMedicaFrecuencia = E.TerapiaMedicaFrecuencia.GetValueOrDefault(0),
                                   RecibeTratamientoMedico = E.RecibeTratamientoMedico.GetValueOrDefault(false),
                                   RecibeTratamientoMedicoCual = E.RecibeTratamientoMedicoCual,
                                   ConsumeMedicamento = E.ConsumeMedicamento.GetValueOrDefault(false),
                                   ConsumeMedicamentoFrecuencia = E.ConsumeMedicamentoFrecuencia.GetValueOrDefault(0),
                                   ConsumeMedicamentoHorarioClase = E.ConsumeMedicamentoHorarioClase,
                                   NombreMedicamento = E.NombreMedicamento,
                                   ElementoApoyo = E.ElementoApoyo.GetValueOrDefault(false),
                                   ElementoApoyoCual = E.ElementoApoyoCual,
                                   DependenciaPersona = E.DependenciaPersona.GetValueOrDefault(false),
                                   DependenciaPersonaNivelEducativo = E.DependenciaPersonaNivelEducativo,
                                   DependenciaPersonaQuien = E.DependenciaPersonaQuien,
                                   PersonaCargo = E.PersonaCargo.GetValueOrDefault(false),
                                   PersonaCargoQuien = E.PersonaCargoQuien,
                                   PersonaCuidadoraNombre = E.PersonaCuidadoraNombre,
                                   PersonaCuidadoraParentesco = E.PersonaCuidadoraParentesco,
                                   PersonaCuidadoraNivelEducativo = E.PersonaCuidadoraNivelEducativo,
                                   PersonaCuidadoraTelefono = E.PersonaCuidadoraTelefono,
                                   PersonaCuidadoraEmail = E.PersonaCuidadoraEmail,
                                   NombrePersonaCrianza = E.NombrePersonaCrianza,
                                   RecibeSubsidio = E.RecibeSubsidio.GetValueOrDefault(false),
                                   RecibeSubsidioCual = E.RecibeSubsidioCual,
                                   MatriculadoInstitucionAnterior = E.MatriculadoInstitucionAnterior.GetValueOrDefault(false),
                                   MatriculadoInstitucionAnteriorCual = E.MatriculadoInstitucionAnteriorCual,
                                   MatriculadoInstitucionAnteriorPorque = E.MatriculadoInstitucionAnteriorPorque,
                                   CuantoSinEstudiar = E.CuantoSinEstudiar.GetValueOrDefault(0),
                                   QueAprendio = E.QueAprendio,
                                   UltimoGrado = E.UltimoGrado,
                                   Aprobo = E.Aprobo.GetValueOrDefault(false),
                                   ObervacionCambio = E.ObservacionCambio,
                                   RazonNoEstudio = E.RazonNoEstudio,
                                   ProgramasComplementario = E.ProgramaComplementario.GetValueOrDefault(false),
                                   ProgramasComplementarioCual = E.ProgramaComplementarioCual,
                                   IdInstitucion = E.IdInstitucion,
                                   IdSede = E.IdSede,
                                   NombreSede = SedeControlador.ConsultaSede(E.IdSede).Nombre,
                                   Jornada = E.Jornada,
                                   MedioTransporte = E.MedioTransporte,
                                   FechaDiligencia = E.FechaDiligencia.GetValueOrDefault(),
                                   FechaModificacion = E.FechaModificacion.GetValueOrDefault(),
                                   DepartamentoDiligencia = E.DepartamentoDiligencia,
                                   MunicipioDiligencia = E.MunicipioDiligencia,
                                   NombreApellidoDiligencia = E.NombreApellidoDiligencia,
                                   RolDiligencia = E.RolDiligencia,
                                   Eliminado = E.Eliminado
                               };
                return consulta.FirstOrDefault();
            }
        }
        public static void NuevoEstudiante(ObjEstudiante ObjEstudiante, ref ObjMensaje mensaje)
        {
            using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
            {
                try
                {
                    var existeEstudiante = ConsultaEstudiantePorDocumento(ObjEstudiante.TipoDocumentoIdentidad, ObjEstudiante.DocumentoIdentidad);
                    if (existeEstudiante == null)
                    {
                        IQueryable<Estudiante> Consulta = null;
                        do
                        {
                            ObjEstudiante.Id = Guid.NewGuid().ToString();
                            Consulta = from E in db.Estudiante
                                       where E.id.Equals(ObjEstudiante.Id)
                                       select E;
                        } while (Consulta.Count() > 0);
                        Estudiante estudiante = new Estudiante();
                        estudiante.id = ObjEstudiante.Id;
                        estudiante.TipoDocumentoIdentidad = ObjEstudiante.TipoDocumentoIdentidad;
                        estudiante.DocumentoIdentidad = ObjEstudiante.DocumentoIdentidad;
                        estudiante.PrimerNombre = ObjEstudiante.PrimerNombre;
                        estudiante.SegundoNombre = ObjEstudiante.SegundoNombre;
                        estudiante.PrimerApellido = ObjEstudiante.PrimerApellido;
                        estudiante.SegundoApellido = ObjEstudiante.SegundoApellido;
                        estudiante.Genero = ObjEstudiante.Genero;
                        estudiante.FechaNacimiento = Convert.ToDateTime(ObjEstudiante.FechaNacimiento);
                        estudiante.IdInstitucion = ObjEstudiante.IdInstitucion;
                        estudiante.Jornada = ObjEstudiante.Jornada;
                        estudiante.IdSede = ObjEstudiante.IdSede;
                        estudiante.Grado = ObjEstudiante.Grado;

                        estudiante.DepartamentoNacimiento = "";
                        estudiante.MunicipioNacimiento = "";
                        estudiante.DepartamentoDomicilio = "";
                        estudiante.MunicipioDomicilio = "";
                        estudiante.Direccion = "";
                        estudiante.BarrioVereda = "";
                        estudiante.Telefono = "";
                        estudiante.CorreoElectronico = "";
                        estudiante.ModalidadProteccion = false;
                        estudiante.ModalidadProtecciónCual = "";
                        estudiante.Ocupacion = "";
                        estudiante.GrupoEtnico = false;
                        estudiante.GrupoEtnicoCual = "";
                        estudiante.VictimaConflictoArmado = false;
                        estudiante.VictimaConflictoArmadoCertificado = false;
                        estudiante.Discapacidad = false;
                        estudiante.DiscapacidadCertificado = false;
                        estudiante.RegistroCaracterizacionDiscapacidad = false;
                        estudiante.AfiliacionSistemaSalud ="";
                        estudiante.EPS = "";
                        estudiante.AtendidoSalud = false;
                        estudiante.AtendidoSaludCual = "";
                        estudiante.AtendidoSaludFrecuencia = 0;
                        estudiante.DiagnosticoMedico = false;
                        estudiante.DiagnosticoMedicoCual = "";
                        estudiante.TerapiaMedica = false;
                        estudiante.TerapiaMedicaCual = ObjEstudiante.TerapiaMedicaCual;
                        estudiante.TerapiaMedicaFrecuencia = ObjEstudiante.TerapiaMedicaFrecuencia;
                        estudiante.RecibeTratamientoMedico = false;
                        estudiante.RecibeTratamientoMedicoCual = ObjEstudiante.RecibeTratamientoMedicoCual;
                        estudiante.ConsumeMedicamento = ObjEstudiante.ConsumeMedicamento;
                        estudiante.ConsumeMedicamentoFrecuencia = ObjEstudiante.ConsumeMedicamentoFrecuencia;
                        estudiante.ConsumeMedicamentoHorarioClase = ObjEstudiante.ConsumeMedicamentoHorarioClase;
                        estudiante.NombreMedicamento = ObjEstudiante.NombreMedicamento;
                        estudiante.ElementoApoyo = false;
                        estudiante.ElementoApoyoCual = ObjEstudiante.ElementoApoyoCual;
                        estudiante.DependenciaPersona = false;
                        estudiante.DependenciaPersonaNivelEducativo = ObjEstudiante.DependenciaPersonaNivelEducativo;
                        estudiante.DependenciaPersonaQuien = ObjEstudiante.DependenciaPersonaQuien;
                        estudiante.PersonaCargo = ObjEstudiante.PersonaCargo;
                        estudiante.PersonaCargoQuien = ObjEstudiante.PersonaCargoQuien;
                        estudiante.PersonaCuidadoraNombre = ObjEstudiante.PersonaCuidadoraNombre;
                        estudiante.PersonaCuidadoraParentesco = ObjEstudiante.PersonaCuidadoraParentesco;
                        estudiante.PersonaCuidadoraNivelEducativo = ObjEstudiante.PersonaCuidadoraNivelEducativo;
                        estudiante.PersonaCuidadoraTelefono = ObjEstudiante.PersonaCuidadoraTelefono;
                        estudiante.PersonaCuidadoraEmail = ObjEstudiante.PersonaCuidadoraEmail;
                        estudiante.NombrePersonaCrianza = ObjEstudiante.NombrePersonaCrianza;
                        estudiante.RecibeSubsidio = ObjEstudiante.RecibeSubsidio;
                        estudiante.RecibeSubsidioCual = ObjEstudiante.RecibeSubsidioCual;
                        estudiante.MatriculadoInstitucionAnterior = ObjEstudiante.MatriculadoInstitucionAnterior;
                        estudiante.MatriculadoInstitucionAnteriorCual = ObjEstudiante.MatriculadoInstitucionAnteriorCual;
                        estudiante.MatriculadoInstitucionAnteriorPorque = ObjEstudiante.MatriculadoInstitucionAnteriorPorque;
                        estudiante.CuantoSinEstudiar = ObjEstudiante.CuantoSinEstudiar;
                        estudiante.QueAprendio = ObjEstudiante.QueAprendio;
                        estudiante.UltimoGrado = ObjEstudiante.UltimoGrado;
                        estudiante.Aprobo = ObjEstudiante.Aprobo;
                        estudiante.ObservacionCambio = ObjEstudiante.ObervacionCambio;
                        estudiante.RazonNoEstudio = ObjEstudiante.RazonNoEstudio;
                        estudiante.ProgramaComplementario = ObjEstudiante.ProgramasComplementario;
                        estudiante.ProgramaComplementarioCual = ObjEstudiante.ProgramasComplementarioCual;
                        estudiante.IdInstitucion = ObjEstudiante.IdInstitucion;
                        estudiante.IdSede = ObjEstudiante.IdSede;
                        estudiante.Jornada = ObjEstudiante.Jornada;
                        estudiante.Grado = ObjEstudiante.Grado;
                        estudiante.MedioTransporte = ObjEstudiante.MedioTransporte;
                        estudiante.FechaDiligencia = DateTime.Now;
                        estudiante.FechaModificacion = DateTime.Now;
                        estudiante.DepartamentoDiligencia = ObjEstudiante.DepartamentoDiligencia;
                        estudiante.MunicipioDiligencia = ObjEstudiante.MunicipioDiligencia;
                        estudiante.NombreApellidoDiligencia = ObjEstudiante.NombreApellidoDiligencia;
                        estudiante.RolDiligencia = ObjEstudiante.RolDiligencia;
                        estudiante.Eliminado = ObjEstudiante.Eliminado;


                        db.Estudiante.InsertOnSubmit(estudiante);
                        db.SubmitChanges();
                    }
                    else
                    {
                        mensaje.TituloMensaje = "Alerta";
                        mensaje.tipoMensaje = TipoMensaje.warning;
                        mensaje.CuerpoMensaje = "El registro no se ha guardado porqué El estudiante ya existe";
                    }
                }
                catch (Exception e)
                {
                    mensaje.TituloMensaje = "Error";
                    mensaje.tipoMensaje = TipoMensaje.danger;
                    mensaje.CuerpoMensaje = "No se guardó el estudiante";
                }
            }
        }

        public static string EditarEstudiante(ObjEstudiante ObjEstudiante)
        {
            using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
            {
                string MensajeError = "";
                try
                {
                        var estudiante = (from e in db.Estudiante
                                          where e.id.Equals(ObjEstudiante.Id)
                                          select e
                                        ).FirstOrDefault();
                        //información General
                        estudiante.TipoDocumentoIdentidad = ObjEstudiante.TipoDocumentoIdentidad;
                        estudiante.DocumentoIdentidad = ObjEstudiante.DocumentoIdentidad;
                        estudiante.PrimerNombre = ObjEstudiante.PrimerNombre;
                        estudiante.SegundoNombre = ObjEstudiante.SegundoNombre;
                        estudiante.PrimerApellido = ObjEstudiante.PrimerApellido;
                        estudiante.SegundoApellido = ObjEstudiante.SegundoApellido;
                        estudiante.Genero = ObjEstudiante.Genero;
                        estudiante.FechaNacimiento = Convert.ToDateTime(ObjEstudiante.FechaNacimiento);
                        estudiante.DepartamentoNacimiento = ObjEstudiante.DepartamentoNacimiento;
                        estudiante.MunicipioNacimiento = ObjEstudiante.MunicipioNacimiento;
                        estudiante.DepartamentoDomicilio = ObjEstudiante.DepartamentoDomicilio;
                        estudiante.MunicipioDomicilio = ObjEstudiante.MunicipioDomicilio;
                        estudiante.Direccion = ObjEstudiante.Direccion;
                        estudiante.BarrioVereda = ObjEstudiante.BarrioVereda;
                        estudiante.Telefono = ObjEstudiante.Telefono;
                        estudiante.CorreoElectronico = ObjEstudiante.CorreoElectronico;
                        estudiante.ModalidadProteccion = ObjEstudiante.ModalidadProtección;
                        estudiante.ModalidadProtecciónCual = ObjEstudiante.ModalidadProtecciónCual;
                        estudiante.Ocupacion = ObjEstudiante.Ocupacion;
                        estudiante.GrupoEtnico = ObjEstudiante.GrupoEtnico;
                        estudiante.GrupoEtnicoCual = ObjEstudiante.GrupoEtnicoCual;
                        estudiante.VictimaConflictoArmado = ObjEstudiante.VictimaConflictoArmado;
                        estudiante.VictimaConflictoArmadoCertificado = ObjEstudiante.VictimaConflictoArmadoCertificado;
                        estudiante.Discapacidad = ObjEstudiante.Discapacidad;
                        estudiante.DiscapacidadCertificado = ObjEstudiante.DiscapacidadCertificado;
                        estudiante.RegistroCaracterizacionDiscapacidad = ObjEstudiante.RegistroCaracterizacionDiscapacidad;
                    //entorno Salud
                        estudiante.AfiliacionSistemaSalud = ObjEstudiante.AfiliacionSistemaSalud;
                        estudiante.EPS = ObjEstudiante.EPS;
                        estudiante.AtendidoSalud = ObjEstudiante.AtendidoSalud;
                        estudiante.AtendidoSaludCual = ObjEstudiante.AtendidoSaludCual;
                        estudiante.AtendidoSaludFrecuencia = ObjEstudiante.AtendidoSaludFrecuencia;
                        estudiante.DiagnosticoMedico = ObjEstudiante.DiagnosticoMedico;
                        estudiante.DiagnosticoMedicoCual = ObjEstudiante.DiagnosticoMedicoCual;
                        estudiante.TerapiaMedica = ObjEstudiante.TerapiaMedica;
                        estudiante.TerapiaMedicaCual = ObjEstudiante.TerapiaMedicaCual;
                        estudiante.TerapiaMedicaFrecuencia = ObjEstudiante.TerapiaMedicaFrecuencia;
                        estudiante.RecibeTratamientoMedico = ObjEstudiante.RecibeTratamientoMedico;
                        estudiante.RecibeTratamientoMedicoCual = ObjEstudiante.RecibeTratamientoMedicoCual;
                        estudiante.ConsumeMedicamento = ObjEstudiante.ConsumeMedicamento;
                        estudiante.ConsumeMedicamentoFrecuencia = ObjEstudiante.ConsumeMedicamentoFrecuencia;
                        estudiante.ConsumeMedicamentoHorarioClase = ObjEstudiante.ConsumeMedicamentoHorarioClase;
                        estudiante.NombreMedicamento = ObjEstudiante.NombreMedicamento;
                        estudiante.ElementoApoyo = ObjEstudiante.ElementoApoyo;
                        estudiante.ElementoApoyoCual = ObjEstudiante.ElementoApoyoCual;
                        estudiante.DependenciaPersona = ObjEstudiante.DependenciaPersona;
                        estudiante.DependenciaPersonaNivelEducativo = ObjEstudiante.DependenciaPersonaNivelEducativo;
                        estudiante.DependenciaPersonaQuien = ObjEstudiante.DependenciaPersonaQuien;
                        estudiante.PersonaCargo = ObjEstudiante.PersonaCargo;
                        estudiante.PersonaCargoQuien = ObjEstudiante.PersonaCargoQuien;
                        estudiante.PersonaCuidadoraNombre = ObjEstudiante.PersonaCuidadoraNombre;
                        estudiante.PersonaCuidadoraParentesco = ObjEstudiante.PersonaCuidadoraParentesco;
                        estudiante.PersonaCuidadoraNivelEducativo = ObjEstudiante.PersonaCuidadoraNivelEducativo;
                        estudiante.PersonaCuidadoraTelefono = ObjEstudiante.PersonaCuidadoraTelefono;
                        estudiante.PersonaCuidadoraEmail = ObjEstudiante.PersonaCuidadoraEmail;
                        estudiante.NombrePersonaCrianza = ObjEstudiante.NombrePersonaCrianza;
                        estudiante.RecibeSubsidio = ObjEstudiante.RecibeSubsidio;
                        estudiante.RecibeSubsidioCual = ObjEstudiante.RecibeSubsidioCual;
                        estudiante.MatriculadoInstitucionAnterior = ObjEstudiante.MatriculadoInstitucionAnterior;
                        estudiante.MatriculadoInstitucionAnteriorCual = ObjEstudiante.MatriculadoInstitucionAnteriorCual;
                        estudiante.MatriculadoInstitucionAnteriorPorque = ObjEstudiante.MatriculadoInstitucionAnteriorPorque;
                        estudiante.CuantoSinEstudiar = ObjEstudiante.CuantoSinEstudiar;
                        estudiante.QueAprendio = ObjEstudiante.QueAprendio;
                        estudiante.UltimoGrado = ObjEstudiante.UltimoGrado;
                        estudiante.Aprobo = ObjEstudiante.Aprobo;
                        estudiante.ObservacionCambio = ObjEstudiante.ObervacionCambio;
                        estudiante.RazonNoEstudio = ObjEstudiante.RazonNoEstudio;
                        estudiante.ProgramaComplementario = ObjEstudiante.ProgramasComplementario;
                        estudiante.ProgramaComplementarioCual = ObjEstudiante.ProgramasComplementarioCual;
                        estudiante.IdInstitucion = ObjEstudiante.IdInstitucion;
                        estudiante.IdSede = ObjEstudiante.IdSede;
                        estudiante.Jornada = ObjEstudiante.Jornada;
                        estudiante.Grado = ObjEstudiante.Grado;
                        estudiante.MedioTransporte = ObjEstudiante.MedioTransporte;
                        estudiante.FechaDiligencia = ObjEstudiante.FechaDiligencia;
                        estudiante.FechaModificacion = DateTime.Now;
                        estudiante.DepartamentoDiligencia = ObjEstudiante.DepartamentoDiligencia;
                        estudiante.MunicipioDiligencia = ObjEstudiante.MunicipioDiligencia;
                        estudiante.NombreApellidoDiligencia = ObjEstudiante.NombreApellidoDiligencia;
                        estudiante.RolDiligencia = ObjEstudiante.RolDiligencia;
                        estudiante.Eliminado = ObjEstudiante.Eliminado;
                        db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MensajeError = e.ToString();
                }
                return MensajeError;
            }
        }
        public static void Eliminar(string Id,ref ObjMensaje Mensaje)
        {
            try
            {
                using (ModelEstudianteDataContext db = new ModelEstudianteDataContext())
                {
                    var estudiante = (from e in db.Estudiante
                                      where e.id.Equals(Id)
                                      select e
                                          ).FirstOrDefault();
                    estudiante.FechaModificacion = DateTime.Now;
                    estudiante.Eliminado = true;
                    db.SubmitChanges();
                }

                Mensaje.TituloMensaje = "Excelente";
                Mensaje.CuerpoMensaje = "El registro del estudiante se eliminó correctamente";
                Mensaje.tipoMensaje = TipoMensaje.success;
            }
            catch (Exception E)
            {
                Mensaje.TituloMensaje = "Error";
                Mensaje.CuerpoMensaje = "Error al eliminar: "+E.ToString();
                Mensaje.tipoMensaje = TipoMensaje.danger;
            }
        }
    }
}