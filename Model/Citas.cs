using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Citas
    {
        [Key]
        public int Id_Cita { get; set; }
        public String Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public String Hora_llegada { get; set; }
        public String Hora_salida { get; set; }
        

        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }
    }
}
