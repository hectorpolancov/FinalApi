using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IVehiculoService
    {
        IEnumerable<Vehiculos> GetAll();
        bool Add(Vehiculos model);
        bool Delete(int id);
        bool Update(Vehiculos model);
        Vehiculos Get(int id);

    }

    public class VehiculoService : IVehiculoService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public VehiculoService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Vehiculos> GetAll()
        {
            var result = new List<Vehiculos>();
            try
            {
                result = _VehiculoDbContext.Vehiculos.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Vehiculos Get(int id)
        {
            var result = new Vehiculos();
            try
            {
                result = _VehiculoDbContext.Vehiculos.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Vehiculos model)
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

        public bool Update(Vehiculos model)
        {
            try
            {
                var original = _VehiculoDbContext.Vehiculos.Single(x =>
                x.Id == model.Id
                );

                original.Matricula = model.Matricula;
                original.Modelo = model.Modelo;
                original.Año = model.Año;
                original.Estado = model.Estado;



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
                _VehiculoDbContext.Entry(new Vehiculos { Id = id }).State = EntityState.Deleted;
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
