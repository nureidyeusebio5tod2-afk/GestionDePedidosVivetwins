using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DashboardBLL
    {
        DashboardDAL dal = new DashboardDAL();

        public DataTable DashboardResumen()
        {
            return dal.DashboardResumen();
        }

        public DataTable PedidosRecientes()
        {
            return dal.PedidosRecientes();
        }

        public DataTable InstalacionesProximas()
        {
            return dal.InstalacionesProximas();
        }
    }
}