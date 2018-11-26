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
    public class Areas_ReparacionController : Controller
    {
        private readonly IAreas_ReparacionService _Areas_ReparacionService;

        public Areas_ReparacionController(IAreas_ReparacionService Areas_ReparacionService)
        {
            _Areas_ReparacionService = Areas_ReparacionService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _Areas_ReparacionService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _Areas_ReparacionService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Areas_Reparacion model)
        {
            return Ok(

            _Areas_ReparacionService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Areas_Reparacion model)
        {
            return Ok(

            _Areas_ReparacionService.Update(model)

            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _Areas_ReparacionService.Delete(id)

            );
        }

    }
}
