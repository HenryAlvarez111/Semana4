using _01_Mi_Primera_Vez.Presentacion.Usuarios;
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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }


        private void btnPerosnal_Click(object sender, EventArgs e)
        {
            CUPersonal frmPrueba = new CUPersonal();
            PanelGeneral.Controls.Clear();
            frmPrueba.Dock = DockStyle.Fill;
            PanelGeneral.Controls.Add(frmPrueba);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            CUUsuarios Usuarios = new CUUsuarios();
            PanelGeneral.Controls.Clear();
            Usuarios.Dock = DockStyle.Fill;
            PanelGeneral.Controls.Add(Usuarios);
        }
    }
}

