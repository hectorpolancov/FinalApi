using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IFacturaService
    {
        IEnumerable<Factura> GetAll();
        bool Add(Factura model);
        bool Delete(int id);
        bool Update(Factura model);
        Factura Get(int id);

    }

    public class FacturaService : IFacturaService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public FacturaService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Factura> GetAll()
        {
            var result = new List<Factura>();
            try
            {
                result = _VehiculoDbContext.Factura.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Factura Get(int id)
        {
            var result = new Factura();
            try
            {
                result = _VehiculoDbContext.Factura.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Factura model)
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

        public bool Update(Factura model)
        {
            try
            {
                var original = _VehiculoDbContext.Factura.Single(x =>
                x.Id == model.Id
                );

                original.Garantia = model.Garantia;
                original.Costo = model.Costo;
                

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
                _VehiculoDbContext.Entry(new Factura { Id = id }).State = EntityState.Deleted;
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




