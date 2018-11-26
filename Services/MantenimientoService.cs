using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IMantenimientoService
    {
        IEnumerable<Mantenimiento> GetAll();
        bool Add(Mantenimiento model);
        bool Delete(int id);
        bool Update(Mantenimiento model);
        Mantenimiento Get(int id);

    }

    public class MantenimientoService : IMantenimientoService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public MantenimientoService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            var result = new List<Mantenimiento>();
            try
            {
                result = _VehiculoDbContext.Mantenimiento.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Mantenimiento Get(int id)
        {
            var result = new Mantenimiento();
            try
            {
                result = _VehiculoDbContext.Mantenimiento.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Mantenimiento model)
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

        public bool Update(Mantenimiento model)
        {
            try
            {
                var original = _VehiculoDbContext.Mantenimiento.Single(x =>
                x.Id == model.Id
                );

                original.Fecha_entrada = model.Fecha_entrada;
                original.Fecha_salida = model.Fecha_salida;
                



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
                _VehiculoDbContext.Entry(new Mantenimiento { Id = id }).State = EntityState.Deleted;
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
