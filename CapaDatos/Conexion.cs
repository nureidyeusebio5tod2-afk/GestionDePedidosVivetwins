using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {


            private string cadena =
                "Server=DESKTOP-PID3H25;Database=VivetwinsDB;Integrated Security=True";

            public SqlConnection AbrirConexion()
            {
                SqlConnection conexion =
                    new SqlConnection(cadena);

                conexion.Open();

                return conexion;
            }
        
    }

}