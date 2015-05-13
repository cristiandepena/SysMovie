using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class Peliculas
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Genero { get; set; }
        public String Idioma { get; set; }
        public int Ano { get; set; }
        public float PrecioRenta { get; set; }

        public Conexion con = new Conexion();

        public Peliculas()
        {
            this.Id = 0;
            this.Nombre = Nombre;
            this.Genero = Genero;
            this.Idioma = Idioma;
            this.Ano = Ano;
            this.PrecioRenta = PrecioRenta;
        }

        public bool insertar() { return con.EjecutarDB("insert into Peliculas (Nombre, Genero, Idioma, Ano, precioRenta) values ('" + this.Nombre + "','" + this.Genero + "','" + this.Idioma + "','" + this.Ano + "','" + this.PrecioRenta + "')"); }

        public bool modificar(int id) { return con.EjecutarDB("update Peliculas set Nombre= '" + this.Nombre + "', Genero= '" + this.Genero + "', Idioma= '" + this.Idioma + "', precioRenta= '" + this.PrecioRenta + "' where idPelicula ='"+id+"' " ); }
        
        public bool eliminar(int id) { return con.EjecutarDB("delete from Peliculas where idPelicula = '"+id+"' "); }
        
        public DataTable buscar(int id) 
        {
            
            DataTable dt = new DataTable();

            dt = con.BuscarDb("select * from Peliculas where idPelicula = "+id.ToString());

            if (dt.Rows.Count > 0)
            {
                this.Id = (int)dt.Rows[0]["idPelicula"];
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Idioma = dt.Rows[0]["Idioma"].ToString();
                this.Genero = dt.Rows[0]["Genero"].ToString();
                this.Ano = (int)dt.Rows[0]["Ano"];
                this.PrecioRenta = (float)dt.Rows[0]["precioRenta"];
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

