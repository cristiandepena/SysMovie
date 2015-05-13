using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MoviesMenu;
using BLL;
using DAL;

namespace MoviesMenu
{
    public partial class fClientes : Form
    {
        public Clientes c = new Clientes();
        public Conexion db = new Conexion();

        public fClientes()
        {
            InitializeComponent();
            cbGenero.SelectedItem = 0;
            tbNombre.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbNombre.Text == string.Empty || tbApellido.Text == string.Empty || tbDireccion.Text == string.Empty || tbEmail.Text == string.Empty || mtbCedula.Text == string.Empty || mtbTelefono.Text == string.Empty)
            {

                MessageBox.Show("Error! \n No todos los campos estan llenos.", "Error: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                c = new Clientes();

                try
                {
                    c.Nombre = tbNombre.Text;
                    c.Apellido = tbApellido.Text;
                    c.FechaNac = dtpFecha.Value;
                    c.NoCedula = mtbCedula.Text;
                    c.Telefono = mtbTelefono.Text;
                    c.Celular = mtbCelular.Text;
                    c.Email = tbEmail.Text;
                    c.Direccion = tbDireccion.Text;
                    c.Genero = cbGenero.SelectedItem.ToString();

                    c.insertar();

                    MessageBox.Show("Guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception) { MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdCliente.Text);

            c = new Clientes();

            try
            {
                if (tbIdCliente.Text == string.Empty)
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 402", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (tbIdCliente.Text != string.Empty)
                {
                    c.Nombre = tbNombre.Text;
                    c.Apellido = tbApellido.Text;
                    c.FechaNac = dtpFecha.Value;
                    c.NoCedula = mtbCedula.Text;
                    c.Telefono = mtbTelefono.Text;
                    c.Celular = mtbCelular.Text;
                    c.Email = tbEmail.Text;
                    c.Direccion = tbDireccion.Text;
                    c.Genero = cbGenero.SelectedItem.ToString();

                    c.modificar(id);
                    MessageBox.Show("El registro ha sido modificado exitosamente!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            c = new Clientes();
            try
            {
                int id = Convert.ToInt32(tbIdCliente.Text);
                if (tbIdCliente.Text == string.Empty)
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 402", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (tbIdCliente.Text != string.Empty)
                {
                    c.buscar(id);

                    tbNombre.Text = c.Nombre;
                    tbApellido.Text = c.Apellido;
                    dtpFecha.Value = c.FechaNac;
                    mtbCedula.Text = c.NoCedula;
                    mtbTelefono.Text = c.Telefono;
                    mtbCelular.Text = c.Celular;
                    tbEmail.Text = c.Email;
                    tbDireccion.Text = c.Direccion;
                    cbGenero.SelectedItem = c.Genero;
                }
            }
            catch (Exception) { MessageBox.Show("Error, no existe ninguna factura con ese id.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdCliente.Text);

            c = new Clientes();
            try
            {
                c.eliminar(id);
                if (tbIdCliente.Text == string.Empty)
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 402", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdCliente.Text != string.Empty)
                {
                    MessageBox.Show("El registro se ha eliminado correctamente!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    tbIdCliente.Text = "";
                    tbNombre.Text = "";
                    tbApellido.Text = "";
                    mtbCedula.Text = "";
                    mtbTelefono.Text = "";
                    mtbCelular.Text = "";
                    tbEmail.Text = "";
                    tbDireccion.Text = "";
                }
            }
            catch (Exception) { MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbNombre.Text = "";
            tbApellido.Text = "";
            mtbCedula.Text = "";
            mtbTelefono.Text = "";
            mtbCelular.Text = "";
            tbEmail.Text = "";
            tbDireccion.Text = "";
        }

        private void tbIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar));
        }
    }
}
