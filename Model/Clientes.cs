using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Clientes
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String Cedula { get; set; }

        public int VehiculosId { get; set; }
        public Vehiculos Vehiculos { get; set; }


    }
}
