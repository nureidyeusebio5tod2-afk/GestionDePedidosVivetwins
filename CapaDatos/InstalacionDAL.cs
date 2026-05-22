using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class InstalacionDAL
    {
        Conexion conexion = new Conexion();

        // INSERTAR INSTALACION
        public void InsertarInstalacion(Instalacion instalacion)
        {
            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand cmd =
                        new SqlCommand("SP_InsertarInstalacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue
                        ("@Id_Pedido", instalacion.Id_Pedido);

                        cmd.Parameters.AddWithValue
                        ("@Id_Instalador", instalacion.Id_Instalador);

                        cmd.Parameters.AddWithValue
                        ("@Fecha_Instalacion",
                        instalacion.Fecha_Instalacion);

                        cmd.Parameters.AddWithValue
                        ("@Estado", instalacion.Estado);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception
                ("Error al insertar instalación: " + ex.Message);
            }
        }

        // MOSTRAR INSTALACIONES
        public DataTable MostrarInstalaciones()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_MostrarInstalaciones", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}