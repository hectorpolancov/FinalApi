using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Factura
    {
        [Key]
        public int Id { get; set; }
        public String Garantia { get; set; }
        public String Costo { get; set; }

        public int Areas_ReparacionId { get; set; }
        public Areas_Reparacion Areas_Reparacion { get; set; }

    }
}
