
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
        public Caixa(int id, bool ativo, string descricao, IEnumerable<CaixaNotas> notasNoCaixa)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = ativo;
            this.NotasNoCaixa = notasNoCaixa;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public IEnumerable<CaixaNotas> NotasNoCaixa { get; set; }
    }
}