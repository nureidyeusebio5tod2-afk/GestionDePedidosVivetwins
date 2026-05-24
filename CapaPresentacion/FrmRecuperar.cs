using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FrmRecuperar : Form
    {
        public FrmRecuperar()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        string codigoGenerado;

        private bool ExisteUsuario(string usuario)
        {
            bool existe = false;

            SqlConnection cn =
            new SqlConnection(
            "Data Source=DESKTOP-PID3H25;Initial Catalog=VivetwinsDB;Integrated Security=True");

            SqlCommand cmd =
            new SqlCommand("SP_ExisteUsuario", cn);

            cmd.CommandType =
            CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
            "@Usuario", usuario);

            cn.Open();

            int cantidad =
            Convert.ToInt32(
            cmd.ExecuteScalar());

            if (cantidad > 0)
            {
                existe = true;
            }

            cn.Close();

            return existe;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ExisteUsuario(txtUsuario.Text))
            {
                MessageBox.Show(
                "El usuario no existe");

                return;
            }

            codigoGenerado =
            new Random().Next(100000, 999999).ToString();

            MessageBox.Show(
            "Tu código de recuperación es: "
            + codigoGenerado);

            FrmNuevaClave frm =
            new FrmNuevaClave(
            txtUsuario.Text,
            codigoGenerado);

            frm.ShowDialog();
        }

        private void FrmRecuperar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
