using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PruebaAnthonyAlvarez.Controllers;
using PruebaAnthonyAlvarez.Models.ViewModels;
using static PruebaAnthonyAlvarez.Controllers.HomeController;

namespace PruebaAnthonyAlvarez.Models.Aplicativo
{
    public class MetodosAplicativo
    {

        public static string procesarMensajes(RespuestaJson resp)
        {
            Dictionary<string, dynamic> map = new Dictionary<string, dynamic>();
            map.Add("codRespuesta", resp.codrespuesta);
            map.Add("data", resp.data);
            map.Add("mensaje", resp.mensaje);
            var serializado = JsonConvert.SerializeObject(map);
            return serializado;
        }


        public RespuestaJson obtenerSegAs(cedulaData model)
        {
            RespuestaJson res = new RespuestaJson();

            SegurosEntities3 db = new SegurosEntities3();

               var seguro = (from seg in db.Seguro_Persona
                          where seg.Asegurados.Cedula == model.cedula
                          select new
                          {
                              seg.CodigoSeguro,
                              seg.Seguro.NombreSeguro,
                              seg.Asegurados.NombrePersona,
                              seg.Asegurados.Cedula
                          }
                          ).ToList();

            if(seguro.Count == 0)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Asegurado con esa cedula no existe";
            }
            else
            {
                res.codrespuesta = "200";
                res.data = seguro;
                res.mensaje = "";
            }
        
            return res;
        }

        public RespuestaJson obtenerCodigo(codigoData model)
        {
            RespuestaJson res = new RespuestaJson();
            int id = Int32.Parse(model.codigo);
            SegurosEntities3 db = new SegurosEntities3();

            var seguro = (from seg in db.Seguro_Persona
                          where seg.CodigoSeguro == id
                          select new
                          {
                              seg.CodigoSeguro,
                              seg.Seguro.NombreSeguro,
                              seg.Asegurados.NombrePersona,
                              seg.Asegurados.Cedula
                          }
                       ).ToList();

            if (seguro.Count == 0)
            {
                res.codrespuesta = "500";
                res.data = new ArrayList();
                res.mensaje = "Seguro con el codigo no existe";
            }
            else
            {
                res.codrespuesta = "200";
                res.data = seguro;
                res.mensaje = "";
            }

            return res;


        }


        public void RegistrarSeguro(SegurosViewModel model)
        {
            using(SegurosEntities3 db = new SegurosEntities3())
            {
                var seguro = new Seguro();
                seguro.NombreSeguro = model.NombreSeguro;
                seguro.Prima = model.Prima;
                seguro.SumaAseguradora = model.SumaAseguradora;
                db.Seguro.Add(seguro);
                db.SaveChanges();
            }
        }

        public void RegistrarSeguroAseg(SeguroAseg model)
        {
            using (SegurosEntities3 db = new SegurosEntities3())
            {
                var seguroAseg = new Seguro_Persona();
                foreach(var aseg in model.idSeguros)
                {
                    seguroAseg.IdPersona = model.idAsegurado;
                    seguroAseg.CodigoSeguro = aseg;
                    db.Seguro_Persona.Add(seguroAseg);
                    db.SaveChanges();
                }
            }
        }

        public async Task<List<AseguradoViewModel>> ListdoAseguradora()
        {
            List<AseguradoViewModel> aseguradores;
            using(SegurosEntities3 db = new SegurosEntities3())
            {
                aseguradores = (from ase in db.Asegurados
                                select new AseguradoViewModel
                                {
                                    IdPersona = ase.IdPersona,
                                    Cedula = ase.Cedula,
                                    NombrePersona = ase.NombrePersona,
                                    Edad = ase.Edad,
                                    Telefono = ase.Telefono
                                }).ToList();
            }
            return aseguradores;
        }

        public List<SeguroAsegViewModel> ListadoSeguroseg(int id)
        {
            List<SeguroAsegViewModel> cliente; 
            using(SegurosEntities3 db = new SegurosEntities3())
            {
                cliente = (from client in db.Seguro_Persona
                           where client.IdPersona == id
                           select new SeguroAsegViewModel
                           {
                               IdPersona = client.IdPersona,
                               CodigoSeguro = client.CodigoSeguro
                           }).ToList();
            }

            return cliente;
        }


        public RespuestaJson ObtenerAsegSeg()
        {
            RespuestaJson res = new RespuestaJson();

            SegurosEntities3 db = new SegurosEntities3();

            var seguros = (from seg in db.Seguro_Persona
                           select new
                           {
                               seg.CodigoSeguro,
                               seg.Seguro.NombreSeguro,
                               seg.Asegurados.NombrePersona,
                               seg.Asegurados.Cedula,

                           }).ToList();

            res.codrespuesta = "200";
            res.data = seguros;
            res.mensaje = "";
            return res;

        }


        public List<SeguroViewModel>ListadoSeguros()
        {
            List<SeguroViewModel> seguros;
            using (SegurosEntities3 db = new SegurosEntities3())
            {
                seguros = (from seguro in db.Seguro
                           select new SeguroViewModel
                           {
                               CodigoSeguro = seguro.CodigoSeguro,
                               NombreSeguro = seguro.NombreSeguro,
                               Prima = seguro.Prima,
                               SumaAseguradora = seguro.SumaAseguradora
                           }).ToList();
            }

            return seguros;
        }

        public SegurosViewModel Seguroid(int id)
        {
            SegurosViewModel seguro = new SegurosViewModel();
            using (SegurosEntities3 db = new SegurosEntities3())
            {
                 seguro = (from se in db.Seguro
                          where se.CodigoSeguro == id
                          select new SegurosViewModel
                          {
                              CodigoSeguro = se.CodigoSeguro,
                              NombreSeguro = se.NombreSeguro,
                              Prima = se.Prima,
                              SumaAseguradora = se.SumaAseguradora
                          }).FirstOrDefault();
            }
            return seguro;
        }

        public void EditarSeguro(SegurosViewModel seguroMod)
        {
            using(SegurosEntities3 db = new SegurosEntities3())
            {
                var model = db.Seguro.Find(seguroMod.CodigoSeguro);
                model.NombreSeguro = seguroMod.NombreSeguro;
                model.Prima = seguroMod.Prima;
                model.SumaAseguradora = seguroMod.SumaAseguradora;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        
        public void EliminarSeguro(int id)
        {
            using (SegurosEntities3 db = new SegurosEntities3())
            {
                var model = db.Seguro.Find(id);
                var aseg = (from ase in db.Seguro_Persona
                            where ase.CodigoSeguro == model.CodigoSeguro
                            select ase).ToList();
                foreach(var a in aseg)
                {
                    db.Seguro_Persona.Remove(a);
                    db.SaveChanges();
                }
                db.Seguro.Remove(model);
                db.SaveChanges();

            }
        }

        public RespuestaJson GuardarAsegurados(HttpPostedFileBase fileUpload)
        {
            RespuestaJson resp = new RespuestaJson();
            try
            {
                var rutaGuardar = $@"C:\Users\ANTHONY ALVAREZ\Documents\prueba\{fileUpload.FileName}";
                //var rutaGuardar = $@"./{fileUpload.FileName}";
                string ext = Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(rutaGuardar);
                using (var fs = new StreamReader(rutaGuardar))
                {
                    string linea;
                    while ((linea = fs.ReadLine()) != null)
                    {
                        char delimitador = ',';
                        string[] arregloString = linea.Split(delimitador);

                        string[] nombreArreglo = arregloString[0].Split(':');
                        string nombre = nombreArreglo[1].Replace(" ", string.Empty);

                        string[] cedulaArreglo = arregloString[1].Split(':');
                        string cedula = cedulaArreglo[1].Replace(" ", string.Empty);

                        string[] telefonoArreglo = arregloString[2].Split(':');
                        string telefono = telefonoArreglo[1].Replace(" ", string.Empty);

                        string[] edadArreglo = arregloString[3].Split(':');
                        int edad = Int32.Parse(edadArreglo[1]);

                        var asegurado = new Asegurados();

                        using (SegurosEntities3 db = new SegurosEntities3())
                        {
                            asegurado.NombrePersona = nombre;
                            asegurado.Cedula = cedula;
                            asegurado.Telefono = telefono;
                            asegurado.Edad = edad;
                            db.Asegurados.Add(asegurado);
                            db.SaveChanges();
                        }
                    }
                }

                resp.codrespuesta = "200";
                resp.data = "";
                resp.mensaje = "Asegurados ingresados con exito";

            }
            catch(Exception ex)
            {
                resp.codrespuesta = "500";
                resp.data = "";
                resp.mensaje = "Ocurrio un error interno";
            }

            return resp;
        }

    }
}