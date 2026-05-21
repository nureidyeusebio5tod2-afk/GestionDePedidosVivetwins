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
    public class InstalacionBLL
    {
        InstalacionDAL datos = new InstalacionDAL();

        public DataTable MostrarInstalaciones()
        {
            return datos.MostrarInstalaciones();
        }

        public void InsertarInstalacion(Instalacion instalacion)
        {
            datos.InsertarInstalacion(instalacion);
        }

        public void ActualizarInstalacion(Instalacion instalacion)
        {
            datos.ActualizarInstalacion(instalacion);
        }
    }
}
