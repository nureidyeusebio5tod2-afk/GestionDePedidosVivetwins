using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCrearCliente : Form
    {
        ClienteBLL negocio = new ClienteBLL();
        public FrmCrearCliente()
        {
            InitializeComponent();
        }

        private void CrearCliente_Load(object sender, EventArgs e)
        {

        }




        // =========================================
        // SOLO NUMEROS
        // =========================================

        private void txtTelefono_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                // =====================================
                // LIMPIAR ESPACIOS
                // =====================================

                txtNombre.Text = txtNombre.Text.Trim();
                txtTelefono.Text = txtTelefono.Text.Trim();
                txtDireccion.Text = txtDireccion.Text.Trim();

                // =====================================
                // VALIDAR NOMBRE
                // =====================================

                if (txtNombre.Text == "")
                {
                    MessageBox.Show(
                        "Ingrese el nombre completo",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombre.Focus();
                    return;
                }

                // SOLO LETRAS

                if (!Regex.IsMatch(
                    txtNombre.Text,
                    @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$"))
                {
                    MessageBox.Show(
                        "El nombre solo puede contener letras",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombre.Focus();
                    return;
                }

                // NOMBRE Y APELLIDO

                string[] partesNombre =
                    txtNombre.Text.Split(' ');

                if (partesNombre.Length < 2)
                {
                    MessageBox.Show(
                        "Debe ingresar nombre y apellido",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombre.Focus();
                    return;
                }

                // =====================================
                // VALIDAR TELEFONO
                // =====================================

                if (!Regex.IsMatch(
                    txtTelefono.Text,
                    @"^\d{10}$"))
                {
                    MessageBox.Show(
                        "El teléfono debe tener 10 dígitos",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtTelefono.Focus();
                    return;
                }

                // =====================================
                // VALIDAR DIRECCION
                // =====================================

                if (txtDireccion.Text == "")
                {
                    MessageBox.Show(
                        "Ingrese la dirección",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtDireccion.Focus();
                    return;
                }

                if (txtDireccion.Text.Length < 5)
                {
                    MessageBox.Show(
                        "Ingrese una dirección válida",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtDireccion.Focus();
                    return;
                }

                // =====================================
                // CREAR OBJETO
                // =====================================

                Cliente cliente = new Cliente();

                cliente.Nombre = txtNombre.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Direccion = txtDireccion.Text;

                ClienteBLL negocio = new ClienteBLL();

                // =====================================
                // INSERTAR O ACTUALIZAR
                // =====================================

                if (txtId.Text == "")
                {
                    negocio.InsertarCliente(cliente);

                    MessageBox.Show(
                        "Cliente guardado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    cliente.Id_Cliente =
                        Convert.ToInt32(txtId.Text);

                    negocio.ActualizarCliente(cliente);

                    MessageBox.Show(
                        "Cliente actualizado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                // =====================================
                // ACTUALIZAR DATAGRIDVIEW
                // =====================================

                FrmCliente frm =
                    Owner as FrmCliente;

                if (frm != null)
                {
                    frm.MostrarClientes();
                }

                // =====================================
                // CERRAR FORM
                // =====================================

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
    

