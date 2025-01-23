using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuarios.frmUsuarios frmUser = new Usuarios.frmUsuarios();
            frmUser.ShowDialog();
        }
    }
}
