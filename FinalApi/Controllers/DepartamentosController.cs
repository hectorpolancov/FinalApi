using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using Services;

namespace FinalApi.Controllers
{
    [Route("[Controller]")]
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentoService _DepartamentoService;

        public DepartamentosController(IDepartamentoService DepartamentoService)
        {
            _DepartamentoService = DepartamentoService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _DepartamentoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _DepartamentoService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Departamentos model)
        {
            return Ok(

            _DepartamentoService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Departamentos model)
        {
            return Ok(

            _DepartamentoService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _DepartamentoService.Delete(id)

            );
        }

    }
}