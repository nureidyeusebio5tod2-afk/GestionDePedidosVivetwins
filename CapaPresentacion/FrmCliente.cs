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
        }

       
    }
}
