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
                // LIMPIAR ESPACIOS
                txtNombre.Text = txtNombre.Text.Trim();

                txtTelefono.Text = txtTelefono.Text.Trim();

                txtDireccion.Text = txtDireccion.Text.Trim();

                // =====================================
                // VALIDAR NOMBRE VACIO
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

                // =====================================
                // VALIDAR SOLO LETRAS
                // =====================================

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

                // =====================================
                // VALIDAR NOMBRE + 2 APELLIDOS
                // =====================================

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
                // VALIDAR DIRECCION VACIA
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

                // =====================================
                // VALIDAR DIRECCION REAL
                // MINIMO 4 PALABRAS
                // =====================================

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

                // =====================================
                // GUARDAR
                // =====================================

                negocio.InsertarCliente(cliente);

                MessageBox.Show(
                    "Cliente guardado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // =====================================
                // ACTUALIZAR GRID
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

