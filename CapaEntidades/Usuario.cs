using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
       public class Usuario
        {
            public int Id_Usuario { get; set; }

            public string Nombre_Usuario { get; set; }

            public string Clave { get; set; }

            public string Estado { get; set; }

            public int Id_Rol { get; set; }
        }
    }
