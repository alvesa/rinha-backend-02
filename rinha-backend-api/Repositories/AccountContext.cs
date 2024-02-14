using Microsoft.EntityFrameworkCore;
using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.Repositories
{
    public class RinhaContexto : DbContext
    {
        public DbSet<ClientesEntidade> Clientes { get; set; }
        public DbSet<TransacoesEntitidade> Transacao { get; set; }

        public RinhaContexto(DbContextOptions<RinhaContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // var clientes = modelBuilder.Entity<ClientesEntidade>();
            // var transacoes = modelBuilder.Entity<TransacoesEntitidade>();

            // clientes.HasMany(x => x.Transacoes);
        }
    }
}