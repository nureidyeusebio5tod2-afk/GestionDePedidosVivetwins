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
    public partial class FrmUsuario : Form
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        public void MostrarUsuarios()
        {
            dataGridView1.DataSource =
                usuarioBLL.MostrarUsuarios();

            // OCULTAR ID
            dataGridView1.Columns["Id_Usuario"].Visible = false;

            // FUENTE REGISTROS
            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Regular);

            // FUENTE ENCABEZADOS
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // ESTILO ENCABEZADOS
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // ESTILO REGISTROS
            dataGridView1.DefaultCellStyle.BackColor =
                Color.White;

            dataGridView1.DefaultCellStyle.ForeColor =
                Color.Black;

            // SELECCIÓN
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 90, 158);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.White;

            // AJUSTES
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 35;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.BorderStyle = BorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frm = new FrmCrearUsuario();

            frm.ShowDialog();
        }
    }
}
