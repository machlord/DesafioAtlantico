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

        //**Pegar caixas;
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Caixa>>> Get([FromServices] DataContext context)
        {
            return await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).AsNoTracking().ToListAsync();
        }

        //**Sacar em um caixa;
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
            //salva a movimentação
            context.NotasSaidas.AddRange(retorno);

            //Persiste a mudança
            context.Caixas.Update(caixa);
            await context.SaveChangesAsync();
            return retorno;

        }

        //*Estoque de um caixa*;
        [HttpGet]
        [Route("estoque/{caixa_id:int}")]
        public async Task<ActionResult<List<CaixaNotas>>> Estoque([FromServices] DataContext context, int caixa_id)
        {
            //Retorna o estoque do caixa
            var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            return caixa.CaixaNotas;
        }

        //*Ativa um caixa*;
        [HttpGet]
        [Route("ativar/{caixa_id:int}")]
        public async Task<ActionResult<Caixa>> Ativar([FromServices] DataContext context, int caixa_id)
        {
            try
            {
                var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).FirstAsync();
                caixa.AtivarCaixa();
                context.Caixas.Update(caixa);
                await context.SaveChangesAsync();

                return caixa;
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "falha ao ativar caixa", ex = ex.Message });
            }
        }

        //*desativar um caixa*;
        [HttpGet]
        [Route("desativar/{caixa_id:int}")]
        public async Task<ActionResult<Caixa>> Desativar([FromServices] DataContext context, int caixa_id)
        {
            try
            {
                var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).FirstAsync();
                caixa.DesativarCaixa();
                context.Caixas.Update(caixa);
                await context.SaveChangesAsync();

                return caixa;
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "falha ao desativar caixa", ex = ex.Message });
            }
        }
    }
}