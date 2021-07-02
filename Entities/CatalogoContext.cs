using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoJogos.Entities
{
    public class CatalogoContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }

        public CatalogoContext(DbContextOptions options) : base(options) { }
    }
}