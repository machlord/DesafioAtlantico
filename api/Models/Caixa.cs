
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace api.Models
{

    public class Caixa
    {
        public Caixa()
        {
            this.CaixaNotas = new List<CaixaNotas>();
        }

        public Caixa(int id, string descricao, List<CaixaNotas> CaixaNotas)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = true;
            this.CaixaNotas = CaixaNotas;
        }

        public Caixa(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = true;
        }

        public Caixa(int id, string descricao, bool ativo)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = ativo;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public virtual List<CaixaNotas> CaixaNotas { get; set; }

        public List<NotaSaida> Saque(float valor)
        {
            if (this.ativo == false)
            {
                throw new ArgumentException("Caixa desativo");
            }

            //Armazeno o valor para processamento
            float valor_restante = valor;
            //Separa as notas
            var notas = this.CaixaNotas;
            //Ordena as notas
            notas = notas.OrderByDescending(e => e.Nota.valor).ToList();

            //Inicia o Resumo de saida
            var resumo = new List<NotaSaida> {
                new NotaSaida { valor = 50, quantidade = 0, CaixaId = this.id, NotaId = 1 },
                new NotaSaida { valor = 20, quantidade = 0, CaixaId = this.id, NotaId = 2 },
                new NotaSaida { valor = 10, quantidade = 0, CaixaId = this.id, NotaId = 3 },
                new NotaSaida { valor = 5,  quantidade = 0, CaixaId = this.id, NotaId = 4 },
                new NotaSaida { valor = 2,  quantidade = 0, CaixaId = this.id, NotaId = 5 }
            };
            //Inicia qual nota esta olhando
            var nota_atual = 0;

            //Percorre 'separando' as notas
            while (valor_restante > 0 && nota_atual <= (notas.Count - 1))
            {
                //Avalia se o valor da nota e mais que o total que resta
                if (valor_restante < notas[nota_atual].Nota.valor)
                {
                    //Passa para a proxima nota
                    nota_atual++;
                    continue;
                }

                //Avalio se existe nota no estoque
                if (notas[nota_atual].quantidade == 0)
                {
                    //Passa para a proxima nota
                    nota_atual++;
                    continue;
                }

                //Diminuir o valor
                valor_restante -= notas[nota_atual].Nota.valor;

                //Retirar do Estoque
                notas[nota_atual].quantidade--;

                //colocar no meu resumo
                resumo.Where(x => x.valor == resumo[nota_atual].valor).First().quantidade += 1;

                //Caso tenha acabado as notas ele j?? para para a proxima
                if (notas[nota_atual].quantidade == 0)
                {
                    nota_atual++;
                }

            }

            //Verifica se o valor foi totalmente preenchido
            if (valor_restante > 0)
            {
                throw new ArgumentException("O valor solicitado n??o corresponde com as notas dispon??veis");
            }

            //Retira do estoque
            this.CaixaNotas = notas;

            //salva a movimenta????o
            return resumo;
        }

        public void DesativarCaixa()
        {
            this.ativo = false;
        }

        public void AtivarCaixa()
        {
            this.ativo = true;
        }
    }
}