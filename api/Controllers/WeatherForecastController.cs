using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /*
              [HttpGet]
              [Route("")]
              public async Task<ActionResult<List<Caixa>>> Get([FromServices] DataContext context)
              {
                  var submaterias = await context.submaterias.AsNoTracking().ToListAsync();
                  return submaterias;
              }

              [HttpGet]
              [Route("getByMateria/{materia_id:int}")]
              public async Task<ActionResult<List<Caixa>>> Get([FromServices] DataContext context, int materia_id)
              {
                  var submaterias = await context.submaterias.Include(x => x.Materia).Where(p => p.materia_id == materia_id).AsNoTracking().ToListAsync();
                  return submaterias;
              }


              [HttpPost]
              [Route("")]
              public async Task<ActionResult<Caixa>> Post([FromServices] DataContext context, [FromBody] SubMateria model)
              {
                  if (ModelState.IsValid)
                  {
                      context.submaterias.Add(model);
                      await context.SaveChangesAsync();
                      return model;
                  }
                  else
                  {
                      return BadRequest(ModelState);
                  }
              }
              */
    }
}
