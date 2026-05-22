using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{

    public class InstaladorDAL
    {
        Conexion conexion = new Conexion();

        // MOSTRAR
        public DataTable MostrarInstaladores()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_MostrarInstaladores", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        SqlDataReader leer = comando.ExecuteReader();

                        tabla.Load(leer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al mostrar los instaladores: " + ex.Message);
            }

            return tabla;
        }


        // INSERTAR
        public void InsertarInstalador(Instalador instalador)
        {
            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_InsertarInstalador", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Nombre", instalador.Nombre);

                        comando.Parameters.AddWithValue("@Telefono", instalador.Telefono);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar el instalador: " + ex.Message);
            }
        }
    }
}

