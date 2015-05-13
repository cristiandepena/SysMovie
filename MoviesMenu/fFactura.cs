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
    public partial class fFactura : Form
    {
        public Factura fr = new Factura();
        public DataTable dt = new DataTable();
        public Conexion con = new Conexion();
        public float total;
        public int pelicula;
        public int usuario;
        public int cliente;
        public int tiempo;
        public DateTime fecha;
        

        public fFactura()
        {
            InitializeComponent();
            
            cbIdUsuario.DataSource = con.BuscarDb("select idUsuario, Nombre from Usuarios");
            cbIdUsuario.DisplayMember = "Nombre";
            cbIdUsuario.ValueMember = "idUsuario";
            
            

            cbIdCliente.DataSource = con.BuscarDb("select idCliente, Nombre from Clientes");
            cbIdCliente.DisplayMember = "Nombre";
            cbIdCliente.ValueMember = "idCliente";

            

            cbPeliculas.DataSource = con.BuscarDb("select idPelicula, Nombre from Peliculas");
            cbPeliculas.DisplayMember = "Nombre";
            cbPeliculas.ValueMember = "idPelicula";


            
            tbTotal.Text = "120.0";
            dtpFechaEntrega.Value = DateTime.Now;

        }

        public void totales()
        {
            float suma = 0;

            foreach (DataGridViewRow fila in dtgFacturas.Rows)
            {
                suma += Convert.ToSingle(fila.Cells[5].Value);
            }
            tbTotal.Text = suma.ToString();

            
        }

        public void anadir()
        {
            total = Convert.ToSingle(tbTotal.Text);

            cliente = (int)cbIdCliente.SelectedValue;
            usuario = (int)cbIdUsuario.SelectedValue;
            pelicula = (int) cbPeliculas.SelectedValue;
            tiempo = Convert.ToInt32(tbTiempoRenta.Text);
            fecha = (DateTime)dtpFechaEntrega.Value;
            total = 120;
            this.dtgFacturas.Rows.Add(cliente, usuario, pelicula, tiempo, fecha, total);
            
        }

        private void dtpFechaEntrega_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            DateTime fr = dtpFechaEntrega.Value;

            TimeSpan ts = fr - fecha;

            int dias = ts.Days+1;

            String diferencia = dias.ToString();

            tbTiempoRenta.Text = diferencia;
        }

        private void tbTiempoRenta_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            fr = new Factura();

            total = Convert.ToSingle(tbTotal.Text);

            int cantidad = 0;

            foreach (DataGridViewRow filas in dtgFacturas.Rows){
                cantidad++;
            }

             try
            {

                fr.cantidad = cantidad;
                fr.idPelicula = (int)cbPeliculas.SelectedValue;

                fr.insertar();
                MessageBox.Show("Registro exitoso!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ie) { MessageBox.Show(ie.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            fr = new Factura();
            total = Convert.ToSingle(tbTotal.Text);
            

            
            try
            {
                int renta = Convert.ToInt32(tbTiempoRenta.Text);

                int id = Convert.ToInt32(tbIdFactura.Text);
                
                if (tbIdFactura.Text == null)
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdFactura.Text != null)
                {
                    fr.idCliente = (int)cbIdCliente.SelectedValue;
                    fr.idUsuario = (int)cbIdUsuario.SelectedValue;
                    fr.idPelicula = (int)cbPeliculas.SelectedValue;
                    
                   
                    fr.fechaEntrega = dtpFechaEntrega.Value;
                    
                    fr.total = total;
                    fr.tiempoRenta = renta;

                    fr.modificar(id);
                    MessageBox.Show("Se ha modificado el registro!", "Modified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error);;
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            fr = new Factura();

            
            try
            {
                int id = Convert.ToInt32(tbIdFactura.Text);
                
                
                if (tbIdFactura.Text == string.Empty)
                {
                    MessageBox.Show("Error, no existe ninguna factura con ese id.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdFactura.Text != string.Empty)
                {
                    fr.buscar(id);

                    //cbIdCliente.SelectedValue = fr.idCliente;
                    //cbIdUsuario.SelectedValue = fr.idUsuario;
                    cbPeliculas.SelectedValue = fr.idPelicula;
                    
                    dtpFechaEntrega.Value = fr.fechaEntrega;
                    //tbSubtotal.Text = fr.Subtotal.ToString();
                    //tbTiempoRenta.Text = fr.tiempoRenta.ToString();
                    //tbTotal.Text = fr.Total.ToString();
                }

            }
            catch (Exception ie)
            {
                
                MessageBox.Show(ie.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdFactura.Text);
            
            fr = new Factura();
            try
            {
                if (tbIdFactura.Text == string.Empty) 
                {
                    MessageBox.Show("Error, no existe ninguna factura con ese id.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdFactura.Text != string.Empty)
                {
                    fr.eliminar(id);
                    MessageBox.Show("El registro se ha eliminado correctamente.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPelicula2_SelectedValueChanged(object sender, EventArgs e)
        {
       
            
        }

        private void cbPelicula3_SelectedValueChanged(object sender, EventArgs e)
        {
      
            
        }

        private void cbPelicula1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            reportesCliente rc = new reportesCliente();
            rc.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            anadir();
            totales();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

            fr = new Factura();

            total = Convert.ToSingle(tbTotal.Text);

            int renta = Convert.ToInt32(tbTiempoRenta.Text);

            fr.idCliente = (int)cbIdCliente.SelectedValue;
            fr.idUsuario = (int)cbIdUsuario.SelectedValue;
            fr.idPelicula = (int)cbPeliculas.SelectedValue;


            fr.fechaEntrega = dtpFechaEntrega.Value;

            fr.total = total;
            fr.tiempoRenta = renta;

            fr.insert();
            MessageBox.Show("Registro exitoso!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
