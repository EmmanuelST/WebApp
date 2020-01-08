using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplication.Entidades
{
    public class Prueba
    {
        public string Nombre { get; set; }
        public virtual List<Productos> lista2 { get; set; }

        public Prueba()
        {
            Nombre = "Prueba";
            lista2 = new List<Productos>();
        }
    }
}