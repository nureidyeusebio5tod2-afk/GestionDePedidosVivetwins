using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {


            private string cadena =
                "Server=NUREIDY-TATTA\\MSSQLSERVER02;Database=VivetwinsDB;Integrated Security=True";

            public SqlConnection AbrirConexion()
            {
                SqlConnection conexion =
                    new SqlConnection(cadena);

                conexion.Open();

                return conexion;
            }
        
    }

}