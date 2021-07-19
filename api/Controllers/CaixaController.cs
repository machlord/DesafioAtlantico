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
        private readonly IRepository _repo;
        public CaixaController(IRepository repository)
        {
            _repo = repository;
        }

        //**Sacar no caixa;
        //Valor tem que ser entre 0 e 1000;
        //Valor tem que ser exatamento o numero de notas
        //*Saber o numero de notas em cada caixas*;
        //*Se ocorreu algum erro*;
        //*Ativa e desativar o caixa*;

    }
}