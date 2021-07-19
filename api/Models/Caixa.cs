
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{

    public class Caixa
    {
        public Caixa()
        {
            this.NotasNoCaixa = new List<CaixaNotas>();
        }
        public Caixa(int id, string descricao, IEnumerable<CaixaNotas> notasNoCaixa)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = true;
            this.NotasNoCaixa = notasNoCaixa;
        }

        public Caixa(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = true;
            this.NotasNoCaixa = new List<CaixaNotas>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public IEnumerable<CaixaNotas> NotasNoCaixa { get; set; }
    }
}