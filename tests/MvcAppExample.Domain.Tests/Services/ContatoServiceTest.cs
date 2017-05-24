using Moq;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Services;
using NUnit.Framework;
using System;

namespace MvcAppExample.Domain.Tests.Services
{
    [TestFixture]
    public class ContatoServiceTest
    {
        ContatoService _contatoService;
        Mock<IContatoRepository> _contatoRepositoryMock;
        Mock<ITelefoneRepository> _telefoneRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();
            _telefoneRepositoryMock = new Mock<ITelefoneRepository>();
            _contatoService = new ContatoService(_contatoRepositoryMock.Object, _telefoneRepositoryMock.Object);
        }

        [Test]
        public void Contato_AdicionarContatoInvalido_NaoAdicionaContato()
        {
            var contato = new Contato
            {
                Email = "contatoemail.com"
            };

            var resultado = _contatoService.Adicionar(contato);

            _contatoRepositoryMock.Verify(x => x.Add(contato), Times.Never);
        }

        [Test]
        public void Contato_AdicionarContatoValido_AdicionaContato()
        {
            var contato = new Contato
            {
                Email = "contato@email.com"
            };

            var resultado = _contatoService.Adicionar(contato);

            _contatoRepositoryMock.Verify(x => x.Add(contato), Times.Once);
        }

        [Test]
        public void Contato_AtualizarContatoInvalido_NaoAtualizaContato()
        {
            var contato = new Contato
            {
                Email = "contatoemail.com"
            };

            var resultado = _contatoService.Atualizar(contato);

            _contatoRepositoryMock.Verify(x => x.Update(contato), Times.Never);
        }

        [Test]
        public void Contato_AtualizarContatoValido_AtualizaContato()
        {
            var contato = new Contato
            {
                Email = "contato@email.com"
            };

            var resultado = _contatoService.Atualizar(contato);

            _contatoRepositoryMock.Verify(x => x.Update(contato), Times.Once);
        }

        [Test]
        public void Contato_ObterContatosAtivos_ObtemAtivos()
        {
            var resultado = _contatoService.ObterAtivos();

            _contatoRepositoryMock.Verify(x => x.ObterAtivos(), Times.Once);
        }

        [Test]
        public void Contato_ObterTodos_ObtemTodos()
        {
            var resultado = _contatoService.ObterTodos();

            _contatoRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void Contato_ObterObterPorEmail_ObtemPorEmail()
        {
            var resultado = _contatoService.ObterPorEmail("email");

            _contatoRepositoryMock.Verify(x => x.ObterPorEmail("email"), Times.Once);
        }

        [Test]
        public void Contato_ObterPorId_ObtemPorId()
        {
            var guid = Guid.NewGuid();

            var resultado = _contatoService.ObterPorId(guid);

            _contatoRepositoryMock.Verify(x => x.FindById(guid), Times.Once);
        }

        [Test]
        public void Contato_Remover_RemoveContato()
        {
            var guid = Guid.NewGuid();

            _contatoService.Remover(guid);

            _contatoRepositoryMock.Verify(x => x.Delete(guid), Times.Once);
        }

        //////////////////////////////////////////////////////////////

        [Test]
        public void Contato_AdicionarTelefoneInvalido_NaoAdicionaTelefone()
        {
            var telefone = new Telefone
            {
                DDD = 1
            };

            var resultado = _contatoService.AdicionarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Add(telefone), Times.Never);
        }

        [Test]
        public void Contato_AdicionarTelefoneValido_AdicionaTelefone()
        {
            var telefone = new Telefone
            {
                DDD  = 16,
                Numero = 33377788
            };

            var resultado = _contatoService.AdicionarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Add(telefone), Times.Once);
        }

        [Test]
        public void Contato_AtualizarTelefoneInvalido_NaoAtualizaTelefone()
        {
            var telefone = new Telefone
            {
                DDD = 1
            };

            var resultado = _contatoService.AtualizarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Update(telefone), Times.Never);
        }

        [Test]
        public void Contato_AtualizarTelefoneValido_AtualizaTelefone()
        {
            var telefone = new Telefone
            {
                DDD = 16,
                Numero = 33377788
            };

            var resultado = _contatoService.AtualizarTelefone(telefone);

            _telefoneRepositoryMock.Verify(x => x.Update(telefone), Times.Once);
        }

        [Test]
        public void Contato_ObterTelefonePorId_ObtemTelefonePorId()
        {
            var guid = Guid.NewGuid();

            var resultado = _contatoService.ObterTelefonePorId(guid);

            _telefoneRepositoryMock.Verify(x => x.FindById(guid), Times.Once);
        }

        [Test]
        public void Contato_RemoverTelefone_RemoveTelefone()
        {
            var guid = Guid.NewGuid();

            _contatoService.RemoverTelefone(guid);

            _telefoneRepositoryMock.Verify(x => x.Delete(guid), Times.Once);
        }
    }
}
