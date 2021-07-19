using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("caixa")]
    public class CaixaController : ControllerBase
    {
        public CaixaController(IRepository repository)
        {

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