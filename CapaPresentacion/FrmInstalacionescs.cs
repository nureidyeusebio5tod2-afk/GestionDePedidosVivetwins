using CapaEntidades;
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

namespace CapaPresentacion
{
    public partial class FrmInstalacionescs : Form
    {
        List<Instalacion> listaInstalaciones = new List<Instalacion>();

        public FrmInstalacionescs()
        {
            InitializeComponent();
        }

        private void FrmInstalacionescs_Load(object sender, EventArgs e)
        {
            cmbFiltro.Items.Add("Cliente");
            cmbFiltro.Items.Add("Estado");
            cmbFiltro.Items.Add("Direccion");

            cmbFiltro.SelectedIndex = 0;
            dataGridView1.DataSource = ObtenerInstalaciones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower();
            string filtro = cmbFiltro.SelectedItem.ToString();

            var resultado = listaInstalaciones;

            if (filtro == "Id Instalacion")
                resultado = listaInstalaciones
                    .Where(x => x.Id_Instalacion.ToString().Contains(texto))
                    .ToList();

            if (filtro == "Id Pedido")
                resultado = listaInstalaciones
                    .Where(x => x.Id_Pedido.ToString().Contains(texto))
                    .ToList();

            if (filtro == "Id Instalador")
                resultado = listaInstalaciones
                    .Where(x => x.Id_Instalador.ToString().Contains(texto))
                    .ToList();

            if (filtro == "Fecha")
                resultado = listaInstalaciones
                    .Where(x => x.Fecha_Instalacion.ToString().Contains(texto))
                    .ToList();

            if (filtro == "Estado")
                resultado = listaInstalaciones
                    .Where(x => x.Estado.ToLower().Contains(texto))
                    .ToList();

            dataGridView1.DataSource = resultado;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbFiltro.SelectedIndex = 0;
            dataGridView1.DataSource = listaInstalaciones;
        }
        private DataTable ObtenerInstalaciones()
        {
            DataTable dt = new DataTable();

            string conexion = "Server=NUREIDY-TATTA\\MSSQLSERVER02;Database=VivetwinsDB;Integrated Security=true";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Instalaciones";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
