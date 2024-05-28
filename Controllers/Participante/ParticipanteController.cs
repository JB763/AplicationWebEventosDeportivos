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
using static AplicationWeb_CRUD_EventosDeportivos.Models.Participante.CsEstructuraParticipante;

namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Participante
{
    public class ParticipanteController : Controller
    {
        // GET: Participante
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaParticipante(string idParticipante)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idParticipante == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarParticipantes";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerParticipante?idParticipante={idParticipante}";
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
        public ActionResult CrearParticipante(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestParticipante insertar = new RequestParticipante();
            insertar.idParticipante = formCollection["idParticipante"];
            insertar.nombre = formCollection["Nombre"];
            insertar.apellido = formCollection["Apellido"];
            insertar.sexo = formCollection["Sexo"];
            insertar.edad = Convert.ToInt32(formCollection["Edad"]);
            insertar.telefono = formCollection["Telefono"];
            
            json = JsonConvert.SerializeObject(insertar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarParticipante";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseParticipante result = new ResponseParticipante();
            result = JsonConvert.DeserializeObject<ResponseParticipante>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaParticipante", "Participante");
            return RedirectToAction("VistaParticipante", "Participante");
        }
        public ActionResult ActualizarParticipante(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestParticipante actualizar = new RequestParticipante();
            actualizar.idParticipante = formCollection["idParticipante"];
            actualizar.nombre = formCollection["Nombre"];
            actualizar.apellido = formCollection["Apellido"];
            actualizar.sexo = formCollection["Sexo"];
            actualizar.edad = Convert.ToInt32(formCollection["Edad"]);
            actualizar.telefono = formCollection["Telefono"];

            json = JsonConvert.SerializeObject(actualizar);
            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarParticipante";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseParticipante result = new ResponseParticipante();
            result = JsonConvert.DeserializeObject<ResponseParticipante>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaParticipante", "Participante");
            return RedirectToAction("VistaParticipante", "Participante");
        }
        public ActionResult EliminarParticipante(string idParticipante)
        {
            string json, resultJson;
            Byte[] reqString, resByte;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarParticipante";
            var Request = (HttpWebRequest)WebRequest.Create(url);

            RequestEliminarParticipante eliminar = new RequestEliminarParticipante();
            eliminar.idParticipante = idParticipante;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";

            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);

            ResponseParticipante result = new ResponseParticipante();
            result = JsonConvert.DeserializeObject<ResponseParticipante>(resultJson);
            webClient.Dispose();

            return RedirectToAction("VistaParticipante", "Participante");
        }

    }
}