using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Nota
    {
        public Nota()
        {

        }
        public Nota(int id, float valor, string descricao, int critico)
        {
            this.id = id;
            this.valor = valor;
            this.descricao = descricao;
            this.critico = critico;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string descricao { get; set; }
        public float valor { get; set; }
        public int critico { get; set; }

    }
}