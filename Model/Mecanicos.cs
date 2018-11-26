using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public partial class Mecanicos
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }

        public int DepartamentosId { get; set; }
        public Departamentos Departamentos { get; set; }

    }
}
