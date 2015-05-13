using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Clientes
    {
        public int Id;
        public String Nombre {get; set;}
        public String Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public String NoCedula { get; set; }
        public String Genero { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }

        public Conexion con = new Conexion();

        public Clientes(){
            this.Id=0;
            this.Nombre=Nombre;
            this.Apellido=Apellido;
            this.FechaNac = DateTime.Now;
            this.NoCedula=NoCedula;
            this.Genero = Genero;
            this.Direccion=Direccion;
            this.Email=Email;
            this.Telefono=Telefono;
            this.Celular=Celular;

        }

        public bool insertar() {

            return con.EjecutarDB("insert into Clientes (Nombre, Apellido, FechaNacimiento, NoCedula, Genero, Direccion, Email, Telefono, Celular) values ('"+this.Nombre+"', '"+this.Apellido+"', '"+this.FechaNac.ToString("MM/dd/yyyy HH:mm:ss")+"', '"+this.NoCedula+"', '"+this.Genero+"', '"+this.Direccion+"', '"+this.Email+"', '"+this.Telefono+"', '"+this.Celular+"')");
        }

        public bool modificar(int id) { return con.EjecutarDB("update Clientes set Nombre = '" + this.Nombre + "',  Apellido = '" + this.Apellido + "', FechaNacimiento = '" + this.FechaNac.ToString("dd-MM-yyyy HH:mm:ss") + "', NoCedula = '" + this.NoCedula + "', Genero = '" + this.Genero + "', Direccion = '" + this.Direccion + "', Email = '" + this.Email + "', Telefono = '" + this.Telefono + "', Celular = '" + this.Celular + "' where idCliente = '"+id+"'"); }
        
        public bool eliminar(int id) { return con.EjecutarDB("delete from Clientes where idCliente = '"+id+"' " ); }
        
        public DataTable buscar(int id) 
        {

            DataTable dt = new DataTable();
            dt = con.BuscarDb("select * from Clientes where idCliente =" +id);

            if (dt.Rows.Count > 0)
            {
                this.Id = (int)dt.Rows[0]["idCliente"];
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Apellido = dt.Rows[0]["Apellido"].ToString();
                this.FechaNac = (DateTime)dt.Rows[0]["FechaNacimiento"];
                this.NoCedula = (String)dt.Rows[0]["NoCedula"];
                this.Genero = (String)dt.Rows[0]["Genero"];
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Celular = dt.Rows[0]["Celular"].ToString();
                
                
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
