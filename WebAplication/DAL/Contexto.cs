using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAplication.Entidades;

namespace WebAplication.DAL
{
    public class Contexto:DbContext
    {
       
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; } 
        public DbSet<Agricultores> Agricultores { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<VentaDetalles> VentaDetalles { get; set; }

        public Contexto():base("ConStr")
        {

        }
    }
}