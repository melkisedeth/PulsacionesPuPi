using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Logica
{
    public class ResponseConsulta
    {
        public IList<Persona> Personas { get; set; }
        public string Mensaje { get; set; }
        public ResponseConsulta(IList<Persona> personas) {
            Personas = personas;
        }
    }
    public class ResponseBusqueda
    {
        public Persona Persona { get; set; }
        public string Mensaje { get; set; }
        public ResponseBusqueda(Persona persona) {
            Persona = persona;
        }
    }
}
