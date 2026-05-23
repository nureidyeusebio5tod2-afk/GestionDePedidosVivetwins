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
        DataTable dtInstalaciones = new DataTable();


        public FrmInstalacionescs()
        {
            InitializeComponent();
        }
        private void CargarInstalaciones()
        {
      
        }
        private void FrmInstalacionescs_Load(object sender, EventArgs e)
        { 
        }
        
        private void Filtrar()
        {
           
        }
        private void CargarComboEstado()
        {
          
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
           
            dataGridView1.DataSource = listaInstalaciones;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
      
          
        }

        private void FiltrarPorEstado()
        {
        }


        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
        


        }
    }
}
