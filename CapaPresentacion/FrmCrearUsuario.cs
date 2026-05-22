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
    public partial class FrmCrearUsuario : Form
    {
        UsuarioBLL negocio = new UsuarioBLL();
        public FrmCrearUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // LIMPIAR ESPACIOS

                txtUsuario.Text = txtUsuario.Text.Trim();

                // =====================================
                // VALIDAR USUARIO VACIO
                // =====================================

                if (txtUsuario.Text == "")
                {
                    MessageBox.Show(
                        "Ingrese el nombre de usuario",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUsuario.Focus();

                    return;
                }

                // =====================================
                // VALIDAR SOLO LETRAS Y NUMEROS
                // =====================================

                if (!Regex.IsMatch(
                    txtUsuario.Text,
                    @"^[a-zA-Z0-9_ ]+$"))
                {
                    MessageBox.Show(
                        "El usuario solo puede contener letras y números",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUsuario.Focus();

                    return;
                }

                // =====================================
                // VALIDAR ROL
                // =====================================

                if (cboRol.Text == "")
                {
                    MessageBox.Show(
                        "Seleccione un rol",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cboRol.Focus();

                    return;
                }

                // =====================================
                // VALIDAR ESTADO
                // =====================================

                if (cboEstado.Text == "")
                {
                    MessageBox.Show(
                        "Seleccione un estado",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cboEstado.Focus();

                    return;
                }

                // =====================================
                // CREAR OBJETO
                // =====================================

                Usuario usuario = new Usuario();

                usuario.Nombre_Usuario = txtUsuario.Text;

                usuario.NombreRol = cboRol.Text;

                usuario.Estado = cboEstado.Text;

                // =====================================
                // GUARDAR
                // =====================================

                negocio.InsertarUsuario(usuario);

                MessageBox.Show(
                    "Usuario guardado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // =====================================
                // ACTUALIZAR GRID
                // =====================================

                FrmUsuario frm =
                    Owner as FrmUsuario;

                if (frm != null)
                {
                    frm.MostrarUsuarios();
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
        

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {
            cboRol.Items.Add("Administrador");
            cboRol.Items.Add("Empleado");

            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
        }

     
          
    }
}

