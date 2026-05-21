using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DashboardDAL
    {
        Conexion conexion = new Conexion();

        public DataTable DashboardResumen()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_Dashboard", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }

            return tabla;
        }

        public DataTable PedidosRecientes()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand cmd =
                        new SqlCommand("SP_PedidosRecientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            tabla.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error cargando pedidos recientes: " + ex.Message);
            }

            return tabla;
        }

        public DataTable InstalacionesProximas()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand cmd =
                        new SqlCommand("SP_InstalacionesProximas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            tabla.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error cargando instalaciones: " + ex.Message);
            }

            return tabla;
        }
    }
}