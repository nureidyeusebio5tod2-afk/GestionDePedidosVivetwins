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
            AgregarBotones();
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

        // =====================================
        // AGREGAR BOTONES
        // =====================================

        private void AgregarBotones()
        {
            // EDITAR

            if (!dataGridView1.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar =
                    new DataGridViewButtonColumn();

                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "";
                btnEditar.Text = "✏";
                btnEditar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(btnEditar);
            }

            // ELIMINAR

            if (!dataGridView1.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar =
                    new DataGridViewButtonColumn();

                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "🗑";
                btnEliminar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(btnEliminar);
            }
        }

        // =====================================
        // EDITAR Y ELIMINAR
        // =====================================

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // =================================
            // EDITAR
            // =================================

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                FrmCrearUsuario frm =
                    new FrmCrearUsuario();

                frm.txtId.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Id_Usuario"]
                    .Value.ToString();

                frm.txtUsuario.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Nombre_Usuario"]
                    .Value.ToString();

                frm.cboRol.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["NombreRol"]
                    .Value.ToString();

                frm.cboEstado.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Estado"]
                    .Value.ToString();

                frm.Owner = this;

                frm.ShowDialog();
            }

            // =================================
            // ELIMINAR
            // =================================

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este usuario?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex]
                        .Cells["Id_Usuario"].Value);

                    usuarioBLL.EliminarUsuario(id);

                    MessageBox.Show(
                        "Usuario eliminado correctamente");

                    MostrarUsuarios();
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frm = new FrmCrearUsuario();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // =================================
            // EDITAR
            // =================================

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                FrmCrearUsuario frm =
                    new FrmCrearUsuario();

                frm.txtId.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Id_Usuario"]
                    .Value.ToString();

                frm.txtUsuario.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Nombre_Usuario"]
                    .Value.ToString();

                frm.cboRol.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["NombreRol"]
                    .Value.ToString();

                frm.cboEstado.Text =
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Estado"]
                    .Value.ToString();

                frm.Owner = this;

                frm.ShowDialog();
            }

            // =================================
            // ELIMINAR
            // =================================

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este usuario?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex]
                        .Cells["Id_Usuario"].Value);

                    usuarioBLL.EliminarUsuario(id);

                    MessageBox.Show(
                        "Usuario eliminado correctamente");

                    MostrarUsuarios();
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
