using System.Collections.Generic;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<CaixaNotas> CaixasNotas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Chave composta
            builder.Entity<CaixaNotas>().HasKey(CN => new { CN.CaixaId, CN.NotaId });

            //Inicialização das Notas
            builder.Entity<Nota>().HasData(
                new List<Nota>(){
                    new Nota {id = 1, valor = 50, descricao = "R$ 50"},
                    new Nota {id = 2, valor = 20, descricao = "R$ 20"},
                    new Nota {id = 3, valor = 10, descricao = "R$ 10"},
                    new Nota {id = 4, valor = 5, descricao = "R$ 5"},
                    new Nota {id = 5, valor = 2, descricao = "R$ 2"}
                }
            );

            //Criar os caixas para teste;

            //Criar a quantidade de notas em cada caixas;

        }
    }
}