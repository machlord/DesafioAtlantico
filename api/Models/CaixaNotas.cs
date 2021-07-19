using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class CaixaNotas
    {
        public CaixaNotas()
        {

        }
        public CaixaNotas(Nota nota, Caixa caixa)
        {
            this.id = id;
            this.Nota = nota;
            this.Caixa = caixa;
        }
        [Key]
        public int id { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }
    }
}