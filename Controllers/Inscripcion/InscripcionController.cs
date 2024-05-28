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
using static AplicationWeb_CRUD_EventosDeportivos.Models.Inscripcion.CsEstructuraInscripcion;

namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Inscripcion
{
    public class InscripcionController : Controller
    {
        // GET: Inscripcion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaInscripcion(string idInscripcion)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idInscripcion == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarInscripcion";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerInscripcion?idInscripcion={idInscripcion}";
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
        public ActionResult CrearInscripcion(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestInscripcion insertar = new RequestInscripcion();
            insertar.idInscripcion = formCollection["idInscripcion"];
            insertar.idEvento = formCollection["idEvento"];
            insertar.idParticipante = formCollection["idParticipante"];
            insertar.idFormaDePago = formCollection["idFormaDePago"];
            insertar.fechaIn = DateTime.Parse(formCollection["FechaIn"]);
            insertar.fechaFin = DateTime.Parse(formCollection["FechaFin"]);
            
            json = JsonConvert.SerializeObject(insertar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarInscripcion";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseInscripcion result = new ResponseInscripcion();
            result = JsonConvert.DeserializeObject<ResponseInscripcion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaInscripcion", "Inscripcion");
            return RedirectToAction("VistaInscripcion", "Inscripcion");
        }
        public ActionResult ActualizarInscripcion(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestInscripcion actualizar = new RequestInscripcion();
            actualizar.idInscripcion = formCollection["idInscripcion"];
            actualizar.idEvento = formCollection["idEvento"];
            actualizar.idParticipante = formCollection["idParticipante"];
            actualizar.idFormaDePago = formCollection["idFormaDePago"];
            actualizar.fechaIn = DateTime.Parse(formCollection["FechaIn"]);
            actualizar.fechaFin = DateTime.Parse(formCollection["FechaFin"]);

            json = JsonConvert.SerializeObject(actualizar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarInscripcion";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseInscripcion result = new ResponseInscripcion();
            result = JsonConvert.DeserializeObject<ResponseInscripcion>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaInscripcion", "Inscripcion");
            return RedirectToAction("VistaInscripcion", "Inscripcion");
        }
        public ActionResult EliminarInscripcion(string idInscripcion)
        {
            string json, resultJson;
            Byte[] reqString, resByte;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarInscripcion";
            var Request = (HttpWebRequest)WebRequest.Create(url);

            RequestEliminarInscripcion eliminar = new RequestEliminarInscripcion();
            eliminar.idInscripcion = idInscripcion;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";

            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);

            ResponseInscripcion result = new ResponseInscripcion();
            result = JsonConvert.DeserializeObject<ResponseInscripcion>(resultJson);
            webClient.Dispose();

            return RedirectToAction("VistaInscripcion", "Inscripcion");
        }

    }
}