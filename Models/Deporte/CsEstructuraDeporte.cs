using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationWeb_CRUD_EventosDeportivos.Models.Deporte
{
    public class CsEstructuraDeporte
    {
        public class RequestDeporte
        {
            public string idDeporte { get; set; }
            public string tipoDeporte { get; set; }
            public string categoria { get; set; }
        }
        public class ResponseDeporte
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarDeporte
        {
            public string idDeporte { get; set; }
        }
    }
}