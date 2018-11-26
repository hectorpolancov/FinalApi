using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IClientesService
    {
        IEnumerable<Clientes> GetAll();
        bool Add(Clientes model);
        bool Delete(int id);
        bool Update(Clientes model);
        Clientes Get(int id);

    }

    public class ClientesService : IClientesService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public ClientesService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Clientes> GetAll()
        {
            var result = new List<Clientes>();
            try
            {
                result = _VehiculoDbContext.Clientes.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Clientes Get(int id)
        {
            var result = new Clientes();
            try
            {
                result = _VehiculoDbContext.Clientes.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Clientes model)
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

        public bool Update(Clientes model)
        {
            try
            {
                var original = _VehiculoDbContext.Clientes.Single(x =>
                x.Id == model.Id
                );

                original.Nombre = model.Nombre;
                original.Apellidos = model.Apellidos;
                original.Telefono = model.Telefono;
                original.Direccion = model.Direccion;
                original.Cedula = model.Cedula;

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
                _VehiculoDbContext.Entry(new Clientes { Id = id }).State = EntityState.Deleted;
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




