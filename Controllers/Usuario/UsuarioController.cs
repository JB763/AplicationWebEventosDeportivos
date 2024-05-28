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
using static AplicationWeb_CRUD_EventosDeportivos.Models.Usuario.CsEstructuraUsuario;

namespace AplicationWeb_CRUD_EventosDeportivos.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VistaUsuario(string idUsuario)
        {
            DataSet dsi = new DataSet();
            var url = "";

            if (idUsuario == null)
            {
                url = $"http://localhost/EventosDeportivos/api/rest/listarUsuarios";
            }
            else
            {
                url = $"http://localhost/EventosDeportivos/api/rest/obtenerUsuario?idUsuario={idUsuario}";
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
        public ActionResult CrearUsuario(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestUsuario insertar = new RequestUsuario();
            // inserta los datos del formulario en la estructura RequestUsuario
            insertar.idUsuario = formCollection["idUsuario"];
            insertar.idParticipante = formCollection["idParticipante"];
            insertar.correo = formCollection["Correo"];
            insertar.contraseña = formCollection["Contraseña"];
            json = JsonConvert.SerializeObject(insertar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/insertarUsuario";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseUsuario result = new ResponseUsuario();
            result = JsonConvert.DeserializeObject<ResponseUsuario>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaUsuario", "Usuario");
            return RedirectToAction("VistaUsuario", "Usuario");
        }
        public ActionResult ActualizarUsuario(FormCollection formCollection)
        {
            string json, resultJson;
            Byte[] reqString, resByte;
            RequestUsuario actualizar = new RequestUsuario();
            // Obtener los datos del formulario
            actualizar.idUsuario = formCollection["idUsuario"];
            actualizar.idParticipante = formCollection["idParticipante"];
            actualizar.correo = formCollection["Correo"];
            actualizar.contraseña = formCollection["Contraseña"];
            json = JsonConvert.SerializeObject(actualizar);

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/actualizarUsuario";
            var Request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";
            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString); 
            resultJson = Encoding.UTF8.GetString(resByte);
            ResponseUsuario result = new ResponseUsuario();
            result = JsonConvert.DeserializeObject<ResponseUsuario>(resultJson);
            webClient.Dispose();

            if (result.respuesta == 1)
                return RedirectToAction("VistaUsuario", "Usuario");
            return RedirectToAction("VistaUsuario", "Usuario");
        }
        public ActionResult EliminarUsuario(string idUsuario)
        {
            string json, resultJson;
            Byte[] reqString, resByte;

            WebClient webClient = new WebClient();
            string url = $"http://localhost/EventosDeportivos/api/rest/eliminarUsuario";
            var Request = (HttpWebRequest)WebRequest.Create(url);

            RequestEliminarUsuario eliminar = new RequestEliminarUsuario();
            eliminar.idUsuario = idUsuario;

            json = JsonConvert.SerializeObject(eliminar);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers["content-type"] = "application/json";

            reqString = Encoding.UTF8.GetBytes(json);
            resByte = webClient.UploadData(Request.Address.ToString(), "post", reqString);
            resultJson = Encoding.UTF8.GetString(resByte);

            ResponseUsuario result = new ResponseUsuario();
            result = JsonConvert.DeserializeObject<ResponseUsuario>(resultJson);
            webClient.Dispose();

            return RedirectToAction("VistaUsuario", "Usuario");
        }

    }
}