using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmInstalacionescs : Form

    {
        List<Instalacion> listaInstalaciones = new List<Instalacion>();
        DataTable dtInstalaciones = new DataTable();
        InstalacionBLL instalacionBLL = new InstalacionBLL();

        public FrmInstalacionescs()
        {
            InitializeComponent();
        }

        private void CargarInstalaciones()
        {
            dtInstalaciones = instalacionBLL.MostrarInstalaciones();

            dataGridView1.DataSource = dtInstalaciones;
        }

        private void FrmInstalacionescs_Load(object sender, EventArgs e)
        {

            CargarInstalaciones();
            CargarComboEstado();
            EstiloDataGrid();
        }

        private void CargarComboEstado()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Completada");
            cmbEstado.Items.Add("En Proceso");

            cmbEstado.SelectedIndex = 0;
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


        private void Filtrar()
        {
            DataTable filtrado = dtInstalaciones.Clone();

            string estado = cmbEstado.Text;

            foreach (DataRow row in dtInstalaciones.Rows)
            {
                bool coincideEstado = false;

                // ===== FILTRO ESTADO =====
                if (estado == "Todos")
                {
                    coincideEstado = true;
                }
                else
                {
                    coincideEstado =
                        row["Estado"].ToString() == estado;
                }

                // ===== SI COINCIDE =====
                if (coincideEstado)
                {
                    filtrado.ImportRow(row);
                }
            }

            dataGridView1.DataSource = filtrado;

            EstiloDataGrid();
        }


        private void FiltrarPorFecha()
        {
            DataTable filtrado = dtInstalaciones.Clone();

            DateTime fechaSeleccionada = dtpFecha.Value.Date;

            foreach (DataRow row in dtInstalaciones.Rows)
            {
                DateTime fechaBD =
                    Convert.ToDateTime(row["Fecha_Instalacion"]).Date;

                if (fechaBD == fechaSeleccionada)
                {
                    filtrado.ImportRow(row);
                }
            }

            dataGridView1.DataSource = filtrado;

            EstiloDataGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
          
            cmbEstado.SelectedIndex = 0;

            CargarInstalaciones();


            dtpFecha.Value = DateTime.Today;

            dataGridView1.DataSource = dtInstalaciones;

            EstiloDataGrid();
        }
           
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            string conexion = "Server=DESKTOP-PID3H25;Database=VivetwinsDB;Integrated Security=true";

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();


        }


    
        private void CargarCombos()
        {
            
        }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            Filtrar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCalendario frm = new FrmCalendario();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFecha();


        }
    }
}
