using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class DetallePedido
    {
        public int Id_Detalle { get; set; }
        public int Id_Pedido { get; set; }

        public string Tipo_Ventana { get; set; }

        public decimal Medida_Ancho { get; set; }

        public decimal Medida_Alto { get; set; }

        public string Material { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio_Unitario { get; set; }

        public decimal Subtotal { get; set; }

        public string Observacion { get; set; }
    }
}

