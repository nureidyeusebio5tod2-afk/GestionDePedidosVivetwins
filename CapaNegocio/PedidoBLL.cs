using System;
using System.Data;
using CapaDatos;
using CapaEntidades;
using CapaEntidades.CapaEntidades;

namespace CapaNegocio
{
    public class PedidoBLL
    {
        PedidoDAL datos = new PedidoDAL();

        // =========================
        // MOSTRAR PEDIDOS
        // =========================
        public DataTable MostrarPedidos()
        {
            return datos.MostrarPedidos();
        }

        // =========================
        // INSERTAR PEDIDO
        // =========================
        public void InsertarPedido(Pedido pedido)
        {
            // VALIDACIONES

            if (pedido.Id_Cliente <= 0)
            {
                throw new Exception("Seleccione un cliente");
            }

            if (string.IsNullOrWhiteSpace(pedido.Tipo_Ventana))
            {
                throw new Exception("Seleccione el tipo de ventana");
            }

            if (pedido.Cantidad <= 0)
            {
                throw new Exception("Ingrese una cantidad válida");
            }

            if (pedido.Medida_Ancho <= 0)
            {
                throw new Exception("Ingrese el ancho");
            }

            if (pedido.Medida_Alto <= 0)
            {
                throw new Exception("Ingrese el alto");
            }

            if (string.IsNullOrWhiteSpace(pedido.Material))
            {
                throw new Exception("Seleccione un material");
            }

            if (pedido.Id_Instalador <= 0)
            {
                throw new Exception("Seleccione un instalador");
            }

            // GUARDAR
            datos.InsertarPedido(pedido);
        }

        // =========================
        // ACTUALIZAR ESTADO
        // =========================
        public void ActualizarEstadoPedido(Pedido pedido)
        {
            datos.ActualizarEstadoPedido(pedido);
        }

        // =========================
        // ELIMINAR PEDIDO
        // =========================
        public void EliminarPedido(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Seleccione un pedido");
            }

            datos.EliminarPedido(id);
        }
    }
}