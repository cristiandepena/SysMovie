using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;

namespace MoviesMenu
{
    public partial class fUsuarios : Form
    {
        public Usuarios us = new Usuarios();
        public DataTable dt = new DataTable();
        public Conexion con = new Conexion();

        public fUsuarios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = con.BuscarDb("Select Usuario, Clave from Usuarios");
            if (tbNombre.Text == string.Empty || tbApellido.Text == string.Empty || tbDireccion.Text == string.Empty || tbEmail.Text == string.Empty || tbUsuario.Text == string.Empty || tbClave.Text == string.Empty || mtbTelefono.Text == string.Empty)
            {
                MessageBox.Show("Error!", "Error: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count > 0 && tbUsuario.Equals(dt.Rows[0]["Usuario"]))
            {
                MessageBox.Show("Error! \n El usuario ya existe.", "Error: 203", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count > 0 && !tbUsuario.Equals(dt.Rows[0]["Usuario"]))
            {
                us.Nombre = tbNombre.Text;
                us.Apellido = tbApellido.Text;
                us.Direccion = tbDireccion.Text;
                us.Email = tbEmail.Text;
                us.Usuario = tbUsuario.Text;
                us.Clave = tbClave.Text;
                us.Telefono = mtbTelefono.Text;
                us.Cedula = mtbCedula.Text;

                us.insertar();
                MessageBox.Show("Registro exitoso!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
