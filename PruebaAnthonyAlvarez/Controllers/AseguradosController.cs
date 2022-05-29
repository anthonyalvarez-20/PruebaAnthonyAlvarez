using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PruebaAnthonyAlvarez.Models;
using PruebaAnthonyAlvarez.Models.Aplicativo;
using PruebaAnthonyAlvarez.Models.ViewModels;

namespace PruebaAnthonyAlvarez.Controllers
{
    public class AseguradosController : Controller
    {

        // GET: Asegurados
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerAsegurados()
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            List<AseguradoViewModel> listado = await mtv.ListdoAseguradora();
            res.codrespuesta = "200";
            res.data = listado;
            res.mensaje = "";
            response = MetodosAplicativo.procesarMensajes(res);
            return Json(response);
        }

        [HttpPost]
        public JsonResult ObtenerSeguros()
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            List<SeguroViewModel> listado = mtv.ListadoSeguros();
            res.codrespuesta = "200";
            res.data = listado;
            res.mensaje = "";
            response = MetodosAplicativo.procesarMensajes(res);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Guardar(HttpPostedFileBase fileUpload)
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson resp = mtv.GuardarAsegurados(fileUpload);

            response = MetodosAplicativo.procesarMensajes(resp);

            return Json(response);
        }

        [HttpPost]
        public JsonResult BuscarSeguroAseg(idBuscar idbuscar)
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();
            try
            {
                res.mensaje = "";
                int id = Int32.Parse(idbuscar.id);
                List<SeguroAsegViewModel> cliente =  mtv.ListadoSeguroseg(id);
                if (cliente.Count == 0)
                {
                    res.mensaje = "No hay elementos";
                }


                res.codrespuesta = "200";
                res.data = cliente;
                response = MetodosAplicativo.procesarMensajes(res);

                

            } catch (Exception ex)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Ocurrio un error interno";
                response = MetodosAplicativo.procesarMensajes(res);
            }
            return Json(response);

        }
        [HttpPost]
        public JsonResult ingresarSeguroAseg(SeguroAseg SeguroAseg)
        {
            var response = string.Empty;
            MetodosAplicativo mtv = new MetodosAplicativo();
            RespuestaJson res = new RespuestaJson();

            if (SeguroAseg.idSeguros.Count == 0)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Debe seleccionar al menos un seguro";
                response = MetodosAplicativo.procesarMensajes(res);
            }
            mtv.RegistrarSeguroAseg(SeguroAseg);

            res.codrespuesta = "200";
            res.data = new ArrayList();
            res.mensaje = "Ingreso exitoso";
            response = MetodosAplicativo.procesarMensajes(res);

            return Json(response);
        }
    }


    public class idBuscar{
        public string id { get; set; }
    }

    public class SeguroAseg
    {
        public int idAsegurado { get; set; }
        public List<int> idSeguros { get; set; }
    }
}