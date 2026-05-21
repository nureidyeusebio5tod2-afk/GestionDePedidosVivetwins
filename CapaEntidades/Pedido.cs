using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Pedido
    {
        public int Id_Pedido { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public string Estado { get; set; }
    }
}
