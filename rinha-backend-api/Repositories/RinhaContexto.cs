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
        
    }
}