using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection(
            "Server=NUREIDY-TATTA\\MSSQLSERVER02;Database=VivetwinsDB;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }

            return conexion;
        }
    }
}