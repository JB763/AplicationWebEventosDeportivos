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
using static AplicationWeb_CRUD_EventosDeportivos.Models.Deporte.CsEstructuraDeporte;


namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Deporte
{
    public class DeporteController : Controller
    {
        // GET: Deporte
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaDeporte(string idDeporte)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idDeporte == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarDeportes";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerDeporte?idDeporte={idDeporte}";
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
        public ActionResult CrearDeporte(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestDeporte insertar = new RequestDeporte();
            // inserta los datos del formulario en la estructura RequestDeporte
            insertar.idDeporte = formCollection["idDeporte"];
            insertar.tipoDeporte = formCollection["TipoDeporte"];
            insertar.categoria = formCollection["Categoria"];

            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarDeporte";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseDeporte result = new ResponseDeporte();
            result = JsonConvert.DeserializeObject<ResponseDeporte>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaDeporte", "Deporte");
            return RedirectToAction("VistaDeporte", "Deporte");
        }
        public ActionResult ActualizarDeporte(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestDeporte actualizar = new RequestDeporte();
            // inserta los datos del formulario en la estructura RequestDeporte
            actualizar.idDeporte = formCollection["idDeporte"];
            actualizar.tipoDeporte = formCollection["TipoDeporte"];
            actualizar.categoria = formCollection["Categoria"];

            json = JsonConvert.SerializeObject(actualizar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarDeporte";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseDeporte result = new ResponseDeporte();
            result = JsonConvert.DeserializeObject<ResponseDeporte>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaDeporte", "Deporte");
            return RedirectToAction("VistaDeporte", "Deporte");
        }
        public ActionResult EliminarDeporte(string idDeporte)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestEliminarDeporte eliminar = new RequestEliminarDeporte();
            // inserta los datos del formulario en la estructura RequestDeporte
            eliminar.idDeporte = idDeporte;
            

            json = JsonConvert.SerializeObject(eliminar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarDeporte";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseDeporte result = new ResponseDeporte();
            result = JsonConvert.DeserializeObject<ResponseDeporte>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaDeporte", "Deporte");
            return RedirectToAction("VistaDeporte", "Deporte");
        }
    }
}