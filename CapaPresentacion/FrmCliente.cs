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
            EstiloDataGrid();
            AgregarBotones();

            cbFiltro.Items.Add("Nombre");
            cbFiltro.Items.Add("Telefono");
            cbFiltro.Items.Add("Direccion");

            cbFiltro.SelectedIndex = 0;
        }


        public void MostrarClientes()
        {
            dgvClientes.DataSource =
                clienteBLL.MostrarClientes();
        }

        // =====================================
        // ESTILO DEL DATAGRIDVIEW
        // =====================================

        private void EstiloDataGrid()
        {
            dgvClientes.BorderStyle = BorderStyle.None;

            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvClientes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(17, 136, 167);

            dgvClientes.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(10, 25, 47);

            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvClientes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvClientes.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvClientes.RowTemplate.Height = 35;

            dgvClientes.EnableHeadersVisualStyles = false;

            dgvClientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.AllowUserToAddRows = false;

            dgvClientes.ReadOnly = true;
        }

        // =====================================
        // BOTONES EDITAR Y ELIMINAR
        // =====================================

        private void AgregarBotones()
        {
            // EDITAR

            if (!dgvClientes.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar =
                    new DataGridViewButtonColumn();

                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "";
                btnEditar.Text = "✏";
                btnEditar.UseColumnTextForButtonValue = true;

                dgvClientes.Columns.Add(btnEditar);
            }

            // ELIMINAR

            if (!dgvClientes.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar =
                    new DataGridViewButtonColumn();

                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "🗑";
                btnEliminar.UseColumnTextForButtonValue = true;

                dgvClientes.Columns.Add(btnEliminar);
            }
        }

        // EDITAR Y ELIMINAR
        // =====================================

    
private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        
        {
            if (e.RowIndex < 0)
                return;

            // =================================
            // EDITAR
            // =================================

            if (dgvClientes.Columns[e.ColumnIndex].Name == "Editar")
            {
                FrmCrearCliente frm =
                    new FrmCrearCliente();

                frm.txtId.Text =
                    dgvClientes.Rows[e.RowIndex]
                    .Cells["Id_Cliente"]
                    .Value.ToString();

                frm.txtNombre.Text =
                    dgvClientes.Rows[e.RowIndex]
                    .Cells["Nombre"]
                    .Value.ToString();

                frm.txtTelefono.Text =
                    dgvClientes.Rows[e.RowIndex]
                    .Cells["Telefono"]
                    .Value.ToString();

                frm.txtDireccion.Text =
                    dgvClientes.Rows[e.RowIndex]
                    .Cells["Direccion"]
                    .Value.ToString();

                frm.Owner = this;

                frm.ShowDialog();
            }

            // =================================
            // ELIMINAR
            // =================================

            if (dgvClientes.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este cliente?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(
                            dgvClientes.Rows[e.RowIndex]
                            .Cells["Id_Cliente"].Value);

                        ClienteBLL negocio =
                            new ClienteBLL();

                        negocio.EliminarCliente(id);

                        MessageBox.Show(
                            "Cliente eliminado correctamente",
                            "Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        MostrarClientes();
                    }
                    catch
                    {
                        MessageBox.Show(
                            "No se puede eliminar el cliente porque tiene pedidos registrados",
                            "Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        

    }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            string campo =
                cbFiltro.SelectedItem.ToString();

            string valor =
                txtBuscar.Text;

            dgvClientes.DataSource =
                clienteBLL.BuscarClientes(campo, valor);

        }
    }
    }
    
        
    
    

