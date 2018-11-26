using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Empleados
    {
        [Key]
        public int Id_Empleado { get; set; }
        public String Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
