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

        [Route("/")]
        [HttpGet]
        public ActionResult<string> Welcome()
        {
            return "Welcome to the National Parks data service.";
        }

        [Route("ws/data/all")]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<Park>> Get()
        {
            return _ParkService.Get();
        }

        [Route("ws/info/")]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult Info()
        {
            var jsonData = new
            {
                id = "nationalparks",
                displayName = "National Parks (C#)",
                center = new
                        {
                            latitude = 47.039304,
                            longitude = 14.505178
                        },
                zoom = 4
            };

            return Json(jsonData);


        }

        [Route("ws/data/load")]
        [HttpGet]
        public ActionResult<string> Load()
        {
            return _ParkService.Load();
        }

        [Route("ws/healthz/")]
        [HttpGet]
        public ActionResult<string> Health()
        {
            return "OK";
        }


        [Route("ws/data/within/")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Within()
        {
            Console.WriteLine("Not implemented");
            return NoContent();
        }

    }
}