using Moq;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Validations.Contatos;
using MvcAppExample.Domain.ValueObjects;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Domain.Tests.Validations.Contatos
{
    [TestFixture]
    public class ContatoAptoParaCadastroValidationTest
    {
        Mock<IAgendaRepository> _agendaRepositoryMock;
        ContatoAptoParaCadastroValidation _validation;

        [SetUp]
        public void Setup()
        {
            _agendaRepositoryMock = new Mock<IAgendaRepository>();
            _validation = new ContatoAptoParaCadastroValidation(_agendaRepositoryMock.Object);
        }

        [Test]
        public void ContatoAptoValidation_IsValid_Apto()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "email@contato.com.br" }
            };

            var resultado = _validation.Validate(contato);

            Assert.IsTrue(resultado.IsValid);
            _agendaRepositoryMock.Verify(x => x.ObterPorEmail("email@contato.com.br"), Times.Once);
        }

        [Test]
        public void ContatoAptoValidation_IsValid_NaoApto()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "email@contato.com.br" }
            };

            _agendaRepositoryMock.Setup(x => x.ObterPorEmail("email@contato.com.br")).Returns(contato);

            var resultado = _validation.Validate(contato);

            Assert.IsFalse(resultado.IsValid);
            Assert.IsTrue(resultado.Erros.Any(e => e.Message == "E-mail informado já cadastrado."));
            _agendaRepositoryMock.Verify(x => x.ObterPorEmail("email@contato.com.br"), Times.Once);

        }
    }
}
