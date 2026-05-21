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
    public class DetallePedidoBLL
    {
        DetallePedidoDAL datos = new DetallePedidoDAL();

        public DataTable MostrarDetallePedido()
        {
            return datos.MostrarDetallePedido();
        }

        public void InsertarDetallePedido(DetallePedido detalle)
        {
            if (detalle.Cantidad <= 0)
            {
                throw new System.Exception("La cantidad debe ser mayor que cero");
            }

            datos.InsertarDetallePedido(detalle);
        }
    }
}

