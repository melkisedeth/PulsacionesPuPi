using Entidad;

namespace PulsacionesDotNet.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
    }

    public class PersonaViewModel: PersonaInputModel
    {
        public decimal Pulsaciones { get; set; }
        public PersonaViewModel() { }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            Apellidos = persona.Apellidos;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Pulsaciones = persona.Pulsaciones;
        }

    }
}
