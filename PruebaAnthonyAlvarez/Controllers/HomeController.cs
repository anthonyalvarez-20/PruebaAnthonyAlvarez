using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaAnthonyAlvarez.Models.Aplicativo;
using PruebaAnthonyAlvarez.Models.ViewModels;

namespace PruebaAnthonyAlvarez.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult BuscarCedula(cedulaData cedulaData)
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            try
            {

                res = mtv.obtenerSegAs(cedulaData);
                
                response = MetodosAplicativo.procesarMensajes(res);



            }
            catch (Exception ex)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Ocurrio un error interno";
                response = MetodosAplicativo.procesarMensajes(res);
            }
            return Json(response);
        }



        [HttpPost]
        public JsonResult BuscarCodigo(codigoData codigodata)
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            try
            {

                res = mtv.obtenerCodigo(codigodata);

                response = MetodosAplicativo.procesarMensajes(res);



            }
            catch (Exception ex)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Ocurrio un error interno";
                response = MetodosAplicativo.procesarMensajes(res);
            }
            return Json(response);
        }


        [HttpPost]
        public JsonResult ObtenerSegAseg()
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            res = mtv.ObtenerAsegSeg();
            response = MetodosAplicativo.procesarMensajes(res);
            return Json(response);
        }



        public class cedulaData
        {
            public string cedula { get; set; }
        }

        public class codigoData
        {
            public string codigo { get; set; }
        }
    }
}