using InterviewTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private FooBarService _fooBarService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFooBarService fooBarService)
        {
            _logger = logger;
            _fooBarService = (FooBarService)fooBarService;
        }

        [HttpGet("weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        

        [HttpGet("{position},{input}")]
        public IActionResult GetFooBar(int position, string input)
        {
            try
            {
                Console.WriteLine(_fooBarService.Test(position, input));
                if (_fooBarService.Test(position, input) != "bad request" || _fooBarService.Test(position, input) != "error")
                    return Ok();

            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
