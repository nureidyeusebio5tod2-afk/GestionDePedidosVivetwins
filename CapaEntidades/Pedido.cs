using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    namespace CapaEntidades
    {
        public class Pedido
        {
            public int Id_Cliente { get; set; }
            public int Id_Usuario { get; set; }
            public string Estado { get; set; }

            public string Tipo_Ventana { get; set; }
            public decimal Medida_Ancho { get; set; }
            public decimal Medida_Alto { get; set; }
            public string Material { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio_Unitario { get; set; }
            public string Observacion { get; set; }

            public int Id_Instalador { get; set; }
            public DateTime Fecha_Instalacion { get; set; }
        }
    }
}
