using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Nota
    {
        public Nota()
        {

        }
        public Nota(int id, float valor, string descricao)
        {
            this.id = id;
            this.valor = valor;
            this.descricao = descricao;
        }
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public float valor { get; set; }
    }
}