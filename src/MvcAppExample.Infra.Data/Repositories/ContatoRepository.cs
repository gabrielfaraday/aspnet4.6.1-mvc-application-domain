using System.Collections.Generic;
using MvcAppExample.Domain.Entities;
using MvcAppExample.Domain.Interfaces.Repositories;
using MvcAppExample.Infra.Data.Contexts;
using System.Linq;
using System;
using Dapper;

namespace MvcAppExample.Infra.Data.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public ICollection<Contato> ObterAtivos()
        {
            var conn = Db.Database.Connection;
            var sql = @"SELECT *" +
                       "  FROM Contatos c " +
                       " INNER JOIN Telefones t ON t.ContatoId = c.ContatoId" +
                       " WHERE c.Ativo = 1 ";

            var lookup = new Dictionary<Guid, Contato>();
            conn.Query<Contato, Telefone, Contato>(sql,
                (c, t) =>
                {
                    Contato contato;

                    if (!lookup.TryGetValue(c.ContatoId, out contato))
                        lookup.Add(c.ContatoId, contato = c);

                    if (contato.Telefones == null)
                        contato.Telefones = new List<Telefone>();

                    contato.Telefones.Add(t);

                    return contato;
                }).AsQueryable();

            return lookup.Values;
        }

        public Contato ObterPorEmail(string email)
        {
            return Find(c => c.Email == email).SingleOrDefault();
        }

        public override Contato FindById(Guid id)
        {
            var conn = Db.Database.Connection;
            var sql = @"SELECT *" +
                       "  FROM Contatos c " +
                       " INNER JOIN Telefones t ON t.ContatoId = c.ContatoId" +
                       " WHERE c.ContatoId = @pid";

            var contatos = new List<Contato>();
            conn.Query<Contato, Telefone, Contato>(sql,
                (c, t) =>
                {
                    c.Telefones.Add(t);
                    contatos.Add(c);
                    return contatos.SingleOrDefault();
                }, new { pid = id }, splitOn: "ContatoId, EnderecoId");

            return contatos.SingleOrDefault();
        }

        public override IEnumerable<Contato> GetAll()
        {
            var conn = Db.Database.Connection;

            var sql = @"SELECT * FROM Contatos";

            return conn.Query<Contato>(sql);
        }
    }
}
