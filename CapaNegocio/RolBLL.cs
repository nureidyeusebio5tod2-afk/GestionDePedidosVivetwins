using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
        public class RolBLL
        {
            RolDAL datos = new RolDAL();

            public DataTable MostrarRoles()
            {
                return datos.MostrarRoles();
            }
        }
    }
