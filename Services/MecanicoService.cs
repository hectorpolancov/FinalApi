using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IMecanicoService
    {
        IEnumerable<Mecanicos> GetAll();
        bool Add(Mecanicos model);
        bool Delete(int id);
        bool Update(Mecanicos model);
        Mecanicos Get(int id);

    }

    public class MecanicoService : IMecanicoService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public MecanicoService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Mecanicos> GetAll()
        {
            var result = new List<Mecanicos>();
            try
            {
                result = _VehiculoDbContext.Mecanicos.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Mecanicos Get(int id)
        {
            var result = new Mecanicos();
            try
            {
                result = _VehiculoDbContext.Mecanicos.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Mecanicos model)
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

        public bool Update(Mecanicos model)
        {
            try
            {
                var original = _VehiculoDbContext.Mecanicos.Single(x =>
                x.Id == model.Id
                );

                original.Nombre = model.Nombre;
               



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
                _VehiculoDbContext.Entry(new Mecanicos { Id = id }).State = EntityState.Deleted;
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

