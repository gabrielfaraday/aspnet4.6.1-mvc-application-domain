using Moq;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Validations.Contatos;
using MvcAppExample.Domain.ValueObjects;
using NUnit.Framework;
using System.Linq;

namespace MvcAppExample.Domain.Tests.Validations.Contatos
{
    [TestFixture]
    public class ContatoEstaConsistenteValidationTest
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ContatoEmailValidoSpecification_IsValid_ValidaEmail(bool resultadoEsperado)
        {
            var emailMock = new Mock<Email>();

            emailMock.Setup(x => x.Validar()).Returns(resultadoEsperado);

            var contato = new Contato
            {
                Email = emailMock.Object
            };

            var resultado = new ContatoEstaConsistenteValidation().Validate(contato);

            Assert.That(resultado.IsValid, Is.EqualTo(resultadoEsperado));
            emailMock.Verify(x => x.Validar(), Times.Once);

            if (resultadoEsperado == false)
                Assert.IsTrue(resultado.Erros.Any(e => e.Message == "E-mail informado não é válido."));
        }
    }
}
