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

            //**Dados TESTE **//

            //Criar os caixas para teste;
            builder.Entity<Caixa>().HasData(new List<Caixa>() {
                new Caixa(1, "Caixa 01"),
                new Caixa(2, "Caixa 02"),
                new Caixa(3, "Caixa 03")
            });

            //Criar a quantidade de notas em cada caixas;
            builder.Entity<CaixaNotas>().HasData(
                new List<CaixaNotas>(){
                    //Caixa 1
                    new CaixaNotas(1, 1, 1, 2),
                    new CaixaNotas(2, 1, 2, 2),
                    new CaixaNotas(3, 1, 3, 2),
                    new CaixaNotas(4, 1, 4, 2),
                    //Caixa 2
                    new CaixaNotas(5, 2, 1, 1),
                    new CaixaNotas(6, 2, 2, 1),
                    new CaixaNotas(7, 2, 3, 1),
                    new CaixaNotas(8, 2, 4, 1),
                    //Caixa 3
                    new CaixaNotas(9, 3, 1, 3),
                    new CaixaNotas(10, 3, 2, 3),
                    new CaixaNotas(11, 3, 3, 3),
                    new CaixaNotas(12, 3, 4, 3),
                }
            );
        }
    }
}