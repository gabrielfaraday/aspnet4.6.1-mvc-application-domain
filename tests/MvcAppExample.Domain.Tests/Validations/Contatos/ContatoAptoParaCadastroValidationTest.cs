using Moq;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Validations.Contatos;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MvcAppExample.Domain.Tests.Validations.Contatos
{
    [TestFixture]
    public class ContatoAptoParaCadastroValidationTest
    {
        Mock<IContatoRepository> _contatoRepositoryMock;
        ContatoAptoParaCadastroValidation _validation;

        [SetUp]
        public void Setup()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();
            _validation = new ContatoAptoParaCadastroValidation(_contatoRepositoryMock.Object);
        }

        [Test]
        public void ContatoAptoValidation_IsValid_Apto()
        {
            var contato = new Contato
            {
                Email = "email@contato.com.br",
                Telefones = new List<Telefone>
                {
                    new Telefone { DDD = 16, Numero = 33337778 }
                }
            };

            var resultado = _validation.Validate(contato);

            Assert.IsTrue(resultado.IsValid);
            Assert.IsFalse(resultado.Erros.Any());
            _contatoRepositoryMock.Verify(x => x.ObterPorEmail("email@contato.com.br"), Times.Once);
        }

        [Test]
        public void ContatoAptoValidation_IsValid_NaoApto()
        {
            var contato = new Contato
            {
                Email = "email@contato.com.br"
            };

            _contatoRepositoryMock.Setup(x => x.ObterPorEmail("email@contato.com.br")).Returns(contato);

            var resultado = _validation.Validate(contato);

            Assert.IsFalse(resultado.IsValid);
            Assert.IsTrue(resultado.Erros.Any(e => e.Message == "E-mail informado já cadastrado."));
            _contatoRepositoryMock.Verify(x => x.ObterPorEmail("email@contato.com.br"), Times.Once);

        }
    }
}
