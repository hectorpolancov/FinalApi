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
    public class CitasController : Controller
    {
        private readonly ICitaService _CitaService;

        public CitasController(ICitaService CitaService)
        {
            _CitaService = CitaService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _CitaService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _CitaService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Citas model)
        {
            return Ok(

            _CitaService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Citas model)
        {
            return Ok(

            _CitaService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _CitaService.Delete(id)

            );
        }

    }
}
