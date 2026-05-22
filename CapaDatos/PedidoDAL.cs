using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaEntidades.CapaEntidades;


namespace CapaDatos
{

    public class PedidoDAL
    {
        Conexion conexion = new Conexion();

        // =========================
        // MOSTRAR PEDIDOS
        // =========================
        public DataTable MostrarPedidos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_MostrarPedidosCompletos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(tabla);
                }
            }

            return tabla;
        }

        // =========================
        // INSERTAR PEDIDO
        // =========================
        public void InsertarPedido(Pedido pedido)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    // =========================
                    // INSERTAR PEDIDO
                    // =========================
                    SqlCommand cmdPedido = new SqlCommand(
                        "SP_InsertarPedido",
                        cn,
                        transaccion);

                    cmdPedido.CommandType = CommandType.StoredProcedure;

                    cmdPedido.Parameters.AddWithValue("@Id_Cliente", pedido.Id_Cliente);

                    cmdPedido.Parameters.AddWithValue("@Id_Usuario", pedido.Id_Usuario);

                    cmdPedido.Parameters.AddWithValue("@Estado", pedido.Estado);

                    int IdPedido =
                        Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // =========================
                    // INSERTAR DETALLE
                    // =========================
                    SqlCommand cmdDetalle = new SqlCommand(
                        "SP_InsertarDetallePedido",
                        cn,
                        transaccion);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@Id_Pedido", IdPedido);

                    cmdDetalle.Parameters.AddWithValue("@Tipo_Ventana", pedido.Tipo_Ventana);

                    cmdDetalle.Parameters.AddWithValue("@Medida_Ancho", pedido.Medida_Ancho);

                    cmdDetalle.Parameters.AddWithValue("@Medida_Alto", pedido.Medida_Alto);

                    cmdDetalle.Parameters.AddWithValue("@Material", pedido.Material);

                    cmdDetalle.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);

                    cmdDetalle.Parameters.AddWithValue("@Precio_Unitario", pedido.Precio_Unitario);

                    cmdDetalle.Parameters.AddWithValue("@Observacion", pedido.Observacion);

                    cmdDetalle.ExecuteNonQuery();

                    // =========================
                    // INSERTAR INSTALACION
                    // =========================
                    SqlCommand cmdInstalacion = new SqlCommand(
                        "SP_AsignarInstalador",
                        cn,
                        transaccion);

                    cmdInstalacion.CommandType = CommandType.StoredProcedure;

                    cmdInstalacion.Parameters.AddWithValue("@Id_Pedido", IdPedido);

                    cmdInstalacion.Parameters.AddWithValue("@Id_Instalador", pedido.Id_Instalador);

                    cmdInstalacion.Parameters.AddWithValue(
                        "@Fecha_Instalacion",
                        pedido.Fecha_Instalacion);

                    cmdInstalacion.ExecuteNonQuery();

                    // =========================
                    // CONFIRMAR
                    // =========================
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        // =========================
        // ACTUALIZAR ESTADO
        // =========================
        public void ActualizarEstadoPedido(Pedido pedido)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SP_ActualizarEstadoPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        pedido.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================
        // ELIMINAR PEDIDO
        // =========================
        public void EliminarPedido(int id)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SP_EliminarPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Pedido", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}