using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebUI
{
    public partial class wfCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddGenero.SelectedIndex = 0;
                tbNombre.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Clientes c = new Clientes();

            
                c.Nombre = tbNombre.Text;
                c.Apellido = tbApellido.Text;
                c.FechaNac = caFechaNac.SelectedDate;
                c.NoCedula = tbCedula.Text;
                c.Telefono = tbTelefono.Text;
                c.Celular = tbCelular.Text;
                c.Email = tbEmail.Text;
                c.Direccion = tbDireccion.Text;
                c.Genero = ddGenero.SelectedValue;

                c.insertar();

                Response.Write("Se guardo!");
        }
    }
}