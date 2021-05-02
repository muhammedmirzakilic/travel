using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using travel.DTO;
using travel.Enums;
using travel.Interfaces;

namespace travel.Controllers
{
    [ApiController]
    [Route("api/passenger")]
    public class PassengerController : ControllerBase
    {
        IPassengerService _service;
        public PassengerController(IPassengerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{source}")]
        public IActionResult GetPassengers(Source source)
        {
            var items = _service.ReadAll(source);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [Route("{source}/")]
        public IActionResult Create(Source source, [FromBody] Passenger passenger)
        {
            var result = _service.Create(source, passenger);
            return Ok(result);
        }

        [HttpGet]
        [Route("{source}/{id}")]
        public IActionResult Read([FromRoute] Source source, [FromRoute] Guid id)
        {
            var result = _service.Read(source, id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{source}")]
        public IActionResult Update(Source source, [FromBody] Passenger passenger)
        {
            var result = _service.Update(source, passenger);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{source}/{id}")]
        public IActionResult Delete([FromRoute] Source source, [FromRoute] Guid id)
        {
            var result = _service.Delete(source, id);
            return Ok(result);
        }
    }
}
