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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
