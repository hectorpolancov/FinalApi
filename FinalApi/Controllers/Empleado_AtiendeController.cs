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
    public class Empleado_AtiendeController : Controller
    {
        private readonly IEmpleado_AtiendeService _Empleado_AtiendeService;

        public Empleado_AtiendeController(IEmpleado_AtiendeService Empleado_AtiendeService)
        {
            _Empleado_AtiendeService = Empleado_AtiendeService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _Empleado_AtiendeService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _Empleado_AtiendeService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Empleado_Atiende model)
        {
            return Ok(

            _Empleado_AtiendeService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Empleado_Atiende model)
        {
            return Ok(

            _Empleado_AtiendeService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _Empleado_AtiendeService.Delete(id)

            );
        }

    }
}
