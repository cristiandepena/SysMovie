using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;

namespace MoviesMenu
{
    public partial class Login : Form
    {
       
        public Conexion co = new Conexion();
        public DataTable dt = new DataTable();
        public String user;  
        
        public Login()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
           //dt = con.BuscarDb("Select Nombre, Usuario, Clave from Usuarios");
           // String usuario = dt.Rows[0]["Nombre"].ToString();
            SqlConnection con = new SqlConnection(@"Data Source=USUARIO-PC\SQLEXPRESS;Initial Catalog = MoviesDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Usuario, Clave from Usuarios", con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        if (mtbUsuario.Text.Trim() == dr.GetString(0).Trim() && textBox1.Text.Trim() == dr.GetString(1))
                        {
                            MessageBox.Show("Exito!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            user = mtbUsuario.Text;
                            this.Hide();
                            fPrincipal fp = new fPrincipal();
                            fp.ShowDialog();
                            this.Close();

                        }
                        else 
                        {
                            MessageBox.Show("Error! \n El usuario o la contrasena son incorrectos...", "Error: 402", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    dr.Close();
                }
                
                con.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
