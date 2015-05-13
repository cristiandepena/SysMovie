using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Usuarios
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Usuario { get; set; }
        public String Clave { get; set; }

        public Conexion con = new Conexion();

        public Usuarios()
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Cedula = Cedula;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Usuario = Usuario;
            this.Clave = Clave;
        }

        public bool insertar() { return con.EjecutarDB("insert into Usuarios (Nombre, Apellido, Cedula, Direccion, Telefono, Email, Usuario, Clave) values('" + this.Nombre + "', '" + this.Apellido + "', '" + this.Cedula + "', '" + this.Direccion + "', '" + this.Telefono + "', '" + this.Email + "' , '" + this.Usuario + "' , '" + this.Clave + "')"); }

        public bool modificar(int id) { return con.EjecutarDB("update Usuarios set Nombre = '" + this.Nombre + "', set Apellido = '" + this.Apellido + "', set Cedula = '" + this.Cedula + "', set Direccion = '" + this.Direccion + "', set Telefono = '" + this.Telefono + "', set Email = '" + this.Email + "' , set Usuario = '" + this.Usuario + "' , set Clave = '" + this.Clave + "' "); }
        
        public bool eliminar(int id) { return con.EjecutarDB("delete from Usuarios where idUsuario = "+id); }
        
        public DataTable buscar(int id) 
        {
            
            DataTable dt = new DataTable();
            dt = con.BuscarDb("select * from Usuarios where idUsuario = "+id);

            if (dt.Rows.Count > 0)
            {
                this.Id = (int)dt.Rows[0]["idUsuario"];
                this.Nombre = (String)dt.Rows[0]["Nombre"];
                this.Apellido = (String)dt.Rows[0]["Apellido"];
                this.Cedula = (String)dt.Rows[0]["Cedula"];
                this.Telefono = (String)dt.Rows[0]["Telefono"];
                this.Email = (String)dt.Rows[0]["Email"];
                this.Usuario = (String)dt.Rows[0]["Usuario"];
                this.Clave = (String)dt.Rows[0]["Clave"];
            }
            
            return dt; 
        }
        public DataTable buscarLista(int id)
        {
            DataTable dt = new DataTable();
            
            return dt; 
        }

    }
}
