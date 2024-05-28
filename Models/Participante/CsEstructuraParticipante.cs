using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationWeb_CRUD_EventosDeportivos.Models.Participante
{
    public class CsEstructuraParticipante
    {
        public class RequestParticipante
        {
            public string idParticipante { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string sexo { get; set; }
            public int edad { get; set; }
            public string telefono { get; set; }
        }
        public class ResponseParticipante
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarParticipante
        {
            public string idParticipante { get; set; }
        }
    }
}