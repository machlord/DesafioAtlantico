
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace api.Models
{

    public class Caixa
    {
        public Caixa()
        {
            this.CaixaNotas = new List<CaixaNotas>();
        }
        public Caixa(int id, string descricao, ICollection<CaixaNotas> CaixaNotas)
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<CaixaNotas> CaixaNotas { get; set; }
    }
}