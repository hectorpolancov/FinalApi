using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IEmpleadosService
    {
        IEnumerable<Empleados> GetAll();
        bool Add(Empleados model);
        bool Delete(int id);
        bool Update(Empleados model);
        Empleados Get(int id);

    }

    public class EmpleadosService : IEmpleadosService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public EmpleadosService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Empleados> GetAll()
        {
            var result = new List<Empleados>();
            try
            {
                result = _VehiculoDbContext.Empleados.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Empleados Get(int id)
        {
            var result = new Empleados();
            try
            {
                result = _VehiculoDbContext.Empleados.Single(x => x.Id_Empleado == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Empleados model)
        {
            try
            {
                _VehiculoDbContext.Add(model);
                _VehiculoDbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return true;
        }

        public bool Update(Empleados model)
        {
            try
            {
                var original = _VehiculoDbContext.Empleados.Single(x =>
                x.Id_Empleado == model.Id_Empleado
                );

                original.Usuario = model.Usuario;
                original.Contraseña = model.Usuario;
                

                _VehiculoDbContext.Update(original);
                _VehiculoDbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _VehiculoDbContext.Entry(new Empleados { Id_Empleado = id }).State = EntityState.Deleted;
                _VehiculoDbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return true;
        }


    }
}