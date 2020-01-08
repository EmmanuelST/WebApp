using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication.Entidades
{
    public class Agricultores
    {
        [Key]
        public int AgricultorId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Agricultores()
        {
            AgricultorId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Cedula = string.Empty;
            FechaNacimiento = DateTime.Now;
        }
    }
}