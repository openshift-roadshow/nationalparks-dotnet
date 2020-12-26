using NationalParks.Models;
using NationalParks.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NationalParks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly ParkService _ParkService;

        public ParksController(ParkService ParkService)
        {
            _ParkService = ParkService;
        }

        [HttpGet]
        public ActionResult<List<Park>> Get() =>
            _ParkService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPark")]
        public ActionResult<Park> Get(string id)
        {
            var Park = _ParkService.Get(id);

            if (Park == null)
            {
                return NotFound();
            }

            return Park;
        }

        [HttpPost]
        public ActionResult<Park> Create(Park Park)
        {
            _ParkService.Create(Park);

            return CreatedAtRoute("GetPark", new { id = Park.Id.ToString() }, Park);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Park ParkIn)
        {
            var Park = _ParkService.Get(id);

            if (Park == null)
            {
                return NotFound();
            }

            _ParkService.Update(id, ParkIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Park = _ParkService.Get(id);

            if (Park == null)
            {
                return NotFound();
            }

            _ParkService.Remove(Park.Id);

            return NoContent();
        }
    }
}