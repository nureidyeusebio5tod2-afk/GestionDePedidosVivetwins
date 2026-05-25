using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaEntidades.CapaEntidades;
using CapaNegocio;
using CapaNegocio.CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            cbCliente.SelectedIndex = -1;
            txtTelefono.Clear();
            txtDireccion.Clear();

            cbTipoVentana.SelectedIndex = -1;
            cbMaterial.SelectedIndex = -1;

            txtCantidad.Clear();
            txtAncho.Clear();
            txtAlto.Clear();
            txtObservaciones.Clear();

            cbInstalador.SelectedIndex = -1;

            dtpFechaPedido.Value = DateTime.Now;
            dtFechaInstalacion.Value = DateTime.Now;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarClientes()
        {
            ClienteBLL negocio = new ClienteBLL();

            cbCliente.DataSource =
                negocio.MostrarClientes();

            cbCliente.DisplayMember = "Nombre";

            cbCliente.ValueMember = "Id_Cliente";

            cbCliente.SelectedIndex = -1;
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarInstaladores();
            CargarMaterial();
            CargarTipoVentana();

        }

        private void CargarMaterial()
        {
            cbMaterial.Items.Clear();

            cbMaterial.Items.Add("Aluminio");
            cbMaterial.Items.Add("PVC");
            cbMaterial.Items.Add("Madera");

            cbMaterial.SelectedIndex = -1;
        }

        private void CargarTipoVentana()
        {
            cbTipoVentana.Items.Clear();

            cbTipoVentana.Items.Add("Corredera");
            cbTipoVentana.Items.Add("Fija");
            cbTipoVentana.Items.Add("Proyectada");
            cbTipoVentana.Items.Add("Francesa");

            cbTipoVentana.SelectedIndex = -1;
        }

        private void CargarInstaladores()
        {
            InstaladorBLL negocio =
                new InstaladorBLL();

            cbInstalador.DataSource =
                negocio.MostrarInstaladores();

            cbInstalador.DisplayMember = "Nombre";

            cbInstalador.ValueMember = "Id_Instalador";

            cbInstalador.SelectedIndex = -1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCrearCliente frm = new FrmCrearCliente();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
          try
            {
                // =========================
                // VALIDACIONES
                // =========================

                if (cbCliente.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione un cliente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbCliente.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show(
                        "Ingrese la cantidad",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCantidad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAncho.Text))
                {
                    MessageBox.Show(
                        "Ingrese el ancho",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtAncho.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAlto.Text))
                {
                    MessageBox.Show(
                        "Ingrese el alto",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtAlto.Focus();
                    return;
                }

                // =========================
                // CONFIRMAR
                // =========================

                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea guardar este pedido?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    return;
                }

                // =========================
                // CREAR OBJETO
                // =========================

                Pedido pedido = new Pedido();

                pedido.Id_Cliente =
                    Convert.ToInt32(cbCliente.SelectedValue);

                pedido.Id_Usuario =
                    Sesion.IdUsuario;

                pedido.Estado = "Pendiente";

                pedido.Tipo_Ventana =
                    cbTipoVentana.Text;

                pedido.Medida_Ancho =
                    Convert.ToDecimal(txtAncho.Text);

                pedido.Medida_Alto =
                    Convert.ToDecimal(txtAlto.Text);

                pedido.Material =
                    cbMaterial.Text;

                pedido.Cantidad =
                    Convert.ToInt32(txtCantidad.Text);

                pedido.Precio_Unitario = 5000;

                pedido.Observacion =
                    txtObservaciones.Text;

                pedido.Id_Instalador =
                    Convert.ToInt32(cbInstalador.SelectedValue);

                pedido.Fecha_Instalacion =
                    dtFechaInstalacion.Value;

                // =========================
                // GUARDAR
                // =========================

                PedidoBLL negocio = new PedidoBLL();

                negocio.InsertarPedido(pedido);

                MessageBox.Show(
                    "Pedido guardado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // =========================
                // REPORTE
                // =========================

                FrmReportePedidos frm =
                    new FrmReportePedidos();

                frm.ShowDialog();

                // =========================
                // LIMPIAR
                // =========================

                Limpiar();
            }

            // ERROR SQL
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos:\n" + ex.Message,
                    "SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // ERROR FORMATO
            catch (FormatException)
            {
                MessageBox.Show(
                    "Verifique los datos numéricos",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // ERROR GENERAL
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAlto_TextChanged(object sender, EventArgs e)
        {

          
            }
       

        private void txtAlto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
    }
