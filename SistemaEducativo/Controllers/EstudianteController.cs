using SistemaEducativo.Models.Constantes;
using SistemaEducativo.Models.Estudiante;
using SistemaEducativo.Models.General;
using SistemaEducativo.Models.Estudiante.Objetos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SistemaEducativo.Models.General.Objetos;

namespace SistemaEducativo.Controllers
{
    public class EstudianteController : Controller
    {
        public void CargarFormulario()
        {
            ViewData["TipoDocumento"] = TipoDocumento.ConsultaListaTipoDocumento();
            ViewData["Genero"] = Genero.ConsultaListaGenero();
            ViewData["Jornada"] = Jornada.ConsultaListaJornada();
            ViewData["InstitucionEducativa"] = InstitucionEducativaControlador.ConsultaListaInstitucionEducativa();
            ViewData["Sede"] = SedeControlador.ConsultaListaSedes();
            ViewData["Grado"] = Grado.ConsultaListaGrado();
            ViewData["Departamento"] = MunicipioControlador.ConsultaListaDepartamentos();
            ViewData["Municipio"] = MunicipioControlador.ConsultaListaMunicipio();
            ViewData["AfiliacionSalud"] = AfiliacionSalud.ConsultaListaAfiliacionSalud();
            ViewData["NivelEducativo"] = NivelEducativo.ConsultaListaNivelEducativo();
        }
        [Authorize]
        [HttpPost]
        public JsonResult ConsultaListaMunicipio(string CodDepartamento)
        {
            var Lista = MunicipioControlador.ConsultaListaMunicipioPorDepartamento(CodDepartamento);
            
            return Json(Lista);
        }
        [Authorize]
        [HttpPost]
        public JsonResult ConsultaEstudianteExiste(string TipoDocumento, string Documento)
        {
            var consulta = EstudianteControlador.ConsultaEstudiantePorDocumento(TipoDocumento, Documento);

            if (consulta != null)
            {
                return Json(consulta);
            }
            
            else {
                return Json(new ObjEstudiante());
            }
        }
        [Authorize]
        // GET: Estudiante
        public ActionResult Index(string TipoMensaje="", string TituloMensaje = "", string CuerpoMensaje = "")
        {
            ObjMensaje OMensaje = new ObjMensaje();
            OMensaje.tipoMensaje = TipoMensaje;
            OMensaje.TituloMensaje = TituloMensaje;
            OMensaje.CuerpoMensaje = CuerpoMensaje;
            ViewData["TipoDocumento"] = TipoDocumento.ConsultaListaTipoDocumento();
            ViewData["Sede"] = SedeControlador.ConsultaListaSedes();
            ViewData["Mensaje"] = OMensaje;
            return View();
        }
        [Authorize]
        // GET: Estudiante
        public ActionResult ListaEstudiante(string TipoDocumento, string Documento, int Sede=0, int pagina=1)
        {
            var Paginacion = new ObjPaginacion();
            Paginacion.PaginaActual = pagina;
            List<ObjEstudiante> estudiantes = EstudianteControlador.ConsultaListaEstudiante(ref Paginacion,TipoDocumento,Documento,Sede);
            ViewData["Paginacion"] = Paginacion;
            return View(estudiantes);
        }
        [Authorize]
        public ActionResult New()
        {
            CargarFormulario();
            return View();
        }
        [Authorize]
        public ActionResult ListaAjusteRazonable()
        {
            return View();
        }
        [Authorize]
        public ActionResult FormularioAjusteRazonable()
        {
            return View();
        }
        [Authorize]
        // GET: Estudiante/Details/5
        public ActionResult Details(string id, string VistaPrevia)
        {
            CargarFormulario();
            if (id != null)
            {
                var consulta = EstudianteControlador.ConsultaEstudiante(id);
                consulta.Edad = DateTime.Today.AddTicks(-consulta.FechaNacimiento.Ticks).Year - 1;
                ViewData["VistaPrevia"] = VistaPrevia;
                return View(consulta);
            }
            else
            {
                Redirect("/Estudiante/Index");
                return null;
            }
            
        }
        [Authorize]
        // GET: Estudiante/Details/5
        public ActionResult Editar(string id, string VistaPrevia)
        {
            CargarFormulario();
            if (id != null)
            {
                var consulta = EstudianteControlador.ConsultaEstudiante(id);
                consulta.Edad = DateTime.Today.AddTicks(-consulta.FechaNacimiento.Ticks).Year - 1;
                ViewData["VistaPrevia"] = VistaPrevia;
                return View(consulta);
            }
            else
            {
                Redirect("/Estudiante/Index");
                return null;
            }

        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(ObjEstudiante estudiante)
        {
            ObjMensaje Mensaje = new ObjMensaje();
            EstudianteControlador.EditarEstudiante(estudiante);
            return Redirect("index");
        }
        [HttpPost]
        public JsonResult New(ObjEstudiante estudiante)
        {
                ObjMensaje Mensaje = new ObjMensaje();
                EstudianteControlador.NuevoEstudiante(estudiante, ref Mensaje);
                return Json(Mensaje);
         
        }
        [Authorize]
        [HttpPost]
        public JsonResult Delete(string Id)
        {
            ObjMensaje Mensaje = new ObjMensaje();
            EstudianteControlador.Eliminar(Id, ref Mensaje);
            //Response.Redirect("~/Estudiante/index");
            return Json(Mensaje);
        }
    }
}