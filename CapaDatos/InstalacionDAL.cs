using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
        public class InstalacionDAL
        {
            Conexion conexion = new Conexion();

            // MOSTRAR
            public DataTable MostrarInstalaciones()
            {
                DataTable tabla = new DataTable();

                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_MostrarInstalaciones", cn))
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

            // INSERTAR
            public void InsertarInstalacion(Instalacion instalacion)
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_InsertarInstalacion", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Id_Pedido", instalacion.Id_Pedido);

                        comando.Parameters.AddWithValue("@Id_Instalador", instalacion.Id_Instalador);

                        comando.Parameters.AddWithValue("@Fecha_Instalacion", instalacion.Fecha_Instalacion);

                        comando.Parameters.AddWithValue("@Estado", instalacion.Estado);

                        comando.ExecuteNonQuery();
                    }
                }
            }

            // ACTUALIZAR
            public void ActualizarInstalacion(Instalacion instalacion)
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ActualizarInstalacion", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Id_Instalacion", instalacion.Id_Instalacion);

                        comando.Parameters.AddWithValue("@Estado", instalacion.Estado);

                        comando.ExecuteNonQuery();
                    }
                }
            }
        }
    }