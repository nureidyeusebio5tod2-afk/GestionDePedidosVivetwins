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
    public partial class FrmInicio : Form
    {
        private Form formularioActivo = null;


        public FrmInicio()
        {

            InitializeComponent();


            this.WindowState = FormWindowState.Maximized;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido " + Sesion.Usuario;
            lblRol.Text = Sesion.Rol;
            lblFecha.Text = DateTime.Now.ToLongDateString();
            
        }
        public void AbrirFormulario(Form nuevoForm)
        {
            try
            {
                if (formularioActivo != null)
                {
                    formularioActivo.Close();
                    formularioActivo.Dispose();
                }

                PanelContenedor.Controls.Clear();

                formularioActivo = nuevoForm;

                nuevoForm.TopLevel = false;
                nuevoForm.FormBorderStyle = FormBorderStyle.None;
                nuevoForm.Dock = DockStyle.Fill;

                PanelContenedor.Controls.Add(nuevoForm);
                PanelContenedor.Tag = nuevoForm;

                nuevoForm.BringToFront();
                nuevoForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= BOTONES ================= 

        private void btnInicio_Click(object sender, EventArgs e)
        {
            btnInicio.BackColor = Color.FromArgb(17, 136, 167);

            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
                formularioActivo = null;
            }

            PanelContenedor.Controls.Clear();

            AbrirFormulario(new FrmDashboard());

        }




        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }



        private void btnClientes_Click(object sender, EventArgs e)
        {
            
            AbrirFormulario(new FrmCliente());

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPedidos());

        }

        private void btnInstalaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInstalacionescs());


        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCalendario());

            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes());

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuario());

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConfiguracion());

        }

        private void btnCerrarSeccion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();

            this.Close();

        }

        private void PanelContenedor_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
