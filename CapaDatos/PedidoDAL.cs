using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{

    public class PedidoDAL
    {
        Conexion conexion = new Conexion();

        // MOSTRAR
        public DataTable MostrarPedidos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_MostrarPedidos", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        tabla.Load(leer);
                    }
                }
            }

            return tabla;
        }

        // INSERTAR
        public void InsertarPedido(Pedido pedido)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_InsertarPedido", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id_Cliente", pedido.Id_Cliente);

                    comando.Parameters.AddWithValue("@Id_Usuario", pedido.Id_Usuario);

                    comando.Parameters.AddWithValue("@Estado", pedido.Estado);

                    comando.ExecuteNonQuery();
                }
            }
        }

        // ACTUALIZAR ESTADO
        public void ActualizarEstadoPedido(Pedido pedido)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_ActualizarEstadoPedido", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id_Pedido", pedido.Id_Pedido);

                    comando.Parameters.AddWithValue("@Estado", pedido.Estado);

                    comando.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR
        public void EliminarPedido(int id)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_EliminarPedido", cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id_Pedido", id);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
        
    