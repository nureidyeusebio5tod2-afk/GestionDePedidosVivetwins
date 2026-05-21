using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Instalacion
    {
        public int Id_Instalacion { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Instalador { get; set; }
        public DateTime Fecha_Instalacion { get; set; }
        public string Estado { get; set; }
    }
}
