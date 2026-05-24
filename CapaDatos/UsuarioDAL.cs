using CapaEntidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        // =========================================
        // MOSTRAR USUARIOS
        // =========================================
        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_MostrarUsuarios", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader leer = comando.ExecuteReader())
                        {
                            tabla.Load(leer);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al mostrar usuarios: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al mostrar usuarios: " + ex.Message);
            }

            return tabla;
        }

        // =========================================
        // INSERTAR USUARIO
        // =========================================
        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_InsertarUsuario", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
                            .Value = usuario.Nombre_Usuario;

                        comando.Parameters.Add("@Clave", SqlDbType.VarChar, 100)
                            .Value = usuario.Clave;

                        comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20)
                            .Value = usuario.Estado;

                        comando.Parameters.Add("@Id_Rol", SqlDbType.Int)
                            .Value = usuario.Id_Rol;

                        int filas = comando.ExecuteNonQuery();

                        return filas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al insertar usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al insertar usuario: " + ex.Message);
            }
        }

        // =========================================
        // LOGIN USUARIO
        // =========================================
        public bool LoginUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection cn = conexion.AbrirConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SP_LoginUsuario", cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
                            .Value = usuario.Nombre_Usuario;

                        comando.Parameters.Add("@Clave", SqlDbType.VarChar, 100)
                            .Value = usuario.Clave;

                        using (SqlDataReader leer = comando.ExecuteReader())
                        {
                            if (leer.Read())
                            {
                                Sesion.IdUsuario = Convert.ToInt32(leer["Id_Usuario"]);

                                Sesion.Usuario = leer["Nombre_Usuario"].ToString();

                                Sesion.Rol = leer["Nombre_Rol"].ToString();

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL en el login: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general en el login: " + ex.Message);
            }
        }

        public void EliminarUsuario(int id)
        {
            using (SqlConnection cn =
                conexion.AbrirConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SP_EliminarUsuario", cn))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Id_Usuario", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection cn = conexion.AbrirConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand("SP_ActualizarUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Id_Usuario",
                        usuario.Id_Usuario);

                    cmd.Parameters.AddWithValue(
                        "@Nombre_Usuario",
                        usuario.Nombre_Usuario);

                    cmd.Parameters.AddWithValue(
                        "@Clave",
                        usuario.Clave);

                    cmd.Parameters.AddWithValue(
                        "@Id_Rol",
                        usuario.Id_Rol);

                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        usuario.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool ActualizarClave(
    string usuario,
    string clave)
        {
            using (SqlConnection cn =
                conexion.AbrirConexion())
            {
                using (SqlCommand cmd =
                    new SqlCommand(
                    "SP_ActualizarClave", cn))
                {
                    cmd.CommandType =
                    CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                    "@Usuario", usuario);

                    cmd.Parameters.AddWithValue(
                    "@Clave", clave);

                    int filas =
                    cmd.ExecuteNonQuery();

                    return filas > 0;
                }
            }
        }
    }
}