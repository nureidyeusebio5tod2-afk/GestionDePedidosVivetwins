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
    public partial class FrmInstalacionescs : Form
    {
        public FrmInstalacionescs()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmInstalacionescs_Load(object sender, EventArgs e)
        {

        }

        private string ObtenerEstado(DateTime fecha)
        {
            if (fecha.Date > DateTime.Now.Date)
            {
                return "Pendiente";
            }
            else if (fecha.Date == DateTime.Now.Date)
            {
                return "En Proceso";
            }
            else
            {
                return "Finalizado";
            }
        }
    }
}
