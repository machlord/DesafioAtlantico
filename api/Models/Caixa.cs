
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{

    public class Caixa
    {
        public Caixa()
        {
            this.notasNoCaixa = new List<CaixaNotas>();
        }
        public Caixa(int id, bool ativo, string descricao, ICollection<CaixaNotas> notasNoCaixa)
        {
            this.id = id;
            this.descricao = descricao;
            this.ativo = ativo;
            this.notasNoCaixa = notasNoCaixa;
        }
        [Key]
        public int id { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public ICollection<CaixaNotas> notasNoCaixa { get; set; }
    }
}