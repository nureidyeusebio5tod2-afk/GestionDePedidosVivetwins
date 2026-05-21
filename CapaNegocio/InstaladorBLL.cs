using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
  
    namespace CapaNegocio
    {
        public class InstaladorBLL
        {
            InstaladorDAL datos = new InstaladorDAL();

            public DataTable MostrarInstaladores()
            {
                return datos.MostrarInstaladores();
            }

            public void InsertarInstalador(Instalador instalador)
            {
                if (string.IsNullOrWhiteSpace(instalador.Nombre))
                {
                    throw new System.Exception("El nombre es obligatorio");
                }

                if (string.IsNullOrWhiteSpace(instalador.Telefono))
                {
                    throw new System.Exception("El teléfono es obligatorio");
                }

                datos.InsertarInstalador(instalador);
            }
        }
    }
}
