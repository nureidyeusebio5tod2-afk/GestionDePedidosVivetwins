using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
   
        public class RolDAL
        {
            Conexion conexion = new Conexion();

            // MOSTRAR ROLES
            public DataTable MostrarRoles()
            {
                DataTable tabla = new DataTable();

                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_MostrarRoles", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader leer = comando.ExecuteReader())
                        {
                            tabla.Load(leer);
                        }
                    }
                }

                return tabla;
            }
        }
    }