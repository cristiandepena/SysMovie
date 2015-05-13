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

namespace MoviesMenu
{
    public partial class fPeliculas : Form
    {
        public Peliculas pe = new Peliculas();
      
        public fPeliculas()
        {
            InitializeComponent();
         
        }

        private void fPeliculas_Load(object sender, EventArgs e)
        {
                          
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float precio = 0;
            int ano = 0;

            int.TryParse(cbAno.SelectedItem.ToString(), out ano);
            
            float.TryParse(cbPrecio.SelectedItem.ToString(), out precio);
            try
            {

                pe.Nombre = tbNombre.Text;
                pe.Genero = cbGenero.SelectedItem.ToString();
                pe.Idioma = cbIdioma.SelectedItem.ToString();
                pe.Ano = ano;
                pe.PrecioRenta = precio;

                pe.insertar();

                MessageBox.Show("Guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }catch (Exception)
            {
                MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdPelicula.Text);

            float precio = 0;
            
            int ano = 0;

            int.TryParse(cbAno.SelectedItem.ToString(), out ano);

            float.TryParse(cbPrecio.SelectedItem.ToString(), out precio);
            
            pe = new Peliculas();

            try
            {
                if (tbIdPelicula.Text == string.Empty) 
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdPelicula.Text != string.Empty)
                {


                    pe.Nombre = tbNombre.Text;
                    pe.Genero = cbGenero.SelectedItem.ToString();
                    pe.Idioma = cbIdioma.SelectedItem.ToString();
                    pe.Ano = ano;
                    pe.PrecioRenta = precio;

                    pe.modificar(id);
                }
            }
            catch (Exception) { MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdPelicula.Text);

            pe = new Peliculas();

            try
            {
                if (tbIdPelicula.Text == string.Empty)
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdPelicula.Text != string.Empty)
                {
                    pe.eliminar(id);

                    MessageBox.Show("El registro se ha eliminado correctamente!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                }
            }catch (Exception) { MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbIdPelicula.Text);
            
            float precio = Convert.ToSingle(cbPrecio.SelectedValue);
            
            pe = new Peliculas();
            
            try
            {
                if (tbIdPelicula.Text == string.Empty) 
                {
                    MessageBox.Show("Error! \n El id no puede estar vacio.", "Error: 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbIdPelicula.Text != string.Empty)
                {
                    pe.buscar(id);

                    tbNombre.Text = pe.Nombre;
                    cbGenero.SelectedValue = pe.Genero;
                    cbAno.SelectedItem = pe.Ano;
                    cbIdioma.SelectedItem = pe.Idioma;
                    precio = pe.PrecioRenta;

                    
                }
            }
            catch (Exception ie)
            {
                MessageBox.Show(ie.Message);
                //MessageBox.Show("Error desconocido!", "Error: 500", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

    }
}
