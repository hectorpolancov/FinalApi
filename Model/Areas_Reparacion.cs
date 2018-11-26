using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
   public partial class Areas_Reparacion
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
    }
}
