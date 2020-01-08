using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAplication.Entidades
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
        public string TipoVeta { get; set; }
        public decimal TasaInteres { get; set; }
        public DateTime HastaFecha { get; set; }

        [Browsable(false)]
        public string Comentario { get; set; }
        [ForeignKey("IdVenta")]
        public virtual List<VentaDetalles> Detalles { get; set; }
        

        public Ventas()
        {
            IdVenta = 0;
            IdVendedor = 0;
            IdCliente = 0;
            Fecha = DateTime.Now;
            Total = 0;
            IdUsuario = 0;
            TipoVeta = "Contado";
            TasaInteres = 0;
            HastaFecha = DateTime.Now;
            Comentario = string.Empty;
            Detalles = new List<VentaDetalles>();
        }

        public void CalcularTotal()
        {
            Total = 0;
            foreach(var obj in Detalles)
            {
                Total += obj.Cantidad * obj.Precio;
            }

        }


        public decimal CalcularInteres()
        {
            return (TasaInteres / 100) / Total;
        }
    }
}