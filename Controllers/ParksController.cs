using NationalParks.Models;
using NationalParks.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System;


namespace NationalParks.Controllers
{
    //[Route("ws/data/[controller]")]
    [ApiController]
    public class ParksController : Controller
    {
        private readonly ParkService _ParkService;

        public ParksController(ParkService ParkService)
        {
            _ParkService = ParkService;
        }

        [Route("ws/data/all")]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<Park>> Get()
        {
            return _ParkService.Get();
        }

        [Route("ws/data/info/")]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult Info()
        {
            var jsonData = new
            {
                id = "nationalparks",
                displayName = "National Parks",
                center = new
                        {
                            latitude = 47.039304,
                            longitude = 14.505178
                        },
                zoom = 4
            };
            //string json = JsonSerializer.Serialize(jsonData);
            //Console.WriteLine(json);
            return Json(jsonData);


        }

        [Route("ws/data/load")]
        [HttpGet]
        public ActionResult<string> Load()
        {
            return _ParkService.Load();
        }


        /*
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
        */
    }
}