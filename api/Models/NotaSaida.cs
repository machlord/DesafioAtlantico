using System;

namespace api.Models
{
    public class NotaSaida
    {
        public int valor { get; set; }
        public int quantidade { get; set; }
        public int CaixaId { get; set; }
        public int NotaId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}