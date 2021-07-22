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
        private readonly DataContext _context;
        public CaixaController(DataContext context)
        {
            _context = context;
        }

        //**Pegar caixas;
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Caixa>>> Get()
        {
            return await _context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).AsNoTracking().ToListAsync();
        }

        //**Sacar em um caixa;
        [HttpGet]
        [Route("saque/{caixa_id:int}/{valor:int}")]
        public async Task<ActionResult<List<NotaSaida>>> Saque(int caixa_id, float valor)
        {
            if (valor <= 0 || valor > 10000)
            {
                return BadRequest(new { error = $"Valor invalido de saque! o valor deve ser entre 0 e 1000, você escolheu: {valor}" });
            }
            //Carrega o caixa
            var caixa = await _context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            //Recebe o retorno das notas para serem retiradas
            var retorno = caixa.Saque(valor);
            //salva a movimentação
            _context.NotasSaidas.AddRange(retorno);

            //Persiste a mudança
            _context.Caixas.Update(caixa);
            await _context.SaveChangesAsync();
            return retorno;

        }

        //*Estoque de um caixa*;
        [HttpGet]
        [Route("estoque/{caixa_id:int}")]
        public async Task<ActionResult<List<CaixaNotas>>> Estoque(int caixa_id)
        {
            //Retorna o estoque do caixa
            var caixa = await _context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            return caixa.CaixaNotas;
        }

        //*Ativa um caixa*;
        [HttpGet]
        [Route("ativar/{caixa_id:int}")]
        public async Task<ActionResult<Caixa>> Ativar(int caixa_id)
        {
            try
            {
                var caixa = await _context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).FirstAsync();
                caixa.AtivarCaixa();
                _context.Caixas.Update(caixa);
                await _context.SaveChangesAsync();

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
        public async Task<ActionResult<Caixa>> Desativar(int caixa_id)
        {
            try
            {
                var caixa = await _context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).FirstAsync();
                caixa.DesativarCaixa();
                _context.Caixas.Update(caixa);
                await _context.SaveChangesAsync();

                return caixa;
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "falha ao desativar caixa", ex = ex.Message });
            }
        }
    }
}