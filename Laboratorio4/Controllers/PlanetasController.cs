using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio4.Models;
using Laboratorio4.Handlers;

namespace Laboratorio4.Controllers
{
    public class PlanetasController : Controller
    {
        // GET: Planetas
        public ActionResult listadoDePlanetas()
        {
            PlanetasHandler accesoDatos = new PlanetasHandler();
            ViewBag.planetas = accesoDatos.obtenerTodoslosPlanetas();
            return View();
        }

        public ActionResult crearPlaneta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearPlaneta(PlanetaModel planeta)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PlanetasHandler accesoDatos = new PlanetasHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.crearPlaneta(planeta);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El planeta" + " " + planeta.nombre + " fue creado con éxito :D";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el planeta :(";

                return View(); //si falla se regresa a la vista original pero sin el mensaje
            }
        }

        [HttpGet]
        public ActionResult editarPlaneta(int? identificador)
        {
            ActionResult vista;
            try
            {
                PlanetasHandler accesoDatos = new PlanetasHandler();
                PlanetaModel planetaModificar = accesoDatos.obtenerTodoslosPlanetas().Find(smodel => smodel.id == identificador);
                if (planetaModificar == null)
                {
                    vista = RedirectToAction("listadoDePlanetas");
                }
                else
                {
                    vista = View(planetaModificar);
                }
            }
            catch
            {
                vista = RedirectToAction("listadoDePlanetas");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult editarPlaneta(PlanetaModel planeta)
        {
            try
            {
                PlanetasHandler accesoDatos = new PlanetasHandler();
                accesoDatos.modificarPlaneta(planeta);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public FileResult accederArchivo(int identificador)
        {
            PlanetasHandler accesoDatos = new PlanetasHandler();
            var tupla = accesoDatos.descargarContenido(identificador);
            return File(tupla.Item1, tupla.Item2);
        }
    }
}



