using Moq;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Domain.Services;
using MvcAppExample.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace MvcAppExample.Domain.Tests.Services
{
    [TestFixture]
    public class AgendaServiceTest
    {
        AgendaService _agendaService;
        Mock<IAgendaRepository> _agendaRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _agendaRepositoryMock = new Mock<IAgendaRepository>();
            _agendaService = new AgendaService(_agendaRepositoryMock.Object);
        }

        [Test]
        public void Agenda_AdicionarContatoInvalido_NaoAdicionaContato()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "contatoemail.com" }
            };

            var resultado = _agendaService.Adicionar(contato);

            _agendaRepositoryMock.Verify(x => x.Add(contato), Times.Never);
        }

        [Test]
        public void Agenda_AdicionarContatoValido_AdicionaContato()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "contato@email.com" }
            };

            var resultado = _agendaService.Adicionar(contato);

            _agendaRepositoryMock.Verify(x => x.Add(contato), Times.Once);
        }

        [Test]
        public void Agenda_AtualizarContatoInvalido_NaoAtualizaContato()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "contatoemail.com" }
            };

            var resultado = _agendaService.Atualizar(contato);

            _agendaRepositoryMock.Verify(x => x.Update(contato), Times.Never);
        }

        [Test]
        public void Agenda_AtualizarContatoValido_AtualizaContato()
        {
            var contato = new Contato
            {
                Email = new Email { Endereco = "contato@email.com" }
            };

            var resultado = _agendaService.Atualizar(contato);

            _agendaRepositoryMock.Verify(x => x.Update(contato), Times.Once);
        }

        [Test]
        public void Agenda_ObterContatosAtivos_ObtemAtivos()
        {
            var resultado = _agendaService.ObterAtivos();

            _agendaRepositoryMock.Verify(x => x.ObterAtivos(), Times.Once);
        }

        [Test]
        public void Agenda_ObterTodos_ObtemTodos()
        {
            var resultado = _agendaService.ObterTodos();

            _agendaRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void Agenda_ObterObterPorEmail_ObtemPorEmail()
        {
            var resultado = _agendaService.ObterPorEmail("email");

            _agendaRepositoryMock.Verify(x => x.ObterPorEmail("email"), Times.Once);
        }

        [Test]
        public void Agenda_ObterPorId_ObtemPorId()
        {
            var guid = Guid.NewGuid();

            var resultado = _agendaService.ObterPorId(guid);

            _agendaRepositoryMock.Verify(x => x.FindById(guid), Times.Once);
        }

        [Test]
        public void Agenda_Remover_RemoveContato()
        {
            var guid = Guid.NewGuid();

            _agendaService.Remover(guid);

            _agendaRepositoryMock.Verify(x => x.Delete(guid), Times.Once);
        }
    }
}
