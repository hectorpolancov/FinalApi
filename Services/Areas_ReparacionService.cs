using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IAreas_ReparacionService
    {
        IEnumerable<Areas_Reparacion> GetAll();
        bool Add(Areas_Reparacion model);
        bool Delete(int id);
        bool Update(Areas_Reparacion model);
        Areas_Reparacion Get(int id);

    }

    public class Areas_ReparacionService : IAreas_ReparacionService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public Areas_ReparacionService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Areas_Reparacion> GetAll()
        {
            var result = new List<Areas_Reparacion>();
            try
            {
                result = _VehiculoDbContext.Areas_Reparacion.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Areas_Reparacion Get(int id)
        {
            var result = new Areas_Reparacion();
            try
            {
                result = _VehiculoDbContext.Areas_Reparacion.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Areas_Reparacion model)
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

        public bool Update(Areas_Reparacion model)
        {
            try
            {
                var original = _VehiculoDbContext.Areas_Reparacion.Single(x =>
                x.Id == model.Id
                );

                original.Nombre = model.Nombre;
                original.Descripcion = model.Descripcion;
                

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
                _VehiculoDbContext.Entry(new Areas_Reparacion { Id = id }).State = EntityState.Deleted;
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
