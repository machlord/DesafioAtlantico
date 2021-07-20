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
        [Route("getCaixa/{caixa_id:int}/{valor:int}")]
        public async Task<ActionResult<List<Object>>> Get([FromServices] DataContext context, int caixa_id, float valor)
        {
            //var caixa = await context.Caixas.Include(n => n.CaixaNotas).Where(x => x.id == caixa_id).AsNoTracking().ToListAsync();
            float valor_restante = valor;
            var caixa = await context.Caixas.Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            var notas = context.CaixasNotas.Include(n => n.Nota).Where(n => n.CaixaId == caixa.id).AsNoTracking().ToList();
            notas = notas.OrderByDescending(e => e.Nota.valor).ToList();

            var resumo = new[] {
                new { valor = 50, total = 0 },
                new { valor = 20, total = 0 },
                new { valor = 10, total = 0 },
                new { valor = 5, total = 0 },
                new { valor = 2, total = 0 }
            };

            try
            {
                var nota_atual = 0;
                while (valor_restante > 0 && nota_atual <= (notas.Count - 1))
                {
                    if (valor_restante < notas[nota_atual].Nota.valor)
                    {
                        nota_atual++;
                        continue;
                    }

                    //Diminuir o valor
                    valor_restante -= notas[nota_atual].Nota.valor;
                    //Retirar do Estoque
                    notas[nota_atual].quantidade--;
                    //colocar no meu resumo
                    //resumo[nota_atual] = new { valor = resumo[nota_atual].valor, total = resumo[nota_atual].total + 1 };
                    resumo.Where(x => x.valor == resumo[nota_atual].valor).First().SetValue();

                    if (notas[nota_atual].quantidade == 0)
                    {
                        nota_atual++;
                    }

                }
                if (valor_restante > 0)
                {
                    throw new Exception();
                }
                //Salva a retirada
                return resumo;
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        //Valor tem que ser entre 0 e 1000;
        //Valor tem que ser exatamento o numero de notas
        //*Saber o numero de notas em cada caixas*;
        //*Se ocorreu algum erro*;
        //*Ativa e desativar o caixa*;

    }
}