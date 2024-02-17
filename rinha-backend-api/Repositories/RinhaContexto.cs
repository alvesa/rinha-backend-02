using Microsoft.EntityFrameworkCore;
using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.Repositories
{
    public class RinhaContexto : DbContext
    {
        public DbSet<ClientesEntidade> Clientes { get; set; }
        public DbSet<TransacoesEntitidade> Transacoes { get; set; }

        public RinhaContexto(DbContextOptions<RinhaContexto> options) : base(options)
        {
            
        }

        // protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     var clientes = modelBuilder.Entity<ClientesEntidade>();
        //     var transacoes = modelBuilder.Entity<TransacoesEntitidade>();

        //     clientes.HasMany(x => x.Transacoes)
        //         .WithOne(x => x.Cliente)
        //         .HasForeignKey(x => x.ClienteId);
            
        //     transacoes.HasOne(x => x.Cliente)
        //         .WithMany(x => x.Transacoes)
        //         .HasForeignKey(x => x.ClienteId);
        // }
        
    }
}