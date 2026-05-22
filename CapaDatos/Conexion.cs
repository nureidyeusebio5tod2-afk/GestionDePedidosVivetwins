using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {


            private string cadena =
                "Server=DESKTOP-MV85JFF;Database=VivetwinsDB;Integrated Security=True";

            public SqlConnection AbrirConexion()
            {
                SqlConnection conexion =
                    new SqlConnection(cadena);

                conexion.Open();

                return conexion;
            }
        
    }

}