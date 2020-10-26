using System.Reflection.Metadata;
using System;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PulsacionesDotNet.Models;
using System.Collections.Generic;
using System.Linq;
using Entidad;

namespace PulsacionesDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _servicioPersona = new ServicioPersona(connectionString);
        }

        [HttpGet("{identificador}/{formulario}")]
        public object SeleccionarConsulta(string identificador, string formulario)
        {
            if (formulario == "Consulta") {
                return Consultar(identificador);
            } else if (formulario == "Busqueda") {
                return Buscar(identificador);
            } else {
                return Totalizar(identificador);
            }
        }
        private IEnumerable<PersonaViewModel> Consultar(string tipoConsulta)
        {
            var personas = _servicioPersona.Consultar(tipoConsulta).Personas.Select(p => new PersonaViewModel(p));
            return personas;
        }
        private ActionResult<PersonaViewModel> Buscar(string identificacion)
        {
            var persona = _servicioPersona.BuscarPorIdentificacion(identificacion).Persona;
            if (persona == null) return NotFound();
            var personaViewmodel = new PersonaViewModel(persona);
            return personaViewmodel;
        }
        private IEnumerable<int> Totalizar(string identificador)
        {
            var totales = _servicioPersona.Totalizar(identificador);
            if (totales == null) return new List<int>();
            return totales;
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Guardar(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var respuesta = _servicioPersona.Guardar(persona);
            if (respuesta.Persona == null) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Persona);
        }
        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<PersonaViewModel> Eliminar(string identificacion)
        {
            var respuesta = _servicioPersona.Eliminar(identificacion);
            if (respuesta.Persona == null) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Persona);
        }

        [HttpPut]
        public ActionResult<PersonaViewModel> Modificar(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var respuesta = _servicioPersona.Modificar(persona);
            if (respuesta.Persona == null) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Persona);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombres = personaInput.Nombres,
                Apellidos = personaInput.Apellidos,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo
            };
            return persona;
        }
    }
}
