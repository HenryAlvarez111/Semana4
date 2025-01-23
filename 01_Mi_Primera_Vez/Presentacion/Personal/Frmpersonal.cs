using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Mi_Primera_Vez.Logica;

namespace _01_Mi_Primera_Vez.Presentacion.Personal
{
    public partial class Frmpersonal : Form
    {
        public bool modoEdision = false;
        public Frmpersonal(string modo)
        {
            InitializeComponent();
            if (modo != "n") this.modoEdision = true;            
        }
        
        private void Frmpersonal_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrmPersonal.Text = "Ingreso de Nuevo Personal";
            }
            else { 
                lblFrmPersonal.Text = "Actualziacion de Personal";
            }

            var listapaises = new cls_pais();
            
            cmbPais.DataSource = listapaises.leer();
            cmbPais.ValueMember = "IdPais";
            cmbPais.DisplayMember = "Detalle";

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dto_personal = new Datos.dto_personal {
            cargo = txtCargo.Text,
            cedula = txtCedula.Text,
            idPais = (int)cmbPais.SelectedValue,
            nombre = txtNombres.Text,
            sueldo = decimal.Parse(txtSalario.Text)
            };

            var cls_personal = new cls_personal();

            if (cls_personal.Insertar(dto_personal) == "ok")
            {
                MessageBox.Show("Se guardo con exito");
                this.Close();
            }
            else {
                MessageBox.Show("Error al guardar");
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
