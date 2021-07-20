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
            //Carrega o caixa
            var caixa = await context.Caixas.Include(c => c.CaixaNotas).ThenInclude(cn => cn.Nota).Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            return caixa.Saque(valor); ;
        }

        //Valor tem que ser entre 0 e 1000;
        //Valor tem que ser exatamento o numero de notas
        //*Saber o numero de notas em cada caixas*;
        //*Se ocorreu algum erro*;
        //*Ativa e desativar o caixa*;

    }
}