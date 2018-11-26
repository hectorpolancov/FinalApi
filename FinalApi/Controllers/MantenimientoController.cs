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
    public class MantenimientoController : Controller
    {
        private readonly IMantenimientoService _MantenimientoService;

        public MantenimientoController(IMantenimientoService MantenimientoService)
        {
            _MantenimientoService = MantenimientoService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _MantenimientoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _MantenimientoService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Mantenimiento model)
        {
            return Ok(

            _MantenimientoService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Mantenimiento model)
        {
            return Ok(

            _MantenimientoService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _MantenimientoService.Delete(id)

            );
        }

    }
}