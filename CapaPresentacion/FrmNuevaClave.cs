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
    public partial class FrmNuevaClave : Form
    {
        UsuarioBLL usuarioBLL =
      new UsuarioBLL();
        string usuario;
        string codigoCorrecto;
        public FrmNuevaClave()
        {
            InitializeComponent();
        }

        public FrmNuevaClave(
      string user,
      string codigo)
        {
            InitializeComponent();

            usuario = user;
            codigoCorrecto = codigo;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNuevaClave_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';

            txtConfirmar.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != codigoCorrecto)
            {
                MessageBox.Show(
                "Código incorrecto");

                return;
            }

            if (txtClave.Text != txtConfirmar.Text)
            {
                MessageBox.Show(
                "Las contraseñas no coinciden");

                return;
            }
            bool resultado =
           usuarioBLL.ActualizarClave(
           usuario,
           txtClave.Text);

            if (resultado)
            {
                MessageBox.Show(
                "Contraseña actualizada");

                this.Close();
            }
            else
            {
                MessageBox.Show(
                "No se pudo actualizar");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
