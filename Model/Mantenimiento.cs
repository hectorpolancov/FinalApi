using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Mantenimiento
    {
        [Key]
        public int Id { get; set; }
        public String Fecha_entrada { get; set; }
        public String Fecha_salida { get; set; }

        public int VehiculosId { get; set; }
        public Vehiculos Vehiculos { get; set; }

        public int MecanicosId { get; set; }
        public Mecanicos Mecanicos { get; set; }

        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
