using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Drawing.Drawing2D;

namespace CapaPresentacion
{
    public partial class FrmDashboard : Form
    {
        DashboardBLL DashboardBLL = new DashboardBLL();
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            EstiloDataGrid();
            CargarDashboard();
            CargarPedidosRecientes();
            CargarInstalacionesProximas();

            // COLOR DEL FORMULARIO
            this.BackColor = Color.FromArgb(245, 247, 250);

            // REDONDEAR TARJETAS
            RedondearPanel(panelPendientes, 25);
            RedondearPanel(panelProceso, 25);
            RedondearPanel(panelFinalizado, 25);
            RedondearPanel(panelHoy, 25);

            // COLORES
            panelPendientes.BackColor = Color.White;
            panelProceso.BackColor = Color.White;
            panelFinalizado.BackColor = Color.White;
            panelHoy.BackColor = Color.White;

            // ==========================
            // POSICIONES DASHBOARD
            // ==========================

            // ==========================
            // TITULO PENDIENTES
            // ==========================

            Label lblTituloPendiente = new Label();

            lblTituloPendiente.Text =
                "Pedidos pendientes";

            lblTituloPendiente.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            lblTituloPendiente.ForeColor =
                Color.FromArgb(30, 41, 59);

            lblTituloPendiente.Location =
                new Point(95, 15);

            lblTituloPendiente.AutoSize = true;

            panelPendientes.Controls.Add(
                lblTituloPendiente);

            // ==========================
            // NUMERO PENDIENTES
            // ==========================

            lblP.Location =
                new Point(95, 45);

            lblP.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblP.ForeColor =
                Color.Black;

            lblP.AutoSize = true;

            // ==========================
            // LINEAS INFERIORES
            // ==========================

            panelLineaPendiente.Dock = DockStyle.Bottom;
            panelLineaPendiente.Height = 6;
            panelLineaPendiente.BackColor =
                Color.FromArgb(239, 68, 68);

            panelLineaProceso.Dock = DockStyle.Bottom;
            panelLineaProceso.Height = 6;
            panelLineaProceso.BackColor =
                Color.FromArgb(245, 158, 11);

            panelLineaFinalizado.Dock = DockStyle.Bottom;
            panelLineaFinalizado.Height = 6;
            panelLineaFinalizado.BackColor =
                Color.FromArgb(16, 185, 129);

            panelLineaHoy.Dock = DockStyle.Bottom;
            panelLineaHoy.Height = 6;
            panelLineaHoy.BackColor =
                Color.FromArgb(59, 130, 246);
        }

        private void CargarPedidosRecientes()
        {
            dataGridView1.DataSource = DashboardBLL.PedidosRecientes();
        }

        // =====================================
        // ESTILO DEL DATAGRIDVIEW
        // =====================================

        private void EstiloDataGrid()
        {
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(17, 136, 167);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(10, 25, 47);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dataGridView1.RowTemplate.Height = 35;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ReadOnly = true;
        }

        private void RedondearPanel(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(control.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(control.Width - radio, control.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radio, radio, radio), 90, 90);

            path.CloseFigure();

            control.Region = new Region(path);
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

                DashboardBLL negocio =
                    new DashboardBLL();

                DataTable tabla =
                    negocio.InstalacionesProximas();

                foreach (DataRow fila in tabla.Rows)
                {
                    // =========================
                    // PANEL PRINCIPAL
                    // =========================

                    Panel panel = new Panel
                    {
                        Width = 300,
                        Height = 90,
                        BackColor = Color.White,
                        Margin = new Padding(10),
                        Padding = new Padding(10)
                    };

                    RedondearPanel(panel, 15);

                    // =========================
                    // BORDE SUAVE
                    // =========================

                    panel.Paint += (s, e) =>
                    {
                        ControlPaint.DrawBorder(
                            e.Graphics,
                            panel.ClientRectangle,
                            Color.FromArgb(230, 230, 230),
                            ButtonBorderStyle.Solid);
                    };

                    // =========================
                    // BARRA IZQUIERDA
                    // =========================

                    Panel barra = new Panel();

                    barra.Width = 5;
                    barra.Dock = DockStyle.Left;

                    barra.BackColor =
                        Color.FromArgb(59, 130, 246);

                    panel.Controls.Add(barra);

                    // =========================
                    // CLIENTE
                    // =========================

                    Label lblCliente = new Label
                    {
                        Text = fila["Cliente"].ToString(),

                        Font =
                            new Font(
                                "Segoe UI Semibold",
                                11),

                        ForeColor =
                            Color.FromArgb(30, 41, 59),

                        Location =
                            new Point(20, 15),

                        AutoSize = true
                    };

                    // =========================
                    // FECHA
                    // =========================

                    Label lblFecha = new Label
                    {
                        Text =
                            Convert.ToDateTime(
                                fila["Fecha_Instalacion"])
                            .ToString(
                                "dd/MM/yyyy - hh:mm tt"),

                        Font =
                            new Font("Segoe UI", 9),

                        ForeColor =
                            Color.FromArgb(100, 100, 100),

                        Location =
                            new Point(20, 45),

                        AutoSize = true
                    };

                    // =========================
                    // AGREGAR CONTROLES
                    // =========================

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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelLineaPendiente_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
