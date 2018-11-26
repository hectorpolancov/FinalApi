using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
   public partial class Vehiculos
    {
        [Key]
        public int Id { get; set; }
        public String Matricula { get; set; }
        public String Modelo { get; set; }
        public String Estado { get; set; }
        public String Agencia { get; set; }
        public int Año { get; set; }

        public Clientes ClientesId { get; set; }
    }
}
