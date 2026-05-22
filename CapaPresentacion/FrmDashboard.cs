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
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            CargarDashboard();
            CargarInstalacionesProximas();
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

    }
}
