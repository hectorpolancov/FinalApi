using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface IEmpleado_AtiendeService
    {
        IEnumerable<Empleado_Atiende> GetAll();
        bool Add(Empleado_Atiende model);
        bool Delete(int id);
        bool Update(Empleado_Atiende model);
        Empleado_Atiende Get(int id);

    }

    public class Empleado_AtiendeService : IEmpleado_AtiendeService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public Empleado_AtiendeService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Empleado_Atiende> GetAll()
        {
            var result = new List<Empleado_Atiende>();
            try
            {
                result = _VehiculoDbContext.Empleado_Atiende.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Empleado_Atiende Get(int id)
        {
            var result = new Empleado_Atiende();
            try
            {
                result = _VehiculoDbContext.Empleado_Atiende.Single(x => x.ID == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Empleado_Atiende model)
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

        public bool Update(Empleado_Atiende model)
        {
            try
            {
                var original = _VehiculoDbContext.Empleado_Atiende.Single(x =>
                x.ID == model.ID
                );

                original.Id_Empleado = model.Id_Empleado;
                original.ClientesId = model.ClientesId;
                

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
                _VehiculoDbContext.Entry(new Empleado_Atiende { ID = id }).State = EntityState.Deleted;
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
