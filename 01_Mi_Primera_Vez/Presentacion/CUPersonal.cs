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
namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUPersonal : UserControl
    {
        public CUPersonal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Personal.Frmpersonal frmpersonal = new Personal.Frmpersonal("n");
            frmpersonal.Text = "Nuevo Ingreso de Personal";
            frmpersonal.ShowDialog();
        }

        private void CUPersonal_Load(object sender, EventArgs e)
        {
            //llamar cls_personal cargar el procedmiento donde se muestren todos los registros de la BDD
            this.cargaGrilla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void cargaGrilla() {
            var logicaPersonal = new cls_personal();
            var autoincrmento = new DataGridViewTextBoxColumn {
            HeaderText="N.-",
            ReadOnly = true
            };
            dataGridView1.Columns.Add(autoincrmento);
            
            var btnEditar = new DataGridViewButtonColumn {
            HeaderText = "Editar",
            Text = "Editar",
            UseColumnTextForButtonValue = true
            };
            

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
           
            dataGridView1.DataSource = logicaPersonal.todos();
            dataGridView1.Columns["cedula"].HeaderText = "Cédula";
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["cargo"].HeaderText = "Cargo";
            dataGridView1.Columns["sueldo"].HeaderText = "Salario";
            dataGridView1.Columns["Detalle"].HeaderText = "Detalle";
            //dataGridView1.Columns["IdPersonal"].Visible = false;
            dataGridView1.Columns["IdPais"].Visible = false;

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
            
            //dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void EditarPersonal(int id) {
            MessageBox.Show("Estoy en el editar y el id es: " + id);
        }

        public void ElimnarPersonal(int id)
        {
            MessageBox.Show("Estoy en el eliminar y el id es: " + id);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaselecciona = dataGridView1.Rows[e.RowIndex];
                var IdPersonal = filaselecciona.Cells["IdPersonal"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarPersonal((int)IdPersonal);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar") {
                    ElimnarPersonal((int)IdPersonal);
                }
            }

        }
    }
}
