using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        int intentos = 0;

        UsuarioBLL negocio = new UsuarioBLL();

        public FrmLogin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {
            txtUsuario.Text = "Ingrese usuario";
            txtUsuario.ForeColor = Color.Gray;

            txtPassword.Text = "Ingrese contraseña";
            txtPassword.ForeColor = Color.Gray;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Ingrese contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;

                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();

                UsuarioBLL negocio = new UsuarioBLL();

                usuario.Nombre_Usuario = txtUsuario.Text.Trim();

                usuario.Clave = txtPassword.Text.Trim();

                bool acceso = negocio.LoginUsuario(usuario);

                if (acceso)
                {
                    MessageBox.Show(
                        "Bienvenido " + Sesion.Usuario +
                        "\nRol: " + Sesion.Rol,
                        "Acceso correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FrmInicio frm = new FrmInicio();

                    frm.Show();

                    this.Hide();
                }
                else
                {
                    intentos++;

                    int restantes = 3 - intentos;

                    MessageBox.Show(
                        "Usuario o contraseña incorrectos\n" +
                        "Intentos restantes: " + restantes,
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    if (intentos >= 3)
                    {
                        MessageBox.Show(
                            "Ha excedido el número de intentos permitidos",
                            "Sistema bloqueado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        btnLogin.Enabled = false;

                        txtUsuario.Enabled = false;

                        txtPassword.Enabled = false;
                    }
                }
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
