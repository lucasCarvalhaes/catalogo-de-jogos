using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoSqlServerEFRepository : IJogoRepository
    {
        private readonly CatalogoContext db;

        public JogoSqlServerEFRepository(CatalogoContext catalogoContext)
        {
            db = catalogoContext;
        }

        public Task Atualizar(Jogo jogo)
        {
            db.Jogos.Update(jogo);
            db.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // todo
        }

        public async Task Inserir(Jogo jogo)
        {
            await db.Jogos.AddAsync(jogo);
            await db.SaveChangesAsync();
        }

        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return await db.Jogos.Skip(pagina).Take(quantidade).Select(jogo => new Jogo
                    {
                        Id = jogo.Id,
                        Nome = jogo.Nome,
                        Produtora = jogo.Produtora,
                        Preco = jogo.Preco
                    }).ToListAsync();
        }

        public async Task<Jogo> Obter(Guid id)
        {
            return await db.Jogos.Where(jogo => jogo.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return await db.Jogos.Where(jogo => jogo.Nome == nome && jogo.Produtora == produtora)
                    .Select(jogo => new Jogo
                    {
                        Id = jogo.Id,
                        Nome = jogo.Nome,
                        Produtora = jogo.Produtora,
                        Preco = jogo.Preco
                    })
                    .ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            var jogo = await db.Jogos.Where(jogo => jogo.Id == id).FirstOrDefaultAsync();

            db.Jogos.Remove(jogo);
            await db.SaveChangesAsync();
        }
    }
}