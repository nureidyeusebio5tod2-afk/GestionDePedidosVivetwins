using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCalendario : Form
    {
        DateTime fechaActual = DateTime.Now;

        DataTable dtInstalaciones = new DataTable();

        InstalacionBLL instalacionBLL = new InstalacionBLL();

        public FrmCalendario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            dtInstalaciones =
           instalacionBLL.MostrarInstalaciones();

            GenerarCalendario();
        }

        private void MostrarInstalaciones(
        Panel panelDia,
        int dia)
        {
            foreach (DataRow row in dtInstalaciones.Rows)
            {
                DateTime fecha =
                    Convert.ToDateTime(
                        row["Fecha_Instalacion"]);

                if (fecha.Day == dia &&
                    fecha.Month == fechaActual.Month &&
                    fecha.Year == fechaActual.Year)
                {
                    Label evento = new Label();

                    evento.Text =
                        fecha.ToString("HH:mm")
                        + " "
                        + row["Cliente"].ToString();

                    evento.Height = 25;

                    evento.Dock = DockStyle.Top;

                    evento.BackColor =
                        Color.FromArgb(17, 136, 167);

                    evento.TextAlign =
                        ContentAlignment.MiddleLeft;

                    panelDia.Controls.Add(evento);
                }
            }
        }

        private void GenerarCalendario()
        {
            tlpCalendario.Controls.Clear();

            lblMes.Text =
                fechaActual.ToString("MMMM yyyy");

            DateTime primerDia =
                new DateTime(
                    fechaActual.Year,
                    fechaActual.Month,
                    1);

            int diasMes =
                DateTime.DaysInMonth(
                    fechaActual.Year,
                    fechaActual.Month);

            int inicio =
                (int)primerDia.DayOfWeek;

            int dia = 1;

            for (int fila = 0; fila < 6; fila++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Panel panelDia = new Panel();
                    int anchoCelda = tlpCalendario.Width / 7;
                    int altoCelda = tlpCalendario.Height / 6;

                    panelDia.Width = anchoCelda - 5;
                    panelDia.Height = altoCelda - 5;

                    panelDia.Left = col * anchoCelda;
                    panelDia.Top = fila * altoCelda;

                    panelDia.BackColor = Color.White;

                    panelDia.BorderStyle =
                        BorderStyle.FixedSingle;

                    if (fila == 0 && col < inicio)
                    {
                        tlpCalendario.Controls.Add(panelDia);
                    }
                    else if (dia <= diasMes)
                    {
                        Label lblDia = new Label();

                        lblDia.Text = dia.ToString();

                        lblDia.Dock = DockStyle.Top;

                        lblDia.Font =
                            new Font(
                                "Segoe UI",
                                10,
                                FontStyle.Bold);

                        panelDia.Controls.Add(lblDia);

                        MostrarInstalaciones(panelDia, dia);

                        tlpCalendario.Controls.Add(panelDia);

                        dia++;
                    }
                }
            }
        }
        private void panelCalendario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            fechaActual =
                fechaActual.AddMonths(1);

            GenerarCalendario();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

            fechaActual =
            fechaActual.AddMonths(-1);

            GenerarCalendario();
        }

        private void tlpDias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpCalendario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPedidos frm = new FrmPedidos();
            frm.ShowDialog();
        }
    }
    }
