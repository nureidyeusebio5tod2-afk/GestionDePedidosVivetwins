using CapaEntidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DetallePedidoDAL
    {
        Conexion conexion = new Conexion();

        // MOSTRAR
        public DataTable MostrarDetallePedido()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_MostrarDetallePedido", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        SqlDataReader leer = comando.ExecuteReader();

                        tabla.Load(leer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los detalles del pedido: " + ex.Message);
            }

            return tabla;
        }

        // INSERTAR
        public void InsertarDetallePedido(DetallePedido detalle)
        {
            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_InsertarDetallePedido", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Id_Pedido", detalle.Id_Pedido);

                        comando.Parameters.AddWithValue("@Tipo_Ventana", detalle.Tipo_Ventana);

                        comando.Parameters.AddWithValue("@Medida_Ancho", detalle.Medida_Ancho);

                        comando.Parameters.AddWithValue("@Medida_Alto", detalle.Medida_Alto);

                        comando.Parameters.AddWithValue("@Material", detalle.Material);

                        comando.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);

                        comando.Parameters.AddWithValue("@Precio_Unitario", detalle.Precio_Unitario);

                        comando.Parameters.AddWithValue("@Observacion", detalle.Observacion);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el detalle del pedido: " + ex.Message);
            }
        }
    }
}