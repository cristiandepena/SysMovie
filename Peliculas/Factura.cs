using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Factura
    {
        public int idFactura;
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int idPelicula { get; set; }
        //public DateTime fechaFactura { get; set; }
        public DateTime fechaEntrega { get; set; }
        public int cantidad { get; set; }
        public float total { get; set; }
        public int tiempoRenta { get; set; }

        public Conexion con = new Conexion();
        

        public Factura()
        {
            this.idFactura = 0;
            this.idCliente = idCliente;
            this.idPelicula = idPelicula;
            this.idUsuario = idUsuario;
            //this.fechaFactura = DateTime.Now;
            this.fechaEntrega = fechaEntrega;
            this.cantidad = cantidad;
            this.total = total;
            this.tiempoRenta = tiempoRenta;
        }
        public bool insert() { return con.EjecutarDB("insert into Encabezado (idCliente, idUsuario, fechaEntrega, total, tiempoRenta) values ('" + this.idCliente + "', '" + this.idUsuario + "', '" + this.fechaEntrega.ToString("MM/dd/yyyy") +"' ,'" + this.total + "' , '" + this.tiempoRenta + "')"); }
        public bool insertar() { return con.EjecutarDB("insert into Detalles (idPelicula, cantidad) values ('" + this.idPelicula + "', '" + this.cantidad + "') "); }
        public bool modificar(int id) { return con.EjecutarDB("update Detalles set idCliente = '" + this.idCliente + "', idUsuario = '" + this.idUsuario + "', idPelicula = '" + this.idPelicula + "', fechaEntrega = '" + this.fechaEntrega.ToString("MM/dd/yyyy") + "', cantidad = '" + this.cantidad + "', total = '" + this.total + "', tiempoRenta ='"+this.tiempoRenta+"' where idDetalle = '"+id+"' "); }
        public bool eliminar(int id) { return con.EjecutarDB("delete from Detalles where idDetalle ="+id); }

        public DataTable buscar(int id) 
        { 
            DataTable dt = new DataTable();
            
            dt = con.BuscarDb("select * from Detalles where idDetalle =" + id);

            if (dt.Rows.Count > 0)
            {
                //this.id = (int)dt.Rows[0]["idDetalle"];
                this.idCliente = (int)dt.Rows[0]["idCliente"];
                this.idUsuario = (int)dt.Rows[0]["idUsuario"];
                this.idPelicula = (int)dt.Rows[0]["idPelicula"];
                this.fechaEntrega = (DateTime)dt.Rows[0]["fechaEntrega"];
                this.cantidad = (int)dt.Rows[0]["cantidad"];
                this.total = (float)dt.Rows[0]["total"];
                this.tiempoRenta = (int)dt.Rows[0]["tiempoRenta"];
            }
            
                return dt; 
        }
        public DataTable buscarLista(String campos, String filtro) 
        {
            Conexion db = new Conexion();


            return db.BuscarDb("Select " + campos + " from Detalles Where " + campos+"like '%"+filtro+"%' " ); 
        }
        
    }
}
