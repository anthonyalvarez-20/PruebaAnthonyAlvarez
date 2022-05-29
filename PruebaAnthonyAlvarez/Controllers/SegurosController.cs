using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaAnthonyAlvarez.Models;
using PruebaAnthonyAlvarez.Models.Aplicativo;
using PruebaAnthonyAlvarez.Models.ViewModels;

namespace PruebaAnthonyAlvarez.Controllers
{
    public class SegurosController : Controller
    {
        // GET: Seguros
        public ActionResult Index()
        {
            MetodosAplicativo mtv = new MetodosAplicativo();
            List<SeguroViewModel> seguros = mtv.ListadoSeguros();
            
            return View(seguros);
        }

        public ActionResult NuevoSeguro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoSeguro(SegurosViewModel seguro)
        {
            try
            {
                if(ModelState.IsValid){
                    MetodosAplicativo mtv = new MetodosAplicativo();
                    mtv.RegistrarSeguro(seguro);
                    return Redirect("~/Seguros/");
                }
                return View(seguro);
               

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarSeguro(int id)
        {
            MetodosAplicativo mtv = new MetodosAplicativo();
            SegurosViewModel model = mtv.Seguroid(id);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarSeguro(SegurosViewModel seguro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MetodosAplicativo mtv = new MetodosAplicativo();
                    mtv.EditarSeguro(seguro);
                    return Redirect("~/Seguros/");
                }
                return View(seguro);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarSeguro(int id)
        {
            MetodosAplicativo mtv = new MetodosAplicativo();
            mtv.EliminarSeguro(id);
            return Redirect("~/Seguros/");
        }
    }
}