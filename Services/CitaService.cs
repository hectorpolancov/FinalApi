using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services
{
    public interface ICitaService
    {
        IEnumerable<Citas> GetAll();
        bool Add(Citas model);
        bool Delete(int id);
        bool Update(Citas model);
        Citas Get(int id);

    }

    public class CitaService : ICitaService
    {

        private readonly VehiculoDbContext _VehiculoDbContext;


        public CitaService(VehiculoDbContext VehiculoDbContext)
        {
            _VehiculoDbContext = VehiculoDbContext;
        }

        public IEnumerable<Citas> GetAll()
        {
            var result = new List<Citas>();
            try
            {
                result = _VehiculoDbContext.Citas.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return result;
        }

        public Citas Get(int id)
        {
            var result = new Citas();
            try
            {
                result = _VehiculoDbContext.Citas.Single(x => x.Id_Cita == id);
            }

            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Citas model)
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

        public bool Update(Citas model)
        {
            try
            {
                var original = _VehiculoDbContext.Citas.Single(x =>
                x.Id_Cita == model.Id_Cita
                );

                original.Detalle = model.Detalle;
                original.Fecha = model.Fecha;
                original.Hora_llegada = model.Hora_salida;
                original.Hora_salida = model.Hora_salida;


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
                _VehiculoDbContext.Entry(new Citas { Id_Cita = id }).State = EntityState.Deleted;
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
