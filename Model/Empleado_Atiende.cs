using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
   public partial class Empleado_Atiende
    {
        [Key]
        public int ID { get; set; }

        public int Id_Empleado { get; set; }
        public Empleados Empleados { get; set; }

        public int ClientesId { get; set; }
        public Clientes clientes { get; set; } 

    }
}
