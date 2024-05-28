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
using static AplicationWeb_CRUD_EventosDeportivos.Models.Evento.CsEstructuraEvento;

namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Evento
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaEvento(string idEvento)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idEvento == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarEvento";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerEvento?idEvento={idEvento}";
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
        public ActionResult CrearEvento(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestEvento insertar = new RequestEvento();
            insertar.idEvento = formCollection["idEvento"];
            insertar.idDeporte = formCollection["idDeporte"];
            insertar.nombre = formCollection["Nombre"];
            insertar.fechaIn = DateTime.Parse(formCollection["FechaIn"]);
            insertar.fechaFin = DateTime.Parse(formCollection["FechaFin"]);
            insertar.costo = double.Parse(formCollection["Costo"]);
            insertar.cupo = int.Parse(formCollection["Cupo"]);
          
            json = JsonConvert.SerializeObject(insertar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarEvento";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseEvento result = new ResponseEvento();
            result = JsonConvert.DeserializeObject<ResponseEvento>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaEvento", "Evento");
            return RedirectToAction("VistaEvento", "Evento");
        }
        public ActionResult ActualizarEvento(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestEvento actualizar = new RequestEvento();
            actualizar.idEvento = formCollection["idEvento"];
            actualizar.idDeporte = formCollection["idDeporte"];
            actualizar.nombre = formCollection["Nombre"];
            actualizar.fechaIn = DateTime.Parse(formCollection["FechaIn"]);
            actualizar.fechaFin = DateTime.Parse(formCollection["FechaFin"]);
            actualizar.costo = double.Parse(formCollection["Costo"]);
            actualizar.cupo = int.Parse(formCollection["Cupo"]);

            json = JsonConvert.SerializeObject(actualizar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarEvento";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseEvento result = new ResponseEvento();
            result = JsonConvert.DeserializeObject<ResponseEvento>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaEvento", "Evento");
            return RedirectToAction("VistaEvento", "Evento");
        }
        public ActionResult EliminarEvento(string idEvento)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestEventoEliminar eliminar = new RequestEventoEliminar();
            eliminar.idEvento = idEvento;
          

            json = JsonConvert.SerializeObject(eliminar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarEvento";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseEvento result = new ResponseEvento();
            result = JsonConvert.DeserializeObject<ResponseEvento>(resultJson);
            webClient.Dispose();          
            
             return RedirectToAction("VistaEvento", "Evento");
            
        }
    }
}