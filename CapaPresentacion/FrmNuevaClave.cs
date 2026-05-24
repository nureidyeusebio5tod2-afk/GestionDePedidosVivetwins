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
    public partial class FrmNuevaClave : Form
    {
        public FrmNuevaClave()
        {
            InitializeComponent();
        }

        public FrmNuevaClave(string user)
        {
            InitializeComponent();

         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNuevaClave_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';

            txtConfirmar.PasswordChar = '*';
        }
    }
}
