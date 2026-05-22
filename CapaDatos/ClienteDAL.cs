using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class ClienteDAL
    {
        Conexion conexion = new Conexion();

      

        // INSERTAR
        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);

                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ACTUALIZAR
        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Cliente", cliente.Id_Cliente);

                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);

                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR
        public void EliminarCliente(int id)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_EliminarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Cliente", id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

            public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("SP_MostrarClientes", cn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(tabla);
            }

            return tabla;
        }


        public DataTable BuscarClientes(string campo, string valor)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.AbrirConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("SP_BuscarClientes", cn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Campo", campo);

                cmd.Parameters.AddWithValue("@Valor", valor);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(tabla);
            }

            return tabla;
        }

    }
    }
