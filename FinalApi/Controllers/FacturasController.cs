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
    public class FacturasController : Controller
    {
        private readonly IFacturaService _FacturaService;

        public FacturasController(IFacturaService FacturaService)
        {
            _FacturaService = FacturaService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _FacturaService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _FacturaService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Factura model)
        {
            return Ok(

            _FacturaService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Factura model)
        {
            return Ok(

            _FacturaService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _FacturaService.Delete(id)

            );
        }

    }
}