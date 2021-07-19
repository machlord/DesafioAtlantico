using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class CaixaNotas
    {
        public CaixaNotas()
        {

        }
        public CaixaNotas(int id, int NotaId, int CaixaId, int quantidade)
        {
            this.id = id;
            this.NotaId = NotaId;
            this.CaixaId = CaixaId;
            this.quantidade = quantidade;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }
        public int quantidade { get; set; }
    }
}