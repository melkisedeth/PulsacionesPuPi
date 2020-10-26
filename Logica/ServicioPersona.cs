using System.Collections;
using System.Collections.Generic;
using System;
using Entidad;
using Datos;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly AdministradorDeConexion _conexion;
        private readonly RepositorioPersona _repositorio;

        public ServicioPersona(string CadenaDeConexion)
        {
            _conexion = new AdministradorDeConexion(CadenaDeConexion);
            _repositorio = new RepositorioPersona(_conexion);
        }

        public ResponseBusqueda Guardar(Persona Persona)
        {
            ResponseBusqueda respuesta = new ResponseBusqueda(Persona);
            try
            {
                respuesta.Persona.CalcularPulsaciones();
                _conexion.Open();
                _repositorio.Guardar(respuesta.Persona);
                respuesta.Mensaje = $"Los datos de {Persona.Nombres} han sido guardados correctamente";
                _conexion.Close();
            }
            catch (Exception E)
            {
                respuesta.Persona = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            finally
            {
                _conexion.Close();
            }
            return respuesta;
        }

        public ResponseConsulta ConsultarTodos()
        {
            ResponseConsulta respuesta = new ResponseConsulta(new List<Persona>());
            try
            {
                _conexion.Open();
                respuesta.Personas = _repositorio.ConsultarTodos();
                _conexion.Close();
                respuesta.Mensaje = "Consulta realizada con éxito";
            }
            catch (Exception e)
            {
                respuesta.Mensaje = "Error: " + e.Message;
            }
            return respuesta;
        }
        public ResponseBusqueda BuscarPorIdentificacion(string Identificacion)
        {
            ResponseBusqueda respuesta = new ResponseBusqueda(new Persona());
            try
            {
                _conexion.Open();
                respuesta.Persona = _repositorio.BuscarPorIdentificacion(Identificacion);
                _conexion.Close();
                respuesta.Mensaje = (respuesta.Persona == null) ? $"La Persona con cédula numero {Identificacion} no se encuentra registrada" : "Persona encontrada";
            }
            catch (Exception E)
            {
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
                respuesta.Persona = null;
            }
            finally
            {
                _conexion.Close();
            }
            return respuesta;
        }
        public ResponseBusqueda Modificar(Persona persona)
        {
            ResponseBusqueda respuesta = BuscarPorIdentificacion(persona.Identificacion);
            try
            {
                if (respuesta.Persona != null)
                {
                    _conexion.Open();
                    persona.CalcularPulsaciones();
                    respuesta.Persona = persona;
                    _repositorio.Modificar(respuesta.Persona);
                    respuesta.Mensaje = $"Los datos de la persona con cédula {persona.Identificacion} han sido modificados correctamente";
                    _conexion.Close();
                }
            }
            catch (Exception E)
            {
                respuesta.Persona = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            finally
            {
                _conexion.Close();
            }
            return respuesta;
        }
        public ResponseBusqueda Eliminar(string identificacion)
        {
            ResponseBusqueda respuesta = BuscarPorIdentificacion(identificacion);
            try
            {
                if (respuesta.Persona != null)
                {
                _conexion.Open();
                _repositorio.Eliminar(respuesta.Persona.Identificacion);
                respuesta.Mensaje = (respuesta.Persona != null) ? $"Los datos de la persona con cedula {identificacion} han sido eliminados correctamente" : $"La persona con cedula {identificacion} no se encuentra registrada";
                _conexion.Close();
                }
            }
            catch (Exception E)
            {
                respuesta.Persona = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            finally
            {
                _conexion.Close();
            }
            return respuesta;
        }
        public IList<int> Totalizar(string identificador)
        {
            IList<int> totales = new List<int>();
            try {
                totales.Add(TotalizarPorSexo("Masculino"));
                totales.Add(TotalizarPorSexo("Femenino"));
                totales.Add(TotalizarPersonas());
                if (identificador == "Masculino") {
                    totales[1] = 0;
                    totales[2] = totales[0];
                } else if (identificador == "Femenino") {
                    totales[0] = 0;
                    totales[2] = totales[1];
                }
            } catch {
                totales.Clear();
            }
            return totales;
        }
        public int TotalizarPorSexo(string Sexo)
        {
            _conexion.Open();
            int Total = _repositorio.TotalizarPorSexo(Sexo);
            _conexion.Close();
            return Total;
        }
        public int TotalizarPersonas()
        {
            _conexion.Open();
            int Total = _repositorio.TotalizarPersonas();
            _conexion.Close();
            return Total;
        }
        public ResponseConsulta ConsultarPorSexo(string Sexo)
        {
            ResponseConsulta respuesta = new ResponseConsulta(new List<Persona>());
            try
            {
                _conexion.Open();
                respuesta.Personas = _repositorio.ConsultarPorSexo(Sexo);
                _conexion.Close();
                respuesta.Mensaje = "Consulta realizada con éxito";
            }
            catch (Exception e)
            {
                respuesta.Mensaje = "Error: " + e.Message;
            }
            return respuesta;
        }

        public ResponseConsulta Consultar(string tipoConsulta)
        {
            if (tipoConsulta == "Todos")
            {
                return ConsultarTodos();
            }
            else if (tipoConsulta == "Femenino" || tipoConsulta == "Masculino")
            {
                return ConsultarPorSexo(tipoConsulta);
            }
            return new ResponseConsulta(new List<Persona>());
        }
    }
}
