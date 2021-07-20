using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/caixa")]
    public class CaixaController : ControllerBase
    {
        private readonly IRepository _repo;
        public CaixaController(IRepository repository)
        {
            _repo = repository;
        }

        //**Sacar no caixa;
        [HttpGet]
        [Route("saque/{caixa_id:int}/{valor:int}")]
        public async Task<ActionResult<List<NotaSaida>>> Saque([FromServices] DataContext context, int caixa_id, float valor)
        {
            if (valor <= 0 || valor > 10000)
            {
                return BadRequest(new { error = $"Valor invalido de saque! o valor deve ser entre 0 e 1000, você escolheu: {valor}" });
            }
            //Carrega o caixa
            var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            //Recebe o retorno das notas para serem retiradas
            var retorno = caixa.Saque(valor);
            //Persiste a mudança
            context.Caixas.Add(caixa);
            await context.SaveChangesAsync();
            return retorno;

        }

        [HttpGet]
        [Route("estoque/{caixa_id:int}")]
        public async Task<ActionResult<List<CaixaNotas>>> Estoque([FromServices] DataContext context, int caixa_id)
        {
            //Retorna o estoque do caixa
            var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            return caixa.CaixaNotas;
        }
        //*Saber o numero de notas em cada caixas*;
        //*Se ocorreu algum erro*;
        //*Ativa e desativar o caixa*;

    }
}