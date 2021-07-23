using System;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace test
{
    public class CaixaControllerTest : IDisposable
    {
        private DataContext _context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
            _context = new DataContext(options);
            var caixas = new[]{
                new Caixa {id = 1},
                new Caixa {id = 2},
                new Caixa {id = 3},
                new Caixa {id = 4}
            };
            _context.Caixas.AddRange(caixas);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}