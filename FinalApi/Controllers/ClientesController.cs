using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using Persistence;
using Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalApi.Controllers
{
    [Route("[Controller]")]
    public class ClientesController : Controller
    {
        private readonly IClientesService _ClientesService;

        public ClientesController(IClientesService ClientesService)
        {
            _ClientesService = ClientesService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                 _ClientesService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _ClientesService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Clientes model)
        {
            
            return Ok(

            _ClientesService.Add(model)

            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Clientes model)
        {
       
                return Ok(
                    

                _ClientesService.Update(model)

                );
            

         }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(

            _ClientesService.Delete(id)

            );
        }

    }
}
