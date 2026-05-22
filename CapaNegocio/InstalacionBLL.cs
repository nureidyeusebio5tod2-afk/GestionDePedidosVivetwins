using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class InstalacionBLL
    {
        InstalacionDAL dal = new InstalacionDAL();

        public void GuardarInstalacion(Instalacion instalacion)
        {
            dal.InsertarInstalacion(instalacion);
        }

        public DataTable MostrarInstalaciones()
        {
            return dal.MostrarInstalaciones();
        }
    }
}