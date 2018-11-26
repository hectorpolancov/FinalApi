using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalApi.Controllers
{
    [Route("[Controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadosService _EmpleadoService;

        public EmpleadoController(IEmpleadosService EmpleadoService)
        {
            _EmpleadoService = EmpleadoService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _EmpleadoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _EmpleadoService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Empleados model)
        {
            return Ok(

            _EmpleadoService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Empleados model)
        {
            return Ok(

            _EmpleadoService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _EmpleadoService.Delete(id)

            );
        }

    }
}
