using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoviesMenu
{
    public partial class fPrincipal : Form
    {
        

        public fPrincipal()
        {
            InitializeComponent();
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUsuarios fr = new fUsuarios();
            fr.Show();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fClientes fc = new fClientes();
            fc.Show();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fPeliculas fp = new fPeliculas();
            fp.Show();
        }

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fFactura fr = new fFactura();
            fr.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listarFacturas lf = new listarFacturas();
            lf.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listarClientes lc = new listarClientes();
            lc.Show();
        }

        private void peliculasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listarPeliculas lp = new listarPeliculas();
            lp.Show();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por: Cristian A. De Pena \n Matricula: 2011-0710 \n Version: 1.0 Beta","About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    Login lp = new Login();
        //    lp.cerrar();
        }

        private void fPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
