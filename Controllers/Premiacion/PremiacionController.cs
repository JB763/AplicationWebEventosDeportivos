using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static AplicationWeb_CRUD_EventosDeportivos.Models.Premiacion.CsEstructuraPremiacion;

namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Premiacion
{
    public class PremiacionController : Controller
    {
        // GET: Premiacion
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult VistaPremiacion(string idPremiacion)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idPremiacion == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarPremiacion";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerPremiacion?idPremiacion={idPremiacion}";
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string responseBody;
            try
            {
                using (WebResponse Response = request.GetResponse())
                {
                    using (Stream StrReader = Response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(StrReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                    dsi = JsonConvert.DeserializeObject<DataSet>(responseBody);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());

            }

            return View(dsi);
        }
        public ActionResult CrearPremiacion(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestPremiacion insertar = new RequestPremiacion();
            insertar.idPremiacion = formCollection["idPremiacion"];
            insertar.idEvento = formCollection["idEvento"];
            insertar.posicion = Convert.ToInt32(formCollection["Posicion"]);
            insertar.descripcion = formCollection["Descripcion"];
            insertar.fecha = Convert.ToDateTime(formCollection["Fecha"]);
                   
            json = JsonConvert.SerializeObject(insertar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarPremiacion";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponsePremiacion result = new ResponsePremiacion();
            result = JsonConvert.DeserializeObject<ResponsePremiacion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaPremiacion", "Premiacion");
            return RedirectToAction("VistaPremiacion", "Premiacion");
        }
        public ActionResult ActualizarPremiacion(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestPremiacion actualizar = new RequestPremiacion();
            actualizar.idPremiacion = formCollection["idPremiacion"];
            actualizar.idEvento = formCollection["idEvento"];
            actualizar.posicion = Convert.ToInt32(formCollection["Posicion"]);
            actualizar.descripcion = formCollection["Descripcion"];
            actualizar.fecha = Convert.ToDateTime(formCollection["Fecha"]);

            json = JsonConvert.SerializeObject(actualizar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarPremiacion";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponsePremiacion result = new ResponsePremiacion();
            result = JsonConvert.DeserializeObject<ResponsePremiacion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaPremiacion", "Premiacion");
            return RedirectToAction("VistaPremiacion", "Premiacion");
        }
        public ActionResult EliminarPremiacion(string idPremiacion)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestEliminarPremiacion eliminar = new RequestEliminarPremiacion();
            eliminar.idPremiacion = idPremiacion;
           

            json = JsonConvert.SerializeObject(eliminar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarPremiacion";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponsePremiacion result = new ResponsePremiacion();
            result = JsonConvert.DeserializeObject<ResponsePremiacion>(resultJson);
            webClient.Dispose();

            return RedirectToAction("VistaPremiacion", "Premiacion");
         
        }
    }
}