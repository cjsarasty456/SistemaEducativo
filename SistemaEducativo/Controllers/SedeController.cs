using SistemaEducativo.Models.Constantes;
using SistemaEducativo.Models.Estudiante;
using SistemaEducativo.Models.General;
using SistemaEducativo.Models.Estudiante.Objetos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SistemaEducativo.Controllers
{
    public class SedeController : Controller
    {
        [Authorize]
        public ActionResult ListaSedes(int pagina = 1)
        {
            var Paginacion = new ObjPaginacion();
            Paginacion.PaginaActual = pagina;
            var ListaSedes = SedeControlador.ConsultaListaSedes(ref Paginacion);
            ViewData["Paginacion"] = Paginacion;

            return View(ListaSedes);
        }
        [Authorize]
        public ActionResult NuevaSede()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NuevaSede(SedeViewModel Sede)
        {
            if (ModelState.IsValid)
            {
                SedeControlador.NuevaSede(Sede);
                return RedirectToAction("Index");
            }
            else
            {
                return View(Sede) ;
            }
        }
        //    public void CargarFormulario()
        //    {
        //        //ViewData["AfiliacionSalud"] = AfiliacionSalud.ConsultaListaAfiliacionSalud();
        //    }
        //    [Authorize]
        //    // GET: Estudiante
        //    public ActionResult Index(int pagina=1)
        //    {
        //        var Paginacion = new ObjPaginacion();
        //        Paginacion.PaginaActual = pagina;
        //        List<ObjSede> Sedes = SedeControlador.ConsultaListaSedes(ref Paginacion);
        //        ViewData["Paginacion"] = Paginacion;
        //        return View(Sedes);
        //    }
        //    [Authorize]
        //    public ActionResult New()
        //    {
        //        CargarFormulario();
        //        return View();
        //    }
        //    [Authorize]
        //    // GET: Estudiante/Details/5
        //    public ActionResult Details(int id=0)
        //    {
        //        CargarFormulario();
        //        if (id != 0)
        //        {
        //            var consulta = SedeControlador.ConsultaSede(id);
        //            return View(consulta);
        //        }
        //        else
        //        {
        //            var consulta = new SedeControlador();
        //            return View(consulta);
        //        }
        //    }
        //    [Authorize]
        //    [HttpPost]
        //    public ActionResult Edit(ObjSede Sede)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                if (Sede.Id == null)
        //                {
        //                    SedeControlador.NuevaSede(Sede);
        //                }
        //                else
        //                {
        //                    SedeControlador.NuevaSede(Sede);
        //                }
        //                return RedirectToAction("/Index");
        //            }
        //            catch
        //            {
        //                return RedirectToAction("/Index");
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    [Authorize(Roles="Admin")]
        //    public ActionResult Delete(int Id=0)
        //    {
        //        try
        //        {
        //            SedeControlador.EliminarSede(Id);
        //            Response.Redirect("~/Sede/index");
        //            return null;
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}