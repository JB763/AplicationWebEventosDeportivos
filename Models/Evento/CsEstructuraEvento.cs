using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationWeb_CRUD_EventosDeportivos.Models.Evento
{
    public class CsEstructuraEvento
    {
        public class RequestEvento
        {
            public string idEvento { get; set; }
            public string idDeporte { get; set; }
            public string nombre { get; set; }
            public DateTime fechaIn { get; set; }
            public DateTime fechaFin { get; set; }
            public double costo { get; set; }
            public int cupo { get; set; }
        }
        public class ResponseEvento
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEventoEliminar
        {
            public string idEvento { get; set; }
        }
    }
}