using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class NotaSaida
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int valor { get; set; }
        public int quantidade { get; set; }
        public int CaixaId { get; set; }
        public int NotaId { get; set; }
        [Timestamp]
        public byte[] CreatedDate { get; set; }
    }
}