using _01_Mi_Primera_Vez.Datos;
using _01_Mi_Primera_Vez.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validación básica de campos
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbPais.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear un objeto de tipo dto_usuarios con los datos del formulario
                dto_usuarios user = new dto_usuarios
                {
                    Cedula = txtCedula.Text,
                    Nombres = txtNombres.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    idPais = Convert.ToInt32(cmbPais.SelectedValue) // Asume que cmbPais tiene un DataSource configurado con ValueMember = idPais
                };

                // Crear una instancia de la clase cls_usuarios y llamar al método insertar
                cls_usuarios clsUsuarios = new cls_usuarios();
                bool isInserted = clsUsuarios.insertar(user);

                if (isInserted)
                {
                    MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos del formulario
                    txtCedula.Clear();
                    txtNombres.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    cmbPais.SelectedIndex = -1; // Restablecer el ComboBox
                }
                else
                {
                    MessageBox.Show("Error al guardar el usuario. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
