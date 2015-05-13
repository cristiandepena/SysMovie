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
    public partial class listarFacturas : Form
    {
        public Conexion db = new Conexion();
        public Factura fr = new Factura();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public SqlCommandBuilder scb = new SqlCommandBuilder();
        public DataTable dt = new DataTable();
        public SqlConnection con = new SqlConnection();
        
        public listarFacturas()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=USUARIO-PC\SQLEXPRESS;Initial Catalog = MoviesDB;Integrated Security=True");
            sda = new SqlDataAdapter(@"select * from Detalles", con);
            dt = new DataTable();
            sda.Fill(dt);
            dtgFactura.DataSource = dt;
            scb = new SqlCommandBuilder(sda);
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbKeyword.Text == string.Empty)
                {
                    dtgFactura.DataSource = db.BuscarDb("select * from Detalles");

                }
                else if (tbKeyword.Text != string.Empty)
                {
                dtgFactura.DataSource = db.BuscarDb("select * from Detalles where "+cbCampos.SelectedItem.ToString()+" like'%"+tbKeyword.Text+"%' ");
                }
            }
            catch (Exception ie) { MessageBox.Show(ie.Message); }
        }

        private void dtgFactura_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
            sda.Update(dt);

        }
    }
}
