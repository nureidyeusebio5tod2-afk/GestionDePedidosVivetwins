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
    public class ClienteBLL
    {
        ClienteDAL datos = new ClienteDAL();

        // MOSTRAR
       
        public DataTable MostrarClientes()
        {
            return datos.MostrarClientes();
        }
        // INSERTAR
        public void InsertarCliente(Cliente cliente)
        {
            if (cliente.Nombre == "")
            {
                throw new System.Exception("El nombre es obligatorio");
            }

            datos.InsertarCliente(cliente);
        }

        // ACTUALIZAR
        public void ActualizarCliente(Cliente cliente)
        {
            datos.ActualizarCliente(cliente);
        }

        // ELIMINAR
        public void EliminarCliente(int id)
        {
            datos.EliminarCliente(id);
        }
    }
}
    