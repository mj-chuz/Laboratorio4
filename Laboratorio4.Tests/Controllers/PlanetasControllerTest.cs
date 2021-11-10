using Laboratorio4;
using Laboratorio4.Controllers;
using Laboratorio4.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Laboratorio4.Tests.Controllers
{
    [TestClass]
    public class PlanetasControllerTest
    {
        [TestMethod]
        public void TestListadoPlanetarViewNotNull()
        {
            PlanetasController planetasController = new PlanetasController();

            ActionResult vista = planetasController.listadoDePlanetas();

            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPlanetaConArchivo()
        {
            PlanetasController planetasController = new PlanetasController();

            int id = 1;
            FileResult archivo = planetasController.accederArchivo(id);

            Assert.IsNotNull(archivo);

            
        }

        [TestMethod]
        public void TestCrearPlanetaViewResultNotNull()
        {
            PlanetasController planetasController = new PlanetasController();

            ActionResult vista = planetasController.crearPlaneta();

            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestCrearPlanetaViewResult()
        {
            //Arrange
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.crearPlaneta() as ViewResult;
            //Assert
            Assert.AreEqual("crearPlaneta", vista.ViewName);
        }

        [TestMethod]
        public void EditarPlanetaIdValidoVistaNoNula()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void EditarPlanetaValidoModeloRetornadoNoEsNulo()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            //Assert
            Assert.IsNotNull(vista.Model);
        }

        [TestMethod]
        public void EditarPlanetaConIdNoExistenteRedirectToLP()
        {
            //Arrange
            int idInvalido = -1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            RedirectToRouteResult vista = planetasController.editarPlaneta(idInvalido) as RedirectToRouteResult;
            //Assert
            Assert.AreEqual("listadoDePlanetas", vista.RouteValues["action"]);
        }

        [TestMethod]
        public void EditarPlanetaElModeloEnviadoEsCorrecto()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            PlanetaModel planeta = vista.Model as PlanetaModel;
            //Assert
            Assert.IsNotNull(planeta);
            Assert.AreEqual(10, planeta.numeroAnillos);
            Assert.AreEqual("Tierra", planeta.nombre);
        }

        [TestMethod]
        public void ListadoDePlanetasCantidadDePlanetasEsCorrecta()
        {
            //Arrange
            int numeroPlanetas = 10;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.listadoDePlanetas() as ViewResult;
            //Assert
            Assert.AreEqual(numeroPlanetas, vista.ViewBag.planetas.Count);
        }
    }


}
