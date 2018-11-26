using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Persistence
{
   public class VehiculoDbContext : DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Mecanicos> Mecanicos { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Empleado_Atiende> Empleado_Atiende { get; set; }
        public DbSet<Areas_Reparacion> Areas_Reparacion { get; set; }
        public DbSet<Empleados> Empleados { get; set; }

        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options)
                : base(options)
        { }

    }


}
