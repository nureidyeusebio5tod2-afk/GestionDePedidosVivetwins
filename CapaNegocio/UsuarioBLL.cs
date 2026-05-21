using CapaDatos;
using CapaEntidades;
using System;
using System.Data;

namespace CapaNegocio
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();

        public DataTable MostrarUsuarios()
        {
            return dal.MostrarUsuarios();
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre_Usuario))
                throw new Exception("El nombre de usuario es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Clave))
                throw new Exception("La contraseña es obligatoria");

            return dal.InsertarUsuario(usuario);
        }

        public bool LoginUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre_Usuario))
                throw new Exception("Ingrese el usuario");

            if (string.IsNullOrWhiteSpace(usuario.Clave))
                throw new Exception("Ingrese la contraseña");

            return dal.LoginUsuario(usuario);
        }
    }
}