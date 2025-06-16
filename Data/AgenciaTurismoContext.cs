using GerenciamentoTurismo.Data.Configurations;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurismo.Data
{
    public class AgenciaTurismoContext : DbContext
    {
        public AgenciaTurismoContext(DbContextOptions<AgenciaTurismoContext> options)
            : base(options)
        {
        }

        // --- DbSets para cada entidade que será uma tabela no banco ---
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PaisDestino> PaisesDestino { get; set; }
        public DbSet<CidadeDestino> CidadesDestino { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PacoteDestino> PacotesDestinos { get; set; }

        /// <summary>
        /// Configura o modelo de dados usando a Fluent API.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PaisDestinoConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeDestinoConfiguration());
            modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.ApplyConfiguration(new PacoteDestinoConfiguration());
        }
    }
}


