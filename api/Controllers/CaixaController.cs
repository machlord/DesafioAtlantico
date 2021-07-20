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
        public async Task<ActionResult<List<ResumoSaida>>> Saque([FromServices] DataContext context, int caixa_id, float valor)
        {
            //var caixa = await context.Caixas.Include(n => n.CaixaNotas).Where(x => x.id == caixa_id).AsNoTracking().ToListAsync();
            float valor_restante = valor;
            var caixa = await context.Caixas.Where(x => x.id == caixa_id).AsNoTracking().FirstAsync();
            var notas = context.CaixasNotas.Include(n => n.Nota).Where(n => n.CaixaId == caixa.id).AsNoTracking().ToList();
            notas = notas.OrderByDescending(e => e.Nota.valor).ToList();

            var resumo = new List<ResumoSaida> {
                new ResumoSaida { valor = 50, liberar = 0 },
                new ResumoSaida { valor = 20, liberar = 0 },
                new ResumoSaida { valor = 10, liberar = 0 },
                new ResumoSaida { valor = 5, liberar = 0 },
                new ResumoSaida { valor = 2, liberar = 0 }
            };


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
                resumo.Where(x => x.valor == resumo[nota_atual].valor).First().liberar += 1;

                if (notas[nota_atual].quantidade == 0)
                {
                    nota_atual++;
                }

            }
            if (valor_restante > 0)
            {
                throw new ArgumentException("O valor solicitado não corresponde com as notas disponíveis");
            }
            //Salva a retirada
            return resumo;
        }

        //Valor tem que ser entre 0 e 1000;
        //Valor tem que ser exatamento o numero de notas
        //*Saber o numero de notas em cada caixas*;
        //*Se ocorreu algum erro*;
        //*Ativa e desativar o caixa*;

    }
}