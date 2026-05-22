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
    public partial class FrmCliente : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearCliente frm = new FrmCrearCliente();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        public void MostrarClientes()
        {
            dataGridView1.DataSource = clienteBLL.MostrarClientes();
            // OCULTAR ID
            dataGridView1.Columns["Id_Cliente"].Visible = false;
            dataGridView1.DataSource =
        clienteBLL.MostrarClientes();

            // FUENTE GENERAL
            dataGridView1.DefaultCellStyle.Font =
          new Font("Segoe UI", 12, FontStyle.Regular);

            // FUENTE ENCABEZADOS
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // COLOR ENCABEZADOS
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(10, 35, 66);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // COLOR REGISTROS
            dataGridView1.DefaultCellStyle.ForeColor =
                Color.Black;

            // OPCIONAL
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 35;
        }

    }
}
