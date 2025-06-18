using DesafioMuralis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMuralis.Infrastructure
{
    public class ConnectionContext : DbContext
    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Endereco);

            modelBuilder.Entity<Cliente>()
                .OwnsMany(c => c.Contatos);
        }


    }
}
