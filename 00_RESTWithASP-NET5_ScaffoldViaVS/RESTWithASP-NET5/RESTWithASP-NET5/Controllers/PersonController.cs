﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithASP_NET5.Models;
using RESTWithASP_NET5.Business;

namespace RESTWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personService;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);

            if (person != null)
                return Ok(person);

            return NotFound();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Create(person));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }
    }
}
