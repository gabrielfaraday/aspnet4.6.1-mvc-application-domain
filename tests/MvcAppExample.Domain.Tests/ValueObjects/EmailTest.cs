using MvcAppExample.Domain.ValueObjects;
using NUnit.Framework;

namespace MvcAppExample.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class EmailTest
    {
        [TestCase("123", false)]
        [TestCase("asda", false)]
        [TestCase("asda@", false)]
        [TestCase("@", false)]
        [TestCase("asda@sasad", false)]
        [TestCase("asda@asas", false)]
        [TestCase("asda@asas.", false)]
        [TestCase("asda@asas.br", true)]
        [TestCase("asda@asas.com.br", true)]
        [TestCase("122@123.pt", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void Email_Validar_ValidaEmail(string endereco, bool resultadoEsperado)
        {
            var email = new Email { Endereco = endereco };

            var resultado = email.Validar();

            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }
    }
}
