using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PedidoBLL
    {
        PedidoDAL datos = new PedidoDAL();

        public DataTable MostrarPedidos()
        {
            return datos.MostrarPedidos();
        }

        public void InsertarPedido(Pedido pedido)
        {
            if (pedido.Id_Cliente <= 0)
            {
                throw new System.Exception("Seleccione un cliente");
            }

            datos.InsertarPedido(pedido);
        }

        public void ActualizarEstadoPedido(Pedido pedido)
        {
            datos.ActualizarEstadoPedido(pedido);
        }

        public void EliminarPedido(int id)
        {
            datos.EliminarPedido(id);
        }
    }
}
