using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;
using System.Data.SqlClient;
using System.Windows;

namespace MoviesMenu
{
    public partial class listarPeliculas : Form
    {
        public Conexion db = new Conexion();
        public Peliculas pl = new Peliculas();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public SqlCommandBuilder scb = new SqlCommandBuilder();
        public DataTable dt = new DataTable();
        public SqlConnection con = new SqlConnection();

        public listarPeliculas()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=USUARIO-PC\SQLEXPRESS;Initial Catalog = MoviesDB;Integrated Security=True");
            sda = new SqlDataAdapter(@"select * from Peliculas", con);
            dt = new DataTable();
            sda.Fill(dt);
            dtgClientes.DataSource = dt;
            scb = new SqlCommandBuilder(sda);
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbKeyword.Text == string.Empty && cbCampos.SelectedItem.ToString() == string.Empty)
                {
                    dtgClientes.DataSource = db.BuscarDb("select * from Peliculas");
                }
                else if (tbKeyword.Text != string.Empty && cbCampos.SelectedItem.ToString() == string.Empty)
                {
                    MessageBox.Show("Error! \n Debe elegir un campo de busqueda...", "Error: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbCampos.Focus();

                }else if(tbKeyword.Text != string.Empty && cbCampos.SelectedItem.ToString() != string.Empty)
                {
                   dtgClientes.DataSource = db.BuscarDb("select * from Peliculas where " + cbCampos.SelectedItem.ToString() + " like '%" + tbKeyword.Text + "%' ");

                }
            }
            catch (Exception) { MessageBox.Show("Error! \n La pelicula no esta registrada o el campo tiene mala definicion...", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
