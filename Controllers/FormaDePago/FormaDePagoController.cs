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
using static AplicationWeb_CRUD_EventosDeportivos.Models.FormaDePago.CsEstructuraFormaDePago;


namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.FormaDePago
{
    public class FormaDePagoController : Controller
    {
        // GET: FormaDePago
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaFormaDePago(string idFormaDePago)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idFormaDePago == null)
            {
                url = $"http://localhost/EventosDeportivos/rest/api/listarFormaDePago";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/rest/api/obtenerFormaDePago?idFormaDePago={idFormaDePago}";
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
        public ActionResult CrearFormaDePago(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestFormaDePago insertar = new RequestFormaDePago();
            // inserta los datos del formulario en la estructura request forma de pago
            insertar.idFormaDePago = formCollection["idFormaDePago"];
            insertar.tipoPago = formCollection["TipoPago"];

            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/rest/api/insertarFormaDePago";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseFormaDePago result = new ResponseFormaDePago();
            result = JsonConvert.DeserializeObject<ResponseFormaDePago>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaFormaDePago", "FormaDePago");
            return RedirectToAction("VistaFormaDePago", "FormaDePago");
        }
        public ActionResult ActualizarFormaDePago(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestFormaDePago actualizar = new RequestFormaDePago();
            // inserta los datos del formulario en la estructura RequestUsuario
            actualizar.idFormaDePago = formCollection["idFormaDePago"];
            actualizar.tipoPago = formCollection["TipoPago"];

            json = JsonConvert.SerializeObject(actualizar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/rest/api/actualizarFormaDePago";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseFormaDePago result = new ResponseFormaDePago();
            result = JsonConvert.DeserializeObject<ResponseFormaDePago>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaFormaDePago", "FormaDePago");
            return RedirectToAction("VistaFormaDePago", "FormaDePago");
        }
        public ActionResult EliminarFormaDePago(string idFormaDePago)
        {
            string json, resultJson;
            Byte[] reqString, resByte;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/rest/api/eliminarFormaDePago";
            var Request = (HttpWebRequest)WebRequest.Create(url);

            RequestEliminarFormaDePago eliminar = new RequestEliminarFormaDePago();
            eliminar.idFormaDePago = idFormaDePago;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";

            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);

            ResponseFormaDePago result = new ResponseFormaDePago();
            result = JsonConvert.DeserializeObject<ResponseFormaDePago>(resultJson);
            webClient.Dispose();

            return RedirectToAction("VistaFormaDePago", "FormaDePago");
        }

    }
}