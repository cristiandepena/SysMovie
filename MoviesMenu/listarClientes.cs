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

namespace MoviesMenu
{
    public partial class listarClientes : Form
    {
        public Conexion db = new Conexion();
        public Clientes cr = new Clientes();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public SqlCommandBuilder scb = new SqlCommandBuilder();
        public DataTable dt = new DataTable();
        public SqlConnection con = new SqlConnection();

        public listarClientes()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=USUARIO-PC\SQLEXPRESS;Initial Catalog = MoviesDB;Integrated Security=True");
            sda = new SqlDataAdapter(@"select * from Clientes", con);
            dt = new DataTable();
            sda.Fill(dt);
            dtgClientes.DataSource = dt;
            scb = new SqlCommandBuilder(sda);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try 
            {
                if (tbKeyword.Text == string.Empty)
                {
                    dtgClientes.DataSource = db.BuscarDb("select * from Clientes");
                }
                else if (tbKeyword.Text != string.Empty) 
                {
                    dtgClientes.DataSource = db.BuscarDb("select * from Clientes where " + cbCampos.SelectedItem.ToString() + " like '%" + tbKeyword.Text + "%' ");
                }
            }
            catch (Exception) { }
        }
    }
}
