using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entidad;
using System.Linq;

namespace Datos
{
    public class RepositorioPersona
    {
        private readonly SqlConnection _conexion;

        public RepositorioPersona(AdministradorDeConexion conexion) {
            _conexion = conexion._conexion;
        }

        public void Guardar(Persona persona)
        {
            using (var command = _conexion.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (Identificacion,Nombres,Apellidos,Edad, Sexo, Pulsaciones) 
                                        values (@Identificacion,@Nombres,@Apellidos,@Edad,@Sexo,@Pulsaciones)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Pulsaciones", persona.Pulsaciones);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _conexion.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = MapearPersona(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }

        public Persona BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _conexion.CreateCommand())
            {
                command.CommandText = "select * from Persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return MapearPersona(dataReader);
            }
        }

        public void Eliminar(string Identificacion)
        {
            using (SqlCommand command = _conexion.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public void Modificar(Persona persona)
        {
            using (SqlCommand command = _conexion.CreateCommand())
            {
                command.CommandText = "update persona set nombres=@Nombres, apellidos=@Apellidos, edad=@Edad, sexo=@Sexo, pulsaciones=@Pulsaciones where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Pulsaciones", persona.Pulsaciones);
                command.ExecuteNonQuery();
            }
        }

        private Persona MapearPersona(SqlDataReader dataReader) 
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombres = (string)dataReader["Nombres"];
            persona.Apellidos = (string)dataReader["Apellidos"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            persona.Pulsaciones = (decimal)dataReader["Pulsaciones"];
            return persona;
        }
        public int TotalizarPorSexo(string Sexo)
        {
            return ConsultarTodos().Count(p => p.Sexo == Sexo);
        }
        public int TotalizarPersonas()
        {
            return ConsultarTodos().Count();
        }
        public IList<Persona> ConsultarPorSexo(string Sexo)
        {
            return ConsultarTodos().Where(p => p.Sexo == Sexo).ToList();
        }
    }
}
