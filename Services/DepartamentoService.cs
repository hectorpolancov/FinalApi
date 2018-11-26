using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IDepartamentoService
    {
        IEnumerable<Departamentos> GetAll();
        bool Add(Departamentos model);
        bool Delete(int id);
        bool Update(Departamentos model);
        Departamentos Get(int id);

    }

    public class DepartamentoService : IDepartamentoService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public DepartamentoService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Departamentos> GetAll()
        {
            var result = new List<Departamentos>();
            try
            {
                result = _VehiculoDbContext.Departamentos.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Departamentos Get(int id)
        {
            var result = new Departamentos();
            try
            {
                result = _VehiculoDbContext.Departamentos.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Departamentos model)
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

        public bool Update(Departamentos model)
        {
            try
            {
                var original = _VehiculoDbContext.Departamentos.Single(x =>
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
                _VehiculoDbContext.Entry(new Departamentos { Id = id }).State = EntityState.Deleted;
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