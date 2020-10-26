using System.Data.SqlClient;

namespace Datos
{
    public class AdministradorDeConexion
    {
        internal SqlConnection _conexion;
        public AdministradorDeConexion(string cadenaDeConexion)
        {
            _conexion = new SqlConnection(cadenaDeConexion);
        }
        public void Open()
        {
            _conexion.Open();
        }
        public void Close()
        {
            _conexion.Close();
        }
    }
}
