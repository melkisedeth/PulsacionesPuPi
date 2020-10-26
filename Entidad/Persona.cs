using System;

namespace Entidad
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public decimal Pulsaciones { get; set; }

        public void CalcularPulsaciones() {
            Pulsaciones = (Sexo.Equals("Femenino"))? (decimal) (220-Edad) / 10 : (decimal) (210-Edad) / 10;
        }
    }
}
