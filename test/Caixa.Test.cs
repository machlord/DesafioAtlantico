using System.Collections.Generic;
using api.Models;
using NUnit.Framework;

namespace test
{
    public class CaixaTest
    {
        private Caixa _caixa;
        [SetUp]
        public void setup()
        {
            _caixa = new Caixa
            {
                id = 1,
                descricao = "CaixaTeste",
                ativo = true,
                CaixaNotas = new List<CaixaNotas>(
                    new List<CaixaNotas>{
                        //Caixa Notas no caixa
                        new CaixaNotas {
                            id = 1,
                            CaixaId = 1,
                            NotaId = 1,
                            quantidade = 2,
                            Nota = new Nota {id = 1, valor = 50, descricao = "R$ 50", critico = 1}
                        },
                        new CaixaNotas {
                            id = 2,
                            CaixaId = 1,
                            NotaId = 2,
                            quantidade = 2,
                            Nota = new Nota {id = 2, valor = 20, descricao = "R$ 20", critico = 1}
                        },
                        new CaixaNotas {
                            id = 3,
                            CaixaId = 1,
                            NotaId = 3,
                            quantidade = 2,
                            Nota = new Nota {id = 3, valor = 10, descricao = "R$ 10", critico = 1}
                        },
                        new CaixaNotas {
                            id = 4,
                            CaixaId = 1,
                            NotaId = 4,
                            quantidade = 2,
                            Nota = new Nota {id = 4, valor = 5, descricao = "R$ 5", critico = 1}
                        },
                        new CaixaNotas {
                            id = 5,
                            CaixaId = 1,
                            NotaId = 5,
                            quantidade = 2,
                            Nota = new Nota {id = 5, valor = 2, descricao = "R$ 2", critico = 1}
                        }
                    }
                )
            };
        }

        [Test]
        public void saque_quantidade_saida_correta()
        {
            var saida_esperada = new List<NotaSaida> {
                new NotaSaida { valor = 50, quantidade = 1, CaixaId = 1, NotaId = 1 },
                new NotaSaida { valor = 20, quantidade = 1, CaixaId = 1, NotaId = 2 },
                new NotaSaida { valor = 10, quantidade = 0, CaixaId = 1, NotaId = 3 },
                new NotaSaida { valor = 5,  quantidade = 0, CaixaId = 1, NotaId = 4 },
                new NotaSaida { valor = 2,  quantidade = 0, CaixaId = 1, NotaId = 5 }
            };
            var saida = _caixa.Saque(50);
            Assert.AreEqual(saida[0].quantidade, saida_esperada[0].quantidade);
        }

        [Test]
        public void ativar_caixa_ativo()
        {
            _caixa.ativo = false;
            _caixa.AtivarCaixa();
            Assert.AreEqual(true, _caixa.ativo);
        }

        [Test]
        public void desativar_caixa_desativo()
        {
            _caixa.ativo = true;
            _caixa.DesativarCaixa();
            Assert.AreEqual(false, _caixa.ativo);
        }
    }
}