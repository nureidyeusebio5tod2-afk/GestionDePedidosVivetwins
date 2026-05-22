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
            CargarDashboard();
            CargarInstalacionesProximas();
        }

        // ================= ABRIR FORMULARIOS =================
        private void AbrirFormulario(Form nuevoForm)
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

        private void CargarDashboard()
        {
            try
            {
                DashboardBLL negocio = new DashboardBLL();
                DataTable tabla = negocio.DashboardResumen();

                if (tabla.Rows.Count > 0)
                {
                    lblP.Text = tabla.Rows[0]["Pendientes"].ToString();
                    lblEnProceso.Text = tabla.Rows[0]["EnProceso"].ToString();
                    lblFinalizados.Text = tabla.Rows[0]["Finalizados"].ToString();
                    lblInstalacionesHoy.Text = tabla.Rows[0]["InstalacionesHoy"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CargarInstalacionesProximas()
        {
            try
            {
                flowInstalaciones.Controls.Clear();

                DashboardBLL negocio = new DashboardBLL();
                DataTable tabla = negocio.InstalacionesProximas();

                foreach (DataRow fila in tabla.Rows)
                {
                    Panel panel = new Panel
                    {
                        Width = 250,
                        Height = 70,
                        BackColor = Color.White,
                        Margin = new Padding(5)
                    };

                    Label lblCliente = new Label
                    {
                        Text = fila["Cliente"].ToString(),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    Label lblFecha = new Label
                    {
                        Text = Convert.ToDateTime(fila["Fecha_Instalacion"])
                               .ToString("dd/MM/yyyy - hh:mm tt"),
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        Location = new Point(10, 35),
                        AutoSize = true
                    };

                    panel.Controls.Add(lblCliente);
                    panel.Controls.Add(lblFecha);

                    flowInstalaciones.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmInicio Inicio = new FrmInicio();
            Inicio.Show();

            AbrirFormulario(new FrmInicio());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente clientes = new FrmCliente();
            clientes.Show();

            AbrirFormulario(new FrmCliente());

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {

            FrmPedidos pedidos = new FrmPedidos();
            pedidos.Show();

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
           
        }
    }
}
